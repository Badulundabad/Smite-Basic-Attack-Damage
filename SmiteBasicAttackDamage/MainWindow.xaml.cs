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
    public partial class MainWindow : Window
    {
        readonly Stack<Build> buildsStack = new Stack<Build>();
        Build emptyBuild;

        public MainWindow()
        {
            InitializeComponent();

            SetListBoxes(leftListOfGods, sixItemsOfAttacker, Data.SixItemsOfAttacker, attacker, Data.CurrentAttacker, characteristicsOfAttacker, Data.Characteristics_Attacker);
            SetLevelBinding(Data.CurrentAttacker[0], levelOfAttacker, attackerLevelSlider);

            SetListBoxes(rightListOfGods, sixItemsOfTarget, Data.SixItemsOfTarget, target, Data.CurrentTarget, characteristicsOfTarget, Data.Characteristics_Target);
            SetLevelBinding(Data.CurrentTarget[0], levelOfTarget, targetLevelSlider);

            /*Build testBuild = new Build();
            buildsStack.Push(testBuild);
            builds.ItemsSource = buildsStack;*/


        }
        //Снимает статус IsSelected с ListBox'ов при нажатии на другие области окна.
        private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //Если источник события не ListBox
            if (e.Source.GetType().Name != "ListBox")
            {
                ListBox[] listBoxes = { attacker, sixItemsOfAttacker, leftListOfItems, target, sixItemsOfTarget, rightListOfItems };
                for (byte i = 0; i < listBoxes.Length; i++)
                {
                    listBoxes[i].SelectedIndex = -1;
                }
                leftListOfItems.Visibility = Visibility.Collapsed;
                rightListOfItems.Visibility = Visibility.Collapsed;
            }
        }
        private void ItemOfLeftList_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            GetInstanceOf<Item>((ListBoxItem)sender).SetItem(sixItemsOfAttacker, Data.SixItemsOfAttacker, leftListOfItems, Data.ResultingItemOfAttacker);
            Data.Characteristics_Attacker.Calculate(Data.CurrentAttacker[0], Data.ResultingItemOfAttacker);
        }
        private void ItemOfRightList_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            GetInstanceOf<Item>((ListBoxItem)sender).SetItem(sixItemsOfTarget, Data.SixItemsOfTarget, rightListOfItems, Data.ResultingItemOfTarget);
            Data.Characteristics_Target.Calculate(Data.CurrentTarget[0], Data.ResultingItemOfTarget);
        }
        private void leftListOfGods_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            GetInstanceOf<God>((ListBoxItem)sender).SetGod(Data.SixItemsOfAttacker, Data.CurrentAttacker, Data.ResultingItemOfAttacker, leftListOfItems, Data.Characteristics_Attacker);
        }
        private void RightListOfGods_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            GetInstanceOf<God>((ListBoxItem)sender).SetGod(Data.SixItemsOfTarget, Data.CurrentTarget, Data.ResultingItemOfTarget, rightListOfItems, Data.Characteristics_Target);
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
            GetInstanceOf<Item>((ListBoxItem)sender).RemoveItem(sixItemsOfAttacker, Data.SixItemsOfAttacker, leftListOfItems);
            Data.Characteristics_Attacker.Calculate(Data.CurrentAttacker[0], Data.ResultingItemOfAttacker);
        }
        private void SixItemsOfTarget_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            GetInstanceOf<Item>((ListBoxItem)sender).RemoveItem(sixItemsOfAttacker, Data.SixItemsOfAttacker, leftListOfItems);
            Data.Characteristics_Target.Calculate(Data.CurrentTarget[0], Data.ResultingItemOfTarget);
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
        private T GetInstanceOf<T>(ListBoxItem container)
        {
            return (T)container.DataContext;
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
        }

        private void AttackerLevelSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Data.CurrentAttacker[0].Level = Convert.ToByte(attackerLevelSlider.Value);
            Data.Characteristics_Attacker.Calculate(Data.CurrentAttacker[0], Data.ResultingItemOfAttacker);
        }
        private void TargetLevelSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Data.CurrentTarget[0].Level = Convert.ToByte(targetLevelSlider.Value);
            Data.Characteristics_Target.Calculate(Data.CurrentTarget[0], Data.ResultingItemOfTarget);
        }
        private void SetListBoxes
            (
                ListBox listOfGods,
                ListBox sixItems,
                ObservableCollection<Item> sixItemsCollection,
                ListBox godListBox,
                ObservableCollection<God> godCollection,
                ListBox characteristicsListBox,
                Characteristic characteristicInstance
            )
        {
            sixItems.ItemsSource = sixItemsCollection;
            listOfGods.ItemsSource = SQLiteDataAccess.LoadGods();
            godListBox.ItemsSource = godCollection;
            characteristicsListBox.ItemsSource = new ObservableCollection<Characteristic> { characteristicInstance };
        }
        private void SetLevelBinding(God god, TextBlock textBlock, Slider slider)
        {
            var binding = new Binding("Level") { Source = god };
            textBlock.SetBinding(TextBlock.TextProperty, binding);
            slider.SetBinding(Slider.ValueProperty, binding);
        }
    }
}

