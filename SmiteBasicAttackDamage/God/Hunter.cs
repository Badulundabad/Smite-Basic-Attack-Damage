using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SmiteBasicAttackDamage
{
    public class Hunter : God
    {
        public Hunter()
        {
            TypeOfDamage = "Physical";
        }
        
        public override List<Item> GetListOfItems()
        {
            var list = new List<Item>();
            list.AddRange(SQLiteDataAccess.LoadItemTable("SharedItems"));
            list.AddRange(SQLiteDataAccess.LoadItemTable("Physical"));
            list.AddRange(SQLiteDataAccess.LoadItemTable("Hunter"));
            return list;
        }
    }
}
