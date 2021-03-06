﻿using System.Windows.Forms;
using Codes.Communication;

namespace Codes.Views
{
    public partial class ScenarioChoice : Form
    {
        private readonly GeneratorMatrix _generatorMatrix;
        private readonly Form _previous;
        public ScenarioChoice(Form previous, int m, int r)
        {
            InitializeComponent();
            _previous = previous;
            _generatorMatrix = new GeneratorMatrix(r, m);
        }

        private void buttonVector_Click(object sender, System.EventArgs e)
        {
            var singleVectorForm = new SingleVectorMessageForm(_generatorMatrix, this);
            singleVectorForm.Show();
            Hide();
        }

        private void buttonText_Click(object sender, System.EventArgs e)
        {
            var textForm = new TextMessageForm(this, _generatorMatrix);
            textForm.Show();
            Hide();
        }

        private void buttonImage_Click(object sender, System.EventArgs e)
        {
            var imageForm = new ImageMessageForm(this, _generatorMatrix);
            imageForm.Show();
            Hide();
        }

        private void backButton_Click(object sender, System.EventArgs e)
        {
            Close();
            _previous.Show();
        }
    }
}
