using Xunit;


public class KomodoCafeDataTest
{
    [Fact]
    public void CreateACombo()
    {
        Menu menus = new Menu(3, "Classic Cheeseburger", "The classic burger with cheese.", "Lettuce, Tomato, Pickle, Onion, Ketchup, Mustard, Mayo", 9.50);
        menus.MealNumber = 3;

        int expectedMenuNum = 3;
        int actualMenuNum = menus.MealNumber;

        Assert.Equal(expectedMenuNum, actualMenuNum);
    }
}