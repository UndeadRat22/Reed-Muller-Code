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
        private readonly GeneratorMatrix _generatorMatrix;
        private readonly Channel _channel;
        private readonly Encoder _encoder;
        private readonly Decoder _decoder;
        public SingleVectorMessageForm()
        {
            InitializeComponent();
            _channel = new Channel(0.00);
            _generatorMatrix = new GeneratorMatrix(2, 4);

            _encoder = new Encoder(_generatorMatrix);
            _decoder = new Decoder(_generatorMatrix);
        }

        #region Events
        private void buttonEncode_Click(object sender, System.EventArgs e)
        {
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

        private void buttonClear_Click(object sender, System.EventArgs e) => ResetForm();

        private void textBoxInitial_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(e, textBoxInitial, buttonEncode, _generatorMatrix.EncodableVectorSize);
        }

        private void textBoxDistorted_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(e, textBoxDistorted, buttonDecode, _generatorMatrix.WordSize);
        }

        private static void ProcessKeyPress(KeyPressEventArgs e, TextBox textBox, Button nextStep, int allowedSize)
        {
            bool isCharAllowed = IsCharAllowed(e.KeyChar);
            e.Handled = !isCharAllowed;
            if (isCharAllowed)
            {
                bool isCorrectSize = allowedSize == (textBox.Text.Length + (IsBackSpace(e.KeyChar) ? -1 : 1));
                nextStep.Enabled = isCorrectSize;
            }
        }

        private static bool IsBackSpace(in char c) => c == '\b';
        private static bool IsCharAllowed(in char c) => c == '1' || c == '0' || c == '\b';

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

        private void ResetForm()
        {
            textBoxInitial.Text = string.Empty;
            textBoxEncoded.Text = string.Empty;
            textBoxDistorted.Text = string.Empty;
            textBoxDecoded.Text = string.Empty;

            textBoxInitial.Enabled = true;
            textBoxDistorted.Enabled = false;

            buttonEncode.Enabled = false;
            buttonDistort.Enabled = false;
            buttonDecode.Enabled = false;
        }
    }
}
