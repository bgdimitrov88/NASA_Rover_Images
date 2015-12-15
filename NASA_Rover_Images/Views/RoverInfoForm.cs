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
        private readonly IReadOnlyDictionary<string, string> _roverLinks;
        private const string _loadError = "Failed to load data";
        private const string _loadingText = "Loading...";
        private string _roverName;
        private readonly LinkLabel.Link _linkLabel;

        public RoverInfoForm(INasaApiCommunicator nasaApiCommunicator)
        {
            InitializeComponent();
            _nasaApiCommunicator = nasaApiCommunicator;
            _roverLinks = new Dictionary<string, string>()
            {
                { Rover.Curiosity, "https://www.nasa.gov/mission_pages/msl/overview/index.html" },
                { Rover.Opportunity,  "http://mars.nasa.gov/mer/overview/"},
                { Rover.Spirit,   "http://mars.nasa.gov/mer/overview/" }
            };

            _linkLabel = new LinkLabel.Link();

            linkLabelNASA.Links.Add(_linkLabel);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();

            _linkLabel.LinkData = null;
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
            if(roverName != _roverName)
            {
                _roverName = roverName;

                nameTextBox.Text = roverName;
                landingDateTextBox.Text = _loadingText;
                totalPhotosTextBox.Text = _loadingText;
                descriptionTextBox.Text = _loadingText;
                _linkLabel.LinkData = _roverLinks[roverName];

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
        }

        public void ShowRoverInfo()
        {
            if(!Visible)
            {
                Show();
            }
            else
            {
                BringToFront();
            }
        }

        public void HideRoverInfo()
        {
            Hide();
        }
    }
}
