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
    /// Логика взаимодействия для AddEditRezume.xaml
    /// </summary>
    public partial class AddEditRezume : Page

    {
        private byte[] _mainImageData = null;
        public string img = null;
        public string path = Path.Combine(Directory.GetParent(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)).FullName, @"Images\");
        public string selectefFileName;
        public string extension = "";
        public Rezume currentRezume;
        public AddEditRezume()
        {
            InitializeComponent();
            this.WindowTitle = "Добавление Резюме";
            
            
        }
        
        public AddEditRezume(Rezume rezume)
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
            TBRezumeOb.Text = currentRezume.educationID.ToString();
            TBRezumeGraf.Text = currentRezume.grafikID.ToString();
            TBRezumePol.Text = currentRezume.polID.ToString();
            TBRezumeZan.Text = currentRezume.zanaytostID.ToString();
            if (currentRezume.image != null)
            {
                _mainImageData = File.ReadAllBytes(path + currentRezume.image);
                Imageqwe.Source = new ImageSourceConverter().ConvertFrom(_mainImageData) as ImageSource;
            }


        }
        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Фото | *.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                img = Path.GetFileName(ofd.FileName);
                extension = Path.GetExtension(img);
                selectefFileName = ofd.FileName;
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                Imageqwe.Source = new ImageSourceConverter()
                    .ConvertFrom(_mainImageData) as ImageSource;
            }
        }
        private void CBpol(object sender, SelectionChangedEventArgs e)
        {

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                img = TBRezumeP.Text + extension;
                var files = Directory.GetFiles(path);
                int a = 0;
                while (File.Exists(path + img))
                {
                    a++;
                    img = TBRezumeP.Text + $" ({a})" + extension;
                }
                path = path + img;
                File.Copy(selectefFileName, path);
            }
            else if (currentRezume.image != null)
            {
                img = currentRezume.image;
            }
            if (currentRezume == null)
            {
                Rezume rezume = new Rezume()
                {
                    name = TBRezumeName.Text,
                    surname = TBRezumeSurname.Text,
                    patronymic = TBRezumePatronymic.Text,
                    gorod = TBRezumeGor.Text,
                    job = TBRezumeD.Text,
                    zarplata = TBRezumeZ.Text,
                    phone = TBRezumeTel.Text,
                    email = TBRezumeP.Text,
                    educationID = Int32.Parse(TBRezumeOb.Text),
                    grafikID = Int32.Parse(TBRezumeGraf.Text),
                    polID = Int32.Parse(TBRezumePol.Text),
                    zanaytostID = Int32.Parse(TBRezumeZan.Text),
                    image = img

                };
                AppData.db.Rezume.Add(rezume);
                AppData.db.SaveChanges();
                MessageBox.Show("Резюме успешно добавленно!");
            }
            else if (currentRezume.image != img || currentRezume.name != TBRezumeName.Text ||
                currentRezume.surname != TBRezumeSurname.Text ||
                currentRezume.patronymic != TBRezumePatronymic.Text ||
                currentRezume.gorod != TBRezumeGor.Text ||
                currentRezume.job != TBRezumeD.Text ||
                currentRezume.zarplata != TBRezumeZ.Text ||
                currentRezume.phone != TBRezumeTel.Text ||
                currentRezume.email != TBRezumeP.Text ||
                currentRezume.educationID != Int32.Parse(TBRezumeOb.Text) ||
                currentRezume.grafikID != Int32.Parse(TBRezumeGraf.Text) ||
                currentRezume.polID != Int32.Parse(TBRezumePol.Text) ||
                currentRezume.zanaytostID != Int32.Parse(TBRezumeZan.Text)  )
                
          
            
               
            {
                currentRezume.name = TBRezumeName.Text;
                currentRezume.surname = TBRezumeSurname.Text;
                currentRezume.patronymic = TBRezumePatronymic.Text;
                currentRezume.gorod = TBRezumeGor.Text;
                currentRezume.job = TBRezumeD.Text;
                currentRezume.zarplata = TBRezumeZ.Text;
                currentRezume.phone = TBRezumeTel.Text;
                currentRezume.email = TBRezumeP.Text;
                currentRezume.educationID = Int32.Parse(TBRezumeOb.Text);
                currentRezume.grafikID = Int32.Parse(TBRezumeGraf.Text);
                currentRezume.polID = Int32.Parse(TBRezumePol.Text);
                currentRezume.zanaytostID = Int32.Parse(TBRezumeZan.Text);
                currentRezume.image = img;
                AppData.db.SaveChanges();
                MessageBox.Show("Резюме успешно обновленно!");
                currentRezume = null;
            }
            NavigationService.Navigate(new RezumePage());
        }
        
    }
    
}
