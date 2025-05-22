using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WpfApp2.DBModels;

namespace WpfApp2.Pages
{
    public partial class VacationHistoryWindow : Window
    {
        public VacationHistoryWindow(List<PersonVacation> vacations)
        {
            InitializeComponent();
            VacationDataGrid.ItemsSource = vacations.Select(v => new
            {
                StartDate = v.StartDate,
                EndDate = v.EndDate,
                Type = v.Type,
                Comment = v.Comment
            }).ToList();
        }
    }
} 