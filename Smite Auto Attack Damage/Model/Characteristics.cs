using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smite_Auto_Attack_Damage
{
    class Characteristics
    {
        double value = 0;
        string imagePath = null;

        public double Value { get => value; set => this.value = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }

        public Characteristics(string path, double val)
        {
            this.ImagePath = path;
            this.value = val;
        }
    }
}
