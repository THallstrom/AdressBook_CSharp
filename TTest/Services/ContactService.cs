using Newtonsoft.Json;
using System.Diagnostics;
using TTest.Mvvm.Models;

namespace TTest.Services
{
    public static class ContactService
    {
        private static List<ContactModel> _contactsService = new();
        private static readonly string filePath = @"C:\Nackademin\Adress\TTest\Adress.json";
        public static event Action ContactsUpdated;

        public static void AddToList(ContactModel contact)
        {
            _contactsService.Add(contact);
            SaveToList(JsonConvert.SerializeObject(_contactsService));
        }

        public static IEnumerable<ContactModel> GetContacts()
        {
            try
            {
                var users = ReadFromFile();
                if (!string.IsNullOrEmpty(users))
                {
                    _contactsService = JsonConvert.DeserializeObject<List<ContactModel>>(users);
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return _contactsService;
        }

        private static void SaveToList(string contacts)
        {
            try
            {
                using var sw = new StreamWriter(filePath);
                sw.Write(contacts);
                ContactsUpdated?.Invoke();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }
        public static string ReadFromFile()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    return File.ReadAllText(filePath);
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null;
        }

        public static void EditList(ContactModel updatedContact)
        {
            var oldContact = _contactsService.FirstOrDefault(x => x.Id == updatedContact.Id);
            _contactsService.Remove(oldContact);
            _contactsService.Add(updatedContact);
            SaveToList(JsonConvert.SerializeObject(_contactsService));

        }

        public static void RemoveContact(ContactModel contact)
        {
            try
            {
                if (_contactsService.Contains(contact))
                {
                    _contactsService.Remove(contact);
                    SaveToList(JsonConvert.SerializeObject(_contactsService));
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }
    }

}
