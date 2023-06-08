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

namespace AndruhaBot.Views
{
    /// <summary>
    /// Логика взаимодействия для RezumePage.xaml
    /// </summary>
    public partial class RezumePage : Page
    {
        public RezumePage()
        {
            InitializeComponent();
            Update();
        }
        public void Update()
        {
            var content = AppData.db.Rezume.ToList();
            LVRezume.ItemsSource = content;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var currentRezume = button.DataContext as Rezume;
            NavigationService.Navigate(new AddEditRezume(currentRezume));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentRezume = (sender as Button).DataContext as Rezume;
            if (MessageBox.Show("Вы уверены что хотите удалить этого автора?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                AppData.db.Rezume.Remove(currentRezume);
                AppData.db.SaveChanges();
                Update();
            }
        }
    }
}
