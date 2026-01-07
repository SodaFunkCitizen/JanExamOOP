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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    
    public abstract class Robot
    {


        #region Properties
        private readonly string _Robotname;
        private readonly string _RobotType;
        public string RobotName
        {
            get { return _Robotname; }
        }
        public string RobotType
        {
            get { return _RobotType; }
        }

        public double PowerCapicityKWH { get; set; }
        public double CurrentPowerKWH { get; set; }
        #endregion

        #region Constructors
        public Robot(string name, double PowerCap, double CurrentPower, string type)
        {
            _Robotname = name;
            PowerCapicityKWH = PowerCap;
            CurrentPowerKWH = CurrentPower;
            _RobotType = type;
        }

        #endregion
        static void CreateRobots()
        {

        }
        public static void downloadSkill()
        {

        }
        static void GetBatteryPercentage()
        {

        }
        public string DisplayBatteryInformation()
        {
         return $"Battery information\nCapacity:{PowerCapicityKWH}KWH\nCurrent Power:{CurrentPowerKWH}KWH\nBattery Level:{(CurrentPowerKWH / PowerCapicityKWH) * 100}%)";
        }
        public string DescribeRobot()
        {
            return $"Robot Name:{RobotName}\nPower Capacity:{PowerCapicityKWH}KWH\nCurrent Power:{CurrentPowerKWH}KWH";
        }
        public override string ToString()
        {
            return $"{RobotName}-{RobotType}";
        }
    }
    public abstract class deliveryRobot : Robot
    {
        public deliveryRobot(string name, double PowerCap, double CurrentPower,string type)
            : base(name, PowerCap, CurrentPower,type)
        {
        }
    }
    public abstract class householdRobot : Robot
    {
        public householdRobot(string name, double PowerCap, double CurrentPower, string type)
            : base(name, PowerCap, CurrentPower, type)
        {
        }
    }
}
