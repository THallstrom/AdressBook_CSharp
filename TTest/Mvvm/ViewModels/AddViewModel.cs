using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TTest.Mvvm.Models;
using TTest.Services;

namespace TTest.Mvvm.ViewModels
{
    public partial class AddViewModel : ObservableObject
    {
        // public static event Action ContactsUpdated;

        [ObservableProperty]
        ContactModel contact = new ContactModel();
        
        [RelayCommand]
        async Task Save()
        {
            ContactService.AddToList(Contact);
            // ContactsUpdated?.Invoke();
            await Shell.Current.GoToAsync("..");
        }
    }
}
