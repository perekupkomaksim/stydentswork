using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // завдання 1 Обчислити sin(sqrt(x+1)) - sin(sqrt(x-1))
        private void btnTask1_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(txtTask1X.Text);
                if (x < 1)
                {
                    MessageBox.Show("Помилка: x повинно бути >= 1 (для sqrt(x-1))",
                        "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                double result = Math.Sin(Math.Sqrt(x + 1)) - Math.Sin(Math.Sqrt(x - 1));
                lblTask1Result.Text = "Результат: " + result.ToString("F6");
            }
            catch
            {
                MessageBox.Show("Введіть коректне число!", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTask1X.Focus();
            }
        }

        private void txtTask1X_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowDoubleInput(sender, e, txtTask1X);
        }

        // завдання 2 площа грані = a^2 площа повної поверхні = 6*a^2 об'єм = a^3
        private void btnTask2_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(txtTask2A.Text);
                if (a <= 0)
                {
                    MessageBox.Show("Довжина ребра повинна бути > 0!",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                double faceArea = a * a;
                double totalArea = 6 * a * a;
                double volume = a * a * a;

                lblTask2Result.Text =
                    $"Площа грані: {faceArea.ToString("F4")}\n" +
                    $"Площа повної поверхні: {totalArea.ToString("F4")}\n" +
                    $"Об'єм куба: {volume.ToString("F4")}";
            }
            catch
            {
                MessageBox.Show("Введіть коректне число!", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTask2A.Focus();
            }
        }

        private void txtTask2A_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowDoubleInput(sender, e, txtTask2A);
        }

        // завдання 3
        // Перевірка: чи є цифри тризначного числа N членами арифметичної прогресії
        private void btnTask3_Click(object sender, EventArgs e)
        {
            try
            {
                int N = Convert.ToInt32(txtTask3N.Text);
                if (N < 100 || N > 999)
                {
                    MessageBox.Show("Введіть тризначне число (100-999)!",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int d1 = N / 100;          // перша цифра
                int d2 = (N / 10) % 10;    // друга цифра
                int d3 = N % 10;           // третя цифра

                // перевірка d2 - d1 == d3 - d2  =>  2*d2 == d1 + d3
                bool isAP = (2 * d2 == d1 + d3);

                lblTask3Result.Text =
                    $"Цифри числа {N}: {d1}, {d2}, {d3}\n" +
                    $"Різниці: {d2 - d1}, {d3 - d2}\n" +
                    $"Арифметична прогресія: {isAP}";
            }
            catch
            {
                MessageBox.Show("Введіть коректне ціле число!", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTask3N.Focus();
            }
        }

        private void txtTask3N_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowIntInput(sender, e, btnTask3);
        }

        // завдання 4 на осі OX три точки a, b, c. Яка точка (b чи c) ближча до a?
        private void btnTask4_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(txtTask4A.Text);
                double b = Convert.ToDouble(txtTask4B.Text);
                double c = Convert.ToDouble(txtTask4C.Text);

                double distAB = Math.Abs(b - a);
                double distAC = Math.Abs(c - a);

                string result;
                if (distAB < distAC)
                    result = $"Точка b (відстань до a: {distAB:F4}) ближча до a";
                else if (distAC < distAB)
                    result = $"Точка c (відстань до a: {distAC:F4}) ближча до a";
                else
                    result = $"Точки b і c однаково віддалені від a (відстань: {distAB:F4})";

                lblTask4Result.Text =
                    $"|b - a| = {distAB:F4}\n|c - a| = {distAC:F4}\n{result}";
            }
            catch
            {
                MessageBox.Show("Введіть коректні числа!", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTask4_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            AllowDoubleInput(sender, e, tb);
        }

        // завдання 5
        // На [2,n] знайти числа, сума цифр яких при множенні на 'a' не змінюється
        private void btnTask5_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(txtTask5N.Text);
                int a = Convert.ToInt32(txtTask5A.Text);

                if (n < 2)
                {
                    MessageBox.Show("n повинно бути >= 2!", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (a <= 1)
                {
                    MessageBox.Show("a повинно бути > 1!", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<int> results = new List<int>();

                for (int num = 2; num <= n; num++)
                {
                    int sumOriginal = SumOfDigits(num);
                    long multiplied = (long)num * a;
                    int sumMultiplied = SumOfDigits(multiplied);

                    if (sumOriginal == sumMultiplied)
                        results.Add(num);
                }

                if (results.Count == 0)
                    lblTask5Result.Text = "Таких чисел немає";
                else
                    lblTask5Result.Text = "Числа: " + string.Join(", ", results) +
                        $"\nКількість: {results.Count}";
            }
            catch
            {
                MessageBox.Show("Введіть коректні цілі числа!", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int SumOfDigits(long num)
        {
            num = Math.Abs(num);
            int sum = 0;
            while (num > 0)
            {
                sum += (int)(num % 10);
                num /= 10;
            }
            return sum;
        }

        private void txtTask5N_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowIntInput(sender, e, btnTask5);
        }

        private void txtTask5A_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowIntInput(sender, e, btnTask5);
        }

        // завдання 6
        // видалити з послідовності елементи рівні мінімальному
        private void btnTask6_Click(object sender, EventArgs e)
        {
            try
            {
                string input = txtTask6Input.Text.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Введіть числа!", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string[] parts = input.Split(new char[] { ' ', ',', ';' },
                    StringSplitOptions.RemoveEmptyEntries);
                List<int> sequence = new List<int>();

                foreach (string part in parts)
                    sequence.Add(Convert.ToInt32(part));

                int minVal = sequence.Min();
                List<int> newSequence = sequence.Where(x => x != minVal).ToList();

                string original = string.Join(", ", sequence);
                string result = newSequence.Count > 0
                    ? string.Join(", ", newSequence)
                    : "(порожня послідовність)";

                lblTask6Result.Text =
                    $"Вихідна: [{original}]\n" +
                    $"Мінімум: {minVal}\n" +
                    $"Нова:    [{result}]";
            }
            catch
            {
                MessageBox.Show("Введіть коректні цілі числа через пробіл/кому!",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // завдання 7
        // видалити : з рядка та підрахувати кількість видалень
        private void btnTask7_Click(object sender, EventArgs e)
        {
            string input = txtTask7Input.Text;
            int count = 0;
            StringBuilder sb = new StringBuilder();

            foreach (char ch in input)
            {
                if (ch == ':')
                    count++;
                else
                    sb.Append(ch);
            }

            string resultStr = sb.ToString();
            lblTask7Result.Text =
                $"Результат: \"{resultStr}\"\n" +
                $"Видалено символів ':': {count}";
        }

        private void AllowDoubleInput(object sender, KeyPressEventArgs e, TextBox tb)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9')) return;

            if (e.KeyChar == '.')
                e.KeyChar = ',';

            if (e.KeyChar == ',')
            {
                if (tb.Text.IndexOf(',') != -1)
                    e.Handled = true;
                return;
            }

            if (e.KeyChar == '-')
            {
                if (tb.SelectionStart != 0 || tb.Text.Contains('-'))
                    e.Handled = true;
                return;
            }

            if (Char.IsControl(e.KeyChar)) return;

            e.Handled = true;
        }

        // дозволяє вводити лише цілі числа
        private void AllowIntInput(object sender, KeyPressEventArgs e, Button btn)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9')) return;

            if (e.KeyChar == '-')
            {
                TextBox tb = sender as TextBox;
                if (tb != null && tb.SelectionStart == 0 && !tb.Text.Contains('-'))
                    return;
                e.Handled = true;
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    btn.Focus();
                return;
            }

            e.Handled = true;
        }
    }
}