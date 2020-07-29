using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Smite_Auto_Attack_Damage
{
    public class Characteristic : INotifyPropertyChanged
    {
        int power = 0;
        double attackSpeed = 0;
        int health = 0;
        int mana = 0;
        int magicalProtections = 0;
        int physicalProtection = 0;
        int baseDamage = 0;
        string penetration = "0 / 0";
        static Characteristic attacker = new Characteristic();

        
        public int BaseDamage
        {
            get
            {
                return baseDamage;
            }
            set
            {
                if (value >= 0)
                {
                    baseDamage = value;
                    OnPropertyChanged("BaseDamage");
                }
            }
        }
        public int PhysicalProtections
        {
            get
            {
                return physicalProtection;
            }
            set
            {
                if (value >= 0)
                {
                    physicalProtection = value;
                    OnPropertyChanged("PhysicalProtections");
                }
            }
        }
        public string Penetration
        {
            get
            {
                return penetration;
            }
            set
            {
                if (value != null)
                {
                    penetration = value;
                    OnPropertyChanged("Penetration");
                }
            }
        }
        public double AttackSpeed
        {
            get
            {
                return attackSpeed;
            }
            set
            {
                if ( value >= 0)
                {
                    attackSpeed = value;
                    OnPropertyChanged("AttackSpeed");
                }
            }
        }

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value >= 0)
                {
                    health = value;
                    OnPropertyChanged("Health");
                }
            }
        }
        public int Mana
        {
            get
            {
                return mana;
            }
            set
            {
                if (value >= 0)
                {
                    mana = value;
                    OnPropertyChanged("Mana");
                }
            }
        }
        public int MagicalProtections
        {
            get
            {
                return magicalProtections;
            }
            set
            {
                if (value >= 0)
                {
                    magicalProtections = value;
                    OnPropertyChanged("MagicalProtections");
                }
            }
        }
        static public Characteristic Attacker
        {
            get
            {
                return attacker;
            }
            set
            {
                attacker = value;
            }
        }

        public int Power
        {
            get
            {
                return power;
            }
            set
            {
                if(value >= 0)
                {
                    power = value;
                    OnPropertyChanged("Power");
                }
            }
        }

       
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
