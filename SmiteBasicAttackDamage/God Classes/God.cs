﻿using System;
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
using System.Globalization;

namespace SmiteBasicAttackDamage
{
    public class God : INotifyPropertyChanged
    {
        string name = "God";
        string previewPath = "/Images/fullLogo.png";
        string iconPath = null;
        string typeOfDamage = "Physical";

        short health = 0;
        short baseDamage = 0;
        short mana = 0;
        short magicalProtections = 0;
        short physicalProtections = 0;

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
        string progressionString = "0/0/0";
        double[] progression = new double[5];

        public virtual List<Item> GetListOfItems()
        {
            return new List<Item>();
        }
        //there is some random text
        public void SetGod(GodEntity entity)
        {
            var list = this.GetListOfItems().OrderBy(god => god.Id);
            entity.ListOfItems.ItemsSource = list;
            //Если i-ый слот содержит предмет, которого нет в новосозданном списке предметов, то слот очищается
            for (byte i = 0; i < 6; i++)
            {
                if (!list.Any(item => item.Name == entity.SixItems[i].Name))
                {
                    entity.ResultingItem -= entity.SixItems[i];
                    entity.SixItems[i] = GodEntity.ZeroItem;
                }
            }
            //Эта часть нужна только для того, чтобы не сбрасывалось значение слайдера
            //#костыль
            byte j = entity.Current[0].Level;
            if (!entity.Current.Contains(this))
            {
                entity.Current[0] = this;
            }
            entity.Current[0].Level = j;
            entity.GodSlot.Tag = entity.Current[0].TypeOfDamage;
            string[] str = entity.Current[0].ProgressionString.Split(new char[] { '/' }, 5, StringSplitOptions.RemoveEmptyEntries);
            for (byte i = 0; i < 5; i++)
            {
                entity.Current[0].Progression[i] = Convert.ToDouble(str[i], CultureInfo.InvariantCulture);
            }
            entity.Characteristics.Calculate(entity.Current[0], entity.ResultingItem);
        }
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
                    throw new ArgumentException("Value cannot be below than 0", "Health");
                }
            }
        }
        public short BaseDamage
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
        public short MagicalProtections
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
        public short PhysicalProtections
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

        public string ProgressionString { get => progressionString; set => progressionString = value; }
        public double[] Progression { get => progression; set => progression = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
