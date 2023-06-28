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
using System.Windows.Shapes;

namespace AndruhaBot.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {

        public UserWindow()
        {
            InitializeComponent();
            AppFrame.frameUser = UserFrame;
            UserFrame.Navigate(new Views.Main());
            
        }
        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            UserFrame.GoBack();
        }

        private void BtnExit(object sender, RoutedEventArgs e)
        {
            Windows.AuthWindow authWindow = new Windows.AuthWindow();
            authWindow.Show();
            this.Close();
            MessageBox.Show("Вы успешно вышли из аккаунта");
        }

        private void DtnAdd_Click(object sender, RoutedEventArgs e)
        {
            UserFrame.Navigate(new Views.AddEditRezume());
        }
    }
}
