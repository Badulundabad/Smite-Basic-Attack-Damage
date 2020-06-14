using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smite_Auto_Attack_Damage.Model
{
    class GarbageTestClass
    {
        string imagePath = null;

        public string ImagePath { get => imagePath; set => imagePath = value; }
        public GarbageTestClass(string path)
        {
            this.ImagePath = path;
        }
    }
}
