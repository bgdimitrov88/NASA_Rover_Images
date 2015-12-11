using NASA_Rover_Images.Models;
using NASA_Rover_Images.Presenters;
using NASA_Rover_Images.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace NASA_Rover_Images.Views
{
    public partial class MainForm : Form, IMainView
    {
        private IMainFormPresenter _presenter;
        private Paginator _paginator;
        private bool _initialized;
        public bool AutoRefresh { get; set; }
        public IRequest PhotosRequest {  get { return _presenter.Request; } }

        public MainForm()
        {
            InitializeComponent();

            _presenter = new MainFormPresenter(this);
            _paginator = new Paginator(12);
            AutoRefresh = false;
            _initialized = false;
        }
        
        protected override void OnLoad(EventArgs e)
        {
            BindFromModel();
            _initialized = true;
        }


        #region IMainView

        public void ShowPhotos(IReadOnlyList<Photo> photos)
        {
            if (photos.Count > 0)
            {
                _paginator.SetPhotos(photos);
                refreshPhotos();
            }
        }

        public void ShowError(Error error)
        {
            photosFlowLayoutPanel.Controls.Clear();
            photosFlowLayoutPanel.Controls.Add(new Label() { Text = error.Errors });
            _paginator.SetPhotos(null);
        }

        #endregion

        #region Events
        private void getButton_Click(object sender, EventArgs e)
        {
            _presenter.GetImages();
        }

        private void solNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _presenter.Request.Sol = (int) solNumericUpDown.Value;

            if (_initialized && AutoRefresh)
            {
                _presenter.GetImages();
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
                _presenter.GetImages();
            }
        }

        private void cameraComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            _presenter.Request.Camera = cameraComboBox.SelectedItem.ToString();

            if (_initialized && AutoRefresh)
            {
                _presenter.GetImages();
            }
        }

        private void photo_Clicked(object sender, EventArgs e)
        {
            PictureBox control = (PictureBox) sender;

            System.Diagnostics.Process.Start(control.ImageLocation);
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
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Cursor = Cursors.Hand,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    pictureBox.Click += photo_Clicked;

                    photosFlowLayoutPanel.Controls.Add(pictureBox);
                }

                dateLabel.Text = DateTime.Parse(((Photo)_paginator.CurrentPageContent.First()).EarthDate).ToShortDateString();
            }
        }

        #endregion

        private void roverInfoButton_Click(object sender, EventArgs e)
        {

        }
    }
}
