using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmiteBasicAttackDamage
{
    class Calculation
    {
        public static void CalculateCharacteristics(Characteristic characteristic, God god, Item resultingItem)
        {
            characteristic.Power = resultingItem.Power;
            characteristic.BaseDamage = god.BaseDamage + god.BaseDamagePerLevel * god.Level + characteristic.Power;
            characteristic.MagicalProtections = god.MagicalProtections + god.MagicalProtectionsPerLevel * god.Level + resultingItem.MagicalProtections;
            characteristic.PhysicalProtections = god.PhysicalProtections + god.PhysicalProtectionsPerLevel * god.Level + resultingItem.PhysicalProtections;
            characteristic.AttackSpeed = god.AttackSpeed * (1 + god.AttackSpeedPerLevel * god.Level + resultingItem.AttackSpeed);
            characteristic.Health = god.Health + god.HealthPerLevel * god.Level + resultingItem.Health;
            characteristic.Mana = god.Mana + god.ManaPerLevel * god.Level + resultingItem.Mana;
            characteristic.CritChance = resultingItem.CritChance * 100;
        }
        
    }
}
