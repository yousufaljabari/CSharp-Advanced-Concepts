namespace TestProject
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxFirstNumber = new TextBox();
            labelSum = new Label();
            labelEqual = new Label();
            textBoxSecondNumber = new TextBox();
            labelResullt = new Label();
            buttonCalculate = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBoxFirstNumber
            // 
            textBoxFirstNumber.Location = new Point(126, 81);
            textBoxFirstNumber.Name = "textBoxFirstNumber";
            textBoxFirstNumber.Size = new Size(218, 27);
            textBoxFirstNumber.TabIndex = 0;
            // 
            // labelSum
            // 
            labelSum.AutoSize = true;
            labelSum.Font = new Font("Segoe UI Variable Display Semib", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSum.Location = new Point(208, 163);
            labelSum.Name = "labelSum";
            labelSum.Size = new Size(30, 31);
            labelSum.TabIndex = 1;
            labelSum.Text = "+";
            // 
            // labelEqual
            // 
            labelEqual.AutoSize = true;
            labelEqual.Location = new Point(386, 164);
            labelEqual.Name = "labelEqual";
            labelEqual.Size = new Size(46, 20);
            labelEqual.TabIndex = 2;
            labelEqual.Text = "Equal";
            // 
            // textBoxSecondNumber
            // 
            textBoxSecondNumber.Location = new Point(126, 243);
            textBoxSecondNumber.Name = "textBoxSecondNumber";
            textBoxSecondNumber.Size = new Size(218, 27);
            textBoxSecondNumber.TabIndex = 3;
            // 
            // labelResullt
            // 
            labelResullt.AutoSize = true;
            labelResullt.Location = new Point(508, 164);
            labelResullt.Name = "labelResullt";
            labelResullt.Size = new Size(44, 20);
            labelResullt.TabIndex = 4;
            labelResullt.Text = "?????";
            // 
            // buttonCalculate
            // 
            buttonCalculate.Location = new Point(442, 329);
            buttonCalculate.Name = "buttonCalculate";
            buttonCalculate.Size = new Size(99, 35);
            buttonCalculate.TabIndex = 5;
            buttonCalculate.Text = "Calculate";
            buttonCalculate.UseVisualStyleBackColor = true;
            buttonCalculate.Click += buttonCalculate_Click;
            // 
            // button1
            // 
            button1.Location = new Point(751, 104);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(buttonCalculate);
            Controls.Add(labelResullt);
            Controls.Add(textBoxSecondNumber);
            Controls.Add(labelEqual);
            Controls.Add(labelSum);
            Controls.Add(textBoxFirstNumber);
            Name = "UserControl1";
            Size = new Size(947, 519);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFirstNumber;
        private Label labelSum;
        private Label labelEqual;
        private TextBox textBoxSecondNumber;
        private Label labelResullt;
        private Button buttonCalculate;
        private Button button1;
    }
}
