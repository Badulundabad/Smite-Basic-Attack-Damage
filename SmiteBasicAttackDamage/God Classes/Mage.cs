using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace SmiteBasicAttackDamage
{
    class Mage : God
    {
        public Mage()
        {
            TypeOfDamage = "Magical";
        }
        public override List<Item> GetListOfItems()
        {
            return SQLiteDataAccess.LoadTheSetOfTables<Item>(new string[] { "SharedItems", "Magical", "Mages" }); ;

        }
    }
}
