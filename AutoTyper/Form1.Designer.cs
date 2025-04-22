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
            ((System.ComponentModel.ISupportInitialize)amountNumUpDown).BeginInit();
            SuspendLayout();
            // 
            // textToLoopTextBox
            // 
            textToLoopTextBox.Location = new Point(12, 56);
            textToLoopTextBox.Name = "textToLoopTextBox";
            textToLoopTextBox.Size = new Size(165, 303);
            textToLoopTextBox.TabIndex = 0;
            textToLoopTextBox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(106, 25);
            label1.TabIndex = 2;
            label1.Text = "Text to loop";
            // 
            // amountLabel
            // 
            amountLabel.AutoSize = true;
            amountLabel.Location = new Point(183, 28);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new Size(156, 25);
            amountLabel.TabIndex = 3;
            amountLabel.Text = "How many loops?";
            // 
            // amountNumUpDown
            // 
            amountNumUpDown.Location = new Point(183, 57);
            amountNumUpDown.Name = "amountNumUpDown";
            amountNumUpDown.Size = new Size(180, 31);
            amountNumUpDown.TabIndex = 5;
            // 
            // loopLabel
            // 
            loopLabel.AutoSize = true;
            loopLabel.Location = new Point(183, 91);
            loopLabel.Name = "loopLabel";
            loopLabel.Size = new Size(80, 25);
            loopLabel.TabIndex = 6;
            loopLabel.Text = "Loops: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(632, 366);
            Controls.Add(loopLabel);
            Controls.Add(amountNumUpDown);
            Controls.Add(amountLabel);
            Controls.Add(label1);
            Controls.Add(textToLoopTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Arrow's AutoTyper";
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
    }
}
