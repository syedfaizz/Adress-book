﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    class AddressManagement
    {

        static Dictionary<string, AddressBookMain> addressDictionary = new Dictionary<string, AddressBookMain>();
        static Dictionary<string, List<Contact>> cityDictionary = new Dictionary<string, List<Contact>>();
        static Dictionary<string, List<Contact>> stateDictionary = new Dictionary<string, List<Contact>>();
        public static void ReadInput()
        {
            AddressBookMain addressBookMain;
            // variables
            bool CONTINUE = true;
            //// the loop continues until the user exit.
            while (CONTINUE)
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1.Add Address Book");
                Console.WriteLine("2.Add Contacts");
                Console.WriteLine("3.Display");
                Console.WriteLine("4.Edit Details");
                Console.WriteLine("5.Delete Contact");
                Console.WriteLine("6.Delete the address book");
                Console.WriteLine("7.Display person by city or state name");
                Console.WriteLine("8.View person by city or state");
                Console.WriteLine("9.Count person by city or state");
                Console.WriteLine("10.Sort the Address book");
                Console.WriteLine("11.Sort by state city or zip");
                Console.WriteLine("0.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter address book name:");
                        string addBookName = Console.ReadLine();
                        AddressBookMain addressBook1 = new AddressBookMain();
                        addressDictionary.Add(addBookName, addressBook1);
                        break;
                    case 2:
                        AddDetails(AddressManagement.BookName(addressDictionary), cityDictionary, stateDictionary);
                        break;
                    case 3:
                        addressBookMain = AddressManagement.BookName(addressDictionary);
                        addressBookMain.DisplayContact();
                        break;
                    case 4:
                        addressBookMain = AddressManagement.BookName(addressDictionary);
                        Console.WriteLine("Enter the first name of person");
                        string name = Console.ReadLine();
                        addressBookMain.EditContact(name);
                        break;
                    case 5:
                        addressBookMain = AddressManagement.BookName(addressDictionary);
                        string firstName = Console.ReadLine();
                        addressBookMain.DeleteContact(firstName);
                        break;
                    case 6:
                        Console.WriteLine("Enter address book name to delete");
                        string addressBook = Console.ReadLine();
                        addressDictionary.Remove(addressBook);
                        break;
                    case 7:
                        AddressBookMain.DisplayPerson(addressDictionary);
                        break;
                    case 8:
                        AddressBookMain.PrintList(cityDictionary);
                        AddressBookMain.PrintList(stateDictionary);
                        break;
                    case 9:
                        Console.WriteLine("City");
                        AddressBookMain.CountPerson(cityDictionary);
                        Console.WriteLine("State");
                        AddressBookMain.CountPerson(stateDictionary);
                        break;
                    case 10:
                        Console.WriteLine("AddressBook after sorting");
                        foreach (var data in addressDictionary.OrderBy(x => x.Key))
                        {
                            Console.WriteLine("{0}", data.Key);
                        }
                        break;
                    case 11:
                        AddressBookMain.SortData(cityDictionary);
                        break;
                    case 0:
                        CONTINUE = false;
                        Console.WriteLine("Thank you for using Address Book System!");
                        break;
                    default:
                        break;
                }
            }
        }
        public static void AddDetails(AddressBookMain addressBookMain, Dictionary<string, List<Contact>> cityDictionary, Dictionary<string, List<Contact>> stateDictionary)
        {
            Console.WriteLine("Enter first Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Zipcode");
            string zipCode = Console.ReadLine();
            Console.WriteLine("Enter Phone Number");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            addressBookMain.AddContactDetails(firstName, lastName, address, city, state, zipCode, phoneNumber, email, cityDictionary, stateDictionary);
        }
        public static AddressBookMain BookName(Dictionary<string, AddressBookMain> addBook)
        {
            addressDictionary = addBook;
            Console.WriteLine("Enter address book name:");
            string name = Console.ReadLine();
            AddressBookMain address = addressDictionary[name];
            return address;
        }
    }
}