namespace NASA_Rover_Images.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.autoRefreshCheckBox = new System.Windows.Forms.CheckBox();
            this.solNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.paginatorPanel = new System.Windows.Forms.Panel();
            this.paginationLabel = new System.Windows.Forms.Label();
            this.paginatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nextButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.photosFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.getButton = new System.Windows.Forms.Button();
            this.cameraComboBox = new System.Windows.Forms.ComboBox();
            this.cameraLabel = new System.Windows.Forms.Label();
            this.solLabel = new System.Windows.Forms.Label();
            this.roverNameLabel = new System.Windows.Forms.Label();
            this.roverNameComboBox = new System.Windows.Forms.ComboBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solNumericUpDown)).BeginInit();
            this.paginatorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paginatorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.dateLabel);
            this.MainPanel.Controls.Add(this.autoRefreshCheckBox);
            this.MainPanel.Controls.Add(this.solNumericUpDown);
            this.MainPanel.Controls.Add(this.paginatorPanel);
            this.MainPanel.Controls.Add(this.getButton);
            this.MainPanel.Controls.Add(this.cameraComboBox);
            this.MainPanel.Controls.Add(this.cameraLabel);
            this.MainPanel.Controls.Add(this.solLabel);
            this.MainPanel.Controls.Add(this.roverNameLabel);
            this.MainPanel.Controls.Add(this.roverNameComboBox);
            this.MainPanel.Location = new System.Drawing.Point(4, 2);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(316, 418);
            this.MainPanel.TabIndex = 0;
            // 
            // autoRefreshCheckBox
            // 
            this.autoRefreshCheckBox.AutoSize = true;
            this.autoRefreshCheckBox.Location = new System.Drawing.Point(216, 129);
            this.autoRefreshCheckBox.Name = "autoRefreshCheckBox";
            this.autoRefreshCheckBox.Size = new System.Drawing.Size(88, 17);
            this.autoRefreshCheckBox.TabIndex = 10;
            this.autoRefreshCheckBox.Text = "Auto Refresh";
            this.autoRefreshCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.autoRefreshCheckBox.UseVisualStyleBackColor = true;
            // 
            // solNumericUpDown
            // 
            this.solNumericUpDown.Location = new System.Drawing.Point(96, 47);
            this.solNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.solNumericUpDown.Name = "solNumericUpDown";
            this.solNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.solNumericUpDown.TabIndex = 9;
            this.solNumericUpDown.ValueChanged += new System.EventHandler(this.solNumericUpDown_ValueChanged);
            // 
            // paginatorPanel
            // 
            this.paginatorPanel.Controls.Add(this.paginationLabel);
            this.paginatorPanel.Controls.Add(this.nextButton);
            this.paginatorPanel.Controls.Add(this.previousButton);
            this.paginatorPanel.Controls.Add(this.photosFlowLayoutPanel);
            this.paginatorPanel.Location = new System.Drawing.Point(9, 159);
            this.paginatorPanel.Name = "paginatorPanel";
            this.paginatorPanel.Size = new System.Drawing.Size(291, 256);
            this.paginatorPanel.TabIndex = 8;
            // 
            // paginationLabel
            // 
            this.paginationLabel.AutoSize = true;
            this.paginationLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.paginatorBindingSource, "PagingInfo", true));
            this.paginationLabel.Location = new System.Drawing.Point(128, 235);
            this.paginationLabel.Name = "paginationLabel";
            this.paginationLabel.Size = new System.Drawing.Size(34, 13);
            this.paginationLabel.TabIndex = 11;
            this.paginationLabel.Text = "0 of 0";
            // 
            // paginatorBindingSource
            // 
            this.paginatorBindingSource.DataSource = typeof(NASA_Rover_Images.Utils.Paginator);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(212, 230);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 10;
            this.nextButton.Text = ">>";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(3, 230);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(75, 23);
            this.previousButton.TabIndex = 9;
            this.previousButton.Text = "<<";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // photosFlowLayoutPanel
            // 
            this.photosFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.photosFlowLayoutPanel.Name = "photosFlowLayoutPanel";
            this.photosFlowLayoutPanel.Size = new System.Drawing.Size(285, 222);
            this.photosFlowLayoutPanel.TabIndex = 8;
            // 
            // getButton
            // 
            this.getButton.Location = new System.Drawing.Point(15, 129);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(75, 23);
            this.getButton.TabIndex = 7;
            this.getButton.Text = "GET";
            this.getButton.UseVisualStyleBackColor = true;
            this.getButton.Click += new System.EventHandler(this.getButton_Click);
            // 
            // cameraComboBox
            // 
            this.cameraComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraComboBox.FormattingEnabled = true;
            this.cameraComboBox.Location = new System.Drawing.Point(96, 87);
            this.cameraComboBox.Name = "cameraComboBox";
            this.cameraComboBox.Size = new System.Drawing.Size(121, 21);
            this.cameraComboBox.TabIndex = 6;
            this.cameraComboBox.SelectedValueChanged += new System.EventHandler(this.cameraComboBox_SelectedValueChanged);
            // 
            // cameraLabel
            // 
            this.cameraLabel.AutoSize = true;
            this.cameraLabel.Location = new System.Drawing.Point(12, 87);
            this.cameraLabel.Name = "cameraLabel";
            this.cameraLabel.Size = new System.Drawing.Size(46, 13);
            this.cameraLabel.TabIndex = 5;
            this.cameraLabel.Text = "Camera:";
            // 
            // solLabel
            // 
            this.solLabel.AutoSize = true;
            this.solLabel.Location = new System.Drawing.Point(12, 47);
            this.solLabel.Name = "solLabel";
            this.solLabel.Size = new System.Drawing.Size(25, 13);
            this.solLabel.TabIndex = 2;
            this.solLabel.Text = "Sol:";
            // 
            // roverNameLabel
            // 
            this.roverNameLabel.AutoSize = true;
            this.roverNameLabel.Location = new System.Drawing.Point(9, 11);
            this.roverNameLabel.Name = "roverNameLabel";
            this.roverNameLabel.Size = new System.Drawing.Size(68, 13);
            this.roverNameLabel.TabIndex = 1;
            this.roverNameLabel.Text = "Rover name:";
            this.roverNameLabel.UseMnemonic = false;
            // 
            // roverNameComboBox
            // 
            this.roverNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roverNameComboBox.FormattingEnabled = true;
            this.roverNameComboBox.Location = new System.Drawing.Point(96, 8);
            this.roverNameComboBox.Name = "roverNameComboBox";
            this.roverNameComboBox.Size = new System.Drawing.Size(172, 21);
            this.roverNameComboBox.TabIndex = 0;
            this.roverNameComboBox.SelectedValueChanged += new System.EventHandler(this.roverNameComboBox_SelectedValueChanged);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(128, 132);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(0, 13);
            this.dateLabel.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 424);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "NASA Rover Images";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solNumericUpDown)).EndInit();
            this.paginatorPanel.ResumeLayout(false);
            this.paginatorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paginatorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label cameraLabel;
        private System.Windows.Forms.Label solLabel;
        private System.Windows.Forms.Label roverNameLabel;
        private System.Windows.Forms.ComboBox roverNameComboBox;
        private System.Windows.Forms.ComboBox cameraComboBox;
        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.FlowLayoutPanel photosFlowLayoutPanel;
        private System.Windows.Forms.Panel paginatorPanel;
        private System.Windows.Forms.Label paginationLabel;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.BindingSource paginatorBindingSource;
        private System.Windows.Forms.NumericUpDown solNumericUpDown;
        private System.Windows.Forms.CheckBox autoRefreshCheckBox;
        private System.Windows.Forms.Label dateLabel;
    }
}

