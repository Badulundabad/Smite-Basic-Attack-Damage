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
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace SmiteBasicAttackDamage
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

            SetLevelBinding(Data.CurrentAttacker[0], levelOfAttacker, attackerLevelSlider);
            SetLevelBinding(Data.CurrentTarget[0], levelOfTarget, targetLevelSlider);
            
            SetListBoxes(rightListOfGods, sixItemsOfTarget, Data.SixItemsOfTarget, target, Data.CurrentTarget, characteristicsOfTarget, Data.Characteristics_Target);
            SetListBoxes(leftListOfGods, sixItemsOfAttacker, Data.SixItemsOfAttacker, attacker, Data.CurrentAttacker, characteristicsOfAttacker, Data.Characteristics_Attacker);

            Build testBuild = new Build();
            buildsStack.Push(testBuild);
            builds.ItemsSource = buildsStack;
            
            void SetListBoxes
            (
                ListBox listOfGods,
                ListBox sixItems,
                ObservableCollection<Item> sixItemsCollection,
                ListBox godListBox,
                ObservableCollection<God> god,
                ListBox characteristicsListBox,
                Characteristic characteristic
            )
            {
                sixItems.ItemsSource = sixItemsCollection;
                listOfGods.ItemsSource = SQLiteDataAccess.LoadGods();
                godListBox.ItemsSource = god;
                characteristicsListBox.ItemsSource = new ObservableCollection<Characteristic> { characteristic };
            }

            void SetLevelBinding(God god, TextBlock textBlock, Slider slider)
            {
                var binding = new Binding("Level") { Source = god };
                textBlock.SetBinding(TextBlock.TextProperty, binding);
                slider.SetBinding(Slider.ValueProperty, binding);
            }
        }

        //Обработчик, снимающий статус IsSelected с ListBoxItem'ов при нажатии на другие области окна.
        private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //Если источник события не ListBox
            if (e.Source.GetType().Name != "ListBox")
            {
                ListBox[] listBoxes = { attacker, sixItemsOfAttacker, leftListOfItems, rightListOfItems, target, sixItemsOfTarget, /*targetsItemsList*/ };
                foreach (ListBox listBox in listBoxes)
                {
                    listBox.SelectedIndex = -1;
                }
                //Скрыть списки предметов.
                leftListOfItems.Visibility = Visibility.Collapsed;
                rightListOfItems.Visibility = Visibility.Collapsed;
            }
        }
        private void ItemOfLeftList_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Item.SetItem(sender as ListBoxItem, sixItemsOfAttacker, Data.SixItemsOfAttacker, leftListOfItems, Data.ResultingItemOfAttacker);
            Calculation.CalculateCharacteristics(Data.Characteristics_Attacker, Data.CurrentAttacker[0], Data.ResultingItemOfAttacker);
        }
        private void ItemOfRightList_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Item.SetItem(sender as ListBoxItem, sixItemsOfTarget, Data.SixItemsOfTarget, rightListOfItems, Data.ResultingItemOfTarget);
            Calculation.CalculateCharacteristics(Data.Characteristics_Target, Data.CurrentTarget[0], Data.ResultingItemOfTarget);
        }


        private void leftListOfGods_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            SetGod(sender as ListBoxItem, Data.SixItemsOfAttacker, Data.CurrentAttacker, Data.ResultingItemOfAttacker, leftListOfItems, Data.Characteristics_Attacker);
        }
        private void RightListOfGods_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            SetGod(sender as ListBoxItem, Data.SixItemsOfTarget, Data.CurrentTarget, Data.ResultingItemOfTarget, rightListOfItems, Data.Characteristics_Target);
        }
        private void SetGod(ListBoxItem container, ObservableCollection<Item> sixItemsCollection, ObservableCollection<God> currentGod, Item resultingItem, ListBox listOfItems, Characteristic characteristics)
        {
            var god = (God)container.DataContext;
            if (god.TypeOfDamage != currentGod[0].TypeOfDamage)
            {
                //Обнуление слотов с предметами и суммы всех их характеристик
                //Почему-то нельзя приравнять одну коллекцию к коллекции пустых предметов
                for (int i = 0; i < 6; i++)
                {
                    sixItemsCollection[i] = Data.ZeroItem ;
                }
                //И экземпляр к пустому экземпляру
                resultingItem.Power = 0;
                resultingItem.AttackSpeed = 0;
                resultingItem.Mana = 0;
                resultingItem.Health = 0;
                resultingItem.MagicalProtections = 0;
                resultingItem.PhysicalProtections = 0;
                resultingItem.FlatPenetration = 0;
                resultingItem.FlatReduction = 0;
                resultingItem.CritChance = 0;
                resultingItem.LifeSteal = 0;
                resultingItem.PercentagePenetration = 0;
                resultingItem.PercentageReduction = 0;
                resultingItem.CritChance = 0;
                //Переделать потом под getProperty
                //нет, не переделать, так как впоследствии этот блок не будет нужен
                /*if (god.TypeOfDamage == "Magical")
                {
                    listOfItems.ItemsSource = Data.ListOfMagicalItems;
                }
                else
                {
                    listOfItems.ItemsSource = Data.ListOfPhysicalItems;
                }*/
            }
            god.SetListOfItems(listOfItems);
            byte j = currentGod[0].Level;
            if (!currentGod.Contains((God)container.DataContext))
            {
                currentGod[0] = god;
            }
            currentGod[0].Level = j;
            Calculation.CalculateCharacteristics(characteristics, currentGod[0], resultingItem);
        }
        private void SixItemsOfAttacker_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            leftListOfItems.Visibility = Visibility.Visible;
        }
        private void SixItemsOfTarget_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            rightListOfItems.Visibility = Visibility.Visible;
        }
        private void SixItemsOfAttacker_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Item.RemoveItem(sender as ListBoxItem, sixItemsOfAttacker, Data.SixItemsOfAttacker, leftListOfItems);
            Calculation.CalculateCharacteristics(Data.Characteristics_Attacker, Data.CurrentAttacker[0], Data.ResultingItemOfAttacker);
        }
        private void SixItemsOfTarget_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Item.RemoveItem(sender as ListBoxItem, sixItemsOfTarget, Data.SixItemsOfTarget, rightListOfItems);
            Calculation.CalculateCharacteristics(Data.Characteristics_Target, Data.CurrentTarget[0], Data.ResultingItemOfTarget);
        }


        //Обработчик для сохранения билда.


        private void SaveButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            /*GarbageTestClass sel = god.Items.CurrentItem as GarbageTestClass;
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
            }*/
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
            Data.Characteristics_Attacker.AttackSpeed = rnd.NextDouble() + rnd.Next(0, 3);
            Data.Characteristics_Attacker.Power = rnd.Next(0, 200);
            Data.Characteristics_Attacker.MagicalProtections = rnd.Next(0, 200);
            Data.Characteristics_Attacker.PhysicalProtections = rnd.Next(0, 200); ;
            Data.Characteristics_Attacker.Mana = rnd.Next(0, 200);
            Data.Characteristics_Attacker.Health = rnd.Next(0, 200);
        }

        private void TestButton2_Click(object sender, RoutedEventArgs e)
        {
            somethingTextBlock.Text = Data.CurrentAttacker[0].TypeOfDamage;
            somethingTextBlock.Text = Data.ResultingItemOfAttacker.AttackSpeed.ToString();

            //test1.Text = Calculation.ItemOfAttackerIndex.ToString();
            //Calculation.SixItems_attacker[3] =  new Item(13, 20, 0, null, "/Images/Item/VoidShield.png", null, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .15);
            //Calculation.Attacker = new Characteristic(80);
        }

        private void AttackerLevelSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Data.CurrentAttacker[0].Level = Convert.ToByte(attackerLevelSlider.Value);
            Calculation.CalculateCharacteristics(Data.Characteristics_Attacker, Data.CurrentAttacker[0], Data.ResultingItemOfAttacker);
        }
        private void TargetLevelSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Data.CurrentTarget[0].Level = Convert.ToByte(targetLevelSlider.Value);
            Calculation.CalculateCharacteristics(Data.Characteristics_Target, Data.CurrentTarget[0], Data.ResultingItemOfTarget);
        }
    }
}

