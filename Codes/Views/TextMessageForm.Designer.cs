
namespace Codes.Views
{
    partial class TextMessageForm
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
            this.backButton = new System.Windows.Forms.Button();
            this.textBoxRaw = new System.Windows.Forms.TextBox();
            this.textBoxNoEncoding = new System.Windows.Forms.TextBox();
            this.textBoxWithEncoding = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRunNoEncoding = new System.Windows.Forms.Button();
            this.buttonRunWithEncoding = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(659, 503);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(159, 62);
            this.backButton.TabIndex = 4;
            this.backButton.Text = "back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // textBoxRaw
            // 
            this.textBoxRaw.Location = new System.Drawing.Point(12, 39);
            this.textBoxRaw.Multiline = true;
            this.textBoxRaw.Name = "textBoxRaw";
            this.textBoxRaw.Size = new System.Drawing.Size(462, 331);
            this.textBoxRaw.TabIndex = 5;
            // 
            // textBoxNoEncoding
            // 
            this.textBoxNoEncoding.Enabled = false;
            this.textBoxNoEncoding.Location = new System.Drawing.Point(508, 39);
            this.textBoxNoEncoding.Multiline = true;
            this.textBoxNoEncoding.Name = "textBoxNoEncoding";
            this.textBoxNoEncoding.Size = new System.Drawing.Size(462, 331);
            this.textBoxNoEncoding.TabIndex = 6;
            // 
            // textBoxWithEncoding
            // 
            this.textBoxWithEncoding.Enabled = false;
            this.textBoxWithEncoding.Location = new System.Drawing.Point(1001, 39);
            this.textBoxWithEncoding.Multiline = true;
            this.textBoxWithEncoding.Name = "textBoxWithEncoding";
            this.textBoxWithEncoding.Size = new System.Drawing.Size(462, 331);
            this.textBoxWithEncoding.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "raw";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "without encoding";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(996, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "with encoding";
            // 
            // buttonRunNoEncoding
            // 
            this.buttonRunNoEncoding.Location = new System.Drawing.Point(895, 9);
            this.buttonRunNoEncoding.Name = "buttonRunNoEncoding";
            this.buttonRunNoEncoding.Size = new System.Drawing.Size(75, 23);
            this.buttonRunNoEncoding.TabIndex = 11;
            this.buttonRunNoEncoding.Text = "run";
            this.buttonRunNoEncoding.UseVisualStyleBackColor = true;
            this.buttonRunNoEncoding.Click += new System.EventHandler(this.buttonRunNoEncoding_Click);
            // 
            // buttonRunWithEncoding
            // 
            this.buttonRunWithEncoding.Location = new System.Drawing.Point(1388, 8);
            this.buttonRunWithEncoding.Name = "buttonRunWithEncoding";
            this.buttonRunWithEncoding.Size = new System.Drawing.Size(75, 23);
            this.buttonRunWithEncoding.TabIndex = 12;
            this.buttonRunWithEncoding.Text = "run";
            this.buttonRunWithEncoding.UseVisualStyleBackColor = true;
            this.buttonRunWithEncoding.Click += new System.EventHandler(this.buttonRunWithEncoding_Click);
            // 
            // TextMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 577);
            this.Controls.Add(this.buttonRunWithEncoding);
            this.Controls.Add(this.buttonRunNoEncoding);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxWithEncoding);
            this.Controls.Add(this.textBoxNoEncoding);
            this.Controls.Add(this.textBoxRaw);
            this.Controls.Add(this.backButton);
            this.Name = "TextMessageForm";
            this.Text = "TextMessageForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox textBoxRaw;
        private System.Windows.Forms.TextBox textBoxNoEncoding;
        private System.Windows.Forms.TextBox textBoxWithEncoding;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonRunNoEncoding;
        private System.Windows.Forms.Button buttonRunWithEncoding;
    }
}