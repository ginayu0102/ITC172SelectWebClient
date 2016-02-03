using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowTrackerForm : System.Web.UI.Page
{
    ShowTrackerServiceReference.SelectServiceClient db
        = new ShowTrackerServiceReference.SelectServiceClient();
    
    //Artist
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDropDown();
        }

        if (!IsPostBack)
        {
            LoadDropDown2();
        }
    }
    protected void DropDownListArtist_SelectedIndexChanged(object sender, EventArgs e)
    {
               
            FillGrid();
        
    }

    protected void LoadDropDown()
    {
        string[] artists = db.GetArtists();
        DropDownListArtist.DataSource = artists;
        DropDownListArtist.DataBind();
        DropDownListArtist.Items.Insert(0, "Choose an Artist");

    }

    protected void FillGrid()
    {
        string artist = DropDownListArtist.SelectedItem.Text;
        ShowTrackerServiceReference.ReviewInfo[] shows = db.GetShowByArtist(artist);
        GridViewShowA.DataSource = shows;
        GridViewShowA.DataBind();
    }
    
    //Venue
     protected void DropDownListVenue_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            FillGrid2();
        
    }

    protected void LoadDropDown2()
    {
        string[] venues = db.GetVenues();
        DropDownListVenue.DataSource = venues;
        DropDownListVenue.DataBind();
        DropDownListVenue.Items.Insert(0, "Choose a Venue");
    }


    protected void FillGrid2()
    {

        string venue = DropDownListVenue.SelectedItem.Text;
        ShowTrackerServiceReference.ReviewInfo[] shows = db.GetShowByVenue(venue);
        GridViewShowV.DataSource = shows;
        GridViewShowV.DataBind();
            
    }

       
}