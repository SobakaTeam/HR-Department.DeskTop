using System;
using System.Windows;
using WpfApp2.DBModels;

namespace WpfApp2.Pages
{
    public partial class DepartmentEditWindow : Window
    {
        public Department Department { get; private set; }
        private readonly bool _isNew;

        public DepartmentEditWindow(Department department = null)
        {
            InitializeComponent();
            _isNew = department == null;
            Department = department != null ? new Department
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                CreateAt = department.CreateAt,
                UpdateAt = department.UpdateAt
            } : new Department { CreateAt = DateTime.Now };
            NameTextBox.Text = Department.Name;
            DescriptionTextBox.Text = Department.Description;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Введите название отдела.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Department.Name = NameTextBox.Text.Trim();
            Department.Description = string.IsNullOrWhiteSpace(DescriptionTextBox.Text) ? null : DescriptionTextBox.Text.Trim();
            if (!_isNew)
                Department.UpdateAt = DateTime.Now;
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
} 