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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using System.Text.Json;

namespace WpfApp1
{
    public abstract class Robot
    {

        #region Properties

        private readonly string _Robotname;
        public string RobotName
        {
            get { return _Robotname; }
        }

        public double PowerCapicityKWH { get; set; }
        public double CurrentPowerKWH { get; set; }
        #endregion

        #region Constructors
        public Robot(string name, double PowerCap, double CurrentPower)
        {
            _Robotname = name;
            PowerCapicityKWH = PowerCap;
            CurrentPowerKWH = CurrentPower;
        }
    }
}
#endregion
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
