using TTest.Mvvm.ViewModels;

namespace TTest.Mvvm.Views;

public partial class AddPage : ContentPage
{
	public AddPage(AddViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}