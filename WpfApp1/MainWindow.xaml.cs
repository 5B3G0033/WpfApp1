using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        private void OnShowInfoClick(object sender, RoutedEventArgs e)
        {
            var name = NameTextBox.Text?.Trim();
            var age = AgeTextBox.Text?.Trim();

            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(age))
            {
                MessageBox.Show("請輸入姓名或年齡後再按此按鈕。", "輸入不足", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var info = new StringBuilder();
            info.AppendLine("使用者資訊：");
            info.AppendLine($"姓名：{(string.IsNullOrEmpty(name) ? "(未填)" : name)}");
            info.AppendLine($"年齡：{(string.IsNullOrEmpty(age) ? "(未填)" : age)}");

            MessageBox.Show(info.ToString(), "使用者資訊", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnGenerateTableClick(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(NumberInputTextBox.Text, out int n) || n <= 0)
            {
                MessageBox.Show("輸入0~9", "輸入0~9", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            const int maxN = 50;
            if (n > maxN)
            {
                MessageBox.Show($"N 過大，已自動限制為 {maxN}。", "限制", MessageBoxButton.OK, MessageBoxImage.Information);
                n = maxN;
            }

            var sb = new StringBuilder();

            // 標題列
            sb.Append("    ");
            for (int col = 1; col <= n; col++) sb.AppendFormat("{0,4}", col);
            sb.AppendLine();
            sb.AppendLine(new string('-', 4 * (n + 1)));

            for (int i = 1; i <= n; i++)
            {
                sb.AppendFormat("{0,3}|", i);
                for (int j = 1; j <= n; j++)
                {
                    sb.AppendFormat("{0,4}", i * j);
                }
                sb.AppendLine();
            }

            TableTextBlock.Text = sb.ToString();
        }
    }
}