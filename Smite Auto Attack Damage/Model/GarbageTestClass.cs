using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Smite_Auto_Attack_Damage.Model
{
    class GarbageTestClass : INotifyPropertyChanged
    {
        private string name;
        private string imagePath;
        private string fullImagePath;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }
        public string FullImagePath
        {
            get => fullImagePath;
            set
            {
                fullImagePath = value;
                OnPropertyChanged("FullImagePath");
            }
        }

        public GarbageTestClass(string name, string imagePath)
        {
            this.Name = name;
            this.ImagePath = imagePath;
        }
        public GarbageTestClass(string name, string imagePath, string fullImagePath)
        {
            this.Name = name;
            this.ImagePath = imagePath;
            this.FullImagePath = fullImagePath;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
