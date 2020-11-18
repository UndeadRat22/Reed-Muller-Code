using System;
using System.Windows.Forms;

namespace Codes.Views
{
    public partial class ChannelDistortionForm : Form
    {
        public ChannelDistortionForm()
        {
            InitializeComponent();
            UpdateTextBoxes();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            var text = textBoxDistortion.Text.Replace(',', '.');
            var success = double.TryParse(text, out var distortion);
            if (!success)
            {
                UpdateTextBoxes();
                return;
            }
            success = int.TryParse(textBoxSeed.Text, out var seed);
            if (!success)
            {
                UpdateTextBoxes();
                return;
            }

            Program.Channel.DistortionProbability = distortion;
            Program.Channel.Seed = seed;
        }

        private void UpdateTextBoxes()
        {
            var probability = Program.Channel.DistortionProbability;
            var seed = Program.Channel.Seed;

            textBoxDistortion.Text = probability.ToString();
            textBoxSeed.Text = seed.ToString();
        }
    }
}
