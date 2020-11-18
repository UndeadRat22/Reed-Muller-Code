
namespace Codes.Views
{
    partial class ChannelDistortionForm
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
            this.textBoxDistortion = new System.Windows.Forms.TextBox();
            this.labelDistortion = new System.Windows.Forms.Label();
            this.labelExtremes = new System.Windows.Forms.Label();
            this.labelSeed = new System.Windows.Forms.Label();
            this.textBoxSeed = new System.Windows.Forms.TextBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxDistortion
            // 
            this.textBoxDistortion.Location = new System.Drawing.Point(257, 38);
            this.textBoxDistortion.Name = "textBoxDistortion";
            this.textBoxDistortion.Size = new System.Drawing.Size(67, 29);
            this.textBoxDistortion.TabIndex = 0;
            // 
            // labelDistortion
            // 
            this.labelDistortion.AutoSize = true;
            this.labelDistortion.Location = new System.Drawing.Point(68, 38);
            this.labelDistortion.Name = "labelDistortion";
            this.labelDistortion.Size = new System.Drawing.Size(183, 25);
            this.labelDistortion.TabIndex = 1;
            this.labelDistortion.Text = "distortion probability";
            // 
            // labelExtremes
            // 
            this.labelExtremes.AutoSize = true;
            this.labelExtremes.Location = new System.Drawing.Point(196, 80);
            this.labelExtremes.Name = "labelExtremes";
            this.labelExtremes.Size = new System.Drawing.Size(128, 25);
            this.labelExtremes.TabIndex = 2;
            this.labelExtremes.Text = "min: 0, max 1";
            // 
            // labelSeed
            // 
            this.labelSeed.AutoSize = true;
            this.labelSeed.Location = new System.Drawing.Point(125, 125);
            this.labelSeed.Name = "labelSeed";
            this.labelSeed.Size = new System.Drawing.Size(126, 25);
            this.labelSeed.TabIndex = 3;
            this.labelSeed.Text = "random seed";
            // 
            // textBoxSeed
            // 
            this.textBoxSeed.Location = new System.Drawing.Point(257, 125);
            this.textBoxSeed.Name = "textBoxSeed";
            this.textBoxSeed.Size = new System.Drawing.Size(67, 29);
            this.textBoxSeed.TabIndex = 4;
            this.textBoxSeed.Text = "666";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(156, 200);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(114, 52);
            this.buttonUpdate.TabIndex = 5;
            this.buttonUpdate.Text = "update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // ChannelDistortionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 282);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.textBoxSeed);
            this.Controls.Add(this.labelSeed);
            this.Controls.Add(this.labelExtremes);
            this.Controls.Add(this.labelDistortion);
            this.Controls.Add(this.textBoxDistortion);
            this.Name = "ChannelDistortionForm";
            this.Text = "ChannelDistortionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDistortion;
        private System.Windows.Forms.Label labelDistortion;
        private System.Windows.Forms.Label labelExtremes;
        private System.Windows.Forms.Label labelSeed;
        private System.Windows.Forms.TextBox textBoxSeed;
        private System.Windows.Forms.Button buttonUpdate;
    }
}