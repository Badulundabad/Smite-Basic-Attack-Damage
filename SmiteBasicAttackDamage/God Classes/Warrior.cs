using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace SmiteBasicAttackDamage
{
    class Warrior : God
    {
        public Warrior()
        {
            TypeOfDamage = "Physical";
        }
        public override List<Item> GetListOfItems()
        {
            return SQLiteDataAccess.LoadTheSetOfTables<Item>(new string[] { "PhysicalBoots", "SharedItems", "Physical", "Warrior" }); ;

        }
    }
}