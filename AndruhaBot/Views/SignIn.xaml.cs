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
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        public SignIn()
        {
            InitializeComponent();
        }
        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentUser = AppData.db.User.FirstOrDefault((u) => u.login == TBLogin.Text && u.password == TBPassword.Text);

                if (currentUser == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации");
                }
                else
                {
                    App.CurrentUser = currentUser;
                    if (currentUser.login.Equals(TBLogin.Text) && currentUser.password.Equals(TBPassword.Text))
                    {
                        if (currentUser.roleID == 1)
                        {
                            Windows.AdminWindow admin = new Windows.AdminWindow(); //currentUser.userID
                            admin.Show();
                        }
                        else
                        {
                            Windows.UserWindow userWindow = new Windows.UserWindow();
                            userWindow.Show();
                        }
                        Window.GetWindow(this).Close();
                    }
                    else
                    {
                        MessageBox.Show("Введите корректные логин и пароль", "Ошибка авторизации");
                    }
                }



                //if (CurrentUser == null)
                //{
                //    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации");

                //} else
                //{
                //    switch (CurrentUser.roleID)
                //    {
                //        case 1:MessageBox.Show("Здравствуйте, Администратор " + CurrentUser.name + "!");
                //            break;
                //        case 2:MessageBox.Show("Здравствуйте, гость " + CurrentUser.name + "!");
                //            break;
                //        default:MessageBox.Show("Ошибка");
                //            break;
                //    }

                //    if (CurrentUser.login.Equals(TBLogin.Text) && CurrentUser.password.Equals(TBPassword.Text))
                //    {
                //        NavigationService.Navigate(new DataPage());
                //    }
                //    else
                //    {
                //        MessageBox.Show("Введите корректные логин и пароль");
                //    }                
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString());
            }

        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUp());
        }
    }
}
