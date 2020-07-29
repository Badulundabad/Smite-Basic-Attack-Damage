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
        static bool[,] selectedItemsState = new bool[2, 6];
        //Массив для пометки Item'ов на очистку от выбранных предметов
        static bool[,] containersToBeEmptied = new bool[2, 6]; 
        Stack<Build> buildsStack = new Stack<Build>();
        Build emptyBuild;

        public MainWindow()
        {
            InitializeComponent();
            var testGod = new God(1, "R a m a", "/Images/God/Preview/Rama.png", "/Images/God/Icon/Rama.png", "PhysicalProtections", 460, 76, 205, 34, 40, 2.5, 30, 0.9, 12, 2.8, 0.95, 0.017);
            var arrayOfGods = new God[] 
            {
                new God(1, "R a m a", "/Images/God/Preview/Rama.png", "/Images/God/Icon/Rama.png", "PhysicalProtections", 460, 76, 205, 34, 40, 2.5, 30, 0.9, 12, 2.8, 0.95, 0.017),
                new God(2, "J i n g  W e i", "/Images/God/Preview/JingWei.png", "/Images/God/Icon/JingWei.png", "PhysicalProtections", 445, 78, 205, 36, 38, 2.7, 30, 0.9, 11, 2.9, 1, 0.0014),
                new God(3, "M e r l i n", "/Images/God/Preview/Merlin.png", "/Images/God/Icon/Merlin.png", "MagicalProtections", 370, 75, 250, 55, 34, 1.5 ,30, 0.9, 10, 3, 1, 0.008),
                new God(4, "S o l", "/Images/God/Preview/Sol.png", "/Images/God/Icon/Sol.png", "MagicalProtections", 400, 75, 300, 57, 34, 1.45, 30, 0.9, 9, 2.6, 1, 0.018 ), 
                testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,
                testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,
                testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,testGod,
            };

            //Проделать то же самое для target
            SetCharacteristics(Characteristic.Attacker, new TextBlock[] { powerTextBlock_attacker, attackSpeedTextBlock_attacker, baseDamageTextBlock_attacker, penetrationTextBlock_attacker, magicalProtectionsTextBlock_attacker, physicalProtectionsTextBlock_attacker, healthTextBlock_attacker, manaTextBlock_attacker });


            var sixItems = new GarbageTestClass[6];
            for (int i = 0; i < sixItems.Length; i++)
            {
                sixItems[i] = new GarbageTestClass("n a m e", "/Images/logo.png");
            }
            var manyItems = new GarbageTestClass[50];
            for (int i = 0; i < manyItems.Length; i++)
            {
                if ((i + 2) % 2 == 0)
                {
                    manyItems[i] = new GarbageTestClass("heartseeker", "/Images/Items/heartseeker.png");
                }
                else manyItems[i] = new GarbageTestClass("soulreaver", "/Images/Items/soulreaver.png");
            }
            
            Characteristics[] stats = new Characteristics[] { new Characteristics("/Images/Stats/HandDamage.png", 200) };

            god.ItemsSource = new God[1] {Calculation.ZeroGod};
            godsItems.ItemsSource = sixItems;
            godsItemsList.ItemsSource = manyItems;
            listOfGods.ItemsSource = arrayOfGods;
            //godsStatistics.ItemsSource = stats;


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
            targetsStatistics.ItemsSource = stats;

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
                    { god, godsItems, godsItemsList, target, targetsItems, targetsItemsList };
                //Проверка всех ListBox'ов на наличие выбранных ListBoxItem'ов.
                //При SelectedIndex равном -1 значит, что у ListBox'а нет выбранных Item'ов.
                foreach (ListBox listBox in listBoxes)
                {
                    //Если есть выбранные Item'ы - снять выбор.
                    if (listBox.SelectedIndex != -1)
                    {
                        if (listBox.Name == "godsItems")
                            selectedItemsState[0, godsItems.SelectedIndex] = false;
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
            }
        }
        
        //Обработчик, работающий с предметами списков доступных предметов.
        private void listsItem_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //Дефолтно устанавливаем всё для Бога.
            int stateArrayNum = 0;
            ListBoxItem itemContainer = sender as ListBoxItem;
            ListBox currentListBox = ListBox.ItemsControlFromItemContainer(itemContainer) as ListBox;
            ListBox selectedItemsList = godsItems;
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
            GarbageTestClass selectedItem = selectedItemsList.SelectedItem as GarbageTestClass;
            GarbageTestClass listsItem = currentListBox.SelectedItem as GarbageTestClass;
            selectedItem.ImagePath = listsItem.ImagePath;
            selectedItem = listsItem;
            itemContainer.IsSelected = false;
            itemContainer = selectedItemsList.ItemContainerGenerator.ContainerFromItem(selectedItemsList.SelectedItem) as ListBoxItem;
            itemContainer.IsSelected = false;
            currentListBox.Visibility = Visibility.Hidden;
        }

        //Обработчик для потомков списка богов
        private void ListOfGods_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var container = sender as ListBoxItem;
            var currentListBox = (ListBox)ListBox.ItemsControlFromItemContainer(container);
            ListBox godBox = god;
            if (currentListBox.Name == "targetsList")
            {
                godBox = target;
            }
            var listsGod = (God)container.DataContext;
            Calculation.CurrentGod[0] = listsGod;
            god.ItemsSource = new God[] {listsGod};
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
            Characteristic.Attacker.BaseDamage = rnd.Next(0, 200); 
            Characteristic.Attacker.AttackSpeed = rnd.Next(0, 200);
            Characteristic.Attacker.Power = rnd.Next(0, 200);
            Characteristic.Attacker.MagicalProtections = rnd.Next(0, 200);
            Characteristic.Attacker.PhysicalProtections = rnd.Next(0, 200); ;
            Characteristic.Attacker.Mana = rnd.Next(0, 200);
            Characteristic.Attacker.Health = rnd.Next(0, 200);
            //Calculation.CurrentGod = new God[] { new God(9, "ololo", "/Images/God/Preview/fullLogo.png", null, "PhysicalProtections", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0) };
            //test1.Text = Calculation.CurrentGod[0].PhysicalProtectionsPerLevel.ToString() + "  " + Calculation.CurrentGod[0].Id;
        }

        private void TestButton2_Click(object sender, RoutedEventArgs e)
        {
            //Calculation.Attacker = new Characteristic(80);
        }
    }
}
