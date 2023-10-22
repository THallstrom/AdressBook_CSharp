
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
            await Shell.Current.GoToAsync($"{nameof(EditPage)}?",
                new Dictionary<string, object>
            {
                ["Content"] = s
            });
        }

        [RelayCommand]
        async Task Back()
        {
            await Shell.Current.GoToAsync("../..");
        }
    }
}
