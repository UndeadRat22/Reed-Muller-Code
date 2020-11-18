
namespace Codes.Views
{
    partial class ImageMessageForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNoEnc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxWithEnc = new System.Windows.Forms.TextBox();
            this.buttonNoEncoding = new System.Windows.Forms.Button();
            this.buttonWithEncoding = new System.Windows.Forms.Button();
            this.buttonValidate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(316, 376);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(159, 62);
            this.backButton.TabIndex = 4;
            this.backButton.Text = "back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // textBoxRaw
            // 
            this.textBoxRaw.Location = new System.Drawing.Point(124, 13);
            this.textBoxRaw.Name = "textBoxRaw";
            this.textBoxRaw.Size = new System.Drawing.Size(616, 29);
            this.textBoxRaw.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "image path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "no encoding";
            // 
            // textBoxNoEnc
            // 
            this.textBoxNoEnc.Location = new System.Drawing.Point(147, 108);
            this.textBoxNoEnc.Name = "textBoxNoEnc";
            this.textBoxNoEnc.Size = new System.Drawing.Size(616, 29);
            this.textBoxNoEnc.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "with encoding";
            // 
            // textBoxWithEnc
            // 
            this.textBoxWithEnc.Location = new System.Drawing.Point(147, 157);
            this.textBoxWithEnc.Name = "textBoxWithEnc";
            this.textBoxWithEnc.Size = new System.Drawing.Size(616, 29);
            this.textBoxWithEnc.TabIndex = 9;
            // 
            // buttonNoEncoding
            // 
            this.buttonNoEncoding.Location = new System.Drawing.Point(787, 103);
            this.buttonNoEncoding.Name = "buttonNoEncoding";
            this.buttonNoEncoding.Size = new System.Drawing.Size(145, 40);
            this.buttonNoEncoding.TabIndex = 11;
            this.buttonNoEncoding.Text = "generate";
            this.buttonNoEncoding.UseVisualStyleBackColor = true;
            this.buttonNoEncoding.Click += new System.EventHandler(this.buttonNoEncoding_Click);
            // 
            // buttonWithEncoding
            // 
            this.buttonWithEncoding.Location = new System.Drawing.Point(787, 152);
            this.buttonWithEncoding.Name = "buttonWithEncoding";
            this.buttonWithEncoding.Size = new System.Drawing.Size(145, 40);
            this.buttonWithEncoding.TabIndex = 12;
            this.buttonWithEncoding.Text = "generate";
            this.buttonWithEncoding.UseVisualStyleBackColor = true;
            this.buttonWithEncoding.Click += new System.EventHandler(this.buttonWithEncoding_Click);
            // 
            // buttonValidate
            // 
            this.buttonValidate.Location = new System.Drawing.Point(764, 5);
            this.buttonValidate.Name = "buttonValidate";
            this.buttonValidate.Size = new System.Drawing.Size(90, 40);
            this.buttonValidate.TabIndex = 13;
            this.buttonValidate.Text = "validate";
            this.buttonValidate.UseVisualStyleBackColor = true;
            this.buttonValidate.Click += new System.EventHandler(this.buttonValidate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "result paths:";
            // 
            // ImageMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonValidate);
            this.Controls.Add(this.buttonWithEncoding);
            this.Controls.Add(this.buttonNoEncoding);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxWithEnc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNoEnc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRaw);
            this.Controls.Add(this.backButton);
            this.Name = "ImageMessageForm";
            this.Text = "ImageMessageForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox textBoxRaw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNoEnc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxWithEnc;
        private System.Windows.Forms.Button buttonNoEncoding;
        private System.Windows.Forms.Button buttonWithEncoding;
        private System.Windows.Forms.Button buttonValidate;
        private System.Windows.Forms.Label label4;
    }
}