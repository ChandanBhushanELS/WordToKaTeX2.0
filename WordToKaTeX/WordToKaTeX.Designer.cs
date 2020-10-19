namespace WordToKaTeX
{
    partial class WordToKaTeX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordToKaTeX));
            this.inputButton = new System.Windows.Forms.Button();
            this.OutputButton = new System.Windows.Forms.Button();
            this.inputPathTextBox = new System.Windows.Forms.TextBox();
            this.outputPathTextBox = new System.Windows.Forms.TextBox();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.ProgressBar();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.exitbutton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.isChemistry = new System.Windows.Forms.RadioButton();
            this.nonChemistry = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputButton
            // 
            this.inputButton.Location = new System.Drawing.Point(41, 32);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(156, 23);
            this.inputButton.TabIndex = 0;
            this.inputButton.Text = "Input Path";
            this.inputButton.UseVisualStyleBackColor = true;
            // 
            // OutputButton
            // 
            this.OutputButton.Location = new System.Drawing.Point(41, 61);
            this.OutputButton.Name = "OutputButton";
            this.OutputButton.Size = new System.Drawing.Size(156, 23);
            this.OutputButton.TabIndex = 1;
            this.OutputButton.Text = "Output Path";
            this.OutputButton.UseVisualStyleBackColor = true;
            // 
            // inputPathTextBox
            // 
            this.inputPathTextBox.AllowDrop = true;
            this.inputPathTextBox.Location = new System.Drawing.Point(222, 34);
            this.inputPathTextBox.Name = "inputPathTextBox";
            this.inputPathTextBox.Size = new System.Drawing.Size(496, 20);
            this.inputPathTextBox.TabIndex = 2;
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.Location = new System.Drawing.Point(222, 63);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.Size = new System.Drawing.Size(496, 20);
            this.outputPathTextBox.TabIndex = 3;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(41, 181);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(156, 23);
            this.ConvertButton.TabIndex = 4;
            this.ConvertButton.Text = "Convert To KaTeX";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(222, 90);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(496, 23);
            this.statusBar.TabIndex = 5;
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(222, 140);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.statusBox.Size = new System.Drawing.Size(496, 216);
            this.statusBox.TabIndex = 6;
            this.statusBox.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Status:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(41, 210);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Zip Directories";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(222, 215);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(496, 80);
            this.textBox1.TabIndex = 10;
            this.textBox1.WordWrap = false;
            // 
            // exitbutton
            // 
            this.exitbutton.Location = new System.Drawing.Point(41, 240);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(156, 23);
            this.exitbutton.TabIndex = 11;
            this.exitbutton.Text = "Exit";
            this.exitbutton.UseVisualStyleBackColor = true;
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(266, 121);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 13);
            this.statusLabel.TabIndex = 12;
            this.statusLabel.Text = "label2";
            // 
            // isChemistry
            // 
            this.isChemistry.AutoSize = true;
            this.isChemistry.Location = new System.Drawing.Point(22, 28);
            this.isChemistry.Name = "isChemistry";
            this.isChemistry.Size = new System.Drawing.Size(70, 17);
            this.isChemistry.TabIndex = 13;
            this.isChemistry.TabStop = true;
            this.isChemistry.Text = "Chemistry";
            this.isChemistry.UseVisualStyleBackColor = true;
            // 
            // nonChemistry
            // 
            this.nonChemistry.AutoSize = true;
            this.nonChemistry.Location = new System.Drawing.Point(22, 51);
            this.nonChemistry.Name = "nonChemistry";
            this.nonChemistry.Size = new System.Drawing.Size(93, 17);
            this.nonChemistry.TabIndex = 14;
            this.nonChemistry.TabStop = true;
            this.nonChemistry.Text = "Non-Chemistry";
            this.nonChemistry.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nonChemistry);
            this.groupBox1.Controls.Add(this.isChemistry);
            this.groupBox1.Location = new System.Drawing.Point(41, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 86);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Subject Type:";
            // 
            // WordToKaTeX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(754, 387);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.exitbutton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.outputPathTextBox);
            this.Controls.Add(this.inputPathTextBox);
            this.Controls.Add(this.OutputButton);
            this.Controls.Add(this.inputButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WordToKaTeX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Word To KaTeX Converter 0.2.0.0";
            this.Load += new System.EventHandler(this.WordToKaTeX_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.Button OutputButton;
        private System.Windows.Forms.TextBox inputPathTextBox;
        private System.Windows.Forms.TextBox outputPathTextBox;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.ProgressBar statusBar;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button exitbutton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.RadioButton isChemistry;
        private System.Windows.Forms.RadioButton nonChemistry;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

