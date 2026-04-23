using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace win3tread
{
    public partial class Form1 : Form
    {
        Thread thread1;
        Thread thread2;
        Thread thread3;

        public Form1()
        {
            InitializeComponent();
            // ініціалізація потоків
            thread1 = new Thread(new ThreadStart(SAFER_encrypt));
            thread2 = new Thread(new ThreadStart(MD2_hash));
            thread3 = new Thread(new ThreadStart(GeneratorPlesa));
        }

        // =================== МЕТОД 1: SAFER ===================
        // Блоковий алгоритм шифрування SAFER
        // таблиця exp для SAFER (45^x mod 257)
        byte[] expTable = new byte[256];
        byte[] logTable = new byte[256];

        // заповнюємо таблиці
        private void BuildSAFERTables()
        {
            int val = 1;
            for (int i = 0; i < 256; i++)
            {
                expTable[i] = (byte)(val & 0xFF);
                logTable[expTable[i]] = (byte)i;
                val = (val * 45) % 257;
            }
        }

        private void SAFER_encrypt()
        {
            try
            {
                BuildSAFERTables();
                Random rnd = new Random();

                while (true)
                {
                    Thread.Sleep(300);

                    // генеруємо випадкові дані і ключ
                    byte[] plaintext = new byte[8];
                    byte[] key = new byte[8];

                    for (int i = 0; i < 8; i++)
                    {
                        plaintext[i] = (byte)rnd.Next(0, 256);
                        key[i] = (byte)rnd.Next(0, 256);
                    }

                    // виконуємо один раунд шифрування SAFER
                    byte[] ciphertext = new byte[8];

                    // фаза XOR і додавання з ключем
                    for (int i = 0; i < 8; i += 2)
                    {
                        // парні - XOR з ключем
                        ciphertext[i] = (byte)(plaintext[i] ^ key[i]);
                        // непарні - додавання з ключем mod 256
                        ciphertext[i + 1] = (byte)((plaintext[i + 1] + key[i + 1]) % 256);
                    }

                    // фаза нелінійного перетворення (exp/log)
                    for (int i = 0; i < 8; i += 2)
                    {
                        if (ciphertext[i] == 0)
                            ciphertext[i] = 1;
                        ciphertext[i] = expTable[ciphertext[i]];

                        ciphertext[i + 1] = logTable[ciphertext[i + 1] == 0 ? 1 : ciphertext[i + 1]];
                    }

                    // формуємо рядок для виводу
                    string inputStr = "Вхід:  ";
                    string keyStr   = "Ключ:  ";
                    string outStr   = "Вихід: ";

                    for (int i = 0; i < 8; i++)
                    {
                        inputStr += plaintext[i].ToString("X2") + " ";
                        keyStr   += key[i].ToString("X2") + " ";
                        outStr   += ciphertext[i].ToString("X2") + " ";
                    }

                    string result = "--- SAFER ---\n" + inputStr + "\n" + keyStr + "\n" + outStr + "\n";

                    // оновлюємо UI з іншого потоку
                    richTextBox1.Invoke((MethodInvoker)delegate ()
                    {
                        richTextBox1.Text += result;
                        // щоб скролилось вниз
                        richTextBox1.SelectionStart = richTextBox1.Text.Length;
                        richTextBox1.ScrollToCaret();
                    });
                }
            }
            catch (Exception ex) { }
        }

        // =================== МЕТОД 2: MD-2 ===================
        // Алгоритм хешування MD-2

        // S-Box таблиця для MD-2 (Pi таблиця)
        int[] S = new int[]
        {
            41,  46,  67, 201, 162, 216, 124,   1,  61,  54,  84, 161, 236, 240,   6,
            19,  98, 167,   5, 243, 192, 199, 115, 140, 152, 147,  43, 217, 188,  76,
           130, 202,  30, 155,  87,  60, 253, 212, 224,  22, 103,  66, 111,  24, 138,
            23, 229,  18, 190,  78, 196, 214, 218, 158, 222,  73, 160, 251, 245, 142,
           187,  47, 238, 122, 169, 104, 121, 145,  21, 178,   7,  63, 148, 194,  16,
           137,  11,  34,  95,  33, 128, 127,  93, 154,  90, 144,  50,  39,  53,  62,
           204, 231, 191, 247, 151,   3, 255,  25,  48, 179,  72, 165, 181, 209, 215,
            94, 146,  42, 172,  86, 170, 198,  79, 184,  56, 210, 150, 164, 125, 182,
           118, 252, 107, 226, 156, 116,   4, 241,  69, 157, 112,  89, 100, 113, 135,
            32, 134,  91, 207, 101, 230,  45, 168,   2,  27,  96,  37, 173, 174, 176,
           185, 246,  28,  70,  97, 105,  52,  64, 126,  15,  85,  71, 163,  35, 221,
            81, 175,  58, 195,  92, 249, 206, 186, 197, 234,  38,  44,  83,  13, 110,
           133,  40, 132,   9, 211, 223, 205, 244,  65, 129,  77,  82, 106, 220,  55,
           200, 108, 193, 171, 250,  36, 225, 123,   8,  12, 189, 177,  74, 120, 136,
           149, 139, 227,  99, 232, 109, 233, 203, 213, 254,  59,   0,  29,  57, 242,
           239, 183,  14, 102,  88, 208, 228, 166, 119, 114, 248, 235, 117,  75,  10,
            49,  68,  80, 180, 143, 237,  31,  26, 219, 153, 141,  51, 159,  17, 131,
            20
        };

        // власне обчислення MD-2
        private byte[] ComputeMD2(byte[] msg)
        {
            // крок 1: доповнення до кратного 16
            int padLen = 16 - (msg.Length % 16);
            byte[] padded = new byte[msg.Length + padLen];
            Array.Copy(msg, padded, msg.Length);
            for (int i = msg.Length; i < padded.Length; i++)
                padded[i] = (byte)padLen;

            // крок 2: обчислення контрольної суми
            byte[] checksum = new byte[16];
            byte L = 0;
            for (int i = 0; i < padded.Length / 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    byte c = padded[i * 16 + j];
                    checksum[j] ^= (byte)S[c ^ L];
                    L = checksum[j];
                }
            }

            // додаємо контрольну суму в кінець
            byte[] withCS = new byte[padded.Length + 16];
            Array.Copy(padded, withCS, padded.Length);
            Array.Copy(checksum, 0, withCS, padded.Length, 16);

            // крок 3: ініціалізація буфера X
            byte[] X = new byte[48];

            // крок 4: обробка блоків по 16 байт
            for (int i = 0; i < withCS.Length / 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    X[16 + j] = withCS[i * 16 + j];
                    X[32 + j] = (byte)(withCS[i * 16 + j] ^ X[j]);
                }

                byte t = 0;
                for (int j = 0; j < 18; j++)
                {
                    for (int k = 0; k < 48; k++)
                    {
                        t = (byte)(X[k] ^ S[t]);
                        X[k] = t;
                    }
                    t = (byte)((t + j) % 256);
                }
            }

            // перші 16 байт X і є хешем
            byte[] hash = new byte[16];
            Array.Copy(X, hash, 16);
            return hash;
        }

        private void MD2_hash()
        {
            try
            {
                Random rnd = new Random();

                while (true)
                {
                    Thread.Sleep(400);

                    // генеруємо випадкові дані для хешування
                    int len = rnd.Next(8, 32);
                    byte[] data = new byte[len];
                    rnd.NextBytes(data);

                    // рахуємо MD-2 хеш
                    byte[] hash = ComputeMD2(data);

                    string dataStr = "Дані: ";
                    for (int i = 0; i < data.Length; i++)
                        dataStr += data[i].ToString("X2") + " ";

                    string hashStr = "MD-2: ";
                    for (int i = 0; i < hash.Length; i++)
                        hashStr += hash[i].ToString("X2");

                    string result = "--- MD-2 ---\n" + dataStr + "\n" + hashStr + "\n";

                    richTextBox2.Invoke((MethodInvoker)delegate ()
                    {
                        richTextBox2.Text += result;
                        richTextBox2.SelectionStart = richTextBox2.Text.Length;
                        richTextBox2.ScrollToCaret();
                    });
                }
            }
            catch (Exception ex) { }
        }

        // =================== МЕТОД 3: ГЕНЕРАТОР ПЛЕСА ===================
        // Blum Blum Shub генератор псевдовипадкових чисел
        // x(n+1) = x(n)^2 mod n, де n = p*q, p і q прості і ≡ 3 (mod 4)

        private void GeneratorPlesa()
        {
            try
            {
                // параметри BBS
                // p і q - прості числа де p mod 4 == 3 і q mod 4 == 3
                long p = 499;   // 499 mod 4 = 3 - ок
                long q = 547;   // 547 mod 4 = 3 - ок
                long n = p * q; // n = 273053

                // початкове зерно (seed) - НСД(seed, n) повинен = 1
                long seed = 17;
                long x = (seed * seed) % n;

                while (true)
                {
                    Thread.Sleep(500);

                    // генеруємо 16 бітів
                    string bits = "";
                    long xCurr = x;

                    for (int i = 0; i < 16; i++)
                    {
                        xCurr = (xCurr * xCurr) % n;
                        // беремо молодший біт
                        bits += (xCurr % 2).ToString();
                    }
                    x = xCurr;

                    // переводимо у число
                    int generatedNum = Convert.ToInt32(bits, 2);

                    string result = "--- Генератор Плеса ---\n";
                    result += "Біти:  " + bits + "\n";
                    result += "Число: " + generatedNum + "\n";

                    richTextBox3.Invoke((MethodInvoker)delegate ()
                    {
                        richTextBox3.Text += result;
                        richTextBox3.SelectionStart = richTextBox3.Text.Length;
                        richTextBox3.ScrollToCaret();
                    });
                }
            }
            catch (Exception ex) { }
        }

        // ============= КНОПКИ =============

        // Запустити 1 потік (SAFER)
        private void button1_Click(object sender, EventArgs e)
        {
            thread1.Start();
        }

        // Зупинити 1 потік (SAFER)
        private void button5_Click(object sender, EventArgs e)
        {
            thread1.Suspend();
        }

        // Запустити 2 потік (MD-2)
        private void button2_Click(object sender, EventArgs e)
        {
            thread2.Start();
        }

        // Зупинити 2 потік (MD-2)
        private void button6_Click(object sender, EventArgs e)
        {
            thread2.Suspend();
        }

        // Запустити 3 потік (BBS)
        private void button3_Click(object sender, EventArgs e)
        {
            thread3.Start();
        }

        // Зупинити 3 потік (BBS)
        private void button7_Click(object sender, EventArgs e)
        {
            thread3.Suspend();
        }

        // Запустити всі потоки
        private void button4_Click(object sender, EventArgs e)
        {
            thread1.Start();
            thread2.Start();
            thread3.Start();
        }

        // Зупинити всі потоки
        private void button8_Click(object sender, EventArgs e)
        {
            thread1.Suspend();
            thread2.Suspend();
            thread3.Suspend();
        }

        // при закритті форми вбиваємо потоки
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread1.Abort();
            thread2.Abort();
            thread3.Abort();
        }
    }
}
