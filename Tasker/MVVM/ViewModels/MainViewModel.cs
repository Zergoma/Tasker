using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tasker.MVVM.Models;
using PropertyChanged;

namespace Tasker.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        public ObservableCollection<Category> Categories { get; set; } = new();
        public ObservableCollection<MyTask> Tasks { get; set; } = new();

        public MainViewModel()
        {
            FillData();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
            Categories.CollectionChanged += Tasks_CollectionChanged;
        }

        private void Tasks_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void FillData()
        {
            Categories = new()
            {
                new Category {
                    Id = 1,
                    CategoryName = ".Net MAUI Course",
                    Color = "#CF14DF"
                },
                new Category {
                    Id = 2,
                    CategoryName = "Tutorials",
                    Color = "#DF6F14"
                },
                new Category {
                    Id = 3,
                    CategoryName = "Shopping",
                    Color = "#14DF80"
                },
            };

            Tasks = new()
            {
                new()
                {
                    TaskName = "Upload exercise files",
                    Completed = false,
                    CategoryId = 1
                },
                new()
                {
                    TaskName = "Boom",
                    Completed = false,
                    CategoryId = 1
                },
                new()
                {
                    TaskName = "Plan next course",
                    Completed = false,
                    CategoryId = 1
                },
                new ()
                {
                        TaskName = "Upload new ASP.NET video on YouTube",
                        Completed = false,
                        CategoryId = 2
                },
                new ()
                {
                        TaskName = "Fix Settings.cs class of the project",
                        Completed = false,
                        CategoryId = 2
                },
                new ()
                {
                        TaskName = "Update github repository",
                        Completed = true,
                        CategoryId = 2
                },
                new ()
                {
                        TaskName = "Buy eggs",
                        Completed = false,
                        CategoryId = 3
                },
                new ()
                {
                        TaskName = "Go for the pepperoni pizza",
                        Completed = false,
                        CategoryId = 3
                },
            };

            UpdateData();
        }

        public void UpdateData()
        {
            foreach(Category c in Categories)
            {
                var tasks = Tasks.Where(o => o.CategoryId == c.Id);

                var completded = tasks.Where(o => o.Completed is true);

                var notComplet = tasks.Where(o => o.Completed is false);

                var totaltasks = tasks.Count();

                c.PendingTasks = notComplet.Count();
                c.Percentage = (float)completded.Count() / (float)tasks.Count();
                c.TotalTasks = totaltasks;
                c.DoneTasks = completded.Count();
            }

            foreach(var t in Tasks)
            {
                var catColor = Categories
                                .Where(o => o.Id == t.CategoryId)
                                ?.FirstOrDefault()?.Color ?? string.Empty;
                t.TaskColor = catColor;

            }
        }
    }
}
