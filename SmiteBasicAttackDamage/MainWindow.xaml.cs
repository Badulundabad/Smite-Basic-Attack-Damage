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
using System.Globalization;

namespace SmiteBasicAttackDamage
{
    public partial class MainWindow : Window
    {
        readonly Stack<Build> buildsStack = new Stack<Build>();
        Build emptyBuild;

        GodEntity attacker = new GodEntity();
        GodEntity target = new GodEntity();
        public MainWindow()
        {
            InitializeComponent();

            attacker.SetReferences(attackerListBox, sixItemsOfAttacker, leftListOfItems, leftListOfGods, characteristicsOfAttacker, attackerLevelSlider, levelOfAttacker);
            target.SetReferences(targetListBox, sixItemsOfTarget, rightListOfItems, rightListOfGods, characteristicsOfTarget, targetLevelSlider, levelOfTarget);

            /*Build testBuild = new Build();
            buildsStack.Push(testBuild);
            builds.ItemsSource = buildsStack;*/
        }
        
        private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e) //Снимает статус IsSelected с ListBox'ов при нажатии на другие области окна.
        {
            if (e.Source.GetType().Name != "ListBox") //Если источник события не ListBox
            {
                ListBox[] listBoxes = { attackerListBox, sixItemsOfAttacker, leftListOfItems, targetListBox, sixItemsOfTarget, rightListOfItems };
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
            GetInstanceOf<Item>((ListBoxItem)sender).SetItem(attacker);
            attacker.Characteristics.Calculate(attacker.Current[0], attacker.ResultingItem);
        }
        private void ItemOfRightList_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            GetInstanceOf<Item>((ListBoxItem)sender).SetItem(target);
            target.Characteristics.Calculate(target.Current[0], target.ResultingItem);
        }
        private void leftListOfGods_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            GetInstanceOf<God>((ListBoxItem)sender).SetGod(attacker);
        }
        private void RightListOfGods_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            GetInstanceOf<God>((ListBoxItem)sender).SetGod(target);
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
            GetInstanceOf<Item>((ListBoxItem)sender).RemoveItemFrom(attacker);
            attacker.Characteristics.Calculate(attacker.Current[0], attacker.ResultingItem);
        }
        private void SixItemsOfTarget_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            GetInstanceOf<Item>((ListBoxItem)sender).RemoveItemFrom(target);
            target.Characteristics.Calculate(target.Current[0], target.ResultingItem);
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
            for (int i = 0; i < 5; i++)
            {
                somethingTextBlock.Text += attacker.Current[0].Progression[i].ToString();

            }
        }

        private void TestButton2_Click(object sender, RoutedEventArgs e)
        {
            attacker.GodSlot.Tag = "Magical";
        }

        private void AttackerLevelSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            attacker.Current[0].Level = Convert.ToByte(attacker.LevelSlider.Value);
            attacker.Characteristics.Calculate(attacker.Current[0], attacker.ResultingItem);
        }
        private void TargetLevelSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            target.Current[0].Level = Convert.ToByte(target.LevelSlider.Value);
            target.Characteristics.Calculate(target.Current[0], target.ResultingItem);
        }


    }
}

