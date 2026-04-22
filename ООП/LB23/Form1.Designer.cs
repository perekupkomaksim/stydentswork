namespace Lab23_Variant18
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // ── Controls ─────────────────────────────────────────────────────
        private Panel     pnlControls;
        private Panel     pnlDraw;
        private Label     lblTitle;
        private Label     lblFormula;
        private Label     lblR;
        private Label     lblr;
        private Label     lblH;
        private Label     lblTMax;
        private TextBox   txtR;
        private TextBox   txtr;
        private TextBox   txtH;
        private TextBox   txtTMax;
        private Button    btnDraw;
        private Button    btnReset;
        private Label     lblInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ── Outer layout ────────────────────────────────────────────
            pnlControls = new Panel();
            pnlDraw     = new Panel();

            // ── Labels ──────────────────────────────────────────────────
            lblTitle = new Label
            {
                Text      = "Лабораторна робота №23  —  Варіант 18  —  Епітрохоїда",
                Font      = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.FromArgb(25, 55, 120),
                AutoSize  = true,
                Location  = new Point(10, 8)
            };

            lblFormula = new Label
            {
                Text      = "x = (R+mR)·cos(mt) − h·cos(t+mt)   |   " +
                             "y = (R+mR)·sin(mt) − h·sin(t+mt)   |   m = r/R",
                Font      = new Font("Consolas", 8.5f),
                ForeColor = Color.FromArgb(70, 70, 70),
                AutoSize  = true,
                Location  = new Point(10, 34)
            };

            lblR    = MakeLabel("R — радіус нерухомого кола:", 10,  62);
            lblr    = MakeLabel("r — радіус рухомого кола:",  215, 62);
            lblH    = MakeLabel("h — відстань від центру:",   415, 62);
            lblTMax = MakeLabel("t max (множник π):",         615, 62);

            txtR    = MakeTextBox("100", 10,  80);
            txtr    = MakeTextBox("50",  215, 80);
            txtH    = MakeTextBox("75",  415, 80);
            txtTMax = MakeTextBox("6",   615, 80);

            // ── Buttons ─────────────────────────────────────────────────
            btnDraw = new Button
            {
                Text      = "▶  Побудувати",
                Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Size      = new Size(130, 32),
                Location  = new Point(720, 76),
                BackColor = Color.FromArgb(45, 95, 195),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand
            };
            btnDraw.FlatAppearance.BorderSize = 0;

            btnReset = new Button
            {
                Text      = "↺  Скинути",
                Font      = new Font("Segoe UI", 9f),
                Size      = new Size(110, 32),
                Location  = new Point(860, 76),
                BackColor = Color.FromArgb(155, 165, 185),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand
            };
            btnReset.FlatAppearance.BorderSize = 0;

            // ── Info label (bottom-right of draw panel) ──────────────────
            lblInfo = new Label
            {
                Text      = "",
                Font      = new Font("Consolas", 8.5f),
                ForeColor = Color.FromArgb(30, 50, 120),
                AutoSize  = false,
                TextAlign = ContentAlignment.TopLeft,
                BackColor = Color.FromArgb(220, 230, 245, 200),
                BorderStyle = BorderStyle.FixedSingle,
                Visible   = false
            };

            // ── Control panel ────────────────────────────────────────────
            pnlControls.Height    = 118;
            pnlControls.Dock      = DockStyle.Top;
            pnlControls.BackColor = Color.FromArgb(220, 228, 245);
            pnlControls.Padding   = new Padding(4);
            pnlControls.Controls.AddRange(new Control[]
            {
                lblTitle, lblFormula,
                lblR, txtR,
                lblr, txtr,
                lblH, txtH,
                lblTMax, txtTMax,
                btnDraw, btnReset
            });

            // ── Draw panel ───────────────────────────────────────────────
            pnlDraw.Dock      = DockStyle.Fill;
            pnlDraw.BackColor = Color.White;
            pnlDraw.Controls.Add(lblInfo);

            // ── Form ─────────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(1000, 680);
            MinimumSize         = new Size(800, 580);
            Text                = "Лаб. робота №23  ·  Варіант 18  ·  Епітрохоїда";
            StartPosition       = FormStartPosition.CenterScreen;
            BackColor           = Color.FromArgb(235, 240, 250);

            Controls.Add(pnlDraw);
            Controls.Add(pnlControls);
        }

        // ── Helpers for repetitive control creation ───────────────────────
        private static Label MakeLabel(string text, int x, int y) =>
            new Label
            {
                Text      = text,
                Font      = new Font("Segoe UI", 8f),
                ForeColor = Color.FromArgb(50, 50, 70),
                AutoSize  = true,
                Location  = new Point(x, y)
            };

        private static TextBox MakeTextBox(string value, int x, int y) =>
            new TextBox
            {
                Text     = value,
                Font     = new Font("Segoe UI", 10f),
                Size     = new Size(80, 24),
                Location = new Point(x, y + 16),
                BorderStyle = BorderStyle.FixedSingle
            };
    }
}
