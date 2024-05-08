namespace Contacts.Maui.Models;

public static class ContactRepository
{
    public static List<Contact> contacts = new()
    {
        new Contact{ContactId = 1, Name = "John Doe", Email = "JohnDoe@gmail.com"},
        new Contact{ContactId = 2,Name = "Jane Doe", Email = "janedoe@gmail.com"},
        new Contact{ContactId = 3,Name = "Tom Hanks", Email = "tomhanks@gmail.com"},
        new Contact{ContactId = 4,Name = "Frank Liu", Email = "frankliu@gmail.com"},
    };

    public static List<Contact> GetContacts() => contacts;

    public static Contact GetContactById(int contactId) => contacts.FirstOrDefault(x => x.ContactId == contactId);
}