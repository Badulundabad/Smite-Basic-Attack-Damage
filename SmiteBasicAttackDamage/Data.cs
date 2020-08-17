using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Net;

namespace SmiteBasicAttackDamage
{
    class Data : INotifyPropertyChanged
    {

        readonly static God zeroGod = new God();
        readonly static Item zeroItem = new Item();

        static Item[] listOfPhysicalItems = new Item[114];
        static Item[] listOfMagicalItems = new Item[114];

        static ObservableCollection<Item> sixItemsOfAttacker = new ObservableCollection<Item> { zeroItem, zeroItem, zeroItem, zeroItem, zeroItem, zeroItem};
        static Characteristic characteristics_attacker = new Characteristic();
        static ObservableCollection<God> currentAttacker = new ObservableCollection<God> { new God() };
        static Item resultingItemOfAttacker = new Item();

        static ObservableCollection<Item> sixItemsOfTarget = new ObservableCollection<Item> { zeroItem, zeroItem, zeroItem, zeroItem, zeroItem, zeroItem };
        static Characteristic characteristics_target = new Characteristic();
        static ObservableCollection<God> currentTarget = new ObservableCollection<God> { new God() };
        static Item resultingItemOfTarget = new Item();

        static public Characteristic Characteristics_Attacker
        {
            get
            {
                return characteristics_attacker;
            }
            set
            {
                characteristics_attacker = value;
            }
        }
        static public Characteristic Characteristics_Target
        {
            get
            {
                return characteristics_target;
            }
            set
            {
                characteristics_target = value;
            }
        }
        static public God ZeroGod
        {
            get
            {
                return zeroGod;
            }
        }
        static public Item ZeroItem
        {
            get
            {
                return zeroItem;
            }
        }
        
        static public ObservableCollection<God> CurrentAttacker { 
            get => currentAttacker; 
            set
            {
                currentAttacker = value;
            }
        }
        static public ObservableCollection<God> CurrentTarget
        {
            get => currentTarget;
            set
            {
                currentTarget = value;
            }
        }
        internal static Item[] ListOfPhysicalItems { get => listOfPhysicalItems; set => listOfPhysicalItems = value; }
        internal static Item[] ListOfMagicalItems { get => listOfMagicalItems; set => listOfMagicalItems = value; }
        internal static ObservableCollection<Item> SixItemsOfAttacker { get => sixItemsOfAttacker; set => sixItemsOfAttacker = value; }
        internal static Item ResultingItemOfAttacker { get => resultingItemOfAttacker; set => resultingItemOfAttacker = value; }
        internal static Item ResultingItemOfTarget { get => resultingItemOfTarget; set => resultingItemOfTarget = value; }
        internal static ObservableCollection<Item> SixItemsOfTarget { get => sixItemsOfTarget; set => sixItemsOfTarget = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
