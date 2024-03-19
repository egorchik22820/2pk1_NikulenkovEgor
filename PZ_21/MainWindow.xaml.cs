using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PZ_21
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void number8_Click(object sender, RoutedEventArgs e)
        {
            inputText.Text = inputText.Text + "8";
        }

        private void number7_Click(object sender, RoutedEventArgs e)
        {
            inputText.Text = inputText.Text + "7";
        }

        private void number9_Click(object sender, RoutedEventArgs e)
        {
            inputText.Text = inputText.Text + "9";
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            inputText.Text = inputText.Text + "+";
        }

        private void number4_Click(object sender, RoutedEventArgs e)
        {
            inputText.Text = inputText.Text + "4";
        }

        private void number5_Click(object sender, RoutedEventArgs e)
        {
            inputText.Text = inputText.Text + "5";
        }

        private void number6_Click(object sender, RoutedEventArgs e)
        {
            inputText.Text = inputText.Text + "6";
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            inputText.Text = inputText.Text + "-";
        }

        private void number3_Click(object sender, RoutedEventArgs e)
        {
            inputText.Text = inputText.Text + "3";
        }

        private void number2_Click(object sender, RoutedEventArgs e)
        {
            inputText.Text = inputText.Text + "2";
        }

        private void number1_Click(object sender, RoutedEventArgs e)
        {
            inputText.Text = inputText.Text + "1";
        }

        private void multiplication_Click(object sender, RoutedEventArgs e)
        {
            inputText.Text = inputText.Text + "*";
        }

        private void number0_Click(object sender, RoutedEventArgs e)
        {
            inputText.Text = inputText.Text + "0";
        }

        private void division_Click(object sender, RoutedEventArgs e)
        {
            inputText.Text = inputText.Text + "/";
        }

        private void equally_Click(object sender, RoutedEventArgs e)
        {
            string expression = inputText.Text;
            inputText.Text = Calculation(expression).ToString();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (inputText.Text.Length != 0)
            {
                inputText.Text = inputText.Text.Remove(inputText.Text.Length - 1);
            }
            else
                inputText.Text = inputText.Text.Insert(inputText.Text.Length, "0");

        }

        public static double Calculation(string expression)
        {
            string pattern = @"(-?\d+(?:\.\d+)?)\s*([-+*/])\s*(-?\d+(?:\.\d+)?)";

            Match match = Regex.Match(expression, pattern);

            double operand1 = double.Parse(match.Groups[1].Value);
            double operand2 = double.Parse(match.Groups[3].Value);
            string operation = match.Groups[2].Value;

            switch (operation)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    return operand1 / operand2;
                default:
                    return 0;
            }
        }
    }
}
