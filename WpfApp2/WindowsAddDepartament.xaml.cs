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
using WpfApp2;
namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для WindowsAddDepartament.xaml
    /// </summary>
    public partial class WindowsAddDepartament : Window
    {

        AddDepartamentAdminWindows addDepartamentAdmin;
        private WindowsAddDepartament (AddDepartamentAdminWindows _addAdminWin)
        {
            addDepartamentAdmin = _addAdminWin;
        }
        public WindowsAddDepartament()
        {
            InitializeComponent();
           
        }


        public void Button_Click_1(object sender, RoutedEventArgs e)
        {

            adminWindows adminWindows = new adminWindows();
            this.Close();
            adminWindows.Visibility = Visibility.Visible;
            
           
           
        }
    }
}
