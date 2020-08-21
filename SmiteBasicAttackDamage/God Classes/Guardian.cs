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
            return SQLiteDataAccess.LoadTheSetOfTables<Item>(new string[] { "SharedItems", "Magical", "Guardian" }); ;
        }
    }
}
