namespace WindowsFormsApp5
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblTask1X = new System.Windows.Forms.Label();
            this.txtTask1X = new System.Windows.Forms.TextBox();
            this.btnTask1 = new System.Windows.Forms.Button();
            this.lblTask1Result = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblTask2A = new System.Windows.Forms.Label();
            this.txtTask2A = new System.Windows.Forms.TextBox();
            this.btnTask2 = new System.Windows.Forms.Button();
            this.lblTask2Result = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblTask3N = new System.Windows.Forms.Label();
            this.txtTask3N = new System.Windows.Forms.TextBox();
            this.btnTask3 = new System.Windows.Forms.Button();
            this.lblTask3Result = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lblTask4A = new System.Windows.Forms.Label();
            this.txtTask4A = new System.Windows.Forms.TextBox();
            this.lblTask4B = new System.Windows.Forms.Label();
            this.txtTask4B = new System.Windows.Forms.TextBox();
            this.lblTask4C = new System.Windows.Forms.Label();
            this.txtTask4C = new System.Windows.Forms.TextBox();
            this.btnTask4 = new System.Windows.Forms.Button();
            this.lblTask4Result = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lblTask5N = new System.Windows.Forms.Label();
            this.txtTask5N = new System.Windows.Forms.TextBox();
            this.lblTask5A = new System.Windows.Forms.Label();
            this.txtTask5A = new System.Windows.Forms.TextBox();
            this.btnTask5 = new System.Windows.Forms.Button();
            this.lblTask5Result = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.lblTask6Input = new System.Windows.Forms.Label();
            this.txtTask6Input = new System.Windows.Forms.TextBox();
            this.btnTask6 = new System.Windows.Forms.Button();
            this.lblTask6Result = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.lblTask7Input = new System.Windows.Forms.Label();
            this.txtTask7Input = new System.Windows.Forms.TextBox();
            this.btnTask7 = new System.Windows.Forms.Button();
            this.lblTask7Result = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 520);
            this.tabControl1.TabIndex = 0;
                        this.tabPage1.Controls.Add(this.lblTask1X);
            this.tabPage1.Controls.Add(this.txtTask1X);
            this.tabPage1.Controls.Add(this.btnTask1);
            this.tabPage1.Controls.Add(this.lblTask1Result);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(752, 489);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Завд. 1: Формула";
            
            this.lblTask1X.Location = new System.Drawing.Point(20, 30);
            this.lblTask1X.Name = "lblTask1X";
            this.lblTask1X.Size = new System.Drawing.Size(150, 23);
            this.lblTask1X.TabIndex = 0;
            this.lblTask1X.Text = "Введіть x (x ≥ 1):";
            
            this.txtTask1X.Location = new System.Drawing.Point(180, 27);
            this.txtTask1X.Name = "txtTask1X";
            this.txtTask1X.Size = new System.Drawing.Size(150, 26);
            this.txtTask1X.TabIndex = 1;
            this.txtTask1X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTask1X_KeyPress);
            
            this.btnTask1.Location = new System.Drawing.Point(20, 70);
            this.btnTask1.Name = "btnTask1";
            this.btnTask1.Size = new System.Drawing.Size(120, 30);
            this.btnTask1.TabIndex = 2;
            this.btnTask1.Text = "Обчислити";
            this.btnTask1.Click += new System.EventHandler(this.btnTask1_Click);
            
            this.lblTask1Result.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblTask1Result.Location = new System.Drawing.Point(20, 120);
            this.lblTask1Result.Name = "lblTask1Result";
            this.lblTask1Result.Size = new System.Drawing.Size(680, 60);
            this.lblTask1Result.TabIndex = 3;
            this.lblTask1Result.Text = "sin(sqrt(x+1)) - sin(sqrt(x-1)) = ?";
            
            this.tabPage2.Controls.Add(this.lblTask2A);
            this.tabPage2.Controls.Add(this.txtTask2A);
            this.tabPage2.Controls.Add(this.btnTask2);
            this.tabPage2.Controls.Add(this.lblTask2Result);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(752, 491);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Завд. 2: Куб";
            
            this.lblTask2A.Location = new System.Drawing.Point(20, 30);
            this.lblTask2A.Name = "lblTask2A";
            this.lblTask2A.Size = new System.Drawing.Size(150, 23);
            this.lblTask2A.TabIndex = 0;
            this.lblTask2A.Text = "Ребро куба a:";
            
            this.txtTask2A.Location = new System.Drawing.Point(180, 27);
            this.txtTask2A.Name = "txtTask2A";
            this.txtTask2A.Size = new System.Drawing.Size(150, 26);
            this.txtTask2A.TabIndex = 1;
            this.txtTask2A.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTask2A_KeyPress);
            
            this.btnTask2.Location = new System.Drawing.Point(20, 70);
            this.btnTask2.Name = "btnTask2";
            this.btnTask2.Size = new System.Drawing.Size(120, 30);
            this.btnTask2.TabIndex = 2;
            this.btnTask2.Text = "Обчислити";
            this.btnTask2.Click += new System.EventHandler(this.btnTask2_Click);
            
            this.lblTask2Result.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTask2Result.Location = new System.Drawing.Point(20, 120);
            this.lblTask2Result.Name = "lblTask2Result";
            this.lblTask2Result.Size = new System.Drawing.Size(680, 80);
            this.lblTask2Result.TabIndex = 3;
            this.lblTask2Result.Text = "Результати з\'являться тут...";
            
            this.tabPage3.Controls.Add(this.lblTask3N);
            this.tabPage3.Controls.Add(this.txtTask3N);
            this.tabPage3.Controls.Add(this.btnTask3);
            this.tabPage3.Controls.Add(this.lblTask3Result);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(752, 491);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Завд. 3: Прогресія";
            
            this.lblTask3N.Location = new System.Drawing.Point(20, 30);
            this.lblTask3N.Name = "lblTask3N";
            this.lblTask3N.Size = new System.Drawing.Size(160, 23);
            this.lblTask3N.TabIndex = 0;
            this.lblTask3N.Text = "Тризначне число N:";
            
            this.txtTask3N.Location = new System.Drawing.Point(190, 27);
            this.txtTask3N.Name = "txtTask3N";
            this.txtTask3N.Size = new System.Drawing.Size(150, 26);
            this.txtTask3N.TabIndex = 1;
            this.txtTask3N.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTask3N_KeyPress);
            
            this.btnTask3.Location = new System.Drawing.Point(20, 70);
            this.btnTask3.Name = "btnTask3";
            this.btnTask3.Size = new System.Drawing.Size(120, 30);
            this.btnTask3.TabIndex = 2;
            this.btnTask3.Text = "Перевірити";
            this.btnTask3.Click += new System.EventHandler(this.btnTask3_Click);
            
            this.lblTask3Result.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTask3Result.Location = new System.Drawing.Point(20, 120);
            this.lblTask3Result.Name = "lblTask3Result";
            this.lblTask3Result.Size = new System.Drawing.Size(680, 80);
            this.lblTask3Result.TabIndex = 3;
            this.lblTask3Result.Text = "Результат з\'явиться тут...";
            
            this.tabPage4.Controls.Add(this.lblTask4A);
            this.tabPage4.Controls.Add(this.txtTask4A);
            this.tabPage4.Controls.Add(this.lblTask4B);
            this.tabPage4.Controls.Add(this.txtTask4B);
            this.tabPage4.Controls.Add(this.lblTask4C);
            this.tabPage4.Controls.Add(this.txtTask4C);
            this.tabPage4.Controls.Add(this.btnTask4);
            this.tabPage4.Controls.Add(this.lblTask4Result);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(752, 491);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Завд. 4: Точки";
            
            this.lblTask4A.Location = new System.Drawing.Point(20, 20);
            this.lblTask4A.Name = "lblTask4A";
            this.lblTask4A.Size = new System.Drawing.Size(70, 23);
            this.lblTask4A.TabIndex = 0;
            this.lblTask4A.Text = "Точка a:";
            
            this.txtTask4A.Location = new System.Drawing.Point(100, 17);
            this.txtTask4A.Name = "txtTask4A";
            this.txtTask4A.Size = new System.Drawing.Size(120, 26);
            this.txtTask4A.TabIndex = 1;
            this.txtTask4A.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTask4_KeyPress);
            
            this.lblTask4B.Location = new System.Drawing.Point(20, 55);
            this.lblTask4B.Name = "lblTask4B";
            this.lblTask4B.Size = new System.Drawing.Size(70, 23);
            this.lblTask4B.TabIndex = 2;
            this.lblTask4B.Text = "Точка b:";
            
            this.txtTask4B.Location = new System.Drawing.Point(100, 52);
            this.txtTask4B.Name = "txtTask4B";
            this.txtTask4B.Size = new System.Drawing.Size(120, 26);
            this.txtTask4B.TabIndex = 3;
            this.txtTask4B.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTask4_KeyPress);
            
            this.lblTask4C.Location = new System.Drawing.Point(20, 90);
            this.lblTask4C.Name = "lblTask4C";
            this.lblTask4C.Size = new System.Drawing.Size(70, 23);
            this.lblTask4C.TabIndex = 4;
            this.lblTask4C.Text = "Точка c:";
            
            this.txtTask4C.Location = new System.Drawing.Point(100, 87);
            this.txtTask4C.Name = "txtTask4C";
            this.txtTask4C.Size = new System.Drawing.Size(120, 26);
            this.txtTask4C.TabIndex = 5;
            this.txtTask4C.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTask4_KeyPress);
            
            this.btnTask4.Location = new System.Drawing.Point(20, 130);
            this.btnTask4.Name = "btnTask4";
            this.btnTask4.Size = new System.Drawing.Size(120, 30);
            this.btnTask4.TabIndex = 6;
            this.btnTask4.Text = "Визначити";
            this.btnTask4.Click += new System.EventHandler(this.btnTask4_Click);
            
            this.lblTask4Result.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTask4Result.Location = new System.Drawing.Point(20, 180);
            this.lblTask4Result.Name = "lblTask4Result";
            this.lblTask4Result.Size = new System.Drawing.Size(680, 80);
            this.lblTask4Result.TabIndex = 7;
            this.lblTask4Result.Text = "Результат з\'явиться тут...";
            
            this.tabPage5.Controls.Add(this.lblTask5N);
            this.tabPage5.Controls.Add(this.txtTask5N);
            this.tabPage5.Controls.Add(this.lblTask5A);
            this.tabPage5.Controls.Add(this.txtTask5A);
            this.tabPage5.Controls.Add(this.btnTask5);
            this.tabPage5.Controls.Add(this.lblTask5Result);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(752, 491);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Завд. 5: Сума цифр";
            
            this.lblTask5N.Location = new System.Drawing.Point(20, 20);
            this.lblTask5N.Name = "lblTask5N";
            this.lblTask5N.Size = new System.Drawing.Size(160, 23);
            this.lblTask5N.TabIndex = 0;
            this.lblTask5N.Text = "Верхня межа n (≥2):";
            
            this.txtTask5N.Location = new System.Drawing.Point(190, 17);
            this.txtTask5N.Name = "txtTask5N";
            this.txtTask5N.Size = new System.Drawing.Size(120, 26);
            this.txtTask5N.TabIndex = 1;
            this.txtTask5N.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTask5N_KeyPress);
            
            this.lblTask5A.Location = new System.Drawing.Point(20, 55);
            this.lblTask5A.Name = "lblTask5A";
            this.lblTask5A.Size = new System.Drawing.Size(160, 23);
            this.lblTask5A.TabIndex = 2;
            this.lblTask5A.Text = "Множник a (>1):";
            
            this.txtTask5A.Location = new System.Drawing.Point(190, 52);
            this.txtTask5A.Name = "txtTask5A";
            this.txtTask5A.Size = new System.Drawing.Size(120, 26);
            this.txtTask5A.TabIndex = 3;
            this.txtTask5A.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTask5A_KeyPress);
            
            this.btnTask5.Location = new System.Drawing.Point(20, 90);
            this.btnTask5.Name = "btnTask5";
            this.btnTask5.Size = new System.Drawing.Size(120, 30);
            this.btnTask5.TabIndex = 4;
            this.btnTask5.Text = "Знайти";
            this.btnTask5.Click += new System.EventHandler(this.btnTask5_Click);
            
            this.lblTask5Result.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTask5Result.Location = new System.Drawing.Point(20, 140);
            this.lblTask5Result.Name = "lblTask5Result";
            this.lblTask5Result.Size = new System.Drawing.Size(700, 300);
            this.lblTask5Result.TabIndex = 5;
            this.lblTask5Result.Text = "Результат з\'явиться тут...";
            
            this.tabPage6.Controls.Add(this.lblTask6Input);
            this.tabPage6.Controls.Add(this.txtTask6Input);
            this.tabPage6.Controls.Add(this.btnTask6);
            this.tabPage6.Controls.Add(this.lblTask6Result);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(752, 491);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Завд. 6: Послідовність";
            
            this.lblTask6Input.Location = new System.Drawing.Point(20, 20);
            this.lblTask6Input.Name = "lblTask6Input";
            this.lblTask6Input.Size = new System.Drawing.Size(350, 23);
            this.lblTask6Input.TabIndex = 0;
            this.lblTask6Input.Text = "Введіть числа через пробіл або кому:";
            
            this.txtTask6Input.Location = new System.Drawing.Point(20, 50);
            this.txtTask6Input.Name = "txtTask6Input";
            this.txtTask6Input.Size = new System.Drawing.Size(680, 26);
            this.txtTask6Input.TabIndex = 1;
            
            this.btnTask6.Location = new System.Drawing.Point(20, 90);
            this.btnTask6.Name = "btnTask6";
            this.btnTask6.Size = new System.Drawing.Size(120, 30);
            this.btnTask6.TabIndex = 2;
            this.btnTask6.Text = "Обробити";
            this.btnTask6.Click += new System.EventHandler(this.btnTask6_Click);
            
            this.lblTask6Result.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTask6Result.Location = new System.Drawing.Point(20, 140);
            this.lblTask6Result.Name = "lblTask6Result";
            this.lblTask6Result.Size = new System.Drawing.Size(700, 120);
            this.lblTask6Result.TabIndex = 3;
            this.lblTask6Result.Text = "Результат з\'явиться тут...";
            
            this.tabPage7.Controls.Add(this.lblTask7Input);
            this.tabPage7.Controls.Add(this.txtTask7Input);
            this.tabPage7.Controls.Add(this.btnTask7);
            this.tabPage7.Controls.Add(this.lblTask7Result);
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(752, 491);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Завд. 7: Рядок";
            
            this.lblTask7Input.Location = new System.Drawing.Point(20, 20);
            this.lblTask7Input.Name = "lblTask7Input";
            this.lblTask7Input.Size = new System.Drawing.Size(350, 23);
            this.lblTask7Input.TabIndex = 0;
            this.lblTask7Input.Text = "Введіть рядок (може містити \':\'):";
            
            this.txtTask7Input.Location = new System.Drawing.Point(20, 50);
            this.txtTask7Input.Name = "txtTask7Input";
            this.txtTask7Input.Size = new System.Drawing.Size(680, 26);
            this.txtTask7Input.TabIndex = 1;
            
            this.btnTask7.Location = new System.Drawing.Point(20, 90);
            this.btnTask7.Name = "btnTask7";
            this.btnTask7.Size = new System.Drawing.Size(120, 30);
            this.btnTask7.TabIndex = 2;
            this.btnTask7.Text = "Обробити";
            this.btnTask7.Click += new System.EventHandler(this.btnTask7_Click);
            
            this.lblTask7Result.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTask7Result.Location = new System.Drawing.Point(20, 140);
            this.lblTask7Result.Name = "lblTask7Result";
            this.lblTask7Result.Size = new System.Drawing.Size(700, 80);
            this.lblTask7Result.TabIndex = 3;
            this.lblTask7Result.Text = "Результат з\'явиться тут...";
            
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Варіант 18 - Лабораторна робота №15";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1, tabPage2, tabPage3,
            tabPage4, tabPage5, tabPage6, tabPage7;
        private System.Windows.Forms.Label lblTask1X, lblTask1Result;
        private System.Windows.Forms.TextBox txtTask1X;
        private System.Windows.Forms.Button btnTask1;
        private System.Windows.Forms.Label lblTask2A, lblTask2Result;
        private System.Windows.Forms.TextBox txtTask2A;
        private System.Windows.Forms.Button btnTask2;
        private System.Windows.Forms.Label lblTask3N, lblTask3Result;
        private System.Windows.Forms.TextBox txtTask3N;
        private System.Windows.Forms.Button btnTask3;
        private System.Windows.Forms.Label lblTask4A, lblTask4B, lblTask4C, lblTask4Result;
        private System.Windows.Forms.TextBox txtTask4A, txtTask4B, txtTask4C;
        private System.Windows.Forms.Button btnTask4;
        private System.Windows.Forms.Label lblTask5N, lblTask5A, lblTask5Result;
        private System.Windows.Forms.TextBox txtTask5N, txtTask5A;
        private System.Windows.Forms.Button btnTask5;
        private System.Windows.Forms.Label lblTask6Input, lblTask6Result;
        private System.Windows.Forms.TextBox txtTask6Input;
        private System.Windows.Forms.Button btnTask6;
        private System.Windows.Forms.Label lblTask7Input, lblTask7Result;
        private System.Windows.Forms.TextBox txtTask7Input;
        private System.Windows.Forms.Button btnTask7;
    }
}