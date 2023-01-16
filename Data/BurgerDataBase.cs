
using AppBurgerJEAI.Models;
using SQLite;


namespace AppBurgerJEAI.Data
{
    public class BurgerDataBase
    {
        string _dbPath;
        private SQLiteConnection conn;

        public BurgerDataBase(string DataBasePath)
        {
            _dbPath = DataBasePath;
        }
        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Burger>();
        }
        public int AddNewBurger(Burger burger)
        {
            Init();
            //int result = conn.Insert(burger);
            //return result;
            if(burger.Id != 0)
            {
                return conn.Update(burger);
            }
            else
            {
                return conn.Insert(burger);
            }
        }
        public List<Burger> GetAllBurgers()
        {
            Init();
            List<Burger> burgers = conn.Table<Burger>().ToList();
            return burgers;
        }
    }
}
