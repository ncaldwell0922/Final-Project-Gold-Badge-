
public class MenuRepository 
{
    private readonly List<Menu> _menuDataBase = new List<Menu>();
    private int _count = 0;
    public bool AddMenuItemToDB(Menu menuItem)
        {
            if(menuItem != null)
            {
                _count++;
                menuItem = _count;
                _menuDatabase.Add(menuItem);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Menu> GetAllMenuItems()
        {
            return _menuDatabase;
        }

        public Menu GetMenuItemByComboNumber(int MealNumber)
        {
            foreach(Menu m in _menuDataBase) 
            {
                if(m.MealNumber == mealNumber)
                {
                    return m; 
                }
            }

            return null; 
        }

        public bool RemoveMenuItemFromDB(int mealNumber)
        {
            var menuItem = GetMenuItemByComboNumber(mealNumber);

            if(menuItem != null)
            {
                _menuDataBase.Remove(menuItem);
                return true;
            }
            else
            {
                return false;
            }
        }

}
