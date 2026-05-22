using System;

namespace Lab16Task18
{
    public class Matrix
    {
        private double[,] _data;
        private int _rows;
        private int _cols;
        private static int _instanceCount = 0;

        // властивості
        public int Rows => _rows;
        public int Cols => _cols;
        public static int InstanceCount => _instanceCount;

        // індексатор для зручного доступу до елементів.
        public double this[int row, int col]
        {
            get
            {
                ValidateIndex(row, col);
                return _data[row, col];
            }
            set
            {
                ValidateIndex(row, col);
                _data[row, col] = value;
            }
        }

        // конструктори

        // конструктор 1 квадратна нульова матриця розміру n×n.
        public Matrix(int n)
        {
            if (n < 1) throw new ArgumentException("Розмір матриці має бути ≥ 1");
            _rows = n;
            _cols = n;
            _data = new double[n, n];
            _instanceCount++;
        }

        // конструктор 2 матриця довільного розміру rows×cols.
        public Matrix(int rows, int cols)
        {
            if (rows < 1 || cols < 1) throw new ArgumentException("Розміри мають бути ≥ 1");
            _rows = rows;
            _cols = cols;
            _data = new double[rows, cols];
            _instanceCount++;
        }

        // конструктор 3 (конструктор копіювання) створює матрицю з двовимірного масиву.
        public Matrix(double[,] data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            _rows = data.GetLength(0);
            _cols = data.GetLength(1);
            _data = (double[,])data.Clone();
            _instanceCount++;
        }

        // Конструктор копіювання об'єкта Matrix.
        public Matrix(Matrix other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            _rows = other._rows;
            _cols = other._cols;
            _data = (double[,])other._data.Clone();
            _instanceCount++;
        }

        // ── Операції над матрицями

        // Додавання двох матриць (перевантаження 1).
        public Matrix Add(Matrix other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (_rows != other._rows || _cols != other._cols)
                throw new InvalidOperationException(
                    $"Розміри матриць не збігаються: {_rows}×{_cols} та {other._rows}×{other._cols}");

            Matrix result = new Matrix(_rows, _cols);
            for (int i = 0; i < _rows; i++)
                for (int j = 0; j < _cols; j++)
                    result[i, j] = _data[i, j] + other[i, j];
            return result;
        }

        // Додавання скаляра до кожного елемента матриці (перевантаження 2).
        public Matrix Add(double scalar)
        {
            Matrix result = new Matrix(_rows, _cols);
            for (int i = 0; i < _rows; i++)
                for (int j = 0; j < _cols; j++)
                    result[i, j] = _data[i, j] + scalar;
            return result;
        }

        // Множення двох матриць (перевантаження 1).
        public Matrix Multiply(Matrix other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (_cols != other._rows)
                throw new InvalidOperationException(
                    $"Кількість стовпців ({_cols}) ≠ кількості рядків ({other._rows})");

            Matrix result = new Matrix(_rows, other._cols);
            for (int i = 0; i < _rows; i++)
                for (int j = 0; j < other._cols; j++)
                    for (int k = 0; k < _cols; k++)
                        result[i, j] += _data[i, k] * other[k, j];
            return result;
        }

        // Множення матриці на скаляр (перевантаження 2).
        public Matrix Multiply(double scalar)
        {
            Matrix result = new Matrix(_rows, _cols);
            for (int i = 0; i < _rows; i++)
                for (int j = 0; j < _cols; j++)
                    result[i, j] = _data[i, j] * scalar;
            return result;
        }

        // Транспонування матриці.
        public Matrix Transpose()
        {
            Matrix result = new Matrix(_cols, _rows);
            for (int i = 0; i < _rows; i++)
                for (int j = 0; j < _cols; j++)
                    result[j, i] = _data[i, j];
            return result;
        }

        // Обчислення визначника (рекурсивне розкладання Лапласа).
        public double Determinant()
        {
            if (_rows != _cols)
                throw new InvalidOperationException("Визначник визначений лише для квадратної матриці");
            return CalcDeterminant(_data, _rows);
        }

        // Метод Крамера
        // Розв'язання системи Ax = b методом Крамера.
        // Статичний метод — не потребує екземпляра.
        public static double[] SolveCramer(Matrix A, double[] b)
        {
            if (A == null) throw new ArgumentNullException(nameof(A));
            if (b == null) throw new ArgumentNullException(nameof(b));

            int n = A.Rows;
            if (A.Rows != A.Cols)
                throw new InvalidOperationException("Матриця коефіцієнтів має бути квадратною");
            if (b.Length != n)
                throw new InvalidOperationException("Довжина вектора b має дорівнювати порядку матриці");

            double detA = A.Determinant();
            if (Math.Abs(detA) < 1e-10)
                throw new InvalidOperationException(
                    $"Визначник матриці = {detA:F6} ≈ 0.\nСистема не має єдиного розв'язку.");

            double[] x = new double[n];
            for (int col = 0; col < n; col++)
            {
                // Замінюємо col-й стовпець на вектор b
                Matrix Ai = new Matrix(A);
                for (int row = 0; row < n; row++)
                    Ai[row, col] = b[row];

                x[col] = Ai.Determinant() / detA;
            }
            return x;
        }

        // Статичний метод скидання лічильника
        public static void ResetCounter() => _instanceCount = 0;

        // Допоміжні приватні методи

        private void ValidateIndex(int row, int col)
        {
            if (row < 0 || row >= _rows || col < 0 || col >= _cols)
                throw new IndexOutOfRangeException(
                    $"Індекс [{row},{col}] виходить за межі матриці {_rows}×{_cols}");
        }

        private static double CalcDeterminant(double[,] m, int n)
        {
            if (n == 1) return m[0, 0];
            if (n == 2) return m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];

            double det = 0;
            for (int col = 0; col < n; col++)
            {
                double[,] minor = GetMinor(m, 0, col, n);
                double sign = (col % 2 == 0) ? 1.0 : -1.0;
                det += sign * m[0, col] * CalcDeterminant(minor, n - 1);
            }
            return det;
        }

        private static double[,] GetMinor(double[,] m, int skipRow, int skipCol, int n)
        {
            double[,] minor = new double[n - 1, n - 1];
            int ri = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == skipRow) continue;
                int ci = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == skipCol) continue;
                    minor[ri, ci++] = m[i, j];
                }
                ri++;
            }
            return minor;
        }

        // Перетворення матриці в рядок для виведення.
        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < _rows; i++)
            {
                sb.Append("[ ");
                for (int j = 0; j < _cols; j++)
                    sb.Append($"{_data[i, j],9:F4}  ");
                sb.AppendLine("]");
            }
            return sb.ToString();
        }
    }
}
