using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class MainView : ContentPage
{
	private MainViewModel _vm = new MainViewModel();
    public MainView()
	{
		InitializeComponent();
		BindingContext = _vm;
	}

    private void checkbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _vm.UpdateData();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        NewTaskView newtaskpage = new()
        {
            BindingContext = new NewTaskViewModel()
            {
                Categories = _vm.Categories,
                Tasks = _vm.Tasks,
            }
        };
        Navigation.PushAsync(newtaskpage);
    }
}