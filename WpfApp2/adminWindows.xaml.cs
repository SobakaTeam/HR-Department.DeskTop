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
using static WpfApp2.AddDepartamentAdminWindows;
namespace WpfApp2
{
    
    /// <summary>
    /// Логика взаимодействия для adminWindows.xaml
    /// </summary>
    public partial class adminWindows : Window
    {
        
     

        public adminWindows()
        {
            InitializeComponent();
           
           
          
           
        }
        AddDepartamentAdminWindows addAdminWin;
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            WindowsAddDepartament addDepartament = new WindowsAddDepartament();
            addDepartament.Show();  
            this.Visibility = Visibility.Collapsed;
           



        }
        
    }
}
