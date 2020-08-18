using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Windows.Media.Animation;
using System.Collections.ObjectModel;

namespace SmiteBasicAttackDamage
{
    public class God : INotifyPropertyChanged
    {
        string name = "God";
        string previewPath = "/Images/fullLogo.png";
        string iconPath = null;
        string typeOfDamage = "Physical";

        int health = 0;
        int baseDamage = 0;
        int mana = 0;
        int magicalProtections = 0;
        int physicalProtections = 0;

        byte level = 0;
        byte id = 0;

        double baseDamagePerLevel = 0;
        double healthPerLevel = 0;
        double manaPerLevel = 0;
        double attackSpeed = 0;
        double attackSpeedPerLevel = 0;
        double magicalProtectionsPerLevel = 0;
        double physicalProtectionsPerLevel = 0;
        string method = null;

        public virtual void SetListOfItems(ListBox listOfItems)
        {
        }

        public void SetGod(ObservableCollection<Item> sixItemsCollection, ObservableCollection<God> currentGod, Item resultingItem, ListBox listOfItems, Characteristic characteristics)
        {
            if (this.TypeOfDamage != currentGod[0].TypeOfDamage)
            {
                //Обнуление слотов с предметами и суммы всех их характеристик
                //Почему-то нельзя приравнять одну коллекцию к коллекции пустых предметов
                for (int i = 0; i < 6; i++)
                {
                    sixItemsCollection[i] = Data.ZeroItem;
                }
                //И экземпляр к пустому экземпляру
                resultingItem.Power = 0;
                resultingItem.AttackSpeed = 0;
                resultingItem.Mana = 0;
                resultingItem.Health = 0;
                resultingItem.MagicalProtections = 0;
                resultingItem.PhysicalProtections = 0;
                resultingItem.FlatPenetration = 0;
                resultingItem.FlatReduction = 0;
                resultingItem.CritChance = 0;
                resultingItem.LifeSteal = 0;
                resultingItem.PercentagePenetration = 0;
                resultingItem.PercentageReduction = 0;
                resultingItem.CritChance = 0;
            }
            this.SetListOfItems(listOfItems);
            //Эта часть нужна только для того, чтобы не сбрасывалось значение слайдера
            //#костыль
            byte j = currentGod[0].Level;
            if (!currentGod.Contains(this))
            {
                currentGod[0] = this;
            }
            currentGod[0].Level = j;
            Calculation.CalculateCharacteristics(characteristics, currentGod[0], resultingItem);
        }
        static private God[] listOfGods = new God[111];
        public God() { }

        public string Method { get; set; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != null)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
                else
                {
                    throw new ArgumentException("Value cannot be null", "Name");
                }
            }
        }
        public string PreviewPath
        {
            get
            {
                return previewPath;
            }
            set
            {
                previewPath = value;
                OnPropertyChanged("PreviewPath");
            }
        }
        public string IconPath
        {
            get
            {
                return iconPath;
            }
            set
            {
                iconPath = value;
            }
        }
        public string TypeOfDamage
        {
            get
            {
                return typeOfDamage;
            }
            set
            {
                if ((value == "Magical") || (value == "Physical"))
                {
                    typeOfDamage = value;
                }
                else
                {
                    throw new ArgumentException("Entered word is incorrect", "TypeOfDamage");
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
                }
                else
                {
                    throw new ArgumentException("Value cannot be below than 0", "Health");
                }
            }
        }
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
                }
                else
                {
                    throw new ArgumentException("Value can't negative", "BaseDamage");
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
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "Mana");
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
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "MagicalProtections");
                }
            }
        }
        public int PhysicalProtections
        {
            get
            {
                return physicalProtections;
            }
            set
            {
                if (value >= 0)
                {
                    physicalProtections = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "PhysicalProtecions");
                }
            }
        }
        public byte Level
        {
            get
            {
                return level;
            }
            set
            {
                if (value >= 0 && value <= 20)
                {
                    level = value;
                    OnPropertyChanged("Level");
                }
                else
                {
                    throw new ArgumentException("Value must be in the range from 0 to 20", "Level");
                }
            }
        }
        public byte Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value >= 0)
                {
                    id = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "Id");
                }
            }
        }

        public double BaseDamagePerLevel
        {
            get
            {
                return baseDamagePerLevel;
            }
            set
            {
                if (value >= 0)
                {
                    baseDamagePerLevel = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "BaseDamagePerLevel");
                }
            }
        }
        public double HealthPerLevel
        {
            get
            {
                return healthPerLevel;
            }
            set
            {
                if (value >= 0)
                {
                    healthPerLevel = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "HealthPerLevel");
                }
            }
        }
        public double ManaPerLevel
        {
            get
            {
                return manaPerLevel;
            }
            set
            {
                if (value >= 0)
                {
                    manaPerLevel = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "ManaPerLevel");
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
                if (value >= 0)
                {
                    attackSpeed = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "AttackSpeed");
                }
            }
        }
        public double AttackSpeedPerLevel
        {
            get
            {
                return attackSpeedPerLevel;
            }
            set
            {
                if (value >= 0)
                {
                    attackSpeedPerLevel = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "AttackSpeedPerLevel");
                }
            }
        }
        public double MagicalProtectionsPerLevel
        {
            get
            {
                return magicalProtectionsPerLevel;
            }
            set
            {
                if (value >= 0)
                {
                    magicalProtectionsPerLevel = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "MagicalProtectionsPerLevel");
                }
            }
        }
        public double PhysicalProtectionsPerLevel
        {
            get
            {
                return physicalProtectionsPerLevel;
            }
            set
            {
                if (value >= 0)
                {
                    physicalProtectionsPerLevel = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "PhysicalProtectionsPerLevel");
                }
            }
        }

        internal static God[] ListOfGods { get => listOfGods; set => listOfGods = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
