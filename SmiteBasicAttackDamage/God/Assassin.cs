using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SmiteBasicAttackDamage
{
    class Assassin : God
    {
        public Assassin()
        {
            TypeOfDamage = "Physical";
        }
        public override void SetListOfItems(ListBox listOfItems)
        {
            var list = new List<Item>();
            list.AddRange(SQLiteDataAccess.LoadItemTable("SharedItems"));
            list.AddRange(SQLiteDataAccess.LoadItemTable("Physical"));
            list.AddRange(SQLiteDataAccess.LoadItemTable("Assassin"));
            listOfItems.ItemsSource = list;
        }
    }
}
