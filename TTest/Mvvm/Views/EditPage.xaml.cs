using TTest.Mvvm.ViewModels;

namespace TTest.Mvvm.Views;

public partial class EditPage : ContentPage
{
	public EditPage(EditViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}