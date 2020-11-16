using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Codes.Communication;
using Codes.Primitives;
using Message = Codes.Communication.Message;

namespace Codes
{
    public partial class SingleVectorMessageForm : Form
    {
        private readonly Channel _channel;
        private readonly Encoder _encoder;
        private readonly Decoder _decoder;
        public SingleVectorMessageForm()
        {
            InitializeComponent();
            _channel = new Channel(0.00);
            _encoder = new Encoder();
            _decoder = new Decoder();
        }

        #region Events
        private void buttonEncode_Click(object sender, System.EventArgs e)
        {
            //TODO: ensure size, char types
            textBoxEncoded.Text = Step(textBoxInitial.Text, message => _encoder.Encode(message));
            buttonDistort.Enabled = true;
            textBoxInitial.Enabled = false;
        }

        private void buttonDistort_Click(object sender, System.EventArgs e)
        {
            textBoxDistorted.Text = Step(textBoxEncoded.Text, message => _channel.Pass(message));
            textBoxDistorted.Enabled = true;
            buttonDecode.Enabled = true;
        }
        private void buttonDecode_Click(object sender, EventArgs e)
        {
            textBoxDecoded.Text = Step(textBoxDistorted.Text, message => _decoder.Decode(message));
            UpdateDifferenceText();
        }

        private void buttonClear_Click(object sender, System.EventArgs e)
        {
            textBoxInitial.Text = string.Empty;
            textBoxEncoded.Text = string.Empty;
            textBoxDistorted.Text = string.Empty;
            textBoxDecoded.Text = string.Empty;

            textBoxInitial.Enabled = true;
            textBoxDistorted.Enabled = false;

            buttonEncode.Enabled = true;
            buttonDistort.Enabled = false;
            buttonDecode.Enabled = false;
        }

        private void textBoxInitial_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != '1' && e.KeyChar != '0';
        }

        #endregion

        private void UpdateDifferenceText()
        {
            var startingString = textBoxInitial.Text;
            var finalString = textBoxDecoded.Text;
            var difference = startingString
                .Zip(finalString, (a, b) => a == b)
                .Count(areEqual => !areEqual);

            labelDifference.Text = $"Initial bits differ from final bits in {difference} places.";
        }

        private string Step(string text, Func<Message, Message> operation)
        {
            var message = new Message
            {
                Vectors = new List<Vector> { new Vector(text) }
            };

            return operation(message).Vectors.First().ToString();
        }
    }
}
