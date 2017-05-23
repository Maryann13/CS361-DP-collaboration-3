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

namespace WpfApplication1
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int number_system;

        private int number_system_1;

        private int number_system_2;

        public MainWindow()
        {
            InitializeComponent();
        }

        public string remove(string s, int number_system)
        {
            switch (number_system)
            {
                case 2:
                    s = new string((from c in s
                                    where c == '1' || c == '0'
                                    select c
                           ).ToArray());
                    break;
                case 10:
                    s = new string((from c in s
                                    where Char.IsDigit(c)
                                    select c
                           ).ToArray());
                    break;
                case 16:
                    s = new string((from c in s
                                    where Char.IsDigit(c) || c == 'a' || c == 'b' || c == 'c' || c == 'd' || c == 'e' || c == 'f'
                                    select c
                          ).ToArray());
                    break;

            }
            return s;
        }

        private void numbersystem_Selected(object sender, RoutedEventArgs e)
        {
            number_system = Int32.Parse((numbersystem.SelectedItem as TextBlock).Text);
            result.Text = "0";
            c_ce.IsEnabled = true;
            del_last.IsEnabled = true;
            plus.IsEnabled = true;
            minus.IsEnabled = true;
            calc_result.IsEnabled = true;
            result.IsEnabled = true;
        }

        private void c_ce_Click(object sender, RoutedEventArgs e)
        {
            result.Text = "0";
            resinten.Text = "0";
        }

        private void del_last_Click(object sender, RoutedEventArgs e)
        {
            if (result.Text.Length > 1) 
            {
                result.Text = result.Text.Remove(result.Text.Length - 1);
            }
            else
            {
                if (result.Text.Length == 1)
                {
                    result.Text = "";
                }
            }
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            result.Text = "";
            //todo
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            result.Text = "";
            //todo
        }

        private void calc_result_Click(object sender, RoutedEventArgs e)
        {

        }

        private void result_TextChanged(object sender, TextChangedEventArgs e)
        {
            result.Text = remove(result.Text, number_system);
            result.SelectionStart = result.Text.Length;
        }


        ///////////////////////////////////////////////////////////////////////////


        private void to_Click(object sender, RoutedEventArgs e)
        {
            textbox_b.Text = "";
            //todo
        }

        private void from_Click(object sender, RoutedEventArgs e)
        {
            textbox_a.Text = "";
            //todo
        }

        private void numbersystem_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            number_system_1 = Int32.Parse((numbersystem_1.SelectedItem as TextBlock).Text);
            textbox_a.IsEnabled = true;
        }

        private void numbersystem_2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            number_system_2 = Int32.Parse((numbersystem_2.SelectedItem as TextBlock).Text);
            textbox_b.IsEnabled = true;
        }

        private void textbox_b_TextChanged(object sender, TextChangedEventArgs e)
        {
            textbox_b.Text = remove(textbox_b.Text, number_system_2);
            if (textbox_b.Text.Length > 0)
                from.IsEnabled = true;
            else
                from.IsEnabled = false;
        }

        private void textbox_a_TextChanged(object sender, TextChangedEventArgs e)
        {
            textbox_a.Text = remove(textbox_a.Text, number_system_1);
            if (textbox_a.Text.Length > 0)
                to.IsEnabled = true;
            else
                to.IsEnabled = false;

        }
    }
}
