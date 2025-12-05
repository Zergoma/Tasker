using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tasker.MVVM.Models;

namespace Tasker.MVVM.ViewModels
{
    public class NewTaskViewModel
    {
        public string Task { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }
    }
}
