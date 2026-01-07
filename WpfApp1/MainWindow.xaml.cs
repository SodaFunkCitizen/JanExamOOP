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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Team> teams = new List<Team>();

        public MainWindow()
        {
            InitializeComponent();
        }

        //Save data to JSON file
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString2 = JsonSerializer.Serialize(teams, options);
            File.WriteAllText("teams.json", jsonString2);


            //Code below commented out but shows dealing with single object serialization
            //Team team = CreateTeam("Warriors");
            //string jsonString = JsonSerializer.Serialize(team, options);
            //File.WriteAllText("team.json", jsonString);

            //Code below commented out but shows dealing with list of objects serialization
            //Team team2 = CreateTeam("Dolphins");
            //List<Team> teams = new List<Team> { team, team2 };
        }

        //Load data from JSON file
        private void bthLoad_Click(object sender, RoutedEventArgs e)
        {
            string path = "teams.json";

            if (!File.Exists(path)) return;

            var json = File.ReadAllText(path);

            teams = JsonSerializer.Deserialize<List<Team>>(json);
            lbxTeams.ItemsSource = teams;
        }

        //Handle team selection change
        private void lbxTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Team selectedTeam = lbxTeams.SelectedItem as Team;

            if (selectedTeam != null)
            {
                lbxPlayers.ItemsSource = selectedTeam.Players;
            }
        }

        //Initialize data on window load
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxPosition.ItemsSource = Enum.GetValues(typeof(Position)).Cast<Position>();

            Team t1 = new Team("Tigers");
            Team t2 = new Team("Eagles");
            Team t3 = new Team("Sharks");

            teams.Add(t1);
            teams.Add(t2);
            teams.Add(t3);

            lbxTeams.ItemsSource = teams;
        }

        //Add player to selected team
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //read date from screen
            string playerName = tbxPlayerName.Text;
            int playerScore = int.Parse(tbxPlayerScore.Text);
            Position playerPosition = (Position)cbxPosition.SelectedItem;

            //create player object
            Player newPlayer = new Player
            {
                Name = playerName,
                Number = playerScore,
                PlayerPosition = playerPosition
            };

            //determine selected team
            Team selectedTeam = lbxTeams.SelectedItem as Team;
            if (selectedTeam != null)
            {
                //add player to team
                selectedTeam.Players.Add(newPlayer);
                //refresh players listbox
                lbxPlayers.ItemsSource = null;
                lbxPlayers.ItemsSource = selectedTeam.Players;

                lbxTeams.ItemsSource = null;
                lbxTeams.ItemsSource = teams;

                tbxPlayerName.Clear();
                tbxPlayerScore.Clear();
                cbxPosition.SelectedIndex = -1;
            }


        }
    }

    //Note code below would normally be in separate files but included here for simplicity
    public class Player
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public Position PlayerPosition { get; set; }

        public override string ToString()
        {
            return $"{Name} - Number: {Number}";
        }
    }

    public class Team
    {
        public string TeamName { get; set; }
        public List<Player> Players { get; set; }

        public Team() : this("") { }

        public Team(string teamName)
        {
            TeamName = teamName;
            Players = new List<Player>();
        }
        public override string ToString()
        {
            return $"{TeamName} ({Players.Count} players)";
        }
    }

    public enum Position
    {
        Goalkeeper,
        Defender,
        Midfielder,
        Forward
    }
}
