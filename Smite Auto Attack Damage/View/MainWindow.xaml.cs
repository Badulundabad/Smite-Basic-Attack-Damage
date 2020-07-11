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
        static bool[] godSelectedItemsStateArray = new bool[7];
        static bool[] targetSelectedItemsStateArray = new bool[7];
        static bool[] godDeletingItemsArray = new bool[7];
        static bool[] targetDeletingItemsArray = new bool[7];

        public MainWindow()
        {
            InitializeComponent();

            var testGod = new GarbageTestClass[1];
            testGod[0] = new GarbageTestClass("n a m e", "/Images/logo.png", "/Images/logo.png");
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
                        "z e u s",
                        "/Images/GodIcons/zeus - mini.jpg",
                        "/Images/Gods/zeus.jpg");
                }
                else manyZeuses[i] = new GarbageTestClass(
                    "h a c h i m a n",
                    "/Images/GodIcons/hachiman-mini.jpg",
                    "/Images/Gods/hachiman.jpg");
            }
            Characteristics[] stats = new Characteristics[] { new Characteristics("/Images/Stats/HandDamage.png", 200) };

            god.ItemsSource = testGod;
            godsItems.ItemsSource = sixItems;
            builds.ItemsSource = sixItems;
            godsItemsList.ItemsSource = manyItems;
            godsList.ItemsSource = manyZeuses;
            godsStatistics.ItemsSource = stats;


            var testTarget = new GarbageTestClass[1];
            testTarget[0] = new GarbageTestClass("n a m e", "/Images/logo.png", "/Images/logo.png");
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
                        "z e u s",
                        "/Images/GodIcons/zeus - mini.jpg",
                        "/Images/Gods/zeus.jpg");
                }
                else targetsManyZeuses[i] = new GarbageTestClass(
                    "h a c h i m a n",
                    "/Images/GodIcons/hachiman-mini.jpg",
                    "/Images/Gods/hachiman.jpg");
            }

            target.ItemsSource = testTarget;
            targetsItems.ItemsSource = targetsSixItems;
            targetsItemsList.ItemsSource = targetsManyItems;
            targetsList.ItemsSource = targetsManyZeuses;
            targetsStatistics.ItemsSource = stats;
        }


        private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.Source.GetType().Name != "ListBox")
            {
                if (godsItems.SelectedIndex != -1)
                {
                    godSelectedItemsStateArray[godsItems.SelectedIndex] = false;
                    ListBoxItem container =
                        godsItems.ItemContainerGenerator.ContainerFromItem(godsItems.SelectedItem)
                        as ListBoxItem;
                    container.IsSelected = false;
                }
                if (godsItemsList.SelectedIndex != -1)
                {
                    ListBoxItem container =
                        godsItemsList.ItemContainerGenerator.ContainerFromItem(godsItemsList.SelectedItem)
                        as ListBoxItem;
                    container.IsSelected = false;
                }
                if (god.SelectedIndex != -1)
                {
                    ListBoxItem container =
                        god.ItemContainerGenerator.ContainerFromIndex(god.SelectedIndex)
                        as ListBoxItem;
                    container.IsSelected = false;
                }
                if (targetsItems.SelectedIndex != -1)
                {
                    targetSelectedItemsStateArray[targetsItems.SelectedIndex] = false;
                    ListBoxItem container =
                        targetsItems.ItemContainerGenerator.ContainerFromItem(targetsItems.SelectedItem)
                        as ListBoxItem;
                    container.IsSelected = false;
                }
                if (targetsItemsList.SelectedIndex != -1)
                {
                    ListBoxItem container =
                        targetsItemsList.ItemContainerGenerator.ContainerFromItem(targetsItemsList.SelectedItem)
                        as ListBoxItem;
                    container.IsSelected = false;
                }
                if (target.SelectedIndex != -1)
                {
                    ListBoxItem container =
                        target.ItemContainerGenerator.ContainerFromIndex(target.SelectedIndex)
                        as ListBoxItem;
                    container.IsSelected = false;
                }
                godsItemsList.Visibility = Visibility.Hidden;
                targetsItemsList.Visibility = Visibility.Hidden;
            }
        }

        private void selectedItem_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (godsItems.SelectedIndex != -1)
            {
                if (!godSelectedItemsStateArray[godsItems.SelectedIndex])
                {
                    for (int number = 0; number < godSelectedItemsStateArray.Count(); number++)
                        godSelectedItemsStateArray[number] = false;
                    godSelectedItemsStateArray[godsItems.SelectedIndex] = true;
                    godsItemsList.Visibility = Visibility.Visible;
                }
                else if (godSelectedItemsStateArray[godsItems.SelectedIndex])
                {
                    for (int number = 0; number < godSelectedItemsStateArray.Count(); number++)
                        godSelectedItemsStateArray[number] = false;
                    godDeletingItemsArray[godsItems.SelectedIndex] = true;
                }
                if (godDeletingItemsArray[godsItems.SelectedIndex])
                {
                    godDeletingItemsArray[godsItems.SelectedIndex] = false;
                    GarbageTestClass selectedItem = godsItems.SelectedItem as GarbageTestClass;
                    selectedItem.ImagePath = "/Images/logo.png";
                    selectedItem = new GarbageTestClass("n a m e", "/Images/logo.png");
                    ListBoxItem container = new ListBoxItem();
                    container = godsItems.ItemContainerGenerator.ContainerFromItem(godsItems.SelectedItem) as ListBoxItem;
                    container.IsSelected = false;
                    godsItemsList.Visibility = Visibility.Hidden;
                }
            }
            if (targetsItems.SelectedIndex != -1)
            {
                if (!targetSelectedItemsStateArray[targetsItems.SelectedIndex])
                {
                    for (int number = 0; number < targetSelectedItemsStateArray.Count(); number++)
                        targetSelectedItemsStateArray[number] = false;
                    targetSelectedItemsStateArray[targetsItems.SelectedIndex] = true;
                    targetsItemsList.Visibility = Visibility.Visible;
                }
                else if (targetSelectedItemsStateArray[targetsItems.SelectedIndex])
                {
                    for (int number = 0; number < targetSelectedItemsStateArray.Count(); number++)
                        targetSelectedItemsStateArray[number] = false;
                    targetDeletingItemsArray[targetsItems.SelectedIndex] = true;
                }
                if (targetDeletingItemsArray[targetsItems.SelectedIndex])
                {
                    targetDeletingItemsArray[targetsItems.SelectedIndex] = false;
                    GarbageTestClass selectedItem = targetsItems.SelectedItem as GarbageTestClass;
                    selectedItem.ImagePath = "/Images/logo.png";
                    selectedItem = new GarbageTestClass("n a m e", "/Images/logo.png");
                    ListBoxItem container = new ListBoxItem();
                    container = targetsItems.ItemContainerGenerator.ContainerFromItem(targetsItems.SelectedItem) as ListBoxItem;
                    container.IsSelected = false;
                    targetsItemsList.Visibility = Visibility.Hidden;
                }

            }
        }

        private void listsItem_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if(godsItems.SelectedIndex != -1)
            {
                godSelectedItemsStateArray[godsItems.SelectedIndex] = false;
                GarbageTestClass selectedItem = godsItems.SelectedItem as GarbageTestClass;
                GarbageTestClass listsItem = godsItemsList.SelectedItem as GarbageTestClass;
                selectedItem.ImagePath = listsItem.ImagePath;
                selectedItem = listsItem;
                ListBoxItem container = new ListBoxItem();
                container = godsItems.ItemContainerGenerator.ContainerFromItem(godsItems.SelectedItem) as ListBoxItem;
                container.IsSelected = false;
                container = godsItemsList.ItemContainerGenerator.ContainerFromItem(listsItem) as ListBoxItem;
                container.IsSelected = false;
                godsItemsList.Visibility = Visibility.Hidden;
            }
            if(targetsItems.SelectedIndex != -1)
            {
                targetSelectedItemsStateArray[targetsItems.SelectedIndex] = false;
                GarbageTestClass selectedItem = targetsItems.SelectedItem as GarbageTestClass;
                GarbageTestClass listsItem = targetsItemsList.SelectedItem as GarbageTestClass;
                selectedItem.ImagePath = listsItem.ImagePath;
                selectedItem = listsItem;
                ListBoxItem container = new ListBoxItem();
                container = targetsItems.ItemContainerGenerator.ContainerFromItem(targetsItems.SelectedItem) as ListBoxItem;
                container.IsSelected = false;
                container = targetsItemsList.ItemContainerGenerator.ContainerFromItem(listsItem) as ListBoxItem;
                container.IsSelected = false;
                targetsItemsList.Visibility = Visibility.Hidden;
            }
        }

        private void listsGod_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (god.SelectedIndex == 0)
            {
                GarbageTestClass selectedGod = god.SelectedItem as GarbageTestClass;
                GarbageTestClass listsGod = godsList.SelectedItem as GarbageTestClass;
                selectedGod.FullImagePath = listsGod.FullImagePath;
                selectedGod = listsGod;
                godsName.Text = selectedGod.Name;
                ListBoxItem container = godsList.ItemContainerGenerator.ContainerFromItem(listsGod) as ListBoxItem;
                container.IsSelected = false;
                container = god.ItemContainerGenerator.ContainerFromIndex(0) as ListBoxItem;
                container.IsSelected = false;
            }
            if(target.SelectedIndex == 0)
            {
                GarbageTestClass selectedGod = target.SelectedItem as GarbageTestClass;
                GarbageTestClass listsGod = targetsList.SelectedItem as GarbageTestClass;
                selectedGod.FullImagePath = listsGod.FullImagePath;
                selectedGod = listsGod;
                targetsName.Text = selectedGod.Name;
                ListBoxItem container = targetsList.ItemContainerGenerator.ContainerFromItem(listsGod) as ListBoxItem;
                container.IsSelected = false;
                container = target.ItemContainerGenerator.ContainerFromIndex(0) as ListBoxItem;
                container.IsSelected = false;
            }
        }
    }
}
