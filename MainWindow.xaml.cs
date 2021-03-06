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

namespace RegistrationFormWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> users = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (FormIsOk())
            {
                AddNewUser(EmailField.Text, PasswordField.Password.ToString());
            }            
        }

        private bool FormIsOk()
        {
            if(EmailField.Text != string.Empty && 
                PasswordField.Password.ToString() != string.Empty &&
                PasswordRepeatField.Password.ToString() != string.Empty &&
                PasswordField.Password.ToString() == PasswordRepeatField.Password.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        private void AddNewUser(string email, string password)
        {
            var user = new User(email, password);
            users.Add(user);
            
            //now adding to the list box
            ListBoxItem item = new ListBoxItem();
            item.Content = $"{user.Email}:{user.Password}";
            UserList.Items.Add(item);
        }
    }

    public class User
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }

}
