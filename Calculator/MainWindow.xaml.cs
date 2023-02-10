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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();

            acButton.Click += acButton_Click;
            negativeButton.Click += negativeButton_Click;
            percentageButton.Click += percentageButton_Click;
            equalButton.Click += equalButton_Click;
            
        }


        private void equalButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch(selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        result = SimpleMath.Substraction(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();
            }

        }

        private void percentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;

            if ( double.TryParse(resultLabel.Content.ToString(), out tempNumber ) )
            {
                tempNumber = (tempNumber / 100);
                if (lastNumber != 0)
                    tempNumber *= lastNumber;

                resultLabel.Content = tempNumber.ToString();
            }
        }


        private void negativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void operationButton_Click(object sender, RoutedEventArgs e) 
        {

            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }
            if (sender == multiplicationButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divisionButton)
                selectedOperator = SelectedOperator.Division;
            if (sender == plusButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == minusButton)
                selectedOperator = SelectedOperator.Substraction;                        
        }

        private void acButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0;

        }


        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }

        }

        private void zeroButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "0";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}0";
            }
        }        
        
        private void pointButton_Click(object sender, RoutedEventArgs e)
        {
            if( resultLabel.Content.ToString().Contains(".") )
            { 
                // Do nothing
            } else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
            
        }

        
    }


    public enum SelectedOperator{
    
        Addition,
        Substraction,
        Multiplication,
        Division
    
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Substraction(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Divide(double n1, double n2)
        {
            if ( n2 == 0 )
            {
                MessageBox.Show("Division by 0 is no supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            return n1 / n2;
        }
    }
}
