using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Smite_Auto_Attack_Damage 
{
    class Calculation : INotifyPropertyChanged
    {
        static God zeroGod = new God(0, "G o d", "/Images/God/Preview/fullLogo.png", null, "Physical", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        static God[] currentAttacker = new God[1] { zeroGod };

        static int itemOfAttackerIndex = 0;
        static int itemOfTargetIndex = 0;

        static Item zeroItem = new Item(0, 0, 0, null, "/Images/logo.png", null, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        static Item[] itemsOfAttacker = new Item[6] { zeroItem, zeroItem, zeroItem, zeroItem, zeroItem, zeroItem};
        static Item[] itemsOfTarget = new Item[6] { zeroItem, zeroItem, zeroItem, zeroItem, zeroItem, zeroItem };

        static Item[] listOfPhysicalItems = new Item[114];
        static Item[] listOfMagicalItems = new Item[114];

        static Item[] zeroItemArray = new Item[6] { ZeroItem, ZeroItem, ZeroItem, ZeroItem, ZeroItem, ZeroItem };
        static Item[] sixItems_attacker = new Item[6];
        static Item[] sixItems_target = ZeroItemArray;

        static Characteristic characteristics_attacker = new Characteristic();
        public static int ItemOfAttackerIndex
        {
            get
            {
                return itemOfAttackerIndex;
            }
            set
            {
                if(value >= 0 && value <= 5)
                {
                    itemOfAttackerIndex = value;
                }
            }
        }

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
        
        static public God[] CurrentAttacker { 
            get => currentAttacker; 
            set
            {
                currentAttacker = value;
            }
        }

        internal static Item[] ListOfPhysicalItems { get => listOfPhysicalItems; set => listOfPhysicalItems = value; }
        internal static Item[] ListOfMagicalItems { get => listOfMagicalItems; set => listOfMagicalItems = value; }
        internal static Item[] ZeroItemArray { get => zeroItemArray; set => zeroItemArray = value; }
        internal static Item[] SixItems_attacker { get => sixItems_attacker; set => sixItems_attacker = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
