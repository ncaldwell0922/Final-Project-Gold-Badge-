using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Program_UI
{
    private readonly MenuRepository _mRepo = new MenuRepository();

    public void Run()
    {
        SeedData();
        RunApplication();
    }

    private void SeedData()
    {
        Menu item1 = new Menu (1, "Classic", "Simple Hamburger", "Sesame Bun, 1/4lb Hamburger, Onion, Ketchup, Mustard", 5.50);
        Menu item2 = new Menu (2, "Cheezy Classic", "Simple Cheeseburger", "Sesame Bun, 1/4lb Hamburger, Cheddar Cheese, Onion, Ketchup, Mustard", 6.50);
        Menu item3 = new Menu (3, "Classic Deluxe", "Loaded Hamburger", "Sesame Bun, 1/2lb Hamburger, Lettuce, Tomatoes, Pickle, Onion, Ketchup, Mustard, Mayo", 9.50);
        Menu item4 = new Menu (4, "Cheezy Classic Deluxe", "Loaded Cheeseburger", "Sesame Bun, 1/2lb Hamburger, Cheddar Cheese, Lettuce, Tomato, Pickle, Onion, Ketchup, Mustard, Mayo", 10.50);
        Menu item5 = new Menu (5, "Classic Chicken", "Fried Chicken Sandwich", "Brioche Bun, Breaded Chicken Thigh, Pickle, Mayo", 8.50);
        Menu item6 = new Menu (6, "Spicy Classic Chicken", "Spicy Fried Chicken Sandwich", "Brioche Bun, Breaded Chicken Thigh, Pepper Jack Cheese, Pickle, Chipotle Mayo", 9.50);
        Menu item7 = new Menu (7, "Fries", "Steak Fries", "Potatoes, Fry Seasoning", 3.50);

        _mRepo.AddMenuItemToDB(item1);
        _mRepo.AddMenuItemToDB(item2);
        _mRepo.AddMenuItemToDB(item3);
        _mRepo.AddMenuItemToDB(item4);
        _mRepo.AddMenuItemToDB(item5);
        _mRepo.AddMenuItemToDB(item6);
        _mRepo.AddMenuItemToDB(item7);

    }

    public void RunApplication()
    {
        bool isRunning = true;

        while(isRunning)
        {
            Console.Clear();

            System.Console.WriteLine("\tKomodo Cafe \n" +
            "===================== \n" +
            "Please make a selection: \n" +
            "1. Add a Menu Item \n" +
            "2. Delete a Menu Item \n" +
            "3. See All Menu Items \n" +
            "===================== \n" +
            "X. Close Application");

            string userInput = Console.ReadLine();

            switch(userInput.ToLower())
            {
                case "1":
                    AddMenuItem();
                    break;
                case "2":
                    DeleteMenuItem();
                    break;
                case "3":
                    ViewAllMenuItems();
                    break;
                case "x":
                    CloseApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection");
                    break;
                
            }
        }
    }

    private void AddMenuItem()
    {
        Console.Clear();
        Menu menuItem = new Menu();

        System.Console.WriteLine("Please enter the number for your Menu Item: ");
        menuItem.MealNumber = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Enter a name for your Menu Item: ");
        menuItem.MealName = Console.ReadLine();

        System.Console.WriteLine("Enter a description for your Menu Item: ");
        menuItem.Description = Console.ReadLine();

        System.Console.WriteLine("Enter the ingredients for your Menu Item: ");
        menuItem.Ingredients = Console.ReadLine();

        System.Console.WriteLine("Enter the price for your Menu Item: ");
        menuItem.Price = double.Parse(Console.ReadLine());

        bool isSuccessful = _mRepo.AddMenuItemToDB(menuItem);
        if(isSuccessful)
        {
            System.Console.WriteLine($"Your Menu Item Number {menuItem.MealNumber} named {menuItem.MealName} has been added!");
        }
        else
        {
            System.Console.WriteLine("Your Menu Item was not added to the database.");
        }

        PressAnyKey();
    }

    private void ViewAllMenuItems()
    {
        Console.Clear();

        System.Console.WriteLine("***Current Menu Items***");
        var menuItemsInDB = _mRepo.GetAllMenuItems();
        foreach(Menu m in menuItemsInDB)
        {
            DisplayCurrentMenuItems(m);
        }

        PressAnyKey();
    }

    private void DisplayCurrentMenuItems(Menu menu)
    {
        System.Console.WriteLine($"Menu Item Number: {menu.MealNumber} \nMenu Item Name: {menu.MealName} \nDescription: {menu.Description} \nIngredients: {menu.Ingredients} \nPrice: {menu.Price} \n");
    }

    private void DeleteMenuItem()
    {
        Console.Clear();

        System.Console.WriteLine("***Remove Menu Item***");
        var menuItems = _mRepo.GetAllMenuItems();
        foreach(Menu m in menuItems)
        {
            DisplayCurrentMenuItems(m);
        }

        try
        {
            System.Console.WriteLine("Please select an item by their number: \n");
            int selectedItem = int.Parse(Console.ReadLine());
            bool isSuccessful = _mRepo.RemoveMenuItemFromDB(selectedItem);
            
            if(isSuccessful)
            {
                System.Console.WriteLine("Menu Item was removed!");
            }
            else
            {
                System.Console.WriteLine("Menu Item could not be removed at this time.");
            }
        }
        catch
        {
            System.Console.WriteLine("Invalid Input");
        }

        PressAnyKey();
    }

    private void PressAnyKey()
    {
        System.Console.WriteLine("Press ANY key to continue...");
        Console.ReadLine();
    }

    private void CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Good-bye!");
        PressAnyKey();
        Environment.Exit(0);
    }
}