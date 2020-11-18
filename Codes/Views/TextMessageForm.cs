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
        private readonly Channel _channel;
        private readonly Encoder _encoder;
        private readonly Decoder _decoder;
        private readonly Form _backForm;

        public TextMessageForm(Form backForm, GeneratorMatrix matrix)
        {
            InitializeComponent();
            _generatorMatrix = matrix;
            _backForm = backForm;
            _channel = new Channel(0.00);

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
            var resultBytes = message.Vectors.Select(vector => vector.Bits.ToByte()).ToArray();
            var resultString = Encoding.ASCII.GetString(resultBytes);
            textBoxNoEncoding.Text = resultString;
        }

        private void buttonRunWithEncoding_Click(object sender, System.EventArgs e)
        {
            if (!textBoxRaw.Text.Any()) return;
        }

        #endregion
    }
}
