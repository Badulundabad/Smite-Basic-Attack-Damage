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
        static God zeroGod = new God(0, "G o d", "/Images/God/Preview/fullLogo.png", null, "PhysicalProtections", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        static God[] currentGod = new God[1] { zeroGod };


        static Item zeroItem = new Item(0, 0, 0, null, "/Images/logo.png", null, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        static Item[] itemsOfCurrentGod = new Item[6] { zeroItem, zeroItem, zeroItem, zeroItem, zeroItem, zeroItem};
        static Item[] itemsOfTarget = new Item[6] { zeroItem, zeroItem, zeroItem, zeroItem, zeroItem, zeroItem };

        

        static public God ZeroGod
        {
            get
            {
                return zeroGod;
            }
        }

        static public God[] CurrentGod { 
            get => currentGod; 
            set
            {
                currentGod = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
