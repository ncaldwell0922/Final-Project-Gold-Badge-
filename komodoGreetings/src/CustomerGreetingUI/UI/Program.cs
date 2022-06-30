using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Program_UI
{
    private readonly CustomerRepository _cRepo = new CustomerRepository();

    public void Run()
    {
        SeedData();
        RunApplication();
    }
    
    private void SeedData()
    {
        Customer jack = new Customer("Jack", "Sparrow", CustomerType.Current);
        Customer james = new Customer("James", "Bond", CustomerType.Current);
        Customer kim = new Customer("Kim", "Possible", CustomerType.Potential);
        Customer tommy = new Customer("Tommy", "Pickles", CustomerType.Potential);
        Customer rick = new Customer("Rick", "Sanchez", CustomerType.Current);
        Customer abe = new Customer("Abraham", "Lincoln", CustomerType.Past);
        Customer anakin = new Customer("Anakin", "Skywalker", CustomerType.Potential);
        Customer buffy = new Customer("Buffy", "Summers", CustomerType.Current);
        Customer scarlett = new Customer("Scarlett", "O'Hara", CustomerType.Past);
        Customer ellen = new Customer("Ellen", "Ripley", CustomerType.Current);
        Customer tony = new Customer("Tony", "Montana", CustomerType.Past);
        Customer jules = new Customer("Jules", "Winnfield", CustomerType.Current);
        Customer mario = new Customer("Mario", "Mario", CustomerType.Current);
        Customer spongebob = new Customer("Spongebob", "Squarepants", CustomerType.Current);
        Customer harry = new Customer("Harry", "Potter", CustomerType.Potential);
        

        _cRepo.AddCustomer(jack);
        _cRepo.AddCustomer(james);
        _cRepo.AddCustomer(kim);
        _cRepo.AddCustomer(tommy);
        _cRepo.AddCustomer(rick);
        _cRepo.AddCustomer(abe);
        _cRepo.AddCustomer(anakin);
        _cRepo.AddCustomer(buffy);
        _cRepo.AddCustomer(scarlett);
        _cRepo.AddCustomer(ellen);
        _cRepo.AddCustomer(tony);
        _cRepo.AddCustomer(jules);
        _cRepo.AddCustomer(mario);
        _cRepo.AddCustomer(spongebob);
        _cRepo.AddCustomer(harry);
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while(isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("*** KOMODO EMAIL GREETINGS *** \n" +
            " \n" +
            "What would you like to do? \n" +
            "1. Add A New Customer \n" +
            "2. Update A Customer \n" +
            "3. Delete A Customer \n" +
            "4. See All Customers \n" +
            "5. Exit Application");

            string userInput = Console.ReadLine();
            switch(userInput)
            {
                case "1":
                    AddACustomerToDB();
                    break;
                case "2":
                    UpdateCustomer();
                    break;
                case "3":
                    DeleteCustomer();
                    break;
                case "4":
                    SeeAllCustomers();
                    break;
                case "5":
                    CloseApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid Input");
                    PressAnyKey();
                    break;
            }
        }
    }

    private void AddACustomerToDB()
    {
        Console.Clear();
        
        var newCustomer = new Customer();
        System.Console.WriteLine("*** ADD NEW CUSTOMER PAGE ***");

        System.Console.WriteLine("Please enter Customer's first name: ");
        newCustomer.FirstName = Console.ReadLine();

        System.Console.WriteLine("Please enter Customer's last name: ");
        newCustomer.LastName = Console.ReadLine();
        
        newCustomer.TypeOfCustomer = CustomerTypeSelection(newCustomer);

        bool isSuccessful = _cRepo.AddCustomer(newCustomer);
        if(isSuccessful)
        {
            System.Console.WriteLine($"Customer {newCustomer.FirstName} {newCustomer.LastName} was added to the email list.");
        }
        else
        {
            System.Console.WriteLine("Failed to add customer.");
        }
    }

    private void UpdateCustomer()
    {
        Console.Clear();

        System.Console.WriteLine("*** CUSTOMER UPDATE ***");
        var currentCustomers = _cRepo.GetAllCustomers();
        foreach(Customer c in currentCustomers)
        {
            DisplayCustomerInfo(c);
        }

        System.Console.WriteLine("Please enter Customer First and Last Name that you would like to update:");
        string userSelection = Console.ReadLine().ToUpper();
        var userSelectedCustomer = _cRepo.UpdateCustomer(userSelection);

        if(userSelectedCustomer != null)
        {
            Console.Clear();

            Customer newCustomer = new Customer();

            System.Console.WriteLine("Enter First Name: ");
            newCustomer.FirstName = Console.ReadLine();

            System.Console.WriteLine("Enter Last Name: ");
            newCustomer.LastName = Console.ReadLine();

            newCustomer.TypeOfCustomer = CustomerTypeSelection(newCustomer);

            bool isSuccessful = _cRepo.UpdateCustomer(userSelectedCustomer);
            if(isSuccessful)
            {
                System.Console.WriteLine($"{newCustomer.FirstName} {newCustomer.LastName} has been updated!");
            }
            else
            {
                System.Console.WriteLine($"{userSelectedCustomer} was not updated.");
            }
        }
        PressAnyKey();
    }

    private void DeleteCustomer()
    {
        Console.Clear();
        System.Console.WriteLine("*** CUSTOMER REMOVAL ***");
        var customer = _cRepo.GetAllCustomers();

        foreach(Customer c in customer)
        {
            DisplayCustomerInfo(c);
        }

        try
        {
            System.Console.WriteLine("Select a customer by First and Last Name:");
            string selectedCustomer = Console.ReadLine().ToUpper();
            bool isSuccessful = _cRepo.DeleteCustomer(selectedCustomer);

            if(isSuccessful)
            {
                System.Console.WriteLine("Customer was removed from email list.");
            }
            else
            {
                System.Console.WriteLine("Customer failed to be removed from list.");
            }
        }
        catch
        {
            System.Console.WriteLine("Invalid Input");
        }
        PressAnyKey();
    }

    private void SeeAllCustomers()
    {
        Console.Clear();
        System.Console.WriteLine("*** ALL CUSTOMER DISPLAY ***");
        var customersInDB = _cRepo.GetAllCustomers();
        foreach(Customer c in customersInDB)
        {
            DisplayCustomerInfo(c);
        }
        PressAnyKey();
    }

    private void CustomerTypeSelection()
    {
        System.Console.WriteLine("Select the type of Customer: \n" +
        "1. Potenial \n" +
        "2. Current \n" +
        "3. Past");

        string userTypePick = Console.ReadLine();
        switch(userTypePick)
        {
            case "1":
                return CustomerType.Potential;
            case "2":
                return CustomerType.Current;
            case "3":
                return CustomerType.Past;
            default:
                System.Console.WriteLine("Invalid Input. Customer set as Undefined.");
                return CustomerType.Potential;
        }
        
    }

    private void DisplayCustomerInfo(Customer customer)
    {
        System.Console.WriteLine($"{customer.FirstName}       {customer.LastName}     {customer.TypeOfCustomer}      {customer.Email}");
    }

    private void PressAnyKey()
    {
        System.Console.WriteLine("Press ANY key to continue...");
        Console.ReadLine();
        RunApplication();
    }

    private void PressAnyKeyTwo()
    {
        System.Console.WriteLine("Press ANY key to exit...");
        Console.ReadLine();
    }


    private void CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Good-bye!");
        PressAnyKeyTwo();
        Environment.Exit(0);
    }
}
