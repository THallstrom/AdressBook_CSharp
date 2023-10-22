
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TTest.Mvvm.Models;

namespace TTest.Mvvm.ViewModels
{
    [QueryProperty(nameof(Content), nameof(Content))]
    public partial class DetailViewModel : ObservableObject
    {
        [ObservableProperty]
        ContactModel content;

        [RelayCommand]
        async Task EditPage(ContactModel s)
        {
            // Skickar vidare infon till EditPage
            await Shell.Current.GoToAsync($"{nameof(EditPage)}?",
                new Dictionary<string, object>
            {
                ["Content"] = s
            });
        }

        [RelayCommand]
        async Task Back()
        {
            // Enkelt att bara komma tillbaka till början igen
            await Shell.Current.GoToAsync("../..");
        }
    }
}
