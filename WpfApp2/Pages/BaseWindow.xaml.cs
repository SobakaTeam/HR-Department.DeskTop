using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp2.DBModels;
using WpfApp2.Services;

namespace WpfApp2.Pages
{
    public partial class BaseWindow : Window
    {
        private readonly IDepartmentService _departmentService;
        private List<Department> _departments;

        public BaseWindow()
        {
            InitializeComponent();
            _departmentService = new InMemoryDepartmentService();
            LoadDepartmentsAsync();
        }

        private async void LoadDepartmentsAsync()
        {
            _departments = await _departmentService.GetAllDepartmentsAsync();
            DepartmentsListView.ItemsSource = _departments;
        }

        private void DepartmentsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DepartmentsListView.SelectedItem is Department selected)
            {
                DepartmentName.Text = selected.Name;
                DepartmentDescription.Text = selected.Description ?? "Нет описания";
                DepartmentCreateAt.Text = $"Создан: {selected.CreateAt:dd.MM.yyyy}";
            }
            else
            {
                DepartmentName.Text = string.Empty;
                DepartmentDescription.Text = string.Empty;
                DepartmentCreateAt.Text = string.Empty;
            }
        }

        private void AddDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new DepartmentEditWindow();
            if (editWindow.ShowDialog() == true)
            {
                LoadDepartmentsAsync();
            }
        }

        private void EditDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (DepartmentsListView.SelectedItem is Department selected)
            {
                var editWindow = new DepartmentEditWindow(selected);
                if (editWindow.ShowDialog() == true)
                {
                    LoadDepartmentsAsync();
                }
            }
            else
            {
                MessageBox.Show("Выберите отдел для редактирования.");
            }
        }

        private async void DeleteDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (DepartmentsListView.SelectedItem is Department selected)
            {
                var result = MessageBox.Show($"Удалить отдел '{selected.Name}'?", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    await _departmentService.DeleteDepartmentAsync(selected.Id);
                    LoadDepartmentsAsync();
                }
            }
            else
            {
                MessageBox.Show("Выберите отдел для удаления.");
            }
        }

        private void ViewDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (DepartmentsListView.SelectedItem is Department selected)
            {
                var detailsWindow = new DepartmentDetailsWindow(selected);
                detailsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите отдел для просмотра.");
            }
        }
    }
} 