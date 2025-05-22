using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WpfApp2.DBModels;

namespace WpfApp2.Pages
{
    public partial class ChildrenListWindow : Window
    {
        public ChildrenListWindow(List<PersonChild> children)
        {
            InitializeComponent();
            ChildrenDataGrid.ItemsSource = children.Select(c => new
            {
                FullName = c.Child != null ? (c.Child.LastName + " " + c.Child.FirstName + (string.IsNullOrWhiteSpace(c.Child.MidleName) ? "" : (" " + c.Child.MidleName))) : "-",
                Birthday = c.Child != null ? c.Child.Birthday : (DateTime?)null,
                Comment = c.Comment
            }).ToList();
        }
    }
} 