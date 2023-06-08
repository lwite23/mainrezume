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
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;

namespace AndruhaBot.Views
{
    /// <summary>
    /// Логика взаимодействия для AddRez.xaml
    /// </summary>
    public partial class AddRez : Page
    {
        private byte[] _mainImageData = null;
        public string img = null;
        public string path = Path.Combine(Directory.GetParent(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)).FullName, @"Images\");
        public string selectefFileName;
        public string extension = "";
        public Rezume currentRezume;
        public AddRez()
        {
            InitializeComponent();
        }
        public AddRez(Rezume rezume)
        {
            InitializeComponent();
            currentRezume = rezume;
            this.WindowTitle = "Редактирование резюме";
            TBRezumeSurname.Text = currentRezume.surname;
            TBRezumeName.Text = currentRezume.name;
            TBRezumePatronymic.Text = currentRezume.patronymic;
            TBRezumeGor.Text = currentRezume.gorod;
            TBRezumeD.Text = currentRezume.job;
            TBRezumeZ.Text = currentRezume.zarplata;
            TBRezumeTel.Text = currentRezume.phone;
            TBRezumeP.Text = currentRezume.email;
            TBRezumeOb.Text = currentRezume.Education.name.ToString();
            TBRezumeGraf.Text = currentRezume.Grafik.name.ToString();
            TBRezumePol.Text = currentRezume.Pol.name.ToString();
            TBRezumeZan.Text = currentRezume.Zanaytost.name.ToString();
            if (currentRezume.image != null)
            {
                _mainImageData = File.ReadAllBytes(path + currentRezume.image);
                Imageqwe.Source = new ImageSourceConverter().ConvertFrom(_mainImageData) as ImageSource;
            }

        }

        private void TBRezumeName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
