using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;

namespace SmiteBasicAttackDamage
{
    public class Item
    {
        string name = null;
        string description = null;
        string imagePath = null;
        string method = null;

        int id = 0;
        short mana = 0;
        short health = 0;

        short power = 0;
        byte magicalProtections = 0;
        byte physicalProtections = 0;
        byte flatPenetration = 0;
        byte flatReduction = 0;
        double critChance = 0;
        byte lifeSteal = 0;
        byte cooldownReduction = 0;
        byte movementSpeed = 0;
        byte crowdControlReduction = 0;
        byte mp5 = 0;
        byte hp5 = 0;

        double attackSpeed = 0;
        double percentagePenetration = 0;
        double percentageReduction = 0;

        static string[] arrayOfMethods = { };



        public Item
        (
            string name, int id, short power, double attackSpeed, string description, string imagePath, string method,
            short mana, short health, byte magicalProtections, byte physicalProtections, byte flatPenetration,
            byte flatReduction, double critChance, byte lifeSteal, byte cooldownReduction, byte movementSpeed,
            byte crowdControlReduction, byte mp5, byte hp5, double percentagePenetration, double percentageReduction
        )
        {
            Name = name;
            Id = id;
            Power = power;
            AttackSpeed = attackSpeed;
            Description = description;
            ImagePath = imagePath;
            Method = method;
            Mana = mana;
            Health = health;
            MagicalProtections = magicalProtections;
            PhysicalProtections = physicalProtections;
            FlatPenetration = flatPenetration;
            FlatReduction = flatReduction;
            CritChance = critChance;
            LifeSteal = lifeSteal;
            CooldownReduction = cooldownReduction;
            MovementSpeed = movementSpeed;
            CrowdControlReduction = crowdControlReduction;
            Mp5 = mp5;
            Hp5 = hp5;
            PercentagePenetration = percentagePenetration;
            PercentageReduction = percentageReduction;
        }
        public Item()
        {
            Id = 0;
            Name = "Zero Item";
            ImagePath = "/Images/logo.png";
            Power = 0;
            AttackSpeed = 0;
            Description = null;
            Method = null;
            Mana = 0;
            Health = 0;
            MagicalProtections = 0;
            PhysicalProtections = 0;
            FlatPenetration = 0;
            FlatReduction = 0;
            CritChance = 0;
            LifeSteal = 0;
            CooldownReduction = 0;
            MovementSpeed = 0;
            CrowdControlReduction = 0;
            Mp5 = 0;
            Hp5 = 0;
            PercentagePenetration = 0;
            PercentageReduction = 0;
        }
        public void SetItem(ListBox sixItemsListBox, ObservableCollection<Item> sixItemsCollection, ListBox listOfItems, Item resultingItem)
        {
            if (!sixItemsCollection.Any(item => item.Id == this.Id))
            {
                resultingItem += this;
                sixItemsCollection[sixItemsListBox.SelectedIndex] = this;
                sixItemsListBox.SelectedIndex = sixItemsCollection.IndexOf(Data.ZeroItem);
                //При отсутствии свободных слотов закрывает список предметов и снимает выделение со слотов
                if (!sixItemsCollection.Contains(Data.ZeroItem))
                {
                    listOfItems.Visibility = Visibility.Collapsed;
                    sixItemsListBox.SelectedIndex = -1;
                }
            }
        }
        public void RemoveItem(ListBox sixItemsListBox, ObservableCollection<Item> sixItemsCollection, ListBox listOfItems, Item resultingItem)
        {
            int i = sixItemsCollection.IndexOf(this);
            if (sixItemsListBox.SelectedIndex > -1)
            {
                if (this != Data.ZeroItem)
                {
                    resultingItem -= this;
                }
                sixItemsCollection[sixItemsListBox.SelectedIndex] = Data.ZeroItem;
            }
            if (listOfItems.Visibility == Visibility.Visible)
            {
                sixItemsListBox.SelectedIndex = i;
            }
        }
        public static Item operator +(Item first, Item second)
        {
            first.Power += second.Power;
            first.AttackSpeed += second.AttackSpeed;
            first.Mana += second.Mana;
            first.Health += second.Health;
            first.MagicalProtections += second.MagicalProtections;
            first.PhysicalProtections += second.PhysicalProtections;
            first.FlatPenetration += second.FlatPenetration;
            first.FlatReduction += second.FlatReduction;
            first.CritChance += second.CritChance;
            first.LifeSteal += second.LifeSteal;
            first.PercentagePenetration += second.PercentagePenetration;
            first.PercentageReduction += second.PercentageReduction;
            return first;
        }
        public static Item operator -(Item first, Item second)
        {
            first.Power -= second.Power;
            first.AttackSpeed -= second.AttackSpeed;
            first.Mana -= second.Mana;
            first.Health -= second.Health;
            first.MagicalProtections -= second.MagicalProtections;
            first.PhysicalProtections -= second.PhysicalProtections;
            first.FlatPenetration -= second.FlatPenetration;
            first.FlatReduction -= second.FlatReduction;
            first.CritChance -= second.CritChance;
            first.LifeSteal -= second.LifeSteal;
            first.PercentagePenetration -= second.PercentagePenetration;
            first.PercentageReduction -= second.PercentageReduction;
            return first;
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public string ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                if (value != null)
                {
                    imagePath = value;
                }
                else
                {
                    throw new ArgumentException("No image path", "ImagePath");
                }
            }
        }
        public string Method
        {
            get
            {
                return method;
            }
            set
            {
                if (value == null | arrayOfMethods.Contains(value))
                {
                    method = value;
                }
                else
                {
                    throw new ArgumentException("Wrong name of method", "Method");
                }
            }
        }
        public int Id
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
        public short Mana
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
        public short Health
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
                    throw new ArgumentException("", "Health");
                }
            }
        }
        public short Power
        {
            get
            {
                return power;
            }
            set
            {
                if (value >= 0)
                {
                    power = value;
                }
                else
                {
                    throw new ArgumentException("", "Power");
                }
            }
        }
        public byte MagicalProtections
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
                    throw new ArgumentException("", "MagicalProtections");
                }
            }
        }
        public byte PhysicalProtections
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
                    throw new ArgumentException("", "PhysicalProtections");
                }
            }
        }
        public byte FlatPenetration
        {
            get
            {
                return flatPenetration;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    flatPenetration = value;
                }
                else
                {
                    throw new ArgumentException("Value must be in the range from 0 to 100", "FlatPenetration");
                }
            }
        }
        public byte FlatReduction
        {
            get
            {
                return flatReduction;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    flatReduction = value;
                }
                else
                {
                    throw new ArgumentException("Value must be in the range from 0 to 100", "FlatReduction");
                }
            }
        }
        public double CritChance
        {
            get
            {
                return critChance;
            }
            set
            {
                if (value >= 0)
                {
                    critChance = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "CritChance");
                }
            }
        }
        public byte LifeSteal
        {
            get
            {
                return lifeSteal;
            }
            set
            {
                if (value >= 0)
                {
                    lifeSteal = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "LifeSteal");
                }
            }
        }
        public byte CooldownReduction
        {
            get
            {
                return cooldownReduction;
            }
            set
            {
                if (value >= 0)
                {
                    cooldownReduction = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "CooldownReduction");
                }
            }
        }
        public byte MovementSpeed
        {
            get
            {
                return movementSpeed;
            }
            set
            {
                if (value >= 0)
                {
                    movementSpeed = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "MovementSpeed");
                }
            }
        }
        public byte CrowdControlReduction
        {
            get
            {
                return crowdControlReduction;
            }
            set
            {
                if (value >= 0)
                {
                    crowdControlReduction = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "CrowdControlReduction");
                }
            }
        }
        public byte Mp5
        {
            get
            {
                return mp5;
            }
            set
            {
                if (value >= 0)
                {
                    mp5 = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "mp5");
                }
            }
        }
        public byte Hp5
        {
            get
            {
                return hp5;
            }
            set
            {
                if (value >= 0)
                {
                    hp5 = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "Hp5");
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
                else if (value < 0)
                {
                    attackSpeed = 0;
                }
            }
        }
        public double PercentagePenetration
        {
            get
            {
                return percentagePenetration;
            }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    percentagePenetration = value;
                }
                else
                {
                    throw new ArgumentException("Value must be in the range from 0 to 0.2", "PercentagePenetration");
                }
            }
        }
        public double PercentageReduction
        {
            get
            {
                return percentageReduction;
            }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    percentageReduction = value;
                }
                else
                {
                    throw new ArgumentException("Value must be in the range from 0 to 0.5", "PercentageReduction");
                }
            }
        }

        public string Name { get => name; set => name = value; }
    }
}
