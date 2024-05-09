using Contacts.Maui.Models;
using System.Collections.ObjectModel;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();

	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ObservableCollection<Contact> contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());
        listContacts.ItemsSource = contacts;
    }


    private async void ListContacts_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if (listContacts.SelectedItem != null)
		{
			await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
		} 
	}

	private void ListContacts_OnItemTapped(object sender, ItemTappedEventArgs e)
	{
		listContacts.SelectedItem = null;
	}
}