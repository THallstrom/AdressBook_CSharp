﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TTest.Mvvm.Models;
using TTest.Services;

/*
 * Uppdatera via listan istället för att lägga in det på nytt i filen då bör det funka bättre men nu är det vin och film. Lycka till
 */

namespace TTest.Mvvm.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>();

        [ObservableProperty]
        Contact contact = new Contact();

        public MainViewModel()
        {
            UpdateList();
            ContactService.ContactsUpdated += UpdateList; // Här sker uppdateringen av sidan via ContactsUpdated
        }

        [RelayCommand]
        async Task AddPage()
        {
            await Shell.Current.GoToAsync(nameof(AddPage));
        }

        public void UpdateList()
        {
            // Nollställer listan och lägger in dem på nytt för att ha en korrekt lista att visa
            Contacts.Clear();
            var conta = ContactService.GetContacts();
            foreach (var item in conta)
            {
                Contacts.Add(item);
            }
        }

        [RelayCommand]
        async Task DetailPage(ContactModel s)
        {
            // Skickar info till DetailPage
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?", new Dictionary<string, object>
            {
                { "Content" , s }
            });
        }

        [RelayCommand]
        public void DeleteItem(ContactModel contact)
        {
            // Tar bort en contact från listan
            ContactService.RemoveContact(contact);
            UpdateList();
            
        }
    }
}
