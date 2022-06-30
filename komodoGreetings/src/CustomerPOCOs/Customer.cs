
public class Customer
{
    public Customer(){}

    public Customer(
        string firstName,
        string lastName,
        CustomerType typeOfCustomer
    )
    {
        FirstName = firstName;
        LastName = lastName;
        TypeOfCustomer = typeOfCustomer;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public CustomerType TypeOfCustomer { get; set; }
    public string Email { 
        get
        {
            if(TypeOfCustomer == CustomerType.Current)
            {
                System.Console.WriteLine("Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
            }
            else if(TypeOfCustomer == CustomerType.Past)
            {
                System.Console.WriteLine("It's been a long time since we've heard from you, we want you back.");
            }
            else
            {
                System.Console.WriteLine("We currently have the lowest rates on Helicopter Insurance!");
            }
        }
    }
}
