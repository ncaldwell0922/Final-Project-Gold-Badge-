using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class CustomerRepository
{
    private readonly List<Customer> _customerDatabase = new List<Customer>();
    private int _count;

    public bool AddCustomer(Customer customer)
    {
        if(customer != null)
        {
            _count++;
            customer.LastName = _count;
            _customerDatabase.Add(customer);
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<Customer> GetAllCustomers()
    {
        return _customerDatabase;
    }

    public Customer GetCustomerByLastName(string lastName)
        {
            foreach(Customer c in _customerDatabase) 
            {
                if(c.LastName == lastName)
                {
                    return c; 
                }
            }

            return null; 
        }

    public bool UpdateCustomer(string lastName, Customer newCustomer)
        {
            var oldCustomer = GetCustomerByLastName(lastName); // Using the "Find One" method to locate and store it's returned value (Store) in our variable.

            if(oldCustomer != null)
            {
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.TypeOfCustomer = newCustomer.TypeOfCustomer;
                
                return true;
            }
            else
            {
                return false;
            }
        }

    public bool DeleteCard(string lastName)
        {
                System.Console.WriteLine(lastName);
                Customer customerToDelete = _customerDatabase.FirstOrDefault(c => c.LastName == lastName);
                return _customerDatabase.Remove(customerToDelete);
        }
}
