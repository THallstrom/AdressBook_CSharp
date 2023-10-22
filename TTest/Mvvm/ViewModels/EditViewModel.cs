using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TTest.Mvvm.Models;
using TTest.Services;

namespace TTest.Mvvm.ViewModels
{
    [QueryProperty(nameof(Content), nameof(Content))]
    public partial class EditViewModel : ObservableObject
    {
        public static event Action ContactsUpdated;

        [ObservableProperty]
        ContactModel content;

        [RelayCommand]
        async Task GoBack()
        {
            ContactService.EditList(Content);
            ContactsUpdated?.Invoke();
            await Shell.Current.GoToAsync("../..");
        }
    }
}
