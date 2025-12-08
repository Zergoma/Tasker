using System;
using System.Collections.Generic;
using System.Text;
using PropertyChanged;

namespace Tasker.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = "";
        public string Color { get; set; } = "";
        public int PendingTasks { get; set; }
        public int TotalTasks { get; set; }
        public int DoneTasks { get; set; }
        public float Percentage { get; set; }
        public bool IsSelected { get; set; }
    }
}
