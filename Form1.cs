namespace oop_lb32123723
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(textBox1.Text);
                double numerator = Math.Log(Math.Abs(Math.Cos(x)));
                double denominator = Math.Log(1 + Math.Pow(x, 2));

                if (denominator == 0)
                {
                    labelResult.Text = "Помилка: ділення на нуль!";
                }
                else
                {
                    double result = numerator / denominator;
                    labelResult.Text = "Результат: " + result.ToString("F4");
                }
            }
            catch
            {
                MessageBox.Show("Будь ласка, введіть коректне значення x.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBox1.Text);
                double b = Convert.ToDouble(textBox2.Text);
                double gammaDegrees = Convert.ToDouble(textBoxGamma.Text);

                double gammaRadians = gammaDegrees * Math.PI / 180.0;

                double S = 0.5 * a * b * Math.Sin(gammaRadians);

                labelResult.Text = "Площа трикутника: " + S.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Перевірте введені дані.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBox1.Text);
                double b = Convert.ToDouble(textBox2.Text);
                double c = Convert.ToDouble(textBox3.Text);
                double d = Convert.ToDouble(textBox4.Text);

                bool isSimilar = (a / c == b / d) || (a / d == b / c);

                labelResult.Text = "Результат: " + isSimilar.ToString(); 
            }
            catch
            {
                MessageBox.Show("Помилка вводу даних.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                double n1 = Convert.ToDouble(textBox1.Text);
                double n2 = Convert.ToDouble(textBox2.Text);
                double n3 = Convert.ToDouble(textBox3.Text);

                bool conditionMet = (n1 + n2 > 0) || (n1 + n3 > 0) || (n2 + n3 > 0);

                if (conditionMet)
                    labelResult.Text = "Так, сума якихось двох чисел є позитивною.";
                else
                    labelResult.Text = "Ні, позитивної суми не знайдено.";
            }
            catch
            {
                MessageBox.Show("Введіть три числа.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string result = "Нічого не знайдено";

            for (int age = 100; age <= 150; age++)
            {
                int sumOfSquares = 0;
                int tempAge = age;

                while (tempAge > 0)
                {
                    int digit = tempAge % 10;
                    sumOfSquares += digit * digit;
                    tempAge /= 10;
                }

                int dayOfBirth = age - sumOfSquares;

                if (dayOfBirth >= 1 && dayOfBirth <= 31)
                {
                    result = $"Довгожителю {age} років! (Народився {dayOfBirth}-го числа)";
                    break; 
                }
            }

            labelResult.Text = result;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strA = textBox1.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] strB = textBox2.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (strA.Length != strB.Length)
                {
                    MessageBox.Show("Помилка: послідовності повинні мати однакову кількість елементів!");
                    return;
                }

                int n = strA.Length;
                int[] a = new int[n];
                int[] b = new int[n];

                for (int i = 0; i < n; i++)
                {
                    a[i] = Convert.ToInt32(strA[i]);
                    b[i] = Convert.ToInt32(strB[i]);
                }

                for (int i = 0; i < n; i++)
                {
                    if (a[i] <= 0)
                        b[i] = b[i] * 10;
                    else
                        b[i] = 0;
                }

                labelResult.Text = "Нова послідовність B: " + string.Join(" ", b);
            }
            catch
            {
                MessageBox.Show("Введіть цілі числа через пробіл.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string input = textBoxString.Text;
            string target = "abc";

            int count = (input.Length - input.Replace(target, "").Length) / target.Length;

            labelResult.Text = $"Група букв 'abc' зустрічається {count} раз(ів).";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9')) return;
            if (e.KeyChar == '.') e.KeyChar = ',';
            if (e.KeyChar == '-' && ((TextBox)sender).Text.IndexOf('-') == -1 && ((TextBox)sender).SelectionStart == 0) return;
            if (e.KeyChar == ',')
            {
                if (((TextBox)sender).Text.IndexOf(',') != -1) e.Handled = true;
                return;
            }
            if (Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
        }
    }
}
