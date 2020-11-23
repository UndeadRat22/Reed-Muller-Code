
namespace Codes.Views
{
    partial class SingleVectorMessageForm
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
            this.textBoxInitial = new System.Windows.Forms.TextBox();
            this.labelInitialVector = new System.Windows.Forms.Label();
            this.labelEncodedVector = new System.Windows.Forms.Label();
            this.textBoxEncoded = new System.Windows.Forms.TextBox();
            this.labelDistorted = new System.Windows.Forms.Label();
            this.textBoxDistorted = new System.Windows.Forms.TextBox();
            this.labelDecoded = new System.Windows.Forms.Label();
            this.textBoxDecoded = new System.Windows.Forms.TextBox();
            this.buttonEncode = new System.Windows.Forms.Button();
            this.buttonDistort = new System.Windows.Forms.Button();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelDifference = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.labelEncDistDifference = new System.Windows.Forms.Label();
            this.labelRequiredSize = new System.Windows.Forms.Label();
            this.labelDifferenceIndices = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxInitial
            // 
            this.textBoxInitial.Location = new System.Drawing.Point(198, 43);
            this.textBoxInitial.Name = "textBoxInitial";
            this.textBoxInitial.Size = new System.Drawing.Size(492, 29);
            this.textBoxInitial.TabIndex = 0;
            this.textBoxInitial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInitial_KeyPress);
            // 
            // labelInitialVector
            // 
            this.labelInitialVector.AutoSize = true;
            this.labelInitialVector.Location = new System.Drawing.Point(38, 43);
            this.labelInitialVector.Name = "labelInitialVector";
            this.labelInitialVector.Size = new System.Drawing.Size(118, 25);
            this.labelInitialVector.TabIndex = 1;
            this.labelInitialVector.Text = "Initial Vector";
            // 
            // labelEncodedVector
            // 
            this.labelEncodedVector.AutoSize = true;
            this.labelEncodedVector.Location = new System.Drawing.Point(38, 102);
            this.labelEncodedVector.Name = "labelEncodedVector";
            this.labelEncodedVector.Size = new System.Drawing.Size(152, 25);
            this.labelEncodedVector.TabIndex = 3;
            this.labelEncodedVector.Text = "Encoded Vector";
            // 
            // textBoxEncoded
            // 
            this.textBoxEncoded.Enabled = false;
            this.textBoxEncoded.Location = new System.Drawing.Point(198, 102);
            this.textBoxEncoded.Name = "textBoxEncoded";
            this.textBoxEncoded.Size = new System.Drawing.Size(491, 29);
            this.textBoxEncoded.TabIndex = 2;
            // 
            // labelDistorted
            // 
            this.labelDistorted.AutoSize = true;
            this.labelDistorted.Location = new System.Drawing.Point(38, 159);
            this.labelDistorted.Name = "labelDistorted";
            this.labelDistorted.Size = new System.Drawing.Size(151, 25);
            this.labelDistorted.TabIndex = 5;
            this.labelDistorted.Text = "Distorted Vector";
            // 
            // textBoxDistorted
            // 
            this.textBoxDistorted.Enabled = false;
            this.textBoxDistorted.Location = new System.Drawing.Point(198, 159);
            this.textBoxDistorted.Name = "textBoxDistorted";
            this.textBoxDistorted.Size = new System.Drawing.Size(491, 29);
            this.textBoxDistorted.TabIndex = 4;
            this.textBoxDistorted.TextChanged += new System.EventHandler(this.textBoxDistorted_TextChanged);
            this.textBoxDistorted.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDistorted_KeyPress);
            // 
            // labelDecoded
            // 
            this.labelDecoded.AutoSize = true;
            this.labelDecoded.Location = new System.Drawing.Point(38, 279);
            this.labelDecoded.Name = "labelDecoded";
            this.labelDecoded.Size = new System.Drawing.Size(153, 25);
            this.labelDecoded.TabIndex = 7;
            this.labelDecoded.Text = "Decoded Vector";
            // 
            // textBoxDecoded
            // 
            this.textBoxDecoded.Enabled = false;
            this.textBoxDecoded.Location = new System.Drawing.Point(198, 279);
            this.textBoxDecoded.Name = "textBoxDecoded";
            this.textBoxDecoded.Size = new System.Drawing.Size(491, 29);
            this.textBoxDecoded.TabIndex = 6;
            // 
            // buttonEncode
            // 
            this.buttonEncode.Enabled = false;
            this.buttonEncode.Location = new System.Drawing.Point(709, 43);
            this.buttonEncode.Name = "buttonEncode";
            this.buttonEncode.Size = new System.Drawing.Size(89, 29);
            this.buttonEncode.TabIndex = 8;
            this.buttonEncode.Text = "encode";
            this.buttonEncode.UseVisualStyleBackColor = true;
            this.buttonEncode.Click += new System.EventHandler(this.buttonEncode_Click);
            // 
            // buttonDistort
            // 
            this.buttonDistort.Enabled = false;
            this.buttonDistort.Location = new System.Drawing.Point(709, 103);
            this.buttonDistort.Name = "buttonDistort";
            this.buttonDistort.Size = new System.Drawing.Size(89, 29);
            this.buttonDistort.TabIndex = 9;
            this.buttonDistort.Text = "distort";
            this.buttonDistort.UseVisualStyleBackColor = true;
            this.buttonDistort.Click += new System.EventHandler(this.buttonDistort_Click);
            // 
            // buttonDecode
            // 
            this.buttonDecode.Enabled = false;
            this.buttonDecode.Location = new System.Drawing.Point(709, 160);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(89, 29);
            this.buttonDecode.TabIndex = 10;
            this.buttonDecode.Text = "decode";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(708, 338);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(89, 29);
            this.buttonClear.TabIndex = 11;
            this.buttonClear.Text = "clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelDifference
            // 
            this.labelDifference.AutoSize = true;
            this.labelDifference.Location = new System.Drawing.Point(35, 342);
            this.labelDifference.Name = "labelDifference";
            this.labelDifference.Size = new System.Drawing.Size(0, 25);
            this.labelDifference.TabIndex = 12;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(265, 392);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(159, 62);
            this.backButton.TabIndex = 13;
            this.backButton.Text = "back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // labelEncDistDifference
            // 
            this.labelEncDistDifference.AutoSize = true;
            this.labelEncDistDifference.Location = new System.Drawing.Point(35, 200);
            this.labelEncDistDifference.Name = "labelEncDistDifference";
            this.labelEncDistDifference.Size = new System.Drawing.Size(0, 25);
            this.labelEncDistDifference.TabIndex = 14;
            // 
            // labelRequiredSize
            // 
            this.labelRequiredSize.AutoSize = true;
            this.labelRequiredSize.Location = new System.Drawing.Point(571, 15);
            this.labelRequiredSize.Name = "labelRequiredSize";
            this.labelRequiredSize.Size = new System.Drawing.Size(136, 25);
            this.labelRequiredSize.TabIndex = 15;
            this.labelRequiredSize.Text = "Required size:";
            // 
            // labelDifferenceIndices
            // 
            this.labelDifferenceIndices.AutoSize = true;
            this.labelDifferenceIndices.Location = new System.Drawing.Point(35, 241);
            this.labelDifferenceIndices.Name = "labelDifferenceIndices";
            this.labelDifferenceIndices.Size = new System.Drawing.Size(0, 25);
            this.labelDifferenceIndices.TabIndex = 16;
            // 
            // SingleVectorMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 595);
            this.Controls.Add(this.labelDifferenceIndices);
            this.Controls.Add(this.labelRequiredSize);
            this.Controls.Add(this.labelEncDistDifference);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.labelDifference);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonDecode);
            this.Controls.Add(this.buttonDistort);
            this.Controls.Add(this.buttonEncode);
            this.Controls.Add(this.labelDecoded);
            this.Controls.Add(this.textBoxDecoded);
            this.Controls.Add(this.labelDistorted);
            this.Controls.Add(this.textBoxDistorted);
            this.Controls.Add(this.labelEncodedVector);
            this.Controls.Add(this.textBoxEncoded);
            this.Controls.Add(this.labelInitialVector);
            this.Controls.Add(this.textBoxInitial);
            this.Name = "SingleVectorMessageForm";
            this.Text = "Single Vector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInitial;
        private System.Windows.Forms.Label labelInitialVector;
        private System.Windows.Forms.Label labelEncodedVector;
        private System.Windows.Forms.TextBox textBoxEncoded;
        private System.Windows.Forms.Label labelDistorted;
        private System.Windows.Forms.TextBox textBoxDistorted;
        private System.Windows.Forms.Label labelDecoded;
        private System.Windows.Forms.TextBox textBoxDecoded;
        private System.Windows.Forms.Button buttonEncode;
        private System.Windows.Forms.Button buttonDistort;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelDifference;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label labelEncDistDifference;
        private System.Windows.Forms.Label labelRequiredSize;
        private System.Windows.Forms.Label labelDifferenceIndices;
    }
}

