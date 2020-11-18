using System.Linq;
using System.Text;
using System.Windows.Forms;
using Codes.Communication;
using Codes.Infrastructure;
using Codes.Primitives;
using Decoder = Codes.Communication.Decoder;
using Encoder = Codes.Communication.Encoder;
using Message = Codes.Communication.Message;

namespace Codes.Views
{
    public partial class TextMessageForm : Form
    {
        private readonly GeneratorMatrix _generatorMatrix;
        private readonly Channel _channel = Program.Channel;
        private readonly Encoder _encoder;
        private readonly Decoder _decoder;
        private readonly Form _backForm;

        public TextMessageForm(Form backForm, GeneratorMatrix matrix)
        {
            InitializeComponent();
            _generatorMatrix = matrix;
            _backForm = backForm;

            _encoder = new Encoder(_generatorMatrix);
            _decoder = new Decoder(_generatorMatrix);
        }

        #region Events

        private void buttonRunNoEncoding_Click(object sender, System.EventArgs e)
        {
            if (!textBoxRaw.Text.Any()) return;
            var bytes = Encoding.ASCII.GetBytes(textBoxRaw.Text);
            var message = new Message
            {
                Vectors = bytes.Select(b => new Vector(b)).ToList()
            };
            var passed = _channel.Pass(message);
            var resultBytes = passed.Vectors.Select(vector => vector.Bits.ToByte()).ToArray();
            var resultString = Encoding.ASCII.GetString(resultBytes);
            textBoxNoEncoding.Text = resultString;
        }

        private void buttonRunWithEncoding_Click(object sender, System.EventArgs e)
        {
            if (!textBoxRaw.Text.Any()) return;
            var bytes = Encoding.ASCII.GetBytes(textBoxRaw.Text);
            var allBits = bytes.SelectMany(b => b.ToBoolList()).ToList();
            var originalSize = allBits.Count;
            var nonFittingBits = originalSize % _generatorMatrix.EncodableVectorSize;
            if (nonFittingBits > 0)
            {
                int totalLength = ((originalSize % _generatorMatrix.EncodableVectorSize) + 1) *
                                  _generatorMatrix.EncodableVectorSize;
                allBits = allBits.Pad(totalLength, false).ToList();
            }

            var vectors = allBits
                .Batch(_generatorMatrix.EncodableVectorSize)
                .Select(bits => new Vector(bits))
                .ToList();

            var message = new Message
            {
                Vectors = vectors
            };
            var encoded = _encoder.Encode(message);
            var passed = _channel.Pass(encoded);
            var decoded = _decoder.Decode(passed);
            var decodedBytes = decoded.Vectors
                .SelectMany(v => v.Bits)
                .Take(originalSize)
                .Batch(8)// batch by byte bit size
                .Select(bits => bits.ToList().ToByte())
                .ToArray();

            var resultString = Encoding.ASCII.GetString(decodedBytes);
            textBoxWithEncoding.Text = resultString;
        }

        private void backButton_Click(object sender, System.EventArgs e)
        {
            _backForm.Show();
            Hide();
        }

        #endregion
    }
}
