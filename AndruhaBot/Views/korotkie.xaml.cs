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
    /// Логика взаимодействия для korotkie.xaml
    /// </summary>
    public partial class korotkie : Page
    {
        public TableName currentTable;

        public korotkie()
        {
            InitializeComponent();
        }
        public korotkie(TableName tn)
        {
            currentTable = tn;
            this.WindowTitle = currentTable.ToString();

            InitializeComponent();
            Update();
        }
        public void Update()
        {
            switch (currentTable)
            {
                case TableName.Education:
                    List<Education> education = AppData.db.Education.ToList();
                    LVShort.ItemsSource = education;
                    break;
                case TableName.Pol:
                    var pol = AppData.db.Pol.ToList();
                    LVShort.ItemsSource = pol;
                    break;
                case TableName.Role:
                    var role = AppData.db.Role.ToList();
                    LVShort.ItemsSource = role;
                    break;
                case TableName.Zanaytost:
                    List<Zanaytost> zanaytost = AppData.db.Zanaytost.ToList();
                    LVShort.ItemsSource = zanaytost;
                    break;
                case TableName.Grafik:
                    var grafik = AppData.db.Grafik.ToList();
                    LVShort.ItemsSource = grafik;
                    break;
                default:
                    MessageBox.Show("Ошибка, сорри!!!");
                    break;
            }
        }
        

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            switch (currentTable)
            {
                case TableName.Education:
                    var currentEducation = button.DataContext as Education;
                    NavigationService.Navigate(new korotkieAddEdit(currentTable, currentEducation));
                    break;
                case TableName.Pol:
                    var currentPol = button.DataContext as Pol;
                    NavigationService.Navigate(new korotkieAddEdit(currentTable, null, currentPol));
                    break;
                case TableName.Role:
                    var currentRole = button.DataContext as Role;
                    NavigationService.Navigate(new korotkieAddEdit(currentTable, null, null, currentRole));
                    break;
                case TableName.Zanaytost:
                    var currentZanaytost = button.DataContext as Zanaytost;
                    NavigationService.Navigate(new korotkieAddEdit(currentTable, null, null, null, currentZanaytost));
                    break;
                case TableName.Grafik:
                    var currentGrafik = button.DataContext as Grafik;
                    NavigationService.Navigate(new korotkieAddEdit(currentTable, null, null, null, null, currentGrafik));
                    break;
                default:
                    break;
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены что хотите удалить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                switch (currentTable)
                {
                    case TableName.Education:
                        var currentEducation = (sender as Button).DataContext as Education;
                        AppData.db.Education.Remove(currentEducation);
                        break;
                    case TableName.Pol:
                        var currentPol = (sender as Button).DataContext as Pol;
                        AppData.db.Pol.Remove(currentPol);
                        break;
                    case TableName.Role:
                        var currentRole = (sender as Button).DataContext as Role;
                        AppData.db.Role.Remove(currentRole);
                        break;
                    case TableName.Zanaytost:
                        var currentZanaytost = (sender as Button).DataContext as Zanaytost;
                        AppData.db.Zanaytost.Remove(currentZanaytost);
                        break;
                    case TableName.Grafik:
                        var currentGrafik = (sender as Button).DataContext as Grafik;
                        AppData.db.Grafik.Remove(currentGrafik);
                        break;
                   
                    default:
                        break;
                }
                AppData.db.SaveChanges();
                Update();
            }
        }
    }
}
