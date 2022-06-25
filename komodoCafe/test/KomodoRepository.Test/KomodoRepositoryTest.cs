using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


    public class KomodoRepositoryTest
    {
        private readonly MenuRepository _mRepo;
        private Menu _menu;
        
        public MenuRepository()
        {
        _mRepo = new MenuRepository();
        _menu = new Menu(5, "Bacon Cheeseburger", "Single cheeseburger topped with cheese and crispy bacon", "Bun, 1/4 Quarter Pound Burger, Mild Cheddar Slice, Applewood Smoked Bacon", 10.50);
        _mRepo.AddMenuItemToDB(_menu);
        }

        [Fact]
        public void AddMenuItemToDB_ShouldReturnTrue()
        {
            var menuItem = new Menu(5, "Bacon Cheeseburger", "Single cheeseburger topped with cheese and crispy bacon", "Bun, 1/4 Quarter Pound Burger, Mild Cheddar Slice, Applewood Smoked Bacon", 10.50);
            var expectingTrue = _mRepo.AddMenuItemToDB(menuItem);
            Assert.True(expectingTrue);
        }
    }
