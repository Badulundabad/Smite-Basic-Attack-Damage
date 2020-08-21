using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmiteBasicAttackDamage
{
    class Ratatoskr : God
    {
        public Ratatoskr()
        {
            TypeOfDamage = "Physical";
        }
        public override List<Item> GetListOfItems()
        {
            return SQLiteDataAccess.LoadTheSetOfTables<Item>(new string[] { "Acorns", "Physical", "Assassin", "SharedItems" });
        }
    }
}
