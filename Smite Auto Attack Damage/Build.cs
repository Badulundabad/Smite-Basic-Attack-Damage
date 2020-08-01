using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Smite_Auto_Attack_Damage.Model
{
    class Build : INotifyPropertyChanged
    {
        private int buildId;
        private string buildName;
        private int godId;
        private string godImagePath;
        private int item0Id;
        private string item0ImagePath;
        private int item1Id;
        private string item1ImagePath;
        private int item2Id;
        private string item2ImagePath;
        private int item3Id;
        private string item3ImagePath;
        private int item4Id;
        private string item4ImagePath;
        private int item5Id;
        private string item5ImagePath;

        public Build()
        {
            buildId = -1;
            buildName = "N a m e o  of  b u i l d";
            godId = -1;
            godImagePath = "/Images/logo.png";
            item0Id = -1;
            item0ImagePath = "/Images/logo.png";
            item1Id = -1;
            item1ImagePath = "/Images/logo.png";
            item2Id = -1;
            item2ImagePath = "/Images/logo.png";
            item3Id = -1;
            item3ImagePath = "/Images/logo.png";
            item4Id = -1;
            item4ImagePath = "/Images/logo.png";
            item5Id = -1;
            item5ImagePath = "/Images/logo.png";
        }

        public int BuildId
        {
            get => buildId;
            set
            {
                buildId = value;
                OnPropertyChanged("BuildId");
            }
        }
        public string BuildName
        {
            get => buildName;
            set
            {
                buildName = value;
                OnPropertyChanged("BuildName");
            }
        }
        public int GodId
        {
            get => godId;
            set
            {
                godId = value;
                OnPropertyChanged("GodId");
            }
        }
        public string GodImagePath
        {
            get => godImagePath;
            set
            {
                godImagePath = value;
                OnPropertyChanged("GodImagePath");
            }
        }
        public int Item0Id
        {
            get => item0Id;
            set
            {
                item0Id = value;
                OnPropertyChanged("Item0Id");
            }
        }
        public string Item0ImagePath
        {
            get => item0ImagePath;
            set
            {
                item0ImagePath = value;
                OnPropertyChanged("Item0ImagePath");
            }
        }
        public int Item1Id
        {
            get => item1Id;
            set
            {
                item1Id = value;
                OnPropertyChanged("Item1Id");
            }
        }
        public string Item1ImagePath
        {
            get => item1ImagePath;
            set
            {
                item1ImagePath = value;
                OnPropertyChanged("Item1ImagePath");
            }
        }
        public int Item2Id
        {
            get => item2Id;
            set
            {
                item2Id = value;
                OnPropertyChanged("Item2Id");
            }
        }
        public string Item2ImagePath
        {
            get => item2ImagePath;
            set
            {
                item2ImagePath = value;
                OnPropertyChanged("Item2ImagePath");
            }
        }
        public int Item3Id
        {
            get => item3Id;
            set
            {
                item3Id = value;
                OnPropertyChanged("Item3Id");
            }
        }
        public string Item3ImagePath
        {
            get => item3ImagePath;
            set
            {
                item3ImagePath = value;
                OnPropertyChanged("Item3ImagePath");
            }
        }
        public int Item4Id
        {
            get => item4Id;
            set
            {
                item4Id = value;
                OnPropertyChanged("Item4Id");
            }
        }
        public string Item4ImagePath
        {
            get => item4ImagePath;
            set
            {
                item4ImagePath = value;
                OnPropertyChanged("Item4ImagePath");
            }
        }
        public int Item5Id
        {
            get => item5Id;
            set
            {
                item5Id = value;
                OnPropertyChanged("Item5Id");
            }
        }
        public string Item5ImagePath
        {
            get => item5ImagePath;
            set
            {
                item5ImagePath = value;
                OnPropertyChanged("Item5ImagePath");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
