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
            return SQLiteDataAccess.LoadTheSetOfTables<Item>(new string[] { "PhysicalBoots", "SharedItems", "Physical", "Hunter" }); ;
        }
    }
}
