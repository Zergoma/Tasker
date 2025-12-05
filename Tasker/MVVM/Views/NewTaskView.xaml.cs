using System.Threading.Tasks;
using Tasker.MVVM.Models;
using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class NewTaskView : ContentPage
{
    public NewTaskView()
    {
        InitializeComponent();
    }

    private async void AddTask_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is NewTaskViewModel viewmodel)
        {
            if(string.IsNullOrEmpty(viewmodel.Task) is true )
            {
                await DisplayAlertAsync("Invalid Task", "You must set a Task name", "Ok");
                return;
            }

            int nb = viewmodel.Categories.Count;

            var selectedCategory =
                viewmodel.Categories.Where(o => o.IsSelected is true)?.FirstOrDefault();

            if (selectedCategory is null)
            {
                await DisplayAlertAsync("Invalid Selection", "You must select a categorie", "Ok");
                return;
            }

            MyTask task = new()
            {
                TaskName = viewmodel.Task,
                CategoryId = selectedCategory.Id,
            };
            viewmodel.Tasks.Add(task);
            await Navigation.PopAsync();
        }
    }

    private async void AddCategory_Clicked(object sender, EventArgs e)
    {
        if(BindingContext is NewTaskViewModel viewmodel)
        {
            string cat =
                await DisplayPromptAsync("New Category", 
                "Write the new category name", 
                keyboard: Keyboard.Text);

            if(string.IsNullOrEmpty(cat) is true)
            {
                return;
            }

            Random rd = new();
            Color newcatcolor = Color.FromRgb(rd.Next(256), rd.Next(256), rd.Next(256));

            viewmodel.Categories.Add(new()
            {
                CategoryName = cat,
                Id = viewmodel.Categories.Max(x => x.Id) +1,
                IsSelected = false,
                Color = newcatcolor.ToHex(),
            });
        }
    }
}