using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WpfApp2.DBModels;

namespace WpfApp2.Pages
{
    public partial class SalaryHistoryWindow : Window
    {
        public SalaryHistoryWindow(List<PersonSalary> salaries)
        {
            InitializeComponent();
            SalaryDataGrid.ItemsSource = salaries.Select(s => new
            {
                Date = s.Date,
                Amount = s.Amount,
                Comment = s.Comment
            }).ToList();
        }
    }
} 