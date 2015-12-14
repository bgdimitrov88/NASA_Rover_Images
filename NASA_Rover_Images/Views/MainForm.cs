using NASA_Rover_Images.Models;
using NASA_Rover_Images.Utils;
using System;
using System.Windows.Forms;
using System.Linq;
using NASA_Rover_Images.Presenters.MainForm;
using NASA_Rover_Images.Views.ContextMenus;
using System.ComponentModel;

namespace NASA_Rover_Images.Views
{
    public partial class MainForm : Form, IMainView
    {
        private IMainFormPresenter _presenter;
        private IPaginator _paginator;
        private bool _initialized;
        private IRoverInfoView _roverInfoView;
        public bool AutoRefresh { get; set; }

        public MainForm(IMainFormPresenter mainFormPresenter, IPaginator paginator, IRoverInfoView roverInfoView)
        {
            InitializeComponent();

            _presenter = mainFormPresenter;
            _paginator = paginator;
            _roverInfoView = roverInfoView;
            AutoRefresh = false;
            _initialized = false;

            _presenter.PhotosUpdated += OnPhotosUpdated;
        }

        private void OnPhotosUpdated(object sender, PhotosChangedEventArgs e)
        {
            if(e.Photos != null)
            {
                if(e.Photos.Count > 0)
                {
                    _paginator.SetPhotos(e.Photos);
                    refreshPhotos();
                }
                else
                {
                    photosFlowLayoutPanel.Controls.Clear();
                    photosFlowLayoutPanel.Controls.Add(new Label() { Text = "No Photos Found" });
                    _paginator.SetPhotos(null);
                }
            }
            else if(e.Error != null)
            {
                photosFlowLayoutPanel.Controls.Clear();
                photosFlowLayoutPanel.Controls.Add(new Label() { Text = e.Error.Errors });
                _paginator.SetPhotos(null);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            BindFromModel();
            _initialized = true;
        }

        #region Events
        private void getButton_Click(object sender, EventArgs e)
        {
            _presenter.GetPhotos();
        }

        private void solNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _presenter.Request.Sol = (int) solNumericUpDown.Value;

            if (_initialized && AutoRefresh)
            {
                _presenter.GetPhotos();
            }
        }

        private void roverNameComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string roverName = roverNameComboBox.SelectedItem.ToString();
            _presenter.Request.Rover = roverName;
            //Only show cameras for this specific rover
            cameraComboBox.DataSource = _presenter.Rovers[roverName];

            if (_initialized && AutoRefresh)
            {
                _presenter.GetPhotos();
            }

            _roverInfoView.SetRover(roverName);
        }

        private void cameraComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            _presenter.Request.Camera = cameraComboBox.SelectedItem.ToString();

            if (_initialized && AutoRefresh)
            {
                _presenter.GetPhotos();
            }
        }

        private void photo_Clicked(object sender, MouseEventArgs e)
        {
            PictureBox control = (PictureBox)sender;

            if (e.Button == MouseButtons.Left)
            {
                System.Diagnostics.Process.Start(control.ImageLocation);
            }
        }

        private void photo_Loaded(object sender, AsyncCompletedEventArgs e)
        {
            PictureBox control = (PictureBox)sender;
            string imgSrc = control.ImageLocation;
            string imgName = imgSrc.Split('/').LastOrDefault();

            control.ContextMenu = new PhotoContextMenu(imgName, control.Image);
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            if(_paginator.Previous())
            {
                refreshPhotos();
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if(_paginator.Next())
            {
                refreshPhotos();
            }
        }

        private async void roverInfoButton_Click(object sender, EventArgs e)
        {
            await _roverInfoView.SetRover(roverNameComboBox.SelectedValue.ToString());
            _roverInfoView.ShowRoverInfo();
        }

        #endregion

        #region Helpers

        private void BindFromModel()
        {
            paginatorBindingSource.DataSource = _paginator;
            cameraComboBox.DataSource = _presenter.Rovers.First().Value;
            roverNameComboBox.DataSource = _presenter.Rovers.Select(rover => rover.Key).ToList();
            solNumericUpDown.Value = _presenter.Request.Sol;
            autoRefreshCheckBox.DataBindings.Add("Checked", this, "AutoRefresh", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void refreshPhotos()
        {
            if(_paginator.CurrentPageContent.Count > 0)
            {
                photosFlowLayoutPanel.Controls.Clear();

                foreach (var photo in _paginator.CurrentPageContent)
                {
                    var pictureBox = new PictureBox()
                    {
                        ImageLocation = ((Photo)photo).ImgSrc,
                        Width = 64,
                        Height = 64,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Cursor = Cursors.Hand,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    pictureBox.MouseClick += photo_Clicked;
                    pictureBox.LoadCompleted += photo_Loaded;

                    photosFlowLayoutPanel.Controls.Add(pictureBox);
                }

                dateLabel.Text = DateTime.Parse(((Photo)_paginator.CurrentPageContent.First()).EarthDate).ToShortDateString();
            }
        }

        #endregion
    }
}
