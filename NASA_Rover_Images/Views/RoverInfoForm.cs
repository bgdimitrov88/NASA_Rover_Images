using NASA_Rover_Images.Models;
using NASA_Rover_Images.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;

namespace NASA_Rover_Images.Views
{
    public partial class RoverInfoForm : Form, IRoverInfoView
    {
        private readonly INasaApiCommunicator _nasaApiCommunicator;
        private readonly IReadOnlyDictionary<string, LinkLabel.Link> _roverLinks;
        private const string _loadError = "Failed to load data";
        private const string _loadingText = "Loading...";
        private string _roverName;

        public RoverInfoForm()
        {
            InitializeComponent();
            _nasaApiCommunicator = new NasaApiCommunicator();
            _roverLinks = new Dictionary<string, LinkLabel.Link>()
            {
                { Rover.Curiosity, new LinkLabel.Link() { LinkData = "https://www.nasa.gov/mission_pages/msl/overview/index.html" } },
                { Rover.Opportunity,  new LinkLabel.Link() { LinkData = "http://mars.nasa.gov/mer/overview/" } },
                { Rover.Spirit,  new LinkLabel.Link() { LinkData = "http://mars.nasa.gov/mer/overview/" } }
            };
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
            if (linkLabelNASA.Links.Count == 1)
            {
                linkLabelNASA.Links.Remove(_roverLinks[_roverName]);
            }
        }
        
        private void linkLabelNASA_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(linkLabelNASA.Links.Count == 1)
            {
                System.Diagnostics.Process.Start(linkLabelNASA.Links[0].LinkData.ToString());
            }
        }

        public async Task SetRover(string roverName)
        {
            _roverName = roverName;

            nameTextBox.Text = roverName;
            landingDateTextBox.Text = _loadingText;
            totalPhotosTextBox.Text = _loadingText;
            descriptionTextBox.Text = _loadingText;
            linkLabelNASA.Links.Add(_roverLinks[roverName]);

            using (StreamReader streamReader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "/Resources/" + roverName + "Description.txt"))
            {
                descriptionTextBox.Text = streamReader.ReadToEnd();
            }

            //Get a sample picture to extract variable field data - total photos, max sol etc.
            Tuple<bool, IReadOnlyList<Photo>, Error> apiResult = await _nasaApiCommunicator.GetPhotos(roverName, Camera.FHAZ, 50);

            if (apiResult.Item1)
            {
                Rover rover = apiResult.Item2[0].Rover;

                landingDateTextBox.Text = rover.LandingDate.ToString();
                totalPhotosTextBox.Text = rover.TotalPhotos.ToString();
            }
            else
            {
                landingDateTextBox.Text = _loadError;
                totalPhotosTextBox.Text = _loadError;
            }
        }

        public void ShowRoverInfo()
        {
            Show();
        }

        public void HideRoverInfo()
        {
            Hide();
        }
    }
}
