﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    class AddressBookMain
    {
        // constants
        const int LAST_NAME = 1, ADDRESS = 2, CITY = 3, STATE = 4, ZIP = 5, PHONE_NUMBER = 6, EMAIL = 7;

        private List<Contact> contactList;
        private List<Contact> cityList;
        private List<Contact> stateList;
        public AddressBookMain()
        {
            this.contactList = new List<Contact>();
        }
        public void AddContactDetails(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNumber, string email, Dictionary<string, List<Contact>> stateDictionary, Dictionary<string, List<Contact>> cityDictionary)
        {
            Contact contact = this.contactList.Find(x => x.firstName.Equals(firstName));
            if (contact == null)
            {
                Contact contactDetails = new Contact(firstName, lastName, address, city, state, zipCode, phoneNumber, email);
                this.contactList.Add(contactDetails);
                if (!cityDictionary.ContainsKey(city))
                {

                    cityList = new List<Contact>();
                    cityList.Add(contactDetails);
                    cityDictionary.Add(city, cityList);
                }
                else
                {
                    List<Contact> cities = cityDictionary[city];
                    cities.Add(contactDetails);
                }
                if (!stateDictionary.ContainsKey(state))
                {

                    stateList = new List<Contact>();
                    stateList.Add(contactDetails);
                    stateDictionary.Add(state, stateList);
                }
                else
                {
                    List<Contact> states = stateDictionary[state];
                    states.Add(contactDetails);
                }
            }
            else
            {
                Console.WriteLine("Person, {0} is already exist in the address book", firstName);
            }
        }
        public void DisplayContact()
        {
            foreach (Contact data in this.contactList)
            {
                data.Display();
            }
        }
        public void EditContact(string name)
        {
            Console.WriteLine("Enter your choice:");
            Console.WriteLine("1. Last Name");
            Console.WriteLine("2. Address");
            Console.WriteLine("3. City");
            Console.WriteLine("4. State");
            Console.WriteLine("5. Zip");
            Console.WriteLine("6. Phone Number");
            Console.WriteLine("7. Email");
            int choice = Convert.ToInt32(Console.ReadLine());
            foreach (Contact data in this.contactList)
            {
                if (data.firstName.Equals(name))
                {
                    switch (choice)
                    {
                        case LAST_NAME:
                            data.lastName = Console.ReadLine();
                            Console.WriteLine("Data updated successfully");
                            break;
                        case ADDRESS:
                            data.address = Console.ReadLine();
                            Console.WriteLine("Data updated successfully");
                            break;
                        case CITY:
                            data.city = Console.ReadLine();
                            Console.WriteLine("Data updated successfully");
                            break;
                        case STATE:
                            data.state = Console.ReadLine();
                            Console.WriteLine("Data updated successfully");
                            break;
                        case ZIP:
                            data.zipCode = Console.ReadLine();
                            Console.WriteLine("Data updated successfully");
                            break;
                        case PHONE_NUMBER:
                            data.phoneNumber = Console.ReadLine();
                            Console.WriteLine("Data updated successfully");
                            break;
                        case EMAIL:
                            data.email = Console.ReadLine();
                            Console.WriteLine("Data updated successfully");
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public void DeleteContact(string name)
        {
            foreach (Contact contact in this.contactList)
            {
                if (contact.firstName.Equals(name))
                {
                    this.contactList.Remove(contact);
                    Console.WriteLine("Contact Deleted Successfully");
                    break;
                }
            }
        }
        public static void DisplayPerson(Dictionary<string, AddressBookMain> addressDictionary)
        {
            List<Contact> list = null;
            string name;
            Console.WriteLine("Enter City or State name");
            name = Console.ReadLine();
            foreach (var data in addressDictionary)
            {
                AddressBookMain address = data.Value;
                list = address.contactList.FindAll(x => x.city.Equals(name) || x.state.Equals(name));
                if (list.Count > 0)
                {
                    DisplayList(list);
                }
            }
            if (list == null)
            {
                Console.WriteLine("No person present in the address book with same city or state name");
            }
        }
        public static void DisplayList(List<Contact> list)
        {
            foreach (var data in list)
            {
                data.Display();
            }
        }
        public static void PrintList(Dictionary<string, List<Contact>> dictionary)
        {
            foreach (var data in dictionary)
            {
                Console.WriteLine("Details of person in {0}", data.Key);
                foreach (var person in data.Value)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", person.firstName, person.lastName, person.address,
                                                                   person.city, person.state, person.zipCode, person.phoneNumber, person.email);
                }
                Console.WriteLine("-----------------------------");
            }
        }
        public static void CountPerson(Dictionary<string, List<Contact>> dictionary)
        {
            foreach (var person in dictionary)
            {
                Console.WriteLine("Number of person {0}:", person.Value.Count);
            }
        }

        public static void SortData(Dictionary<string, List<Contact>> dictionary)
        {
            List<Contact> list = new List<Contact>();
            foreach (var data in dictionary)
            {
                foreach (var item in data.Value)
                {
                    list.Add(item);
                }
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("\nDisplaying the list based on zipcode");
            foreach (var item in list.OrderBy(detail => detail.zipCode))
            {
                item.Display();
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("\nDisplaying the list based on state");
            foreach (var item in list.OrderBy(detail => detail.state))
            {
                item.Display();
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("\nDisplaying the list based on city");
            foreach (var item in list.OrderBy(detail => detail.city))
            {
                item.Display();
            }
        }
    }
}