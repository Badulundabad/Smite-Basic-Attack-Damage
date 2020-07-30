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

namespace Smite_Auto_Attack_Damage
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //
        
        Stack<Build> buildsStack = new Stack<Build>();
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
                if (i % 7 == 0) Calculation.ListOfPhysicalItems[i] = voidShield;
                if (i % 7 == 1) Calculation.ListOfPhysicalItems[i] = ninjaTabi;
                if (i % 7 == 2) Calculation.ListOfPhysicalItems[i] = sovereignty;
                if (i % 7 == 3) Calculation.ListOfPhysicalItems[i] = goldenBlade;
                if (i % 7 == 4) Calculation.ListOfPhysicalItems[i] = gauntletOfThebes;
                if (i % 7 == 5) Calculation.ListOfPhysicalItems[i] = poisonedStar;
                if (i % 7 == 6) Calculation.ListOfPhysicalItems[i] = theCrusher;
            }

            for (int i = 0; i < 112; i++)
            {
                if (i % 7 == 0) Calculation.ListOfMagicalItems[i] = demonicGrip;
                if (i % 7 == 1) Calculation.ListOfMagicalItems[i] = ringOfHecate;
                if (i % 7 == 2) Calculation.ListOfMagicalItems[i] = typhonsFang;
                if (i % 7 == 3) Calculation.ListOfMagicalItems[i] = divineRuin;
                if (i % 7 == 4) Calculation.ListOfMagicalItems[i] = voidStone;
                if (i % 7 == 5) Calculation.ListOfMagicalItems[i] = sovereignty;
                if (i % 7 == 6) Calculation.ListOfMagicalItems[i] = charonsCoin;

            }

            //Проделать то же самое для target
            SetCharacteristics(Calculation.Characteristics_Attacker, new TextBlock[] { powerTextBlock_attacker, attackSpeedTextBlock_attacker, baseDamageTextBlock_attacker, penetrationTextBlock_attacker, magicalProtectionsTextBlock_attacker, physicalProtectionsTextBlock_attacker, healthTextBlock_attacker, manaTextBlock_attacker });


            var manyItems = new GarbageTestClass[50];
            for (int i = 0; i < manyItems.Length; i++)
            {
                if ((i + 2) % 2 == 0)
                {
                    manyItems[i] = new GarbageTestClass("heartseeker", "/Images/Items/heartseeker.png");
                }
                else manyItems[i] = new GarbageTestClass("soulreaver", "/Images/Items/soulreaver.png");
            }

            Calculation.SixItems_attacker = Calculation.ZeroItemArray;

            god.ItemsSource = new God[1] { Calculation.ZeroGod };
            sixItemsOfAttacker.ItemsSource = Calculation.SixItems_attacker;
            godsItemsList.ItemsSource = Calculation.ListOfMagicalItems;
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
            targetsItemsList.ItemsSource = targetsManyItems;
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
                Binding binding = new Binding(properties[i]);
                binding.Source = character;
                textBlocks[i].SetBinding(TextBlock.TextProperty, binding);
            }
        }

        //Обработчик, снимающий статус IsSelected с ListBoxItem'ов при нажатии на другие области окна.
        private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //Если источник события не ListBox
            if (e.Source.GetType().Name != "ListBox")
            {
                ListBox[] listBoxes =
                    { god, sixItemsOfAttacker, godsItemsList, target, targetsItems, targetsItemsList };
                //Проверка всех ListBox'ов на наличие выбранных ListBoxItem'ов.
                //При SelectedIndex равном -1 значит, что у ListBox'а нет выбранных Item'ов.
                foreach (ListBox listBox in listBoxes)
                {
                    //Если есть выбранные Item'ы - снять выбор.
                    if (listBox.SelectedIndex != -1)
                    {
                        if (listBox.Name == "sixItemsOfAttacker")
                            selectedItemsState[0, sixItemsOfAttacker.SelectedIndex] = false;
                        else if (listBox.Name == "targetsItems")
                            selectedItemsState[1, targetsItems.SelectedIndex] = false;
                        ListBoxItem container = listBox.ItemContainerGenerator.
                            ContainerFromIndex(listBox.SelectedIndex) as ListBoxItem;
                        container.IsSelected = false;
                    }
                }
                //Скрыть списки предметов.
                godsItemsList.Visibility = Visibility.Hidden;
                targetsItemsList.Visibility = Visibility.Hidden;
            }
        }

        //Обработчик, работающий с 6 предметами Бога или Цели. 
        //Определяет состояние Item'а в момент нажатия кнопки мыши.
        private void selectedItem_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            godsItemsList.Visibility = Visibility.Visible;
            Calculation.ItemOfAttackerIndex =  sixItemsOfAttacker.ItemContainerGenerator.IndexFromContainer(sender as ListBoxItem);
            /*
            //Номер двумерного массива с состояниями 6 предметов.
            //Дефолтно установлен номер (0) массива для Бога, а не Цели.
            int stateArrayNum = 0;
            //В зависимости от sender'а получаем ссылку на один из ListBox'ов с 6 предметами.
            ListBox currentListBox = ListBox.ItemsControlFromItemContainer(sender as ListBoxItem)
                as ListBox;
            //Делаем ссылку на список доступных предметов. Дефолтно для бога.
            ListBox itemsList = godsItemsList;
            //Если sender от Цели, то номер массива состояний и 
            //список доступных предметов устанавливаем для цели.
            if (currentListBox.Name == "targetsItems")
            {
                stateArrayNum = 1;
                itemsList = targetsItemsList;
            }
            //Если есть выбранные Item'ы.
            if (currentListBox.SelectedIndex != -1)
            {
                //Если по номеру выбранного Item'а в массиве состояний было false,
                //то все состояния установить на false, а это сделать true и
                //сделать список доступных предметов видимым.
                if (!selectedItemsState[stateArrayNum, currentListBox.SelectedIndex])
                {
                    for (int number = 0; number < 6; number++)
                        selectedItemsState[stateArrayNum, number] = false;
                    selectedItemsState[stateArrayNum, currentListBox.SelectedIndex] = true;
                    itemsList.Visibility = Visibility.Visible;
                }
                //Если предмет перед этим нажатием уже был в выбранном состоянии,
                //то записать его в массив на опустошение.
                else if (selectedItemsState[stateArrayNum, currentListBox.SelectedIndex])
                {
                    for (int number = 0; number < 6; number++)
                        selectedItemsState[stateArrayNum, number] = false;
                    containersToBeEmptied[stateArrayNum, currentListBox.SelectedIndex] = true;
                }
                //Если в массиве на опустошение по индексу Item,а значение true,
                //то отчитсить выбранный предмет, снять выбор с этого Item'а и скрыть список
                //доступных предметов.
                if (containersToBeEmptied[stateArrayNum, currentListBox.SelectedIndex])
                {
                    containersToBeEmptied[stateArrayNum, currentListBox.SelectedIndex] = false;
                    GarbageTestClass selectedItem = currentListBox.SelectedItem as GarbageTestClass;
                    selectedItem.ImagePath = "/Images/logo.png";
                    selectedItem = new GarbageTestClass("n a m e", "/Images/logo.png");
                    ListBoxItem container = new ListBoxItem();
                    container = currentListBox.ItemContainerGenerator.ContainerFromItem(currentListBox.SelectedItem)
                        as ListBoxItem;
                    container.IsSelected = false;
                    itemsList.Visibility = Visibility.Hidden;
                }
            }*/
        }
        static bool[,] selectedItemsState = new bool[2, 6];
        //Массив для пометки Item'ов на очистку от выбранных предметов
        static bool[,] containersToBeEmptied = new bool[2, 6];


        public void SetItem(ListBoxItem container)
        {
            
            var item = (Item)container.DataContext;
            //Обновляет элемент массива предметов бога(поле), индекс которого соответствует порядковому номеру выбранного слота
            //При выборе предмета тот устанавливается в слот, и выделяется следующий слот
            if (Calculation.SixItems_attacker.Contains(Calculation.ZeroItem) && !Calculation.SixItems_attacker.Contains(item))
            {
                Calculation.SixItems_attacker[sixItemsOfAttacker.SelectedIndex] = item;
                sixItemsOfAttacker.ItemsSource = new Item[] { Calculation.SixItems_attacker[0], Calculation.SixItems_attacker[1], Calculation.SixItems_attacker[2], Calculation.SixItems_attacker[3], Calculation.SixItems_attacker[4], Calculation.SixItems_attacker[5] };
                //скрывает, когда все слоты заняты
                if (Calculation.SixItems_attacker.Contains(Calculation.ZeroItem) == false) godsItemsList.Visibility = Visibility.Collapsed;
            }
            //почти не отличается от вышенаписанного
            //если при выборе слота все слоты уже заняты, то сразу же после выбора предмета скрывает список
            if (Calculation.SixItems_attacker.Contains(Calculation.ZeroItem) == false && !Calculation.SixItems_attacker.Contains(item))
            {
                Calculation.SixItems_attacker[sixItemsOfAttacker.SelectedIndex] = item;
                sixItemsOfAttacker.ItemsSource = new Item[] { Calculation.SixItems_attacker[0], Calculation.SixItems_attacker[1], Calculation.SixItems_attacker[2], Calculation.SixItems_attacker[3], Calculation.SixItems_attacker[4], Calculation.SixItems_attacker[5] };
                //аналогично, но при этом еще и снимает выделение
                if (Calculation.SixItems_attacker.Contains(Calculation.ZeroItem) == false) godsItemsList.Visibility = Visibility.Collapsed;
                sixItemsOfAttacker.SelectedIndex = -1;
            }
            if (sixItemsOfAttacker.SelectedIndex > 5) sixItemsOfAttacker.SelectedIndex = 0;
            test1.Text = Calculation.SixItems_attacker[0].Id + " " + Calculation.SixItems_attacker[1].Id + " " + Calculation.SixItems_attacker[2].Id + " " + Calculation.SixItems_attacker[3].Id + " " + Calculation.SixItems_attacker[4].Id + " " + Calculation.SixItems_attacker[5].Id;
        }
        //Обработчик, работающий с предметами списков доступных предметов.
        private void listsItem_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            SetItem(sender as ListBoxItem);
            
            /*
            //Дефолтно устанавливаем всё для Бога.
            int stateArrayNum = 0;
            ListBoxItem itemContainer = sender as ListBoxItem;
            ListBox currentListBox = ListBox.ItemsControlFromItemContainer(itemContainer) as ListBox;
            ListBox selectedItemsList = sixItemsOfAttacker;
            //Если sender от списка предметов Цели, то
            //устанавливаем всё для Цели.
            if (currentListBox.Name == "targetsItemsList")
            {
                stateArrayNum = 1;
                selectedItemsList = targetsItems;
            }
            //Переносим выбранный предмет в слот 6 предметов, снимаем выделение со всех Item'ов и
            //скрываем список выбранных предметов.
            selectedItemsState[stateArrayNum, selectedItemsList.SelectedIndex] = false;
            var selectedItem = (Item)selectedItemsList.SelectedItem;
            var listsItem = (Item)currentListBox.SelectedItem;
            selectedItem.ImagePath = listsItem.ImagePath;
            selectedItem = listsItem;
            itemContainer.IsSelected = false;
            itemContainer = selectedItemsList.ItemContainerGenerator.ContainerFromItem(selectedItemsList.SelectedItem) as ListBoxItem;
            itemContainer.IsSelected = false;
            currentListBox.Visibility = Visibility.Hidden;*/
        }

        //Обработчик для потомков списка богов
        private void ListOfGods_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            SetGod(sender as ListBoxItem, god, Calculation.CurrentAttacker);
        }
        public void SetGod(ListBoxItem container, ListBox godToSet, God[] currentGod)
        {
            currentGod[0] = (God)container.DataContext;
            godToSet.ItemsSource = new God[] { currentGod[0] };
        }
        //Обработчик для сохранения билда.
        private void saveButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
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
        private void deleteButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Build build = (e.Source as Image).DataContext as Build;
            List<Build> buildList = buildsStack.ToList<Build>();
            buildList.Remove(buildList.Find(x => x.BuildId == build.BuildId));
            buildList.Reverse();
            buildsStack.Clear();
            buildList.ForEach(x => buildsStack.Push(x));
            builds.Items.Refresh();
        }

        private void restoreButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            var rnd = new Random();
            Calculation.Characteristics_Attacker.BaseDamage = rnd.Next(0, 200);
            Calculation.Characteristics_Attacker.AttackSpeed = rnd.Next(0, 200);
            Calculation.Characteristics_Attacker.Power = rnd.Next(0, 200);
            Calculation.Characteristics_Attacker.MagicalProtections = rnd.Next(0, 200);
            Calculation.Characteristics_Attacker.PhysicalProtections = rnd.Next(0, 200); ;
            Calculation.Characteristics_Attacker.Mana = rnd.Next(0, 200);
            Calculation.Characteristics_Attacker.Health = rnd.Next(0, 200);
        }

        private void TestButton2_Click(object sender, RoutedEventArgs e)
        {
            test1.Text = Calculation.ItemOfAttackerIndex.ToString();
            //Calculation.SixItems_attacker[3] =  new Item(13, 20, 0, null, "/Images/Item/VoidShield.png", null, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .15);
            //Calculation.Attacker = new Characteristic(80);
        }
    }
}
