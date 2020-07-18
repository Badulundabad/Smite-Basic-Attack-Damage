using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Smite_Auto_Attack_Damage.Model
{
    class GarbageTestClass : INotifyPropertyChanged
    {
        private string name;
        private string imagePath;
        private string fullImagePath;
        private int id;
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
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public GarbageTestClass()
        {
            this.Name = name;
        }
        public GarbageTestClass(string name, string imagePath)
        {
            this.Name = name;
            this.ImagePath = imagePath;
        }
        public GarbageTestClass(int id,  string name, string imagePath, string fullImagePath)
        {
            this.Id = id;
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
