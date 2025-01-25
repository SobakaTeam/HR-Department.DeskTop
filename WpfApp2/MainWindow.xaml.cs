using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
using System.Xml.Linq;
using WpfApp2; 
namespace WpfApp2
{
    /// <>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        adminWindows adminWindows = new adminWindows();
     
        public MainWindow()
        {
            InitializeComponent();
           
            passwordBoxNew.Visibility = Visibility.Collapsed;
            eyeLocked.Visibility = Visibility.Collapsed;
            

        }

        private void eye_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            eye.Visibility = Visibility.Collapsed;
            eyeLocked.Visibility = Visibility.Visible;
            passwordBoxNew.Text = passwordBox.Password;
            passwordBox.Visibility = Visibility.Collapsed;
            passwordBoxNew.Visibility = Visibility.Visible; 
        }

        private void eyeLocked_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            eye.Visibility = Visibility.Visible;
            eyeLocked.Visibility = Visibility.Collapsed;
            passwordBox.Password = passwordBoxNew.Text ;
            passwordBox.Visibility = Visibility.Visible;
            passwordBoxNew.Visibility = Visibility.Collapsed;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var pass = passwordBox.SecurePassword.GetType();         
            adminWindows.Show();
            this.Close();
           






        }

      
    }
}
