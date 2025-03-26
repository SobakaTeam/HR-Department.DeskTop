using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WpfApp2.view;
using static System.Net.Mime.MediaTypeNames;
namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для WindowsAddDepartament.xaml
    /// </summary>
    public partial class WindowsAddDepartament : Window
    {
        
        
        public WindowsAddDepartament()
        {
            InitializeComponent();
           
        }


        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            view.DepartmentControl departmentControl;
            adminWindows admin;
            departmentControl = new view.DepartmentControl();

            DataBAnk.name = registorName.Text;
            DataBAnk.Department = registorDepartName.Text;
            DataBAnk.names.Add(departmentControl.name.Text);
            DataBAnk.Departments.Add(departmentControl.Departament.Text);

            departmentControl.name.Visibility = Visibility.Visible;
            departmentControl.Departament.Visibility = Visibility.Visible;
            departmentControl.border.Visibility = Visibility.Visible;
            departmentControl.borderfon.Visibility = Visibility.Visible;

                                                   
            if (registorName.Text.Length <= 1)
            {
                MessageBox.Show("Введённое имя слишком короткое, введите своё настоящие имя!");
                registorName.Text = "";
            }
            else 
            {
                MessageBox.Show("Вы успешно зарегестрировались");

                admin = new adminWindows();
                admin.Show();
                this.Close();
            }   
        }

        private void registorName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {            
           Regex regex = new Regex("[^a-zA-Zа-яА-ЯёЁ]"); 
           e.Handled = regex.IsMatch(e.Text);
                    
        }
    }
}
