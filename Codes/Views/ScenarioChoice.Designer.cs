
namespace Codes.Views
{
    partial class ScenarioChoice
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
            this.buttonVector = new System.Windows.Forms.Button();
            this.buttonText = new System.Windows.Forms.Button();
            this.buttonImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonVector
            // 
            this.buttonVector.Location = new System.Drawing.Point(12, 25);
            this.buttonVector.Name = "buttonVector";
            this.buttonVector.Size = new System.Drawing.Size(159, 62);
            this.buttonVector.TabIndex = 0;
            this.buttonVector.Text = "vector";
            this.buttonVector.UseVisualStyleBackColor = true;
            // 
            // buttonText
            // 
            this.buttonText.Location = new System.Drawing.Point(204, 25);
            this.buttonText.Name = "buttonText";
            this.buttonText.Size = new System.Drawing.Size(159, 62);
            this.buttonText.TabIndex = 1;
            this.buttonText.Text = "text";
            this.buttonText.UseVisualStyleBackColor = true;
            // 
            // buttonImage
            // 
            this.buttonImage.Location = new System.Drawing.Point(396, 25);
            this.buttonImage.Name = "buttonImage";
            this.buttonImage.Size = new System.Drawing.Size(159, 62);
            this.buttonImage.TabIndex = 2;
            this.buttonImage.Text = "image";
            this.buttonImage.UseVisualStyleBackColor = true;
            // 
            // ScenarioChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 111);
            this.Controls.Add(this.buttonImage);
            this.Controls.Add(this.buttonText);
            this.Controls.Add(this.buttonVector);
            this.Name = "ScenarioChoice";
            this.Text = "ScenarioChoice";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonVector;
        private System.Windows.Forms.Button buttonText;
        private System.Windows.Forms.Button buttonImage;
    }
}