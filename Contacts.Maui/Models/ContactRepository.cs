
namespace Contacts.Maui.Models;

public static class ContactRepository
{
    public static List<Contact> _contacts = new()
    {
        new Contact{ContactId = 1, Name = "John Doe", Email = "JohnDoe@gmail.com"},
        new Contact{ContactId = 2,Name = "Jane Doe", Email = "janedoe@gmail.com"},
        new Contact{ContactId = 3,Name = "Tom Hanks", Email = "tomhanks@gmail.com"},
        new Contact{ContactId = 4,Name = "Frank Liu", Email = "frankliu@gmail.com"},
    };

    public static List<Contact> GetContacts() => _contacts;

    public static Contact GetContactById(int contactId)
    {
        var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
        if (contact != null)
        {
            return new Contact
            {
                ContactId = contactId,
                Address = contact.Address,
                Email = contact.Email,
                Name = contact.Name,
                Phone = contact.Phone,
            };
        }
        return null;
    }

    public static void UpdateContact(int contactId, Contact contact)
    {
        if (contactId != contact.ContactId)
            return;

        var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId);
        if (contactToUpdate != null)
        {
            contactToUpdate.Address = contact.Address;
            contactToUpdate.Email = contact.Email;
            contactToUpdate.Name = contact.Name;
            contactToUpdate.Phone = contact.Phone;
        }
    }

    public static void AddContact(Contact contact)
    {
        var maxId = _contacts.Max(x => x.ContactId);
        contact.ContactId = maxId + 1;
        _contacts.Add(contact);
    }

    public static void DeleteContact(int contactId)
    {
        var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
        if (contact != null)
        {
            _contacts.Remove(contact);
        }
    }

    public static List<Contact> SearchContacts(string filterText)
    {
        var contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();

        if (contacts == null || contacts.Count <= 0)
        {
            contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
        }
        else
        {
            return contacts;
        }

        if (contacts == null || contacts.Count <= 0)
        {
            contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Phone.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
        }
        else
        {
            return contacts;
        }

        if (contacts == null || contacts.Count <= 0)
        {
            contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
        }
        else
        {
            return contacts;
        }
        return contacts;
    }
}