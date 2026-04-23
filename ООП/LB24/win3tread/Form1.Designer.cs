namespace win3tread
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.button1  = new System.Windows.Forms.Button(); // Запустити 1 потік
            this.button2  = new System.Windows.Forms.Button(); // Запустити 2 потік
            this.button3  = new System.Windows.Forms.Button(); // Запустити 3 потік
            this.button4  = new System.Windows.Forms.Button(); // Запустити всі потоки
            this.button5  = new System.Windows.Forms.Button(); // Зупинити 1 потік
            this.button6  = new System.Windows.Forms.Button(); // Зупинити 2 потік
            this.button7  = new System.Windows.Forms.Button(); // Зупинити 3 потік
            this.button8  = new System.Windows.Forms.Button(); // Зупинити всі потоки
            this.SuspendLayout();

            // richTextBox1 (SAFER)
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Size = new System.Drawing.Size(270, 220);
            this.richTextBox1.ReadOnly = true;

            // richTextBox2 (MD-2)
            this.richTextBox2.Location = new System.Drawing.Point(295, 12);
            this.richTextBox2.Size = new System.Drawing.Size(270, 220);
            this.richTextBox2.ReadOnly = true;

            // richTextBox3 (BBS)
            this.richTextBox3.Location = new System.Drawing.Point(578, 12);
            this.richTextBox3.Size = new System.Drawing.Size(270, 220);
            this.richTextBox3.ReadOnly = true;

            // button1 - Запустити 1 потік (SAFER)
            this.button1.Location = new System.Drawing.Point(12, 245);
            this.button1.Size = new System.Drawing.Size(270, 30);
            this.button1.Text = "Запустити 1 потік (SAFER)";
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // button5 - Зупинити 1 потік (SAFER)
            this.button5.Location = new System.Drawing.Point(12, 285);
            this.button5.Size = new System.Drawing.Size(270, 30);
            this.button5.Text = "Зупинити 1 потік (SAFER)";
            this.button5.Click += new System.EventHandler(this.button5_Click);

            // button2 - Запустити 2 потік (MD-2)
            this.button2.Location = new System.Drawing.Point(295, 245);
            this.button2.Size = new System.Drawing.Size(270, 30);
            this.button2.Text = "Запустити 2 потік (MD-2)";
            this.button2.Click += new System.EventHandler(this.button2_Click);

            // button6 - Зупинити 2 потік (MD-2)
            this.button6.Location = new System.Drawing.Point(295, 285);
            this.button6.Size = new System.Drawing.Size(270, 30);
            this.button6.Text = "Зупинити 2 потік (MD-2)";
            this.button6.Click += new System.EventHandler(this.button6_Click);

            // button3 - Запустити 3 потік (BBS)
            this.button3.Location = new System.Drawing.Point(578, 245);
            this.button3.Size = new System.Drawing.Size(270, 30);
            this.button3.Text = "Запустити 3 потік (BBS)";
            this.button3.Click += new System.EventHandler(this.button3_Click);

            // button7 - Зупинити 3 потік (BBS)
            this.button7.Location = new System.Drawing.Point(578, 285);
            this.button7.Size = new System.Drawing.Size(270, 30);
            this.button7.Text = "Зупинити 3 потік (BBS)";
            this.button7.Click += new System.EventHandler(this.button7_Click);

            // button4 - Запустити всі потоки
            this.button4.Location = new System.Drawing.Point(12, 330);
            this.button4.Size = new System.Drawing.Size(836, 30);
            this.button4.Text = "Запустити всі потоки";
            this.button4.Click += new System.EventHandler(this.button4_Click);

            // button8 - Зупинити всі потоки
            this.button8.Location = new System.Drawing.Point(12, 370);
            this.button8.Size = new System.Drawing.Size(836, 30);
            this.button8.Text = "Зупинити всі потоки";
            this.button8.Click += new System.EventHandler(this.button8_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 415);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Text = "Багатопотокова програма";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}
