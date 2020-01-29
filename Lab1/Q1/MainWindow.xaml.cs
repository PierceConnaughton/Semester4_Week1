using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
            /*
        2.	Create a class called Band with Band Name, Year formed and Members.
        3.	Create 6 bands and display in the listbox
        4.	Implement IComparable to enable sorting by Band Name
        5.	Sort the bands
        6.	Make Band an abstract class
        7.	Create sub classes of Rock Band, Pop Band and Indie Band
        8.	Override the ToString() method to display the type of band in the listbox.
        9.	Create an album class, which should have Album Name, Released (a year), Sales.  Use random for year of release and sales.
        10.	Clicking on a band name should display the Name, Year Formed and Members along with a list of the Albums
        11.	Add filtering to filter by Genre
        12.	Amend Released to a DateTime object and calculate years since release which should be displayed in the listbox.
        13.	Add functionality to write the band information to file. 
    */
    public partial class MainWindow : Window
    {

        //auto refresh list 
        //ObservableCollection<Band> bands;

            //list for all bands and diffrent genre of bands
        List<Band> bands = new List<Band>();

        List<Band> RockBands = new List<Band>();

        List<Band> PopBands = new List<Band>();

        List<Band> Indiebands = new List<Band>();

        //random number generator
        public Random rnd = new Random(); 

        //random release dates too choose from
        DateTime[] ReleaseDates = {
                new DateTime(1991,10,13) , new DateTime(1992,10,13), new DateTime(1993,10,13), new DateTime(1994,10,13), new DateTime(1995,10,13),
                new DateTime(1996,10,13), new DateTime(1997,10,13), new DateTime(1998,10,13), new DateTime(1999,10,13), new DateTime(2015,10,13),
                new DateTime(2011,10,13),new DateTime(2012,10,13),new DateTime(2013,10,13),new DateTime(2014,10,13)
             };

        //bool for when the save button is clicked
        private bool savebtnClicked = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        //method too generate a random date for the bands album but has too be after the band was created
        public DateTime RandomDate(string x)
        {
            if (x == "1D")
            {
                int randomDate = rnd.Next(11, 14);
                DateTime releaseDate = ReleaseDates[randomDate];
                return releaseDate;
            }
            else if (x == "SlipKnot")
            {
                int randomDate = rnd.Next(5, 14);
                DateTime releaseDate = ReleaseDates[randomDate];
                return releaseDate;
            }
            else if (x == "Metallica")
            {
                int randomDate = rnd.Next(1, 14);
                DateTime releaseDate = ReleaseDates[randomDate];
                return releaseDate;
            }
            else if (x == "MegaDeth")
            {
                int randomDate = rnd.Next(1, 14);
                DateTime releaseDate = ReleaseDates[randomDate];
                return releaseDate;
            }
            else if (x == "Iron Maiden")
            {
                int randomDate = rnd.Next(1, 14);
                DateTime releaseDate = ReleaseDates[randomDate];
                return releaseDate;
            }
            else if (x == "Linkin Park")
            {
                int randomDate = rnd.Next(6, 14);
                DateTime releaseDate = ReleaseDates[randomDate];
                return releaseDate;
            }
            else
            {
                return DateTime.Now;
            }
        }

        //method for sales
        public int RandomSales()
        {
           int rndSales = rnd.Next(100000, 1000000);
            return rndSales;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //creating Bands
            #region Bands

            Band band1 = new RockBand("SlipKnot", new DateTime(1995, 8, 18), "Corey Taylor, Joey Jordison, Shawn Crahan, Sid Wilson");

            Album Iowa = new Album("Iowa", RandomDate(band1.BandName), RandomSales());
            band1.Albums.Add(Iowa);

            Band band2 = new RockBand("Metallica", new DateTime(1981, 8, 18), "James Hetfield, Kirk Hammett, Lars Ulrich");
            Album JusticeForAll = new Album("... And Justice For All", RandomDate(band2.BandName), RandomSales());
            band2.Albums.Add(JusticeForAll);

            Band band3 = new RockBand("MegaDeth", new DateTime(1983, 8, 18), "Dave Mustaine, Marty Friedman, Kiko Loureiro");
            Album PeaceSells = new Album("Peace Sells", RandomDate(band3.BandName), RandomSales());
            band3.Albums.Add(PeaceSells);

            Band band4 = new RockBand("Iron Maiden", new DateTime(1975, 8, 18), "Bruce Dickinson, Steve Harris, Paul Di'Anno");
            Album NumberOfTheBeast = new Album("Number Of The Beast", RandomDate(band4.BandName), RandomSales());
            band4.Albums.Add(NumberOfTheBeast);

            Band band5 = new PopBand("1D", new DateTime(2011, 8, 18), "Harry Styles, Zayn Malik, Louis Tomlinson, Niall Horan, Liam Payne");
            Album UpAllNight = new Album("Up All Night", RandomDate(band5.BandName), RandomSales());
            band5.Albums.Add(UpAllNight);

            Band band6 = new IndieBand("Linkin Park", new DateTime(1996, 8, 18), "Chester Bennington, Mike Shinoda, Joe Hahn");
            Album Meteora = new Album("Meteora", RandomDate(band6.BandName), RandomSales());
            band6.Albums.Add(Meteora);

            #endregion Bands

            combGenres.Items.Add("Rock");
            combGenres.Items.Add("Pop");
            combGenres.Items.Add("Indie");

            //auto refrfreshable list
            //bands = new ObservableCollection<Band>();

            //add bands too lists
            #region AddBands
            bands.Add(band1);
            bands.Add(band2);
            bands.Add(band3);
            bands.Add(band4);

            RockBands.Add(band1);
            RockBands.Add(band2);
            RockBands.Add(band3);
            RockBands.Add(band4);

            bands.Add(band5);

            PopBands.Add(band5);

            bands.Add(band6);

            Indiebands.Add(band6);

            #endregion AddBands

            //sort bands and add them too list
            bands.Sort();

            lstbxBands.ItemsSource = bands;

           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        

            private void LstbxBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if this band has been selected show all details about band and prsent each album in a list
            Band selectedBand = lstbxBands.SelectedItem as Band;

            if (selectedBand != null)
            {
                txtBlMembers.Text = selectedBand.Members;
                txtBlYearFormed1.Text = selectedBand.YearFormed.ToShortDateString();

                lstBxAlbums.ItemsSource = selectedBand.Albums;


                //if savebtn has been clicked write info about the band and there albums too text file
                if (savebtnClicked == true)
                {
                    FileStream fs = new FileStream(@"H:\Year Two\Semester 4\Programming\Lab1\BandFile.txt", FileMode.Append, FileAccess.Write);

                    StreamWriter sw = new StreamWriter(fs);

                
                    sw.WriteLine("Band name and Genre : " + selectedBand + " Band members: " + selectedBand.Members  + " Year Formed "
                        + selectedBand.YearFormed.ToShortDateString());

                    foreach (Album selectedAlbum in selectedBand.Albums)
                    {
                        int x = 1;
                        sw.WriteLine("Album " + x + " of " + selectedBand.BandName + " is " + selectedAlbum.ToString());

                        x++;
                    }

                    sw.WriteLine("");

                    

                    sw.Close();

                    savebtnClicked = false;
                    
                }
            

            }
            else
            {
                //if band cant be found that you selected
                MessageBox.Show("No band has been selected");

                savebtnClicked = false;
            }
            
            

        }

        private void LstbxBands_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void combGenres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //changes what list is shown depending whats been picked from combo box

            if (this.combGenres.SelectedItem == "Rock")
            {
                RockBands.Sort();
                lstbxBands.ItemsSource = null;
                lstbxBands.ItemsSource = RockBands;

                

            }

            else if (this.combGenres.SelectedItem == "Pop")
            {
                PopBands.Sort();
                lstbxBands.ItemsSource = null;
                lstbxBands.ItemsSource = PopBands;

               
            }

            else if (this.combGenres.SelectedItem == "Indie")
            {
                Indiebands.Sort();
                lstbxBands.ItemsSource = null;
                lstbxBands.ItemsSource = Indiebands;

                
            }


        }

        //refresh the screen
        private void RefreshScreen()
        {

            bands.Sort();
            lstbxBands.ItemsSource = null;
            lstbxBands.ItemsSource = bands;

            

            
        }

        //when save btn is clicked
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Band has been saved too text file");
            savebtnClicked = true;
        }
    }
}
