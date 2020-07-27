using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Smite_Auto_Attack_Damage
{
    class God
    {
        string name = null;
        string imagePath = null;
        string iconPath = null;
        string typeOfDamage = null;

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

        public God
        (
            byte id, string name, string imagePath, string iconPath, string typeOfDamage, int health,
            double healthPerLevel, int mana, double manaPerLevel, int baseDamage, double baseDamagePerLevel, 
            int magicalProtections, double magicalProtectionsPerLevel, int physicalProtections, 
            double physicalProtectionsPerLevel, double attackSpeed, double attackSpeedPerLevel            
        )
        {
            Id = id;
            Name = name;
            ImagePath = imagePath;
            IconPath = iconPath;
            TypeOfDamage = typeOfDamage;
            Health = health;
            HealthPerLevel = healthPerLevel;
            Mana = mana;
            ManaPerLevel = manaPerLevel;
            BaseDamage = baseDamage;
            BaseDamagePerLevel = baseDamagePerLevel;
            MagicalProtections = magicalProtections;
            MagicalProtectionsPerLevel = magicalProtectionsPerLevel;
            PhysicalProtections = physicalProtections;
            PhysicalProtecionsPerLevel = physicalProtectionsPerLevel;
            AttackSpeed = attackSpeed;
            AttackSpeedPerLevel = attackSpeedPerLevel;
        }
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
                }
                else
                {
                    throw new ArgumentException("Value cannot be null", "Name");
                }
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
                imagePath = value;
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
                if ((value == "MagicalProtections") || (value == "PhysicalProtections"))
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
                if (value > 0)
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
                if (value > 0)
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
                if (value > 0)
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
                if (value > 0)
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
                if (value > 0)
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
                if (value > 0)
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
                if (value > 0)
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
                if (value > 0)
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
                if(value > 0)
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
                if (value > 0)
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
                if (value > 0)
                {
                    magicalProtectionsPerLevel = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "MagicalProtectionsPerLevel");
                }
            }
        }
        public double PhysicalProtecionsPerLevel
        {
            get
            {
                return physicalProtectionsPerLevel;
            }
            set
            {
                if (value > 0)
                {
                    physicalProtectionsPerLevel = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "PhysicalProtectionsPerLevel");
                }
            }
        }
    }
}
