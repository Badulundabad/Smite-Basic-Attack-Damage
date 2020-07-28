using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Smite_Auto_Attack_Damage
{
    class Item
    {
        string description = null;
        string imagePath = null;
        string method = null;

        int id = 0;
        int mana = 0;
        int health = 0;

        byte power = 0;
        byte magicalProtections = 0;
        byte physicalProtections = 0;
        byte flatPenetration = 0;
        byte flatReduction = 0;
        byte critChance = 0;
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
            int id, byte power, double attackSpeed, string description, string imagePath, string method,
            int mana, int health, byte magicalProtections, byte physicalProtections, byte flatPenetration,
            byte flatReduction, byte critChance, byte lifeSteal, byte cooldownReduction, byte movementSpeed,
            byte crowdControlReduction, byte mp5, byte hp5, double percentagePenetration, double percentageReduction
        )
        {
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
            PercentagePenetration = percentageReduction;
        }
        string Description
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
        string ImagePath
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
        string Method
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
        int Id
        {
            get
            {
                return id;
            }
            set
            {
                if( value >= 0)
                {
                    id = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "Id");
                }
            }
        }
        int Mana
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
        int Health
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
        byte Power
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
        byte MagicalProtections
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
        byte PhysicalProtections
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
        byte FlatPenetration
        {
            get
            {
                return flatPenetration;
            }
            set
            {
                if (value >= 0 && value <= 15)
                {
                    flatPenetration = value;
                }
                else
                {
                    throw new ArgumentException("Value cannot be negative", "FlatPenetration");
                }
            }
        }
        byte FlatReduction
        {
            get
            {
                return flatReduction;
            }
            set
            {
                if (value >= 0 && value <= 25)
                {
                    flatReduction = value;
                }
                else
                {
                    throw new ArgumentException("Value must be in the range from 0 to 25", "FlatReduction");
                }
            }
        }
        byte CritChance
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
        byte LifeSteal
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
        byte CooldownReduction
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
        byte MovementSpeed
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
        byte CrowdControlReduction
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
        byte Mp5
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
        byte Hp5
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
        double AttackSpeed
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
        double PercentagePenetration
        {
            get
            {
                return percentagePenetration;
            }
            set
            {
                if (value >= 0 && value <= 0.2)
                {
                    percentagePenetration = value;
                }
                else
                {
                    throw new ArgumentException("Value must be in the range from 0 to 0.2", "PercentagePenetration");
                }
            }
        }
        double PercentageReduction
        {
            get
            {
                return percentageReduction;
            }
            set
            {
                if (value >= 0 && value <= 0.25)
                {

                }
                else
                {
                    throw new ArgumentException("Value must be in the range from 0 to 0.25", "PercentageReduction");
                }
            }
        }
    }
}
