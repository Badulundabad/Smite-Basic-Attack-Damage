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
        public override void SetListOfItems(ListBox listOfItems)
        {
            var list = new List<Item>();
            list.AddRange(SQLiteDataAccess.LoadItemTable("SharedItems"));
            list.AddRange(SQLiteDataAccess.LoadItemTable("Magical"));
            list.AddRange(SQLiteDataAccess.LoadItemTable("Mages"));
            listOfItems.ItemsSource = list;
        }
    }
}
