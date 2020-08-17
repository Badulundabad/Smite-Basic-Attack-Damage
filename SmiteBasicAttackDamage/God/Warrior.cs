﻿using System;
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
        public override void SetListOfItems(ListBox listOfItems)
        {
            var list = new List<Item>();
            list.AddRange(SQLiteDataAccess.LoadItemTable("SharedItems"));
            list.AddRange(SQLiteDataAccess.LoadItemTable("Physical"));
            list.AddRange(SQLiteDataAccess.LoadItemTable("Warrior"));
            listOfItems.ItemsSource = list;
        }
    }
}