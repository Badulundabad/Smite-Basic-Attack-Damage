using Smite_Auto_Attack_Damage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Smite_Auto_Attack_Damage
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Characteristics[] stats = new Characteristics[] { new Characteristics("/Images/Stats/HandDamage.png", 200) };
            attackerTestListBox.ItemsSource = stats;
            targetTestListBox.ItemsSource = stats;
            var sixItems = new GarbageTestClass[6];
            for (int i = 0; i < sixItems.Length; i++)
            {
                sixItems[i] = new GarbageTestClass("/Images/Items/bloodforge.png");
            }
            var manyItems = new GarbageTestClass[50];
            for (int i = 0; i < sixItems.Length; i++)
            {
                manyItems[i] = new GarbageTestClass("/Images/Items/bloodforge.png");
            }

            godsListsItems.ItemsSource = manyItems;
            targetsListsItems.ItemsSource = manyItems;

            godsItems.ItemsSource = sixItems;
            targetsItems.ItemsSource = sixItems;

            godBuildsItems.ItemsSource = sixItems;
            //items.ItemsSource = sixItems;
            var manyZeuses = new GarbageTestClass[100];
            for (int i = 0; i < manyZeuses.Length; i++)
            {
                manyZeuses[i] = new GarbageTestClass("/Images/GodIcons/zeus.png");
            }
        }
    }
}
