using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace SmiteBasicAttackDamage
{
    public class GodEntity : INotifyPropertyChanged
    {
        readonly static God zeroGod = new God();
        readonly static Item zeroItem = new Item();

        ListBox godSlot = new ListBox();
        ListBox itemSlots = new ListBox();
        ListBox listOfItems = new ListBox();
        ListBox listOfGods = new ListBox();
        ListBox characteristicsListBox = new ListBox();
        ObservableCollection<Item> sixItems = new ObservableCollection<Item> { zeroItem, zeroItem, zeroItem, zeroItem, zeroItem, zeroItem };
        Characteristic characteristics = new Characteristic();
        ObservableCollection<God> current = new ObservableCollection<God> { new God() };
        Item resultingItem = new Item();
        Slider levelSlider = new Slider();
        TextBlock levelTextBlock = new TextBlock();
        public void SetLevelBinding()
        {
            var binding = new Binding("Level") { Source = this.Current[0] };
            this.LevelTextBlock.SetBinding(TextBlock.TextProperty, binding);
            this.LevelSlider.SetBinding(Slider.ValueProperty, binding);
        }
        public GodEntity() { }
        
        public void SetReferences(ListBox godListBox, ListBox sixItemsOfGod, ListBox listOfItems, ListBox listOfGods, ListBox characteristicsOfGod, Slider levelSlider, TextBlock levelTextBlock)
        {
            this.GodSlot = godListBox;
            this.GodSlot.ItemsSource = this.Current;
            this.ItemSlots = sixItemsOfGod;
            this.ItemSlots.ItemsSource = this.SixItems;
            this.ListOfItems = listOfItems;
            this.ListOfGods = listOfGods;
            this.ListOfGods.ItemsSource = SQLiteDataAccess.LoadGods();
            this.CharacteristicsListBox = characteristicsOfGod;
            this.CharacteristicsListBox.ItemsSource = new ObservableCollection<Characteristic> { this.Characteristics };
            this.LevelSlider = levelSlider;
            this.LevelTextBlock = levelTextBlock;
            this.SetLevelBinding();
        }
        public Characteristic Characteristics
        {
            get
            {
                return characteristics;
            }
            set
            {
                characteristics = value;
            }
        }
        static public God ZeroGod
        {
            get
            {
                return zeroGod;
            }
        }
        static public Item ZeroItem
        {
            get
            {
                return zeroItem;
            }
        }

        public ObservableCollection<God> Current
        {
            get => current;
            set
            {
                current = value;
            }
        }
        internal Item ResultingItem { get => resultingItem; set => resultingItem = value; }
        public ListBox ListOfItems { get => listOfItems; set => listOfItems = value; }
        public ListBox GodSlot { get => godSlot; set => godSlot = value; }
        public ListBox ItemSlots { get => itemSlots; set => itemSlots = value; }
        public ObservableCollection<Item> SixItems { get => sixItems; set => sixItems = value; }
        public ListBox ListOfGods { get => listOfGods; set => listOfGods = value; }
        public ListBox CharacteristicsListBox { get => characteristicsListBox; set => characteristicsListBox = value; }
        public Slider LevelSlider { get => levelSlider; set => levelSlider = value; }
        public TextBlock LevelTextBlock { get => levelTextBlock; set => levelTextBlock = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
