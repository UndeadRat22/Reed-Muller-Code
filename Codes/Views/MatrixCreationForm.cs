using System.Windows.Forms;

namespace Codes.Views
{
    public partial class MatrixCreationForm : Form
    {
        public MatrixCreationForm()
        {
            InitializeComponent();
            Reset();
        }

        #region Events
        private void buttonStart_Click(object sender, System.EventArgs e)
        {
            Hide();
            var scenarioChoice = new ScenarioChoice(this, GetMValue().Value, GetRValue().Value);
            scenarioChoice.Show();

            var distortionForm = new ChannelDistortionForm();
            distortionForm.Show();
        }
        private void textBoxMValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !IsCharAllowed(e.KeyChar);
        }

        private void textRValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !IsCharAllowed(e.KeyChar);
        }

        private void textBoxMValue_TextChanged(object sender, System.EventArgs e) => CheckFormValidity();

        private void textBoxRValue_TextChanged(object sender, System.EventArgs e) => CheckFormValidity();
        #endregion

        private bool IsCharAllowed(in char c) => char.IsDigit(c) || c == '\b';

        private void CheckFormValidity()
        { 
            var mValue = GetMValue();
            var rValue = GetRValue();
            if (mValue.HasValue && rValue.HasValue && mValue >= rValue)
            {
                Settings.R = rValue.Value;
                Settings.M = mValue.Value;
                EnableNextStep();
            }
            else
            {
                DisableNextStep();
            }
        }

        private int? GetMValue() => string.IsNullOrEmpty(textBoxMValue.Text) ? (int?)null : int.Parse(textBoxMValue.Text);
        private int? GetRValue() => string.IsNullOrEmpty(textBoxRValue.Text) ? (int?)null : int.Parse(textBoxRValue.Text);

        private void Reset()
        {
            textBoxMValue.Text = string.Empty;
            textBoxRValue.Text = string.Empty;
            DisableNextStep();
        }

        private void DisableNextStep()
        {
            buttonStart.Enabled = false;
        }

        private void EnableNextStep()
        {
            buttonStart.Enabled = true;
        }
    }
}
