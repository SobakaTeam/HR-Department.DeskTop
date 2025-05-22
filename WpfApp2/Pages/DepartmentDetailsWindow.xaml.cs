using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.DBModels;
using WpfApp2.Services;

namespace WpfApp2.Pages
{
    public partial class DepartmentDetailsWindow : Window
    {
        private readonly Department _department;
        private readonly InMemoryDepartmentService _service;
        private List<Person> _employees;

        public DepartmentDetailsWindow(Department department)
        {
            InitializeComponent();
            _department = department;
            _service = new InMemoryDepartmentService();
            LoadDepartmentInfo();
            LoadEmployeesAsync();
        }

        private void LoadDepartmentInfo()
        {
            DepartmentName.Text = _department.Name;
            DepartmentDescription.Text = _department.Description ?? "Нет описания";
            DepartmentCreateAt.Text = $"Создан: {_department.CreateAt:dd.MM.yyyy}";
        }

        private async void LoadEmployeesAsync()
        {
            _employees = await _service.GetPersonsByDepartmentIdAsync(_department.Id);
            EmployeesListView.ItemsSource = _employees.Select(p => new
            {
                Person = p,
                FullName = string.Format("{0} {1} {2}", p.LastName, p.FirstName, p.MidleName),
                Position = "-", // Можно доработать для получения позиции
                Email = p.Email,
                Phone = p.Phone
            }).ToList();
        }

        private void EmployeesListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (EmployeesListView.SelectedItem != null)
            {
                var person = ((dynamic)EmployeesListView.SelectedItem).Person as Person;
                if (person != null)
                {
                    var win = new EmployeeDetailsWindow(person);
                    win.ShowDialog();
                }
            }
        }
    }
} 