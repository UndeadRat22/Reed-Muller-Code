
namespace Codes.Views
{
    partial class MatrixCreationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelR = new System.Windows.Forms.Label();
            this.textBoxRValue = new System.Windows.Forms.TextBox();
            this.labelM = new System.Windows.Forms.Label();
            this.textBoxMValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(192, 71);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(119, 29);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "Generate";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // labelR
            // 
            this.labelR.AutoSize = true;
            this.labelR.Location = new System.Drawing.Point(183, 21);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(83, 25);
            this.labelR.TabIndex = 10;
            this.labelR.Text = "R value:";
            // 
            // textBoxRValue
            // 
            this.textBoxRValue.Location = new System.Drawing.Point(272, 21);
            this.textBoxRValue.MaxLength = 1;
            this.textBoxRValue.Name = "textBoxRValue";
            this.textBoxRValue.Size = new System.Drawing.Size(39, 29);
            this.textBoxRValue.TabIndex = 9;
            this.textBoxRValue.TextChanged += new System.EventHandler(this.textBoxRValue_TextChanged);
            this.textBoxRValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textRValue_KeyPress);
            // 
            // labelM
            // 
            this.labelM.AutoSize = true;
            this.labelM.Location = new System.Drawing.Point(32, 21);
            this.labelM.Name = "labelM";
            this.labelM.Size = new System.Drawing.Size(87, 25);
            this.labelM.TabIndex = 12;
            this.labelM.Text = "M value:";
            // 
            // textBoxMValue
            // 
            this.textBoxMValue.Location = new System.Drawing.Point(125, 21);
            this.textBoxMValue.MaxLength = 1;
            this.textBoxMValue.Name = "textBoxMValue";
            this.textBoxMValue.Size = new System.Drawing.Size(39, 29);
            this.textBoxMValue.TabIndex = 13;
            this.textBoxMValue.TextChanged += new System.EventHandler(this.textBoxMValue_TextChanged);
            this.textBoxMValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMValue_KeyPress);
            // 
            // MatrixCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 118);
            this.Controls.Add(this.textBoxMValue);
            this.Controls.Add(this.labelM);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelR);
            this.Controls.Add(this.textBoxRValue);
            this.Name = "MatrixCreationForm";
            this.Text = "MatrixCreationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.TextBox textBoxRValue;
        private System.Windows.Forms.Label labelM;
        private System.Windows.Forms.TextBox textBoxMValue;
    }
}