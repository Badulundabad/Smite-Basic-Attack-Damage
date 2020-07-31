using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Smite_Auto_Attack_Damage 
{
    class Data : INotifyPropertyChanged
    {
        readonly static God zeroGod = new God(0, "G o d", "/Images/God/Preview/fullLogo.png", null, "Physical", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        static ObservableCollection<God> currentAttacker = new ObservableCollection<God> { zeroGod };

        readonly static Item zeroItem = new Item(0, 0, 0, null, "/Images/logo.png", null, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        static Item[] listOfPhysicalItems = new Item[114];
        static Item[] listOfMagicalItems = new Item[114];

        static ObservableCollection<Item> sixItems_attacker = new ObservableCollection<Item> { zeroItem, zeroItem, zeroItem, zeroItem, zeroItem, zeroItem};
        static Characteristic characteristics_attacker = new Characteristic();

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
        
        static public ObservableCollection<God> CurrentAttacker { 
            get => currentAttacker; 
            set
            {
                currentAttacker = value;
            }
        }

        internal static Item[] ListOfPhysicalItems { get => listOfPhysicalItems; set => listOfPhysicalItems = value; }
        internal static Item[] ListOfMagicalItems { get => listOfMagicalItems; set => listOfMagicalItems = value; }
        internal static ObservableCollection<Item> SixItems_attacker { get => sixItems_attacker; set => sixItems_attacker = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
