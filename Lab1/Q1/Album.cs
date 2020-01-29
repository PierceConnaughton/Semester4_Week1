using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{

    /*
        2.	Create a class called Band with Band Name, Year formed and Members.
        3.	Create 6 bands and display in the listbox
        4.	Implement IComparable to enable sorting by Band Name
        5.	Sort the bands
        6.	Make Band an abstract class
        7.	Create sub classes of Rock Band, Pop Band and Indie Band
        8.	Override the ToString() method to display the type of band in the listbox.
        9.	Create an album class, which should have Album Name, Released (a year), Sales.
            Use random for year of release and sales.
        10.	Clicking on a band name should display the Name, Year Formed and Members along with a list of the Albums
        11.	Add filtering to filter by Genre
        12.	Amend Released to a DateTime object and calculate years since release which should be displayed in the listbox.
        13.	Add functionality to write the band information to file. 
    */
    public class Album
    {
        #region Properties
        public string AlbumName;
        public DateTime Released;
        public int Sales;
        #endregion Properties

        #region Constructors
        public Album()
        {

        }

        public Album(string albumName,DateTime released,int sales)
        {
            AlbumName = albumName;
            Released = released;
            Sales = sales;
        }
        #endregion Constructors

        public override string ToString()
        {

            //timespan too find out how many months its been since the album has been released
            TimeSpan timeSpan = DateTime.Now - Released;

            int months = timeSpan.Days / 365;

            return AlbumName + ", Year Released: " + Released.ToShortDateString() + ", Sales: €" + Sales + " Time since release: " + months + " Months";
        }
    }
}
