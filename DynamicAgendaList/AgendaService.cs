using DynamicAgendaList.Entities;
using DynamicAgendaList.Entities.Enums;
using System;

namespace DynamicAgendaList
{
    internal class AgendaService
    {
        Agenda agenda = new Agenda();
        int count;

        public void GetAllContacts()
        {
            CheckIsEmpty();
            agenda.PrintPaused();
        }

        public Contact[] GetContactsByNamePhone()
        {
            CheckIsEmpty();

            Console.Write("Enter the name of the contact to be searched for: ");
            Contact[] contacts = agenda.Search(Console.ReadLine());

            if (contacts[0] == null)
            {
                Console.WriteLine("Contact not found");
            }

            foreach (Contact c in contacts)
            {
                if (c != null) Console.WriteLine(c.ToString());
            }

            return contacts;
        }



        public void AddContact()
        {
            Console.WriteLine(agenda.Push(InputInfo(new Contact())).ToString());
            count++;
            Console.WriteLine("Contact added successfully");
        }


        private Contact InputInfo(Contact contact)
        {
            if (contact.Name == null || contact.Name == "")
            {
                Console.Write("Name: ");
                contact.Name = Console.ReadLine();

                if (string.Empty == contact.Name)
                {
                    Console.WriteLine($"The name is empty");
                    InputInfo(contact);
                }
            }

            if (contact.Email == null || contact.Email == "")
            {
                Console.Write("E-mail: ");
                contact.Email = Console.ReadLine();

                if (string.Empty == contact.Email)
                {
                    Console.WriteLine($"The E-mail is empty");
                    InputInfo(contact);
                }
            }

            ContactPhone[] contactPhones;

            Console.WriteLine(" How many contacts do you want to add?");
            int countContacts = int.Parse(Console.ReadLine());

            contactPhones = new ContactPhone[countContacts];

            for (int i = 0; i != countContacts; i++)
            {
                contactPhones[i] = InputPhoneInfo(new ContactPhone());
            }

            contact.ContactPhones = contactPhones;

            Console.Clear();

            return contact;

        }

        private ContactPhone InputPhoneInfo(ContactPhone contactPhone)
        {

            if (contactPhone.DDD == 0)
            {
                Console.Write("DDD: ");
                if (Int32.TryParse(Console.ReadLine(), out int ddd))
                    contactPhone.DDD = ddd;
                else
                {
                    Console.WriteLine("Incorrect format enter a valid telephone area code");
                    InputPhoneInfo(contactPhone);
                }
            }

            if (contactPhone.Phone == 0)
            {
                Console.Write("Phone: ");
                if (Int32.TryParse(Console.ReadLine(), out int phone))
                    contactPhone.Phone = phone;
                else
                {
                    Console.WriteLine("Incorrect format enter a valid phone number");
                    InputPhoneInfo(contactPhone);
                }
            }


            if (contactPhone.TypesPhone == 0)
            {
                Console.WriteLine("Type: ");
                Console.WriteLine(@"
    1- Home
    2- Work
    3- Mobile
");
                if (Int32.TryParse(Console.ReadLine(), out int typesPhone))
                    contactPhone.TypesPhone = (TypesPhone)typesPhone;
                else
                {
                    Console.WriteLine("Incorrect format!");
                    InputPhoneInfo(contactPhone);
                }
            }

            return contactPhone;
        }

        public void EditContact()
        {
            CheckIsEmpty();
            Contact[] contacts = GetContactsByNamePhone();
            int position = 0;

            if (contacts.Length > 1)
            {
                Console.WriteLine("Type the number of the contact you wish to edit");
                position = int.Parse(Console.ReadLine());
            }

            agenda.Pop(contacts[0].Id);
            Console.WriteLine(agenda.Push(InputInfo(new Contact())).ToString());

            Console.WriteLine("Contact was successfully edited");
        }

        public void RemoveContact()
        {
            CheckIsEmpty();

            Contact[] contacts = GetContactsByNamePhone();

            if (contacts[0] == null)
            {
                Console.WriteLine("Contact not found");
                RemoveContact();
            }

            Console.WriteLine("Do you want to remove this contact? y/n");
            bool confirm = Console.ReadLine() == "y" ? true : false;

            if (confirm && contacts[1] == null)
            {
                agenda.Pop(contacts[0].Id);

                Console.WriteLine("The contact was removed");
            }
            else if (!confirm)
                RemoveContact();

        }


        public void CheckIsEmpty()
        {
            if (agenda.IsEmpty())
            {
                Console.WriteLine("Empty Agenda. Add a contact first");
                Program.BackMenu();
            }
        }
    }
}
