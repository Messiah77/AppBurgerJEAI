
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
            int result = conn.Insert(burger);
            return result;
        }
        public List<Burger> GetAllBurgers()
        {
            Init();
            List<Burger> burgers = conn.Table<Burger>().ToList();
            return burgers;
        }

        public int DeleteItem(Burger item)
        {
            Init();
            int result = conn.Delete(item);
            return result;
        }

        public int  UpdateUser(Burger item)
        {
            Init();
            int result = 0;
            result = conn.Update(item);
            return result;
        }
        public Burger GetBurguer(int id)
        {
            Burger aux = new Burger();
            Init();
            List<Burger> burguers = conn.Table<Burger>().ToList();
            foreach (Burger aux1 in burguers)
            {
                if (aux1.Id == id)
                    aux = aux1;
            }
            return aux;
        }
    }
}
