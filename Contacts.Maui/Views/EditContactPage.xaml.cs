using Contacts.Maui.Models;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Contact contact;
    public EditContactPage()
    {
        InitializeComponent();
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    public string ContactId
    {
        set
        {
            contact = ContactRepository.GetContactById(int.Parse(value));
            if (contact != null)
            {
                // lblName.Text = contact.Name;
                entryName.Text = contact.Name;
                entryEmail.Text = contact.Email;
                entryAddress.Text = contact.Address;
                entryPhone.Text = contact.Phone;
            }
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        contact.Name = entryName.Text;
        contact.Address = entryAddress.Text;
        contact.Phone = entryPhone.Text;
        contact.Email = entryEmail.Text;
        ContactRepository.UpdateContact(contact.ContactId, contact);
        Shell.Current.GoToAsync("..");
    }
}