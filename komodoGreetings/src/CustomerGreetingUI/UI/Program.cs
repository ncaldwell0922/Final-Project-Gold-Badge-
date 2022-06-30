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
    }

    private void UpdateCustomer()
    {

    }

    private void DeleteCustomer()
    {

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
