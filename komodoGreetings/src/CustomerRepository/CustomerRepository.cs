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
            int startingCount = _customerDatabase.Count();
            _customerDatabase.Add(customer);
            bool wasAdded =(_customerDatabase.Count() > startingCount) ? true : false;

        return wasAdded;
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

    public Customer GetCustomerByFullName(string FullName)
    {
        foreach(Customer c in _customerDatabase) 
            {
                if(c.FullName == c.FullName)
                {
                    return c; 
                }
            }

        return null; 
    }

    public bool UpdateCustomer(Customer newCustomer)
        {
            var oldCustomer = GetCustomerByFullName(newCustomer.ToString()); 

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

    public bool DeleteCustomer(string firstName, string lastName)
        {
                System.Console.WriteLine(firstName, lastName);
                Customer customerToDelete = _customerDatabase.FirstOrDefault(c => c.LastName == lastName);
                return _customerDatabase.Remove(customerToDelete);
        }
}
