using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace SmiteBasicAttackDamage
{
    public class Characteristic : INotifyPropertyChanged
    {
        double power = 0;
        double attackSpeed = 0;
        double health = 0;
        double mana = 0;
        double magicalProtections = 0;
        double physicalProtection = 0;
        double baseDamage = 0;
        double critChance = 0;

        public void Calculate(God god, Item resultingItem)
        {
            this.Power = resultingItem.Power;
            this.BaseDamage = (god.BaseDamage + god.BaseDamagePerLevel * god.Level + this.Power) * god.Progression[0];
            this.MagicalProtections = god.MagicalProtections + god.MagicalProtectionsPerLevel * god.Level + resultingItem.MagicalProtections;
            this.PhysicalProtections = god.PhysicalProtections + god.PhysicalProtectionsPerLevel * god.Level + resultingItem.PhysicalProtections;
            this.AttackSpeed = god.AttackSpeed * (1 + god.AttackSpeedPerLevel * god.Level + resultingItem.AttackSpeed);
            this.Health = god.Health + god.HealthPerLevel * god.Level + resultingItem.Health;
            this.Mana = god.Mana + god.ManaPerLevel * god.Level + resultingItem.Mana;
            this.CritChance = resultingItem.CritChance * 100;
        }
        public double CritChance
        {
            get
            {
                return critChance;
            }
            set
            {
                if( value > 0 )
                {
                    critChance = value;
                    OnPropertyChanged("CritChance");
                }
            }
        }
        public double BaseDamage
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
        public double PhysicalProtections
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

        public double Health
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
        public double Mana
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
        public double MagicalProtections
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
        

        public double Power
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
