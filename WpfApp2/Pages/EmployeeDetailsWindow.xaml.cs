using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.DBModels;
using WpfApp2.Services;

namespace WpfApp2.Pages
{
    public partial class EmployeeDetailsWindow : Window
    {
        private readonly Person _person;
        private readonly InMemoryDepartmentService _service;

        public EmployeeDetailsWindow(Person person)
        {
            InitializeComponent();
            _person = person;
            _service = new InMemoryDepartmentService();
            LoadPersonInfo();
        }

        private void LoadPersonInfo()
        {
            FullName.Text = string.Format("{0} {1} {2}", _person.LastName, _person.FirstName, _person.MidleName);
            Phone.Text = _person.Phone;
            Email.Text = _person.Email;
            Birthday.Text = _person.Birthday.HasValue ? _person.Birthday.Value.ToString("dd.MM.yyyy") : "-";
            HireDate.Text = _person.HireDate.HasValue ? _person.HireDate.Value.ToString("dd.MM.yyyy") : "-";
            IsMarried.Text = _person.IsMarried.HasValue ? (_person.IsMarried.Value ? "Женат/Замужем" : "Не женат/Не замужем") : "-";
            NowPlaceLiving.Text = _person.NowPlaceLiving;
            // Текущая должность — получаем из базы
            LoadCurrentPositionAsync();
        }

        private async void LoadCurrentPositionAsync()
        {
            var positions = await _service.GetPositionsByPersonIdAsync(_person.Id);
            var currentPosition = positions.FirstOrDefault();
            Position.Text = currentPosition != null ? currentPosition : "-";
        }

        private async void SalaryHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            var salaries = await _service.GetSalariesByPersonIdAsync(_person.Id);
            var win = new SalaryHistoryWindow(salaries);
            win.ShowDialog();
        }

        private async void VacationHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            var vacations = await _service.GetVacationsByPersonIdAsync(_person.Id);
            var win = new VacationHistoryWindow(vacations);
            win.ShowDialog();
        }

        private async void ChildrenButton_Click(object sender, RoutedEventArgs e)
        {
            var children = await _service.GetChildrenByPersonIdAsync(_person.Id);
            var win = new ChildrenListWindow(children);
            win.ShowDialog();
        }
    }
} 