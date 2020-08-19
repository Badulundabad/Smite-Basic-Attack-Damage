using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SmiteBasicAttackDamage
{
    class Guardian : God
    {
        public Guardian()
        {
            TypeOfDamage = "Magical";
        }
        public override List<Item> GetListOfItems()
        {
            var list = new List<Item>();
            list.AddRange(SQLiteDataAccess.LoadItemTable("SharedItems"));
            list.AddRange(SQLiteDataAccess.LoadItemTable("Magical"));
            list.AddRange(SQLiteDataAccess.LoadItemTable("Guardian"));
            return list;
        }
    }
}
