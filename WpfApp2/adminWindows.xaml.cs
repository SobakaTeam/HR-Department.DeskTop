using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Xml.Linq;
using WpfApp2;
using WpfApp2.view;
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
        
       

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            windowsHuman windowsHuman = new windowsHuman();
            windowsHuman.Show();
            DepartmentControl departmentControl = new DepartmentControl();
            WindowsAddDepartament addDepartament = new WindowsAddDepartament();
            departmentControl = new DepartmentControl();
            addDepartament.Show();  
            this.Close();
            
            



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }

        private void DepartmentControl_Loaded(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
