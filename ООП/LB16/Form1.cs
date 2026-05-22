using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab16Task18
{
    public class Form1 : Form
    {
        // елементи керування
        private TabControl tabControl;

        // вкладка 1 крамер
        private NumericUpDown nudSize;
        private DataGridView dgvA, dgvB;
        private RichTextBox rtbCramerResult;
        private Button btnSolve, btnFillExample;
        private Label lblDet;

        // вкладка 2 матричні операції
        private DataGridView dgvM1, dgvM2, dgvMResult;
        private Button btnAdd, btnMultiply, btnTranspose;
        private NumericUpDown nudOpSize;
        private Label lblOpStatus;

        // вкладка 3 інформація
        private Label lblInfo;
        private Button btnRefreshInfo;

        public Form1()
        {
            InitializeComponent();
            InitCramerTab();
        }

        // інтерфейс
        private void InitializeComponent()
        {
            this.Text = "Лабораторна робота №16 — Завдання 18: Метод Крамера";
            this.Size = new Size(900, 680);
            this.MinimumSize = new Size(860, 620);
            this.Font = new Font("Segoe UI", 9f);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 247, 250);

            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5f)
            };

            TabPage tabCramer = new TabPage("Метод Крамера");
            tabCramer.BackColor = Color.FromArgb(245, 247, 250);
            BuildCramerTab(tabCramer);

            TabPage tabOps = new TabPage("Операції над матрицями");
            tabOps.BackColor = Color.FromArgb(245, 247, 250);
            BuildOpsTab(tabOps);

            TabPage tabInfo = new TabPage("Інформація");
            tabInfo.BackColor = Color.FromArgb(245, 247, 250);
            BuildInfoTab(tabInfo);

            tabControl.TabPages.Add(tabCramer);
            tabControl.TabPages.Add(tabOps);
            tabControl.TabPages.Add(tabInfo);

            this.Controls.Add(tabControl);
        }

        // вкладка 1 крамер
        private void BuildCramerTab(TabPage tab)
        {
            var lblTitle = MakeLabel("Розв'язання системи лінійних рівнянь методом Крамера  (2 ≤ N ≤ 10)",
                new Point(10, 10), new Size(840, 26), true);

            var lblN = MakeLabel("Розмір системи N:", new Point(10, 48), new Size(135, 22));
            nudSize = new NumericUpDown
            {
                Location = new Point(150, 46),
                Size = new Size(55, 22),
                Minimum = 2, Maximum = 10, Value = 3
            };
            nudSize.ValueChanged += (s, e) => InitCramerTab();

            btnFillExample = MakeButton("Приклад", new Point(220, 44), new Size(80, 26), Color.SteelBlue);
            btnFillExample.Click += BtnFillExample_Click;

            btnSolve = MakeButton("Розв'язати", new Point(315, 44), new Size(120, 26), Color.FromArgb(39, 174, 96));
            btnSolve.Click += BtnSolve_Click;

            var lblA = MakeLabel("Матриця коефіцієнтів A:", new Point(10, 85), new Size(220, 20), true);
            var lblBv = MakeLabel("Вектор правих частин b:", new Point(540, 85), new Size(220, 20), true);

            dgvA = MakeGrid(new Point(10, 108), new Size(500, 200));
            dgvB = MakeGrid(new Point(540, 108), new Size(120, 200));
            dgvB.ColumnCount = 1;

            lblDet = MakeLabel("", new Point(10, 318), new Size(650, 22));
            lblDet.ForeColor = Color.DarkSlateBlue;
            lblDet.Font = new Font("Segoe UI", 9f, FontStyle.Italic);

            var lblRes = MakeLabel("Результат:", new Point(10, 346), new Size(100, 20), true);
            rtbCramerResult = new RichTextBox
            {
                Location = new Point(10, 368),
                Size = new Size(850, 240),
                ReadOnly = true,
                BackColor = Color.White,
                Font = new Font("Consolas", 9.5f),
                BorderStyle = BorderStyle.FixedSingle
            };

            tab.Controls.AddRange(new Control[] {
                lblTitle, lblN, nudSize, btnFillExample, btnSolve,
                lblA, lblBv, dgvA, dgvB, lblDet, lblRes, rtbCramerResult
            });
        }

        private void InitCramerTab()
        {
            int n = (int)nudSize.Value;

            dgvA.Columns.Clear();
            dgvA.Rows.Clear();
            for (int j = 0; j < n; j++)
                dgvA.Columns.Add($"x{j + 1}", $"x{j + 1}");
            dgvA.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < n; i++)
            {
                dgvA.Rows.Add();
                dgvA.Rows[i].HeaderCell.Value = $"р{i + 1}";
            }
            SetGridColumnWidth(dgvA, n);

            dgvB.Columns.Clear();
            dgvB.Rows.Clear();
            dgvB.Columns.Add("b", "b");
            for (int i = 0; i < n; i++)
            {
                dgvB.Rows.Add();
                dgvB.Rows[i].HeaderCell.Value = $"р{i + 1}";
            }
            SetGridColumnWidth(dgvB, 1);

            lblDet.Text = "";
            rtbCramerResult.Clear();
        }

        private void BtnFillExample_Click(object sender, EventArgs e)
        {
            int n = (int)nudSize.Value;
            double[,] aEx;
            double[] bEx;

            if (n == 2)
            {
                aEx = new double[,] { { 2, 1 }, { 5, 3 } };
                bEx = new double[] { 5, 14 };
            }
            else if (n == 3)
            {
                aEx = new double[,] { { 2, 1, -1 }, { -3, -1, 2 }, { -2, 1, 2 } };
                bEx = new double[] { 8, -11, -3 };
            }
            else
            {
                Random rnd = new Random(42);
                aEx = new double[n, n];
                bEx = new double[n];
                for (int i = 0; i < n; i++)
                {
                    double rowSum = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                        {
                            aEx[i, j] = rnd.Next(-3, 4);
                            rowSum += Math.Abs(aEx[i, j]);
                        }
                    }
                    aEx[i, i] = rowSum + rnd.Next(1, 5);
                    bEx[i] = rnd.Next(-10, 11);
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    dgvA.Rows[i].Cells[j].Value = aEx[i, j];
                dgvB.Rows[i].Cells[0].Value = bEx[i];
            }
        }

        private void BtnSolve_Click(object sender, EventArgs e)
        {
            rtbCramerResult.Clear();
            lblDet.Text = "";
            try
            {
                int n = (int)nudSize.Value;
                Matrix A = ReadMatrixFromGrid(dgvA, n, n);
                double[] b = ReadVectorFromGrid(dgvB, n);

                double det = A.Determinant();
                lblDet.Text = $"det(A) = {det:F6}";

                rtbCramerResult.SelectionFont = new Font("Consolas", 9.5f, FontStyle.Bold);
                rtbCramerResult.AppendText($"=== Система {n}×{n} ===\n\n");

                rtbCramerResult.SelectionFont = new Font("Consolas", 9.5f);
                rtbCramerResult.AppendText("Матриця A:\n" + A.ToString() + "\n");

                rtbCramerResult.AppendText("Вектор b:  [ ");
                foreach (var v in b) rtbCramerResult.AppendText($"{v,8:F4}  ");
                rtbCramerResult.AppendText("]\n\n");

                rtbCramerResult.AppendText($"det(A) = {det:F6}\n\n");

                for (int col = 0; col < n; col++)
                {
                    Matrix Ai = new Matrix(A);
                    for (int row = 0; row < n; row++)
                        Ai[row, col] = b[row];
                    rtbCramerResult.AppendText(
                        $"det(A{col + 1}) = {Ai.Determinant():F6}  →  x{col + 1} = {Ai.Determinant():F6} / {det:F6} = {Ai.Determinant() / det:F6}\n");
                }

                double[] x = Matrix.SolveCramer(A, b);
                rtbCramerResult.SelectionFont = new Font("Consolas", 9.5f, FontStyle.Bold);
                rtbCramerResult.AppendText("\n── Розв'язок ──────────────────────────────────\n");
                rtbCramerResult.SelectionFont = new Font("Consolas", 9.5f);
                for (int i = 0; i < n; i++)
                    rtbCramerResult.AppendText($"   x{i + 1} = {x[i]:F6}\n");

                rtbCramerResult.SelectionFont = new Font("Consolas", 9.5f, FontStyle.Bold);
                rtbCramerResult.AppendText("\n── Перевірка (Ax = b) ─────────────────────────\n");
                rtbCramerResult.SelectionFont = new Font("Consolas", 9.5f);
                bool ok = true;
                for (int i = 0; i < n; i++)
                {
                    double lhs = 0;
                    for (int j = 0; j < n; j++)
                        lhs += A[i, j] * x[j];
                    bool rowOk = Math.Abs(lhs - b[i]) < 1e-6;
                    if (!rowOk) ok = false;
                    rtbCramerResult.AppendText(
                        $"   Рядок {i + 1}: {lhs:F6}  ≈  {b[i]:F6}  {(rowOk ? "✓" : "✗")}\n");
                }
                rtbCramerResult.SelectionFont = new Font("Consolas", 9.5f, FontStyle.Bold);
                rtbCramerResult.AppendText(ok ? "\n   ✅ Розв'язок вірний!\n" : "\n   ❌ Похибка!\n");

                Matrix At = A.Transpose();
                rtbCramerResult.AppendText("\n── Транспонована матриця A^T ───────────────────\n");
                rtbCramerResult.SelectionFont = new Font("Consolas", 9.5f);
                rtbCramerResult.AppendText(At.ToString());

                UpdateInfoTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // вкладка 2 матричні операції
        private void BuildOpsTab(TabPage tab)
        {
            var lblTitle = MakeLabel("Демонстрація операцій: додавання, множення, транспонування",
                new Point(10, 10), new Size(840, 26), true);

            var lblN = MakeLabel("Розмір матриць N:", new Point(10, 48), new Size(140, 22));
            nudOpSize = new NumericUpDown
            {
                Location = new Point(155, 46),
                Size = new Size(55, 22),
                Minimum = 2, Maximum = 6, Value = 3
            };
            nudOpSize.ValueChanged += (s, e) => InitOpsGrids();

            var btnGenerate = MakeButton("Згенерувати", new Point(225, 44), new Size(110, 26), Color.SteelBlue);
            btnGenerate.Click += BtnGenerate_Click;

            var lblM1 = MakeLabel("Матриця M1:", new Point(10, 85), new Size(140, 20), true);
            var lblM2 = MakeLabel("Матриця M2:", new Point(300, 85), new Size(140, 20), true);
            var lblMR = MakeLabel("Результат:", new Point(590, 85), new Size(200, 20), true);

            dgvM1 = MakeGrid(new Point(10, 108), new Size(270, 180));
            dgvM2 = MakeGrid(new Point(300, 108), new Size(270, 180));
            dgvMResult = MakeGrid(new Point(590, 108), new Size(270, 180));

            btnAdd = MakeButton("M1 + M2", new Point(10, 300), new Size(110, 30), Color.FromArgb(39, 174, 96));
            btnAdd.Click += (s, e) => DoMatrixOp("add");

            btnMultiply = MakeButton("M1 × M2", new Point(135, 300), new Size(110, 30), Color.FromArgb(52, 152, 219));
            btnMultiply.Click += (s, e) => DoMatrixOp("mul");

            btnTranspose = MakeButton("Транспонувати M1", new Point(260, 300), new Size(160, 30), Color.FromArgb(155, 89, 182));
            btnTranspose.Click += (s, e) => DoMatrixOp("trans");

            lblOpStatus = MakeLabel("", new Point(10, 340), new Size(840, 22));
            lblOpStatus.ForeColor = Color.DarkSlateBlue;

            tab.Controls.AddRange(new Control[] {
                lblTitle, lblN, nudOpSize, btnGenerate,
                lblM1, lblM2, lblMR, dgvM1, dgvM2, dgvMResult,
                btnAdd, btnMultiply, btnTranspose, lblOpStatus
            });

            InitOpsGrids();
        }

        private void InitOpsGrids()
        {
            int n = (int)nudOpSize.Value;
            SetupSquareGrid(dgvM1, n);
            SetupSquareGrid(dgvM2, n);
            SetupSquareGrid(dgvMResult, n);
            lblOpStatus.Text = "";
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            int n = (int)nudOpSize.Value;
            Random rnd = new Random();
            FillGridRandom(dgvM1, n, n, rnd);
            FillGridRandom(dgvM2, n, n, rnd);
            lblOpStatus.Text = "Матриці згенеровані.";
        }

        private void DoMatrixOp(string op)
        {
            try
            {
                int n = (int)nudOpSize.Value;
                Matrix m1 = ReadMatrixFromGrid(dgvM1, n, n);
                Matrix m2 = ReadMatrixFromGrid(dgvM2, n, n);

                Matrix result = null;
                string desc = "";

                switch (op)
                {
                    case "add":
                        result = m1.Add(m2);
                        desc = $"M1 + M2  (det={result.Determinant():F2})";
                        break;
                    case "mul":
                        result = m1.Multiply(m2);
                        desc = $"M1 × M2  (det={result.Determinant():F2})";
                        break;
                    case "trans":
                        result = m1.Transpose();
                        desc = "Транспонована M1";
                        // Adjust result grid dimensions
                        SetupSquareGrid(dgvMResult, n); // stays n×n for square
                        break;
                }

                for (int i = 0; i < result.Rows; i++)
                    for (int j = 0; j < result.Cols; j++)
                        if (i < dgvMResult.Rows.Count && j < dgvMResult.Columns.Count)
                            dgvMResult.Rows[i].Cells[j].Value = $"{result[i, j]:F2}";

                lblOpStatus.Text = $"✓ {desc}  |  Об'єктів Matrix створено: {Matrix.InstanceCount}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // вкладка 3 інформація
        private void BuildInfoTab(TabPage tab)
        {
            var lblTitle = MakeLabel("Інформація про клас Matrix", new Point(10, 10), new Size(500, 26), true);

            lblInfo = MakeLabel("", new Point(10, 50), new Size(800, 500));
            lblInfo.Font = new Font("Consolas", 9.5f);

            btnRefreshInfo = MakeButton("Оновити", new Point(10, 570), new Size(100, 28), Color.SteelBlue);
            btnRefreshInfo.Click += (s, e) => UpdateInfoTab();

            tab.Controls.AddRange(new Control[] { lblTitle, lblInfo, btnRefreshInfo });
            UpdateInfoTab();
        }

        private void UpdateInfoTab()
        {
            lblInfo.Text =
                $"Клас:            Matrix\n" +
                $"Простір імен:    Lab16Task18\n\n" +
                $"Конструктори:\n" +
                $"  1) Matrix(int n)             — квадратна нульова матриця n×n\n" +
                $"  2) Matrix(int rows, int cols) — прямокутна матриця\n" +
                $"  3) Matrix(double[,] data)     — з двовимірного масиву (копіювання)\n\n" +
                $"Методи:\n" +
                $"  Add(Matrix)    / Add(double)    — додавання (перевантаження)\n" +
                $"  Multiply(Matrix) / Multiply(double) — множення (перевантаження)\n" +
                $"  Transpose()    — транспонування\n" +
                $"  Determinant()  — обчислення визначника\n\n" +
                $"Статичний метод:\n" +
                $"  SolveCramer(Matrix A, double[] b) — метод Крамера\n\n" +
                $"Статичне поле:\n" +
                $"  InstanceCount  — лічильник створених об'єктів\n\n" +
                $"─────────────────────────────────────\n" +
                $"Об'єктів Matrix створено за сеанс:  {Matrix.InstanceCount}";
        }

        // помічники
        private DataGridView MakeGrid(Point loc, Size size)
        {
            var g = new DataGridView
            {
                Location = loc,
                Size = size,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersWidth = 40,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    BackColor = Color.White,
                    Font = new Font("Consolas", 9f)
                },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(52, 152, 219),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                },
                RowHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(236, 240, 241),
                    Font = new Font("Segoe UI", 8f)
                },
                BorderStyle = BorderStyle.FixedSingle,
                GridColor = Color.LightSteelBlue,
                BackgroundColor = Color.WhiteSmoke,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ScrollBars = ScrollBars.Both
            };
            return g;
        }

        private void SetGridColumnWidth(DataGridView g, int cols) { }

        private void SetupSquareGrid(DataGridView g, int n)
        {
            g.Columns.Clear();
            g.Rows.Clear();
            for (int j = 0; j < n; j++)
                g.Columns.Add($"c{j}", $"c{j + 1}");
            for (int i = 0; i < n; i++)
            {
                g.Rows.Add();
                g.Rows[i].HeaderCell.Value = $"r{i + 1}";
            }
        }

        private void FillGridRandom(DataGridView g, int rows, int cols, Random rnd)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    g.Rows[i].Cells[j].Value = rnd.Next(-9, 10);
        }

        private Matrix ReadMatrixFromGrid(DataGridView g, int rows, int cols)
        {
            double[,] data = new double[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    var cell = g.Rows[i].Cells[j].Value?.ToString() ?? "0";
                    if (!double.TryParse(cell, out data[i, j]))
                        throw new FormatException($"Невірне значення у клітинці [{i + 1},{j + 1}]: «{cell}»");
                }
            return new Matrix(data);
        }

        private double[] ReadVectorFromGrid(DataGridView g, int n)
        {
            double[] v = new double[n];
            for (int i = 0; i < n; i++)
            {
                var cell = g.Rows[i].Cells[0].Value?.ToString() ?? "0";
                if (!double.TryParse(cell, out v[i]))
                    throw new FormatException($"Невірне значення у b[{i + 1}]: «{cell}»");
            }
            return v;
        }

        private Label MakeLabel(string text, Point loc, Size size, bool bold = false)
        {
            return new Label
            {
                Text = text,
                Location = loc,
                Size = size,
                Font = bold ? new Font("Segoe UI", 9f, FontStyle.Bold) : new Font("Segoe UI", 9f),
                AutoSize = false
            };
        }

        private Button MakeButton(string text, Point loc, Size size, Color backColor)
        {
            return new Button
            {
                Text = text,
                Location = loc,
                Size = size,
                BackColor = backColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
        }
    }
}
