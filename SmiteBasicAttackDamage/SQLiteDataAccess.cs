using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmiteBasicAttackDamage
{
    public class SQLiteDataAccess
    {
        public static List<T> LoadGodTable<T>()
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                var output = connection.Query<T>($"select * from {typeof(T).Name}s", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<Item> LoadItemTable(string parameter)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString("Items")))
            {
                var output = connection.Query<Item>($"select * from {parameter}", new DynamicParameters());
                return output.ToList();
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        public static ObservableCollection<God> LoadGods()
        {
            var list = new List<God>();
            list.AddRange(LoadGodTable<Hunter>());
            list.AddRange(LoadGodTable<Guardian>());
            list.AddRange(LoadGodTable<Assassin>());
            list.AddRange(LoadGodTable<Mage>());
            list.AddRange(LoadGodTable<Warrior>());
            return new ObservableCollection<God>(list.OrderBy(god => god.Name));
        }
    }
}
