using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AndruhaBot.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public TableName currentTable;
        public AdminWindow()
        {
            InitializeComponent();
            SelectTable.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTable = (TableName)SelectTable.SelectedIndex;
            switch (currentTable)
            {
                case TableName.Education:
                    MainFrame.Navigate(new Views.korotkie(TableName.Education));
                    break;
                case TableName.Grafik:
                    MainFrame.Navigate(new Views.korotkie(TableName.Grafik));
                    break;
                case TableName.Pol:
                    MainFrame.Navigate(new Views.korotkie(TableName.Pol));
                    break;
                case TableName.Zanaytost:
                    MainFrame.Navigate(new Views.korotkie(TableName.Zanaytost));
                    break;
                case TableName.Role:
                    MainFrame.Navigate(new Views.korotkie());
                    break;
                case TableName.User:
                    break;
                case TableName.Rezume:
                    break;
                case TableName.UserRezume:
                    break;
                default:
                    break;
            }
        }

        private void DtnAdd_Click(object sender, RoutedEventArgs e)
        {
            switch (currentTable)
            {
                case TableName.Rezume:
                    MainFrame.Navigate(new Views.AddEditRezume());
                    break;
                case TableName.Education:
                    MainFrame.Navigate(new Views.korotkieAddEdit(TableName.Education));
                    break;
                case TableName.Grafik:
                    MainFrame.Navigate(new Views.korotkieAddEdit(TableName.Grafik));
                    break;
                case TableName.Role:
                    MainFrame.Navigate(new Views.korotkieAddEdit(TableName.Role));
                    break;
                case TableName.Pol:
                    MainFrame.Navigate(new Views.korotkieAddEdit(TableName.Pol));
                    break;
                case TableName.Zanaytost:
                    MainFrame.Navigate(new Views.korotkieAddEdit(TableName.Zanaytost));
                    break;
                case TableName.User:
                    break;
                case TableName.UserRezume:
                    break;
                default:
                    break;
            }
        }

        private void GoBackImage_Click(object sender, MouseEventArgs e)
        {
            if (MainFrame.CanGoBack && MessageBox.Show("Вы уверены, что хотите вернуться?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                MainFrame.GoBack();
        }
    }
}
