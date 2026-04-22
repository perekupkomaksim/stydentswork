using System.Drawing.Drawing2D;

namespace Lab23_Variant18
{
    /// <summary>
    /// Лабораторна робота №23 — Варіант 18
    /// ─────────────────────────────────────
    /// Параметрична крива: Епітрохоїда
    ///
    ///   x = (R + m·R)·cos(m·t) − h·cos(t + m·t)
    ///   y = (R + m·R)·sin(m·t) − h·sin(t + m·t)
    ///   де  m = r / R
    ///
    /// Параметри:
    ///   R — радіус нерухомого кола
    ///   r — радіус рухомого кола  (0 < r ≤ R)
    ///   h — відстань від центру рухомого кола до точки
    /// </summary>
    public partial class Form1 : Form
    {
        // ── Current curve parameters ──────────────────────────────────────
        private double _R    = 100;
        private double _r    = 50;
        private double _h    = 75;
        private double _tMax = 6 * Math.PI;   // 6π = 3 повні оберти

        private const int STEPS     = 8000;   // кількість точок кривої
        private const int GRID_STEP = 50;     // пікселів між поділками осі

        // ════════════════════════════════════════════════════════════════
        public Form1()
        {
            InitializeComponent();

            // Прив'язка подій
            btnDraw.Click  += BtnDraw_Click;
            btnReset.Click += BtnReset_Click;
            pnlDraw.Paint  += PnlDraw_Paint;
            pnlDraw.Resize += (s, e) => pnlDraw.Invalidate();

            // Перший малюнок одразу при запуску
            TryReadParams();
        }

        // ════════════════════════════════════════════════════════════════
        //  ОБРОБНИКИ ПОДІЙ
        // ════════════════════════════════════════════════════════════════
        private void BtnDraw_Click(object sender, EventArgs e)
        {
            if (TryReadParams())
                pnlDraw.Invalidate();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtR.Text    = "100";
            txtr.Text    = "50";
            txtH.Text    = "75";
            txtTMax.Text = "6";

            foreach (var tb in new[] { txtR, txtr, txtH, txtTMax })
                tb.BackColor = SystemColors.Window;

            TryReadParams();
            pnlDraw.Invalidate();
        }

        // ════════════════════════════════════════════════════════════════
        //  ЧИТАННЯ ПАРАМЕТРІВ З ПОЛІВ ВВОДУ
        // ════════════════════════════════════════════════════════════════
        private bool TryReadParams()
        {
            bool ok = true;

            ok &= TryParseBox(txtR,    "R",            out _R,    1,    10000);
            ok &= TryParseBox(txtr,    "r",            out _r,    0.01, _R);
            ok &= TryParseBox(txtH,    "h",            out _h,    0,    10000);

            double tMaxFactor;
            ok &= TryParseBox(txtTMax, "t max (×π)", out tMaxFactor, 0.1, 1000);
            if (ok) _tMax = tMaxFactor * Math.PI;

            return ok;
        }

        /// <summary>
        /// Перевіряє TextBox на коректне число у заданому діапазоні.
        /// Підсвічує поле червоним при помилці.
        /// </summary>
        private static bool TryParseBox(
            TextBox tb, string name,
            out double val, double min, double max)
        {
            bool parsed = double.TryParse(
                tb.Text.Replace(',', '.'),
                System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture,
                out val);

            bool valid = parsed && val >= min && val <= max;
            tb.BackColor = valid ? SystemColors.Window : Color.MistyRose;

            if (!valid)
            {
                MessageBox.Show(
                    $"Невірне значення для «{name}».\n" +
                    $"Допустимий діапазон: [{min}; {max}]",
                    "Помилка вводу",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                val = 0;
            }
            return valid;
        }

        // ════════════════════════════════════════════════════════════════
        //  ПОДІЯ МАЛЮВАННЯ
        // ════════════════════════════════════════════════════════════════
        private void PnlDraw_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode      = SmoothingMode.AntiAlias;
            g.TextRenderingHint  =
                System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int W  = pnlDraw.Width;
            int H  = pnlDraw.Height;
            int cx = W / 2;   // пікселі центру = початок координат
            int cy = H / 2;

            double scale = ComputeScale(cx, cy);

            DrawGrid(g, cx, cy, W, H);
            DrawAxes(g, cx, cy, W, H, scale);
            DrawCurve(g, cx, cy, scale);
            DrawInfoPanel(g, W, H, scale);
        }

        // ════════════════════════════════════════════════════════════════
        //  ПАРАМЕТРИЧНА ФУНКЦІЯ
        // ════════════════════════════════════════════════════════════════

        /// <summary>Обчислює точку кривої для параметра t.</summary>
        private (double x, double y) Epitrochoid(double t)
        {
            double m = _r / _R;
            double x = (_R + m * _R) * Math.Cos(m * t) - _h * Math.Cos(t + m * t);
            double y = (_R + m * _R) * Math.Sin(m * t) - _h * Math.Sin(t + m * t);
            return (x, y);
        }

        // ════════════════════════════════════════════════════════════════
        //  АВТОМАСШТАБУВАННЯ
        // ════════════════════════════════════════════════════════════════

        /// <summary>
        /// Підбирає масштаб так, щоб крива вписалась у 82 % панелі.
        /// </summary>
        private double ComputeScale(int cx, int cy)
        {
            double maxAbs = 0;
            int    probe  = Math.Max(300, STEPS / 8);
            double dt     = _tMax / probe;

            for (int i = 0; i <= probe; i++)
            {
                var (x, y) = Epitrochoid(i * dt);
                if (Math.Abs(x) > maxAbs) maxAbs = Math.Abs(x);
                if (Math.Abs(y) > maxAbs) maxAbs = Math.Abs(y);
            }

            if (maxAbs < 1e-9) maxAbs = 1;
            return Math.Min(cx, cy) * 0.82 / maxAbs;
        }

        // ════════════════════════════════════════════════════════════════
        //  МАЛЮВАННЯ СІТКИ
        // ════════════════════════════════════════════════════════════════
        private static void DrawGrid(Graphics g, int cx, int cy, int W, int H)
        {
            using var pen = new Pen(Color.FromArgb(210, 220, 240), 1f);
            pen.DashStyle = DashStyle.Dot;

            for (int px = cx % GRID_STEP; px < W; px += GRID_STEP)
                g.DrawLine(pen, px, 0, px, H);

            for (int py = cy % GRID_STEP; py < H; py += GRID_STEP)
                g.DrawLine(pen, 0, py, W, py);
        }

        // ════════════════════════════════════════════════════════════════
        //  МАЛЮВАННЯ ОСЕЙ
        // ════════════════════════════════════════════════════════════════
        private static void DrawAxes(
            Graphics g, int cx, int cy, int W, int H, double scale)
        {
            using var axisPen = new Pen(Color.FromArgb(50, 50, 50), 1.8f);
            using var tickPen = new Pen(Color.FromArgb(80, 80, 80), 1f);
            using var font    = new Font("Segoe UI", 7.5f);
            const int ARROW   = 9;

            // ── Осі ─────────────────────────────────────────────────────
            g.DrawLine(axisPen, 0, cy, W, cy);                  // X
            g.DrawLine(axisPen, cx, H, cx, 0);                  // Y

            // ── Стрілки ─────────────────────────────────────────────────
            // X →
            g.DrawLine(axisPen, W - ARROW, cy - 4, W, cy);
            g.DrawLine(axisPen, W - ARROW, cy + 4, W, cy);
            // Y ↑
            g.DrawLine(axisPen, cx - 4, ARROW, cx, 0);
            g.DrawLine(axisPen, cx + 4, ARROW, cx, 0);

            // ── Підписи осей ─────────────────────────────────────────────
            using var boldFont = new Font("Segoe UI", 10f, FontStyle.Bold);
            g.DrawString("X", boldFont, Brushes.Black, W - 18, cy - 22);
            g.DrawString("Y", boldFont, Brushes.Black, cx + 6,  4);
            g.DrawString("0", font,     Brushes.DimGray, cx + 4, cy + 3);

            // ── Поділки по X ─────────────────────────────────────────────
            for (int px = cx + GRID_STEP; px < W - ARROW - 10; px += GRID_STEP)
            {
                g.DrawLine(tickPen, px, cy - 4, px, cy + 4);
                string lbl = FormatTickValue((px - cx) / scale);
                g.DrawString(lbl, font, Brushes.DimGray, px - 12, cy + 7);
            }
            for (int px = cx - GRID_STEP; px > 5; px -= GRID_STEP)
            {
                g.DrawLine(tickPen, px, cy - 4, px, cy + 4);
                string lbl = FormatTickValue(-(cx - px) / scale);
                g.DrawString(lbl, font, Brushes.DimGray, px - 16, cy + 7);
            }

            // ── Поділки по Y ─────────────────────────────────────────────
            for (int py = cy - GRID_STEP; py > ARROW + 10; py -= GRID_STEP)
            {
                g.DrawLine(tickPen, cx - 4, py, cx + 4, py);
                string lbl = FormatTickValue((cy - py) / scale);
                g.DrawString(lbl, font, Brushes.DimGray, cx + 6, py - 7);
            }
            for (int py = cy + GRID_STEP; py < H - 5; py += GRID_STEP)
            {
                g.DrawLine(tickPen, cx - 4, py, cx + 4, py);
                string lbl = FormatTickValue(-(py - cy) / scale);
                g.DrawString(lbl, font, Brushes.DimGray, cx + 6, py - 7);
            }
        }

        /// <summary>Форматує числове значення поділки осі.</summary>
        private static string FormatTickValue(double v)
        {
            if (Math.Abs(v) >= 1000) return ((int)Math.Round(v)).ToString();
            if (Math.Abs(v) >= 10)   return v.ToString("F0");
            return v.ToString("F1");
        }

        // ════════════════════════════════════════════════════════════════
        //  МАЛЮВАННЯ КРИВОЇ
        // ════════════════════════════════════════════════════════════════
        private void DrawCurve(Graphics g, int cx, int cy, double scale)
        {
            double dt = _tMax / STEPS;

            // Перетворення координати у піксель
            float ToPixX(double x) => (float)(cx + x * scale);
            float ToPixY(double y) => (float)(cy - y * scale);   // екранна вісь Y йде вниз

            // Градієнтне забарвлення: синій → фіолетовий
            for (int i = 0; i < STEPS; i++)
            {
                double t0 = i * dt;
                double t1 = (i + 1) * dt;

                var (x0, y0) = Epitrochoid(t0);
                var (x1, y1) = Epitrochoid(t1);

                float frac = (float)i / STEPS;
                Color col = Color.FromArgb(
                    (int)(30  + frac * 180),   // R
                    (int)(80  - frac * 50),    // G
                    (int)(220 - frac * 90)     // B
                );

                using var pen = new Pen(col, 2f);
                g.DrawLine(pen,
                    ToPixX(x0), ToPixY(y0),
                    ToPixX(x1), ToPixY(y1));
            }

            // Маркер початкової точки (t = 0)
            var (sx, sy) = Epitrochoid(0);
            using var markerBrush = new SolidBrush(Color.OrangeRed);
            g.FillEllipse(markerBrush,
                ToPixX(sx) - 5, ToPixY(sy) - 5, 10, 10);
            g.DrawString("t=0",
                new Font("Segoe UI", 7.5f), Brushes.OrangeRed,
                ToPixX(sx) + 7, ToPixY(sy) - 7);
        }

        // ════════════════════════════════════════════════════════════════
        //  ІНФОРМАЦІЙНА ПАНЕЛЬ (нижній правий кут)
        // ════════════════════════════════════════════════════════════════
        private void DrawInfoPanel(Graphics g, int W, int H, double scale)
        {
            double m = _r / _R;
            string[] lines =
            {
                $"R = {_R}   r = {_r}   h = {_h}",
                $"m = r/R = {m:F4}",
                $"t ∈ [0 ; {_tMax / Math.PI:F1}π]",
                $"Масштаб ≈ {scale:F3} px / од."
            };

            using var font = new Font("Consolas", 8.5f);
            float lineH = font.GetHeight(g);
            float boxH  = lines.Length * lineH + 10;
            float boxW  = 230;
            float bx    = W - boxW - 10;
            float by    = H - boxH - 10;

            // фон
            using var bgBrush = new SolidBrush(Color.FromArgb(210, 232, 240, 255));
            g.FillRectangle(bgBrush, bx, by, boxW, boxH);
            g.DrawRectangle(new Pen(Color.SteelBlue, 1f), bx, by, boxW, boxH);

            using var textBrush = new SolidBrush(Color.FromArgb(20, 40, 110));
            for (int i = 0; i < lines.Length; i++)
                g.DrawString(lines[i], font, textBrush, bx + 6, by + 4 + i * lineH);
        }
    }
}
