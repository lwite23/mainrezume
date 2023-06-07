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
    /// Логика взаимодействия для korotkieAddEdit.xaml
    /// </summary>
    public partial class korotkieAddEdit : Page
    {
        public TableName currentTable;
        public string itemName;
        public Role role;
        public Education education;
        public Pol pol;
        public Zanaytost zanaytost;
        public Grafik grafik;
        public bool addOrEditFlag = false;
        public korotkieAddEdit(TableName tn)
        {
            InitializeComponent();
            this.WindowTitle = "Добавление";
            currentTable = tn;
            addOrEditFlag = true;
            switch (currentTable)
            {
                case TableName.Education:
                    this.WindowTitle = "Добавление образования";
                    TBName.Text = "Образование:";
                    break;
                case TableName.Role:
                    this.WindowTitle = "Добавление ролей";
                    TBName.Text = "Роль:";
                    break;
                case TableName.Pol:
                    this.WindowTitle = "Добавление пола";
                    TBName.Text = "Пол:";
                    break;
                case TableName.Zanaytost:
                    this.WindowTitle = "Добавление типя занятости";
                    TBName.Text = "Занятость:";
                    break;
                case TableName.Grafik:
                    this.WindowTitle = "Добавление графика";
                    TBName.Text = "График:";
                    break;
                default:
                    break;
            }
        }
        public korotkieAddEdit(TableName tn, Role rl = null, Education ed = null, Pol pl = null, Zanaytost zn = null, Grafik gr = null)
        {
            this.currentTable = tn;
            addOrEditFlag = false;
            InitializeComponent();
            this.role = rl;
            this.education = ed;
            this.pol = pl;
            this.zanaytost = zn;
            this.grafik = gr;

            switch (currentTable)
            {
                case TableName.Education:
                    this.WindowTitle = "Редактирование жанров";
                    TBName.Text = "Жанр:";
                    TBShortName.Text = education.name;
                    break;
                case TableName.Pol:
                    this.WindowTitle = "Редактирование жанров";
                    TBName.Text = "Жанр:";
                    TBShortName.Text = pol.name;
                    break;
                case TableName.Role:
                    this.WindowTitle = "Редактирование ролей";
                    TBName.Text = "Роль:";
                    TBShortName.Text = role.name;
                    break;
                case TableName.Zanaytost:
                    this.WindowTitle = "Редактирование издательств";
                    TBName.Text = "Издательство:";
                    TBShortName.Text = zanaytost.name;
                    break;
                case TableName.Grafik:
                    this.WindowTitle = "Редактирование состояний книг";
                    TBName.Text = "Состояние:";
                    TBShortName.Text = grafik.name;
                    break;
                default:
                    break;
            }

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            
            if (addOrEditFlag)
            {
                switch (currentTable)
                {
                    case TableName.Education:
                        Education education = new Education()
                        {
                            name = TBShortName.Text,
                        };
                        AppData.db.Education.Add(education);
                        break;
                    case TableName.Pol:
                        Pol pol = new Pol()
                        {
                            name = TBShortName.Text,
                        };
                        AppData.db.Pol.Add(pol);
                        break;
                    case TableName.Role:
                        Role role = new Role()
                        {
                            name = TBShortName.Text,
                        };
                        AppData.db.Role.Add(role);
                        break;
                    case TableName.PublishingHouse:
                        PublishingHouse publishingHouse = new PublishingHouse()
                        {
                            name = TBShortName.Text,
                        };
                        AppData.db.PublishingHouse.Add(publishingHouse);
                        break;
                    case TableName.State:
                        State state = new State() { name = TBShortName.Text, };
                        AppData.db.State.Add(state);
                        break;
                    default:
                        break;
                }
                AppData.db.SaveChanges();
                MessageBox.Show("Запись успешно добавлена в таблицу!");
            }
            else
            {
                switch (currentTable)
                {
                    case TableName.Genres:
                        genre.name = TBShortName.Text;
                        break;
                    case TableName.Role:
                        role.name = TBShortName.Text;
                        break;
                    case TableName.PublishingHouse:
                        publishingHouse.name = TBShortName.Text;
                        break;
                    case TableName.State:
                        state.name = TBShortName.Text;
                        break;
                    default:
                        break;
                }
                AppData.db.SaveChanges();
                MessageBox.Show("Запись успешно изменена");
            }
            NavigationService.Navigate(new ShortPage(currentTable));
        }
    }
}
