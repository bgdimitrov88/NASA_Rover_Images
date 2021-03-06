﻿using NASA_Rover_Images.Models;
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
        private ComponentResourceManager _resources;
        public bool AutoRefresh { get; set; }
        private const string _loadingText = "Loading...";

        public MainForm(IMainFormPresenter mainFormPresenter, IPaginator paginator, IRoverInfoView roverInfoView)
        {
            InitializeComponent();

            _presenter = mainFormPresenter;
            _paginator = paginator;
            _roverInfoView = roverInfoView;
            _resources = new ComponentResourceManager(typeof(MainForm));
            AutoRefresh = true;
            _initialized = false;

            _presenter.PhotosUpdated += OnPhotosUpdated;
        }

        private void OnPhotosUpdated(object sender, PhotosChangedEventArgs e)
        {
            if(e.Photos != null)
            {
                _paginator.SetItems(e.Photos);

                if(e.Photos.Count > 0)
                {
                    refreshPhotos();
                }
                else
                {
                    ClearPhotosAndAddLabel("No Photos Found");
                }
            }
            else if(e.Error != null)
            {
                ClearPhotosAndAddLabel(e.Error.Errors);
                _paginator.ClearItems();
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
            LoadPhotos();
        }

        private void solNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var sol = (int)solNumericUpDown.Value;
            LoadPhotosForSol(sol);

            var roverLandingDate = _presenter.RoverLandingDates.First(x => x.Key == roverNameComboBox.SelectedItem.ToString()).Value;
            earthDatePicker.Value = roverLandingDate.AddDays(sol);
        }

        private void earthDatePicker_ValueChanged(object sender, EventArgs e)
        {
            var roverLandingDate = _presenter.RoverLandingDates.First(x => x.Key == roverNameComboBox.SelectedItem.ToString()).Value;
            var sol = (earthDatePicker.Value - roverLandingDate).Days;

            LoadPhotosForSol(sol);

            solNumericUpDown.Value = sol;
        }

        private void LoadPhotosForSol(int sol)
        {
            _presenter.Request.Sol = sol;

            if (_initialized && AutoRefresh)
            {
                LoadPhotos();
            }
        }

        private void roverNameComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string roverName = roverNameComboBox.SelectedItem.ToString();
            _presenter.Request.Rover = roverName;
            //Only show cameras for this specific rover
            cameraComboBox.DataSource = _presenter.RoverCameras[roverName];
            earthDatePicker.MinDate = _presenter.RoverLandingDates.First(x => x.Key == roverNameComboBox.SelectedItem.ToString()).Value;
            earthDatePicker.Value = _presenter.RoverLandingDates.First(x => x.Key == roverNameComboBox.SelectedItem.ToString()).Value.AddDays(_presenter.Request.Sol);

            if (_initialized && AutoRefresh)
            {
                LoadPhotos();
            }

            _roverInfoView.SetRover(roverName);
        }

        private void cameraComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            _presenter.Request.Camera = cameraComboBox.SelectedItem.ToString();

            if (_initialized && AutoRefresh)
            {
                LoadPhotos();
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

        private void autoRefreshCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (autoRefreshCheckBox.CheckState == CheckState.Checked)
            {
                LoadPhotos();
            }
        }

        #endregion

        #region Helpers

        private void BindFromModel()
        {
            paginatorBindingSource.DataSource = _paginator;
            cameraComboBox.DataSource = _presenter.RoverCameras.First().Value;
            roverNameComboBox.DataSource = _presenter.RoverCameras.Select(rover => rover.Key).ToList();
            solNumericUpDown.Value = _presenter.Request.Sol;
            earthDatePicker.MinDate = _presenter.RoverLandingDates.First().Value;
            earthDatePicker.Value = _presenter.RoverLandingDates.First().Value.AddDays(_presenter.Request.Sol);
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
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Cursor = Cursors.Hand,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = System.Drawing.Color.White,
                        InitialImage = ((System.Drawing.Image)(_resources.GetObject("photoLoadingSpinner")))
                    };
                    pictureBox.MouseClick += photo_Clicked;
                    pictureBox.LoadCompleted += photo_Loaded;

                    photosFlowLayoutPanel.Controls.Add(pictureBox);
                }

                dateLabel.Text = DateTime.Parse(((Photo)_paginator.CurrentPageContent.First()).EarthDate).ToShortDateString();
            }
        }

        private void ClearPhotosAndAddLabel(string labelText)
        {
            dateLabel.Text = string.Empty;
            photosFlowLayoutPanel.Controls.Clear();
            photosFlowLayoutPanel.Controls.Add(new Label() { Text = labelText });
        }

        private void LoadPhotos()
        {
            ClearPhotosAndAddLabel(_loadingText);
            dateLabel.Text = _loadingText;
            _presenter.GetPhotos();
        }

        #endregion
    }
}
