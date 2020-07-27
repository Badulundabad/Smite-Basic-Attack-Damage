using Smite_Auto_Attack_Damage.Model;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
            var arrayOfGods = new God[] 
            {
                new God(1, "R a m a", "/Images/God/Preview/Rama.png", "Images/God/Icon/Rama.png", "PhysicalProtections", 460, 76, 205, 34, 40, 2.5, 30, 0.9, 12, 2.8, 0.95, 0.017),
                new God(2, " J i n g  W e i", "/Images/God/Preview/JingWei.png", "Images/God/Icon/JingWei.png", "PhysicalProtections", 445, 78, 205, 36, 38, 2.7, 30, 0.9, 11, 2.9, 1, 0.0014),
            };






            var testGod = new GarbageTestClass[1];
            testGod[0] = new GarbageTestClass(-1, "n a m e", "/Images/logo.png", "/Images/logo.png");
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
            var manyZeuses = new GarbageTestClass[100];
            for (int i = 0; i < manyZeuses.Length; i++)
            {
                if ((i + 2) % 2 == 0)
                {
                    manyZeuses[i] = new GarbageTestClass(
                        i,
                        "z e u s",
                        "/Images/GodIcons/zeus - mini.jpg",
                        "/Images/Gods/zeus.jpg");
                }
                else manyZeuses[i] = new GarbageTestClass(
                    i,
                    "h a c h i m a n",
                    "/Images/GodIcons/hachiman-mini.jpg",
                    "/Images/Gods/hachiman.jpg");
            }
            Characteristics[] stats = new Characteristics[] { new Characteristics("/Images/Stats/HandDamage.png", 200) };

            god.ItemsSource = testGod;
            godsItems.ItemsSource = sixItems;
            godsItemsList.ItemsSource = manyItems;
            godsList.ItemsSource = arrayOfGods;
            godsStatistics.ItemsSource = stats;


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

        //Обработчик для Item'ов списков богов.
        private void listsGod_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem container = sender as ListBoxItem;
            ListBox currentListBox = ListBox.ItemsControlFromItemContainer(container) as ListBox;
            //Делаем ссылку на 6 предметов. Дефолтно для Бога.
            ListBox godBox = god;
            //Если sender от Цели, то берём ссылку для 6 предметов Цели.
            if (currentListBox.Name == "targetsList")
            {
                godBox = target;
            }
            //Переносим экземпляр бога в окно выбранного бога.
            GarbageTestClass selectedGod = godBox.SelectedItem as GarbageTestClass;
            GarbageTestClass listsGod = currentListBox.SelectedItem as GarbageTestClass;
            selectedGod.FullImagePath = listsGod.FullImagePath;
            selectedGod.ImagePath = listsGod.ImagePath;
            selectedGod.Name = listsGod.Name;
            selectedGod = listsGod;
            container.IsSelected = false;
            container = godBox.ItemContainerGenerator.ContainerFromIndex(0) as ListBoxItem;
            container.IsSelected = false;
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
    }
}
