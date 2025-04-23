namespace AutoTyper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textToLoopTextBox = new RichTextBox();
            label1 = new Label();
            amountLabel = new Label();
            amountNumUpDown = new NumericUpDown();
            loopLabel = new Label();
            loopProgress = new ProgressBar();
            etaLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)amountNumUpDown).BeginInit();
            SuspendLayout();
            // 
            // textToLoopTextBox
            // 
            textToLoopTextBox.Location = new Point(8, 34);
            textToLoopTextBox.Margin = new Padding(2, 2, 2, 2);
            textToLoopTextBox.Name = "textToLoopTextBox";
            textToLoopTextBox.Size = new Size(117, 183);
            textToLoopTextBox.TabIndex = 0;
            textToLoopTextBox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 17);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 2;
            label1.Text = "Text to loop";
            // 
            // amountLabel
            // 
            amountLabel.AutoSize = true;
            amountLabel.Location = new Point(128, 17);
            amountLabel.Margin = new Padding(2, 0, 2, 0);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new Size(102, 15);
            amountLabel.TabIndex = 3;
            amountLabel.Text = "How many loops?";
            // 
            // amountNumUpDown
            // 
            amountNumUpDown.Location = new Point(128, 34);
            amountNumUpDown.Margin = new Padding(2, 2, 2, 2);
            amountNumUpDown.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            amountNumUpDown.Name = "amountNumUpDown";
            amountNumUpDown.Size = new Size(126, 23);
            amountNumUpDown.TabIndex = 5;
            // 
            // loopLabel
            // 
            loopLabel.AutoSize = true;
            loopLabel.Location = new Point(128, 55);
            loopLabel.Margin = new Padding(2, 0, 2, 0);
            loopLabel.Name = "loopLabel";
            loopLabel.Size = new Size(51, 15);
            loopLabel.TabIndex = 6;
            loopLabel.Text = "Loops: 0";
            // 
            // loopProgress
            // 
            loopProgress.Location = new Point(132, 71);
            loopProgress.Margin = new Padding(2, 2, 2, 2);
            loopProgress.Name = "loopProgress";
            loopProgress.Size = new Size(122, 20);
            loopProgress.TabIndex = 7;
            // 
            // etaLabel
            // 
            etaLabel.AutoSize = true;
            etaLabel.Location = new Point(132, 93);
            etaLabel.Name = "etaLabel";
            etaLabel.Size = new Size(29, 15);
            etaLabel.TabIndex = 8;
            etaLabel.Text = "ETA:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(442, 220);
            Controls.Add(etaLabel);
            Controls.Add(loopProgress);
            Controls.Add(loopLabel);
            Controls.Add(amountNumUpDown);
            Controls.Add(amountLabel);
            Controls.Add(label1);
            Controls.Add(textToLoopTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Arrow's AutoTyper";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)amountNumUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox textToLoopTextBox;
        private Label label1;
        private Label amountLabel;
        private NumericUpDown amountNumUpDown;
        private Label loopLabel;
        private ProgressBar loopProgress;
        private Label etaLabel;
    }
}
