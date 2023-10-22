using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TTest.Mvvm.Models;
using TTest.Services;

namespace TTest.Mvvm.ViewModels
{
    public partial class AddViewModel : ObservableObject
    {
        [ObservableProperty]
        ContactModel contact = new ContactModel();
        
        [RelayCommand]
        async Task Save() //Skickar vidare och spara till lista
        {
            ContactService.AddToList(Contact);
            await Shell.Current.GoToAsync("..");
        }
    }
}
