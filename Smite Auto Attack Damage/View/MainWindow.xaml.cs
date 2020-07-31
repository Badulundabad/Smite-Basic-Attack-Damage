using Smite_Auto_Attack_Damage.Model;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Data;
using System;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Smite_Auto_Attack_Damage
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //

        readonly Stack<Build> buildsStack = new Stack<Build>();
        Build emptyBuild;

        public MainWindow()
        {
            InitializeComponent();
            var rama = new God(1, "R a m a", "/Images/God/Preview/Rama.png", "/Images/God/Icon/Rama.png", "Physical", 460, 76, 205, 34, 40, 2.5, 30, 0.9, 12, 2.8, 0.95, 0.017);
            var jingWei = new God(2, "J i n g  W e i", "/Images/God/Preview/JingWei.png", "/Images/God/Icon/JingWei.png", "Physical", 445, 78, 205, 36, 38, 2.7, 30, 0.9, 11, 2.9, 1, 0.0014);
            var merlin = new God(3, "M e r l i n", "/Images/God/Preview/Merlin.png", "/Images/God/Icon/Merlin.png", "Magical", 370, 75, 250, 55, 34, 1.5, 30, 0.9, 10, 3, 1, 0.008);
            var sol = new God(4, "S o l", "/Images/God/Preview/Sol.png", "/Images/God/Icon/Sol.png", "Magical", 400, 75, 300, 57, 34, 1.45, 30, 0.9, 9, 2.6, 1, 0.018);

            for (int i = 0; i < 111; i++)
            {
                if (i % 4 == 0) God.ListOfGods[i] = rama;
                if (i % 4 == 1) God.ListOfGods[i] = jingWei;
                if (i % 4 == 2) God.ListOfGods[i] = merlin;
                if (i % 4 == 3) God.ListOfGods[i] = sol;
            }

            var demonicGrip = new Item(1, 75, 0.3, "Your Basic Attacks reduce your target's Magical Protection by 10% for 3s (max 3 Stacks).", "/Images/Item/DemonicGrip.png", null, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.3);
            var ringOfHecate = new Item(2, 80, 0.3, "Each successful basic attack applies a hex to enemies and empowers you. Enemies receive 5% decreased power per stack while you receive 5% increased power. Both effects stack up to 3 times and stacks last 5s", "/Images/Item/RingOfHecate.png", null, 0, 0, 0, 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0);
            var typhonsFang = new Item(3, 70, 0, null, "/Images/Item/TyphonsFang.png", null, 200, 0, 0, 0, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0.1, 0);
            var divineRuin = new Item(4, 90, 0, null, "/Images/Item/DivineRuin.png", null, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var voidStone = new Item(5, 0, 0, null, "/Images/Item/VoidStone.png", null, 0, 150, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .1);
            var ninjaTabi = new Item(6, 20, .25, null, "/Images/Item/NinjaTabi.png", null, 100, 0, 0, 0, 0, 0, 0, 0, 0, 18, 0, 0, 0, 0, 0);
            var sovereignty = new Item(7, 0, 0, null, "/Images/Item/Sovereignty.png", null, 0, 250, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 35, 0, 0);
            var goldenBlade = new Item(8, 30, .15, null, "/Images/Item/GoldenBlade.png", null, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 0, 0, 0);
            var gauntletOfThebes = new Item(9, 0, 0, null, "/Images/Item/GauntletOfThebes.png", null, 0, 300, 60, 60, 0, 0, 0, 0, 0, 0, 0, 0, 15, 0, 0);
            var poisonedStar = new Item(10, 35, .1, null, "/Images/Item/PoisonedStar.png", null, 0, 0, 0, 0, 0, 0, .15, 0, 0, 0, 0, 0, 0, 0, 0);
            var theCrusher = new Item(11, 30, .2, null, "/Images/Item/TheCrusher.png", null, 0, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            var charonsCoin = new Item(12, 80, 0, null, "/Images/Item/CharonsCoin.png", null, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 20, 20, .2, 0);
            var voidShield = new Item(13, 20, 0, null, "/Images/Item/VoidShield.png", null, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .15);

            for (int i = 0; i < 112; i++)
            {
                if (i % 7 == 0) Data.ListOfPhysicalItems[i] = voidShield;
                if (i % 7 == 1) Data.ListOfPhysicalItems[i] = ninjaTabi;
                if (i % 7 == 2) Data.ListOfPhysicalItems[i] = sovereignty;
                if (i % 7 == 3) Data.ListOfPhysicalItems[i] = goldenBlade;
                if (i % 7 == 4) Data.ListOfPhysicalItems[i] = gauntletOfThebes;
                if (i % 7 == 5) Data.ListOfPhysicalItems[i] = poisonedStar;
                if (i % 7 == 6) Data.ListOfPhysicalItems[i] = theCrusher;
            }

            for (int i = 0; i < 112; i++)
            {
                if (i % 7 == 0) Data.ListOfMagicalItems[i] = demonicGrip;
                if (i % 7 == 1) Data.ListOfMagicalItems[i] = ringOfHecate;
                if (i % 7 == 2) Data.ListOfMagicalItems[i] = typhonsFang;
                if (i % 7 == 3) Data.ListOfMagicalItems[i] = divineRuin;
                if (i % 7 == 4) Data.ListOfMagicalItems[i] = voidStone;
                if (i % 7 == 5) Data.ListOfMagicalItems[i] = sovereignty;
                if (i % 7 == 6) Data.ListOfMagicalItems[i] = charonsCoin;

            }


            //Проделать то же самое для target
            SetCharacteristics(Data.Characteristics_Attacker, new TextBlock[] { powerTextBlock_attacker, attackSpeedTextBlock_attacker, baseDamageTextBlock_attacker, penetrationTextBlock_attacker, magicalProtectionsTextBlock_attacker, physicalProtectionsTextBlock_attacker, healthTextBlock_attacker, manaTextBlock_attacker });


            var manyItems = new GarbageTestClass[50];
            for (int i = 0; i < manyItems.Length; i++)
            {
                if ((i + 2) % 2 == 0)
                {
                    manyItems[i] = new GarbageTestClass("heartseeker", "/Images/Items/heartseeker.png");
                }
                else manyItems[i] = new GarbageTestClass("soulreaver", "/Images/Items/soulreaver.png");
            }


            god.ItemsSource = Data.CurrentAttacker;


            sixItemsOfAttacker.ItemsSource = Data.SixItems_attacker;
            listOfItems.ItemsSource = Data.ListOfMagicalItems;
            listOfGods.ItemsSource = God.ListOfGods;











            var testTarget = new GarbageTestClass[1];
            testTarget[0] = new GarbageTestClass(-1, "n a m e", "/Images/logo.png", "/Images/logo.png");
            var targetsSixItems = new GarbageTestClass[6];
            for (int i = 0; i < targetsSixItems.Length; i++)
            {
                targetsSixItems[i] = new GarbageTestClass("n a m e", "/Images/logo.png");
            }
            var targetsManyItems = new GarbageTestClass[50];
            for (int i = 0; i < targetsManyItems.Length; i++)
            {
                if ((i + 2) % 2 == 0)
                {
                    targetsManyItems[i] = new GarbageTestClass("heartseeker", "/Images/Items/heartseeker.png");
                }
                else targetsManyItems[i] = new GarbageTestClass("soulreaver", "/Images/Items/soulreaver.png");
            }
            var targetsManyZeuses = new GarbageTestClass[100];
            for (int i = 0; i < targetsManyZeuses.Length; i++)
            {
                if ((i + 2) % 2 == 0)
                {
                    targetsManyZeuses[i] = new GarbageTestClass(
                        i,
                        "z e u s",
                        "/Images/GodIcons/zeus - mini.jpg",
                        "/Images/Gods/zeus.jpg");
                }
                else targetsManyZeuses[i] = new GarbageTestClass(
                    i,
                    "h a c h i m a n",
                    "/Images/GodIcons/hachiman-mini.jpg",
                    "/Images/Gods/hachiman.jpg");
            }

            target.ItemsSource = testTarget;
            targetsItems.ItemsSource = targetsSixItems;
            //targetsItemsList.ItemsSource = targetsManyItems;
            targetsList.ItemsSource = targetsManyZeuses;

            Build testBuild = new Build();
            buildsStack.Push(testBuild);
            builds.ItemsSource = buildsStack;

        }
        public void SetCharacteristics(Characteristic character, TextBlock[] textBlocks)
        {
            string[] properties = new string[8] { "Power", "AttackSpeed", "BaseDamage", "Penetration", "MagicalProtections", "PhysicalProtections", "Health", "Mana" }; ;

            for (int i = 0; i < 8; i++)
            {
                Binding binding = new Binding(properties[i]) { Source = character };
                textBlocks[i].SetBinding(TextBlock.TextProperty, binding);
            }
        }

        //Обработчик, снимающий статус IsSelected с ListBoxItem'ов при нажатии на другие области окна.
        private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //Если источник события не ListBox
            if (e.Source.GetType().Name != "ListBox")
            {
                ListBox[] listBoxes = { god, sixItemsOfAttacker, listOfItems, target, targetsItems, /*targetsItemsList*/ };
                foreach (ListBox listBox in listBoxes)
                {
                    listBox.SelectedIndex = -1;
                }
                //Скрыть списки предметов.
                listOfItems.Visibility = Visibility.Collapsed;
                //targetsItemsList.Visibility = Visibility.Hidden;
            }
        }
        private void ItemOfList_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            SetItem(sender as ListBoxItem, sixItemsOfAttacker, Data.SixItems_attacker, listOfItems);
        }
        private void SetItem(ListBoxItem container, ListBox sixItemsListBox, ObservableCollection<Item> sixItemsCollection, ListBox listOfItems)
        {
            var item = (Item)container.DataContext;
            //После выбора предмета тот переносится в текущий слот, и выделяется самый левый слот из содержащих нулевой предмет
            if (!Data.SixItems_attacker.Contains(item))
            {
                sixItemsCollection[sixItemsListBox.SelectedIndex] = item;
                sixItemsListBox.SelectedIndex = sixItemsCollection.IndexOf(Data.ZeroItem);
                //При отсутствии свободных слотов закрывает список предметов и снимает выделение со слотов
                if (!sixItemsCollection.Contains(Data.ZeroItem))
                {
                    listOfItems.Visibility = Visibility.Collapsed;
                    sixItemsListBox.SelectedIndex = -1;
                }
            }
        }


        private void ListOfGods_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            SetGod(sender as ListBoxItem, Data.SixItems_attacker, Data.CurrentAttacker);
        }
        private void SetGod(ListBoxItem container, ObservableCollection<Item> sixItemsCollection, ObservableCollection<God> currentGod)
        {
            var god = (God)container.DataContext;
            test1.Text = god.TypeOfDamage;
            if (god.TypeOfDamage != currentGod[0].TypeOfDamage)
            {
                for (int i = 0; i < 6; i++)
                {
                    sixItemsCollection[i] = Data.ZeroItem;
                }
                if (god.TypeOfDamage == "Magical")
                {
                    listOfItems.ItemsSource = Data.ListOfMagicalItems;
                }
                else
                {
                    listOfItems.ItemsSource = Data.ListOfPhysicalItems;
                }
            }

            if (!currentGod.Contains((God)container.DataContext)) currentGod[0] = god;

        }
        private void SixItemsOfAttacker_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            listOfItems.Visibility = Visibility.Visible;
        }
        private void SixItemsOfAttacker_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            RemoveItem(sender as ListBoxItem, sixItemsOfAttacker, Data.SixItems_attacker, listOfItems);
        }
        private void RemoveItem(ListBoxItem container, ListBox sixItemsListBox, ObservableCollection<Item> sixItemsCollection, ListBox listOfItems)
        {
            int i = sixItemsCollection.IndexOf((Item)container.DataContext);
            if (sixItemsListBox.SelectedIndex > -1) sixItemsCollection[sixItemsListBox.SelectedIndex] = Data.ZeroItem;
            if (listOfItems.Visibility == Visibility.Visible)
            {
                sixItemsOfAttacker.SelectedIndex = i;
            }
        }


        //Обработчик для сохранения билда.


        private void SaveButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            GarbageTestClass sel = god.Items.CurrentItem as GarbageTestClass;
            Build build = (e.Source as Image).DataContext as Build;
            build.GodId = sel.Id;
            build.BuildName = sel.Name;
            build.GodImagePath = sel.ImagePath;
            if (buildsStack.Count() != 100 && build.BuildId == -1)
            {
                emptyBuild = new Build();
                buildsStack.Push(emptyBuild);
                builds.Items.Refresh();
                for (int i = 0; i < 100; i++)
                {
                    bool isNotContains = buildsStack.All(x => x.BuildId != i);
                    if (isNotContains)
                    {
                        build.BuildId = i;
                        break;
                    }
                }
            }
        }

        //Обработчик для кнопки удаления билда.
        private void DeleteButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Build build = (e.Source as Image).DataContext as Build;
            List<Build> buildList = buildsStack.ToList<Build>();
            buildList.Remove(buildList.Find(x => x.BuildId == build.BuildId));
            buildList.Reverse();
            buildsStack.Clear();
            buildList.ForEach(x => buildsStack.Push(x));
            builds.Items.Refresh();
        }

        private void RestoreButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            var rnd = new Random();
            Data.Characteristics_Attacker.BaseDamage = rnd.Next(0, 200);
            Data.Characteristics_Attacker.AttackSpeed = rnd.Next(0, 200);
            Data.Characteristics_Attacker.Power = rnd.Next(0, 200);
            Data.Characteristics_Attacker.MagicalProtections = rnd.Next(0, 200);
            Data.Characteristics_Attacker.PhysicalProtections = rnd.Next(0, 200); ;
            Data.Characteristics_Attacker.Mana = rnd.Next(0, 200);
            Data.Characteristics_Attacker.Health = rnd.Next(0, 200);
        }

        private void TestButton2_Click(object sender, RoutedEventArgs e)
        {
            //test1.Text = Calculation.ItemOfAttackerIndex.ToString();
            //Calculation.SixItems_attacker[3] =  new Item(13, 20, 0, null, "/Images/Item/VoidShield.png", null, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .15);
            //Calculation.Attacker = new Characteristic(80);
        }


    }
}
