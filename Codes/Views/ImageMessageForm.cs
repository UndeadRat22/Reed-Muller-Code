using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Codes.Communication;
using Codes.Infrastructure;
using Decoder = Codes.Communication.Decoder;
using Encoder = Codes.Communication.Encoder;
using Message = Codes.Communication.Message;

namespace Codes.Views
{
    public partial class ImageMessageForm : Form
    {
        private readonly GeneratorMatrix _generatorMatrix;
        private readonly Channel _channel = Program.Channel;
        private readonly Encoder _encoder;
        private readonly Decoder _decoder;
        private readonly Form _backForm;
        public ImageMessageForm(Form backForm, GeneratorMatrix matrix)
        {
            InitializeComponent();
            _generatorMatrix = matrix;
            _backForm = backForm;

            _encoder = new Encoder(_generatorMatrix);
            _decoder = new Decoder(_generatorMatrix);

            Reset();
        }

        #region Events
        private void buttonValidate_Click(object sender, EventArgs e)
        {
            var bmpPath = textBoxRaw.Text;
            SetActions(File.Exists(bmpPath) && bmpPath.EndsWith(".bmp"));
        }

        private void buttonNoEncoding_Click(object sender, EventArgs e)
        {
            var bytes = File.ReadAllBytes(textBoxRaw.Text);
            var (header, body) = SplitBmpHeaderFromBody(bytes);
            var message = MessageTools.BuildMessage(body, Constants.BitsInByte);
            var passed = _channel.Pass(message);
            var passedBodyBytes = passed.Vectors
                .Select(v => v.Bits.ToByte());

            var fileBytes= header.Concat(passedBodyBytes).ToArray();
            File.WriteAllBytes(textBoxNoEnc.Text, fileBytes);
        }

        private void buttonWithEncoding_Click(object sender, EventArgs e)
        {
            var bytes = File.ReadAllBytes(textBoxRaw.Text);
            var (header, body) = SplitBmpHeaderFromBody(bytes);

            var originalSize = body.Length * Constants.BitsInByte;
            var message = MessageTools.BuildMessage(body, _generatorMatrix.EncodableVectorSize);
            var encoded = _encoder.Encode(message);
            var passed = _channel.Pass(encoded);
            var decoded = _decoder.Decode(passed);
            var decodedBytes = decoded.Vectors
                .SelectMany(v => v.Bits)
                .Take(originalSize) //only take the original bytes, ignore anything that was added by padding
                .Batch(Constants.BitsInByte) // batch by byte bit size
                .Select(bits => bits.ToList().ToByte());

            //add header back
            var fileBytes = header
                .Concat(decodedBytes)
                .ToArray();

            File.WriteAllBytes(textBoxWithEnc.Text, fileBytes);
        }

        /// <summary>
        /// Splits the header from the body (54 bytes)
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private (byte[] header, byte[] body) SplitBmpHeaderFromBody(byte[] bytes)
        {
            var header = bytes.Take(Constants.BMP.HeaderSizeInBytes).ToArray();
            var body = bytes.Skip(Constants.BMP.HeaderSizeInBytes).ToArray();
            return (header, body);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            _backForm.Show();
            Close();
        }

        #endregion

        private void SetActions(bool enabled)
        {
            buttonNoEncoding.Enabled = enabled;
            buttonWithEncoding.Enabled = enabled;
            textBoxNoEnc.Enabled = enabled;
            textBoxWithEnc.Enabled = enabled;
        }
        private void Reset()
        {
            SetActions(false);
            textBoxRaw.Text = string.Empty;
            textBoxWithEnc.Text = Environment.CurrentDirectory + @"with_enc.bmp";
            textBoxNoEnc.Text = Environment.CurrentDirectory + @"no_enc.bmp";
        }
    }
}
