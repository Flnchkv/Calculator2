using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calculator
{
    public partial class MainWindow : Window
    {
        public double Accumulator = 0;
        public string Operand = "";
        public string NumberText;
        public string str = "0";
        public double M = 0;
        public double k = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void MC_Click(object sender, RoutedEventArgs e)
        {
            M = 0;
        }

        private void MS_Click(object sender, RoutedEventArgs e)
        {
            if (TEXT.Text != "Это не число" && TEXT.Text != "∞")
            {
                NumberText = TEXT.Text;
                M = double.Parse(NumberText);
            }
        }

        private void MR_Click(object sender, RoutedEventArgs e)
        {
            TEXT.Text = M.ToString();
            str = M.ToString();
            TEXT2.Content = str;
        }

        private void MP_Click(object sender, RoutedEventArgs e)
        {
            if (TEXT.Text != "Это не число" && TEXT.Text != "∞")
            {
                NumberText = TEXT.Text;
                M += double.Parse(NumberText);
            }
        }

        private void MM_Click(object sender, RoutedEventArgs e)
        {
            if (TEXT.Text != "Это не число" && TEXT.Text != "∞")
            {
                NumberText = TEXT.Text;
                M -= double.Parse(NumberText);
            }
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            TEXT.Text = "0";
            Operand = "";
            Accumulator = 0;
            str = "";
            TEXT2.Content = str;
        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            NumberText = TEXT.Text;
            int lenght = NumberText.Length;
            if (lenght <= 1 && TEXT.Text != "0")
            {
                TEXT.Text = "0";
                lenght = str.Length;
                NumberText = str;
                str = "";
                for (int i = 0; i < lenght - 1; i++)
                {
                    str += NumberText[i];
                }
                TEXT2.Content = str;
            }
            else if (TEXT.Text == "Это не число" || TEXT.Text == "∞" || TEXT.Text.Contains('E'))
            {
                TEXT.Text = "0";
                str = "";
                TEXT2.Content = str;
            }
            else if (TEXT.Text == "0")
            {

            }
            else
            {
                TEXT.Text = "";
                for (int i = 0; i < lenght - 1; i++)
                {
                    TEXT.Text = TEXT.Text + NumberText[i];
                }
                lenght = str.Length;
                NumberText = str;
                str = "";
                for (int i = 0; i < lenght - 1; i++)
                {
                    str += NumberText[i];
                }
                TEXT2.Content = str;
            }
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            NumberText = TEXT.Text;
            int lenght = str.Length - NumberText.Length;
            TEXT.Text = "";
            NumberText = str;
            str = "";
            for (int i = 0; i < lenght; i++)
            {
                str += NumberText[i];
            }
            TEXT2.Content = str;
        }

        private void NUMBER_Click(object sender, EventArgs e)
        {
            if (TEXT.Text == "0")
            {
                TEXT.Text = (string)(sender as Button).Content;
                str = (string)(sender as Button).Content;
                TEXT2.Content = str;
            }
            else if (TEXT.Text == "Это не число" || TEXT.Text == "∞")
            {
                TEXT.Text = (string)(sender as Button).Content;
                str = (string)(sender as Button).Content;
                TEXT2.Content = str;
            }
            else
            {
                TEXT.Text = TEXT.Text + (sender as Button).Content;
                str += (sender as Button).Content;
                TEXT2.Content = str;
            }
        }

        private void P_Click(object sender, EventArgs e)
        {
            if (TEXT.Text == "Это не число" || TEXT.Text.Contains(',') || TEXT.Text ==  "∞")
            {
                
            }
            else
            {
                TEXT.Text = TEXT.Text + ",";
                str += ",";
                TEXT2.Content = str;
            }
        }

        private void OPERATOR_Click(object sender, EventArgs e)
        {
            NumberText = TEXT.Text;
            if (NumberText != "Это не число" && NumberText != "∞" && NumberText != "")
            {
                if (Operand == "")
                {
                    Accumulator = double.Parse(NumberText);
                }
                else if (Operand == "+")
                {
                    Accumulator += double.Parse(NumberText);
                }
                else if (Operand == "-")
                {
                    Accumulator -= double.Parse(NumberText);
                }
                else if (Operand == "/")
                {
                    Accumulator /= double.Parse(NumberText);
                }
                else if (Operand == "*")
                {
                    Accumulator *= double.Parse(NumberText);
                }
                Operand = (string)(sender as Button).Content;
                TEXT.Text = "";
                str = Accumulator.ToString() + (sender as Button).Content;
                TEXT2.Content = str;
            }
            else if (NumberText == "")
            {
                Operand = (string)(sender as Button).Content;
                TEXT.Text = "";
                str = Accumulator.ToString() + (sender as Button).Content;
                TEXT2.Content = str;
            }
            else
            {
                Accumulator = 0;
                str = Accumulator.ToString();
                TEXT2.Content = str;
                TEXT.Text = Accumulator.ToString();
            }
        }

        private void OPERATIONS_Click(object sender, EventArgs e)
        {
            NumberText = TEXT.Text;
            if (NumberText != "Это не число" && NumberText != "∞" && NumberText != "")
            {
                if (Operand == "")
                {
                    Accumulator = -(double.Parse(TEXT.Text));
                }
                else if (Operand == "+")
                {
                    Accumulator += -(double.Parse(TEXT.Text));
                }
                else if (Operand == "-")
                {
                    Accumulator -= -(double.Parse(TEXT.Text));
                }
                else if (Operand == "/")
                {
                    Accumulator /= -(double.Parse(TEXT.Text));
                }
                else if (Operand == "*")
                {
                    Accumulator *= -(double.Parse(TEXT.Text));
                }
                Operand = "";
                TEXT.Text = Accumulator.ToString();
                str = Accumulator.ToString();
                TEXT2.Content = str;
            }
            else if (NumberText == "")
            {
                Operand = "";
                TEXT.Text = Accumulator.ToString();
                str = Accumulator.ToString();
                TEXT2.Content = str;
            }
            else
            {
                Accumulator = 0;
                str = Accumulator.ToString();
                TEXT2.Content = str;
                TEXT.Text = Accumulator.ToString();
            }
        }

        private void ROOT_Click(object sender, EventArgs e)
        {
            NumberText = TEXT.Text;
            if (NumberText != "Это не число" && NumberText != "∞" && NumberText != "")
            {
                if (Operand == "")
                {
                    Accumulator = Math.Pow(double.Parse(TEXT.Text), 0.5);
                }
                else if (Operand == "+")
                {
                    Accumulator += Math.Pow(double.Parse(TEXT.Text), 0.5);
                }
                else if (Operand == "-")
                {
                    Accumulator -= Math.Pow(double.Parse(TEXT.Text), 0.5);
                }
                else if (Operand == "/")
                {
                    Accumulator /= Math.Pow(double.Parse(TEXT.Text), 0.5);
                }
                else if (Operand == "*")
                {
                    Accumulator *= Math.Pow(double.Parse(TEXT.Text), 0.5);
                }
                Operand = "";
                TEXT.Text = Accumulator.ToString();
                str = Accumulator.ToString();
                TEXT2.Content = str;
            }
            else if (NumberText == "")
            {
                Operand = "";
                TEXT.Text = Accumulator.ToString();
                str = Accumulator.ToString();
                TEXT2.Content = str;
            }
            else
            {
                Accumulator = 0;
                str = Accumulator.ToString();
                TEXT2.Content = str;
                TEXT.Text = Accumulator.ToString();
            }
        }

        private void X_Click(object sender, EventArgs e)
        {
            NumberText = TEXT.Text;
            if (NumberText != "Это не число" && NumberText != "∞" && NumberText != "")
            {
                if (Operand == "")
                {
                    Accumulator = 1 / double.Parse(TEXT.Text);
                }
                else if (Operand == "+")
                {
                    Accumulator += 1 / double.Parse(TEXT.Text);
                }
                else if (Operand == "-")
                {
                    Accumulator -= 1 / double.Parse(TEXT.Text);
                }
                else if (Operand == "/")
                {
                    Accumulator /= 1 / double.Parse(TEXT.Text);
                }
                else if (Operand == "*")
                {
                    Accumulator *= 1 / double.Parse(TEXT.Text);
                }
                Operand = "";
                TEXT.Text = Accumulator.ToString();
                str = Accumulator.ToString();
                TEXT2.Content = str;
            }
            else if (NumberText == "")
            {
                Operand = "";
                TEXT.Text = Accumulator.ToString();
                str = Accumulator.ToString();
                TEXT2.Content = str;
            }
            else
            {
                Accumulator = 0;
                str = Accumulator.ToString();
                TEXT2.Content = str;
                TEXT.Text = Accumulator.ToString();
            }
        }

        private void RAVNO_Click(object sender, RoutedEventArgs e)
        {
            NumberText = TEXT.Text;
            if (NumberText == "")
            {
                k = Accumulator;
            }
            else
            {
                k = double.Parse(NumberText);
            }
            if (Operand == "*")
            {
                Accumulator *= k;
            }
            else if (Operand == "/")
            {
                Accumulator /= k;
            }
            else if (Operand == "-")
            {
                Accumulator -= k;
            }
            else if (Operand == "+")
            {
                Accumulator += k;
            }
            else
            {
                Accumulator = k;
            }
            Operand = "";
            TEXT.Text = Accumulator.ToString();
            str = Accumulator.ToString();
            TEXT2.Content = str;
        }

        private void PROCENT_Click(object sender, RoutedEventArgs e)
        {
            NumberText = TEXT.Text;
            if (NumberText == "")
            {
                Operand = "";
                TEXT.Text = Accumulator.ToString();
                str = Accumulator.ToString();
                TEXT2.Content = str;
            }
            else
            {
                if (Operand == "")
                {
                    Accumulator = 0;
                }
                else if (Operand == "+")
                {
                    Accumulator += Accumulator * (double.Parse(NumberText) / 100);
                }
                else if (Operand == "-")
                {
                    Accumulator -= Accumulator * (double.Parse(NumberText) / 100);
                }
                else if (Operand == "/")
                {
                    Accumulator = Accumulator / (double.Parse(NumberText) / 100);
                }
                else
                {
                    Accumulator = Accumulator * (double.Parse(NumberText) / 100);
                }
                Operand = "";
                TEXT.Text = Accumulator.ToString();
                str = Accumulator.ToString();
                TEXT2.Content = str;
            }
        }

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                C_Click(sender, e);
            }
            else if (e.Key == Key.Back)
            {
                DEL_Click(sender, e);
            }
            else if (e.Key == Key.Delete)
            {
                CE_Click(sender, e);
            }
            else if (e.Key == Key.Enter)
            {
                RAVNO_Click(sender, e);
            }
        }

        private void Window_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int value))
            {
                if (TEXT.Text == "0")
                {
                    TEXT.Text = e.Text;
                    str = e.Text;
                    TEXT2.Content = str;
                }
                else if (TEXT.Text == "Это не число" || TEXT.Text == "∞")
                {
                    TEXT.Text = e.Text;
                    str = e.Text;
                    TEXT2.Content = str;
                }
                else
                {
                    TEXT.Text = TEXT.Text + e.Text;
                    str += e.Text;
                    TEXT2.Content = str;
                }
            }
            else if (e.Text == ",")
            {
                P_Click(sender, e);
            }
            else if (e.Text == "+" || e.Text == "-" || e.Text == "*" || e.Text == "/")
            {
                NumberText = TEXT.Text;
                if (NumberText != "Это не число" && NumberText != "∞")
                {
                    if (Operand == "")
                    {
                        Accumulator = double.Parse(NumberText);
                    }
                    else if (Operand == "+")
                    {
                        Accumulator += double.Parse(NumberText);
                    }
                    else if (Operand == "-")
                    {
                        Accumulator -= double.Parse(NumberText);
                    }
                    else if (Operand == "/")
                    {
                        Accumulator /= double.Parse(NumberText);
                    }
                    else if (Operand == "*")
                    {
                        Accumulator *= double.Parse(NumberText);
                    }
                    Operand = e.Text;
                    TEXT.Text = "";
                    str = Accumulator.ToString() + e.Text;
                    TEXT2.Content = str;
                }
                else
                {
                    Accumulator = 0;
                    str = Accumulator.ToString();
                    TEXT2.Content = str;
                    TEXT.Text = Accumulator.ToString();
                }
            }
            else if (e.Text == "Q")
            {
                ROOT_Click(sender, e);
            }
            else if (e.Text == "@")
            {
                X_Click(sender, e);
            }
            else if (e.Text == "Z")
            {
                OPERATIONS_Click(sender, e);
            }
            else if (e.Text == "=")
            {
                RAVNO_Click(sender, e);
            }
            else if (e.Text == "%")
            {
                PROCENT_Click(sender, e);
            }
            else if (e.Text == "A")
            {
                MC_Click(sender, e);
            }
            else if (e.Text == "S")
            {
                MR_Click(sender, e);
            }
            else if (e.Text == "D")
            {
                MS_Click(sender, e);
            }
            else if (e.Text == "F")
            {
                MP_Click(sender, e);
            }
            else if (e.Text == "G")
            {
                MM_Click(sender, e);
            }
        }
    }
}
