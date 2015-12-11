namespace NASA_Rover_Images.Views
{
    partial class RoverInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoverInfoForm));
            this.nameLabel = new System.Windows.Forms.Label();
            this.landingDateLabel = new System.Windows.Forms.Label();
            this.totalPhotosLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.landingDateTextBox = new System.Windows.Forms.TextBox();
            this.totalPhotosTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.linkLabelNASA = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(13, 13);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // landingDateLabel
            // 
            this.landingDateLabel.AutoSize = true;
            this.landingDateLabel.Location = new System.Drawing.Point(13, 41);
            this.landingDateLabel.Name = "landingDateLabel";
            this.landingDateLabel.Size = new System.Drawing.Size(77, 13);
            this.landingDateLabel.TabIndex = 1;
            this.landingDateLabel.Text = "Landing Date: ";
            // 
            // totalPhotosLabel
            // 
            this.totalPhotosLabel.AutoSize = true;
            this.totalPhotosLabel.Location = new System.Drawing.Point(13, 71);
            this.totalPhotosLabel.Name = "totalPhotosLabel";
            this.totalPhotosLabel.Size = new System.Drawing.Size(70, 13);
            this.totalPhotosLabel.TabIndex = 2;
            this.totalPhotosLabel.Text = "Total Photos:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(98, 13);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // landingDateTextBox
            // 
            this.landingDateTextBox.Location = new System.Drawing.Point(98, 41);
            this.landingDateTextBox.Name = "landingDateTextBox";
            this.landingDateTextBox.ReadOnly = true;
            this.landingDateTextBox.Size = new System.Drawing.Size(100, 20);
            this.landingDateTextBox.TabIndex = 4;
            // 
            // totalPhotosTextBox
            // 
            this.totalPhotosTextBox.Location = new System.Drawing.Point(98, 71);
            this.totalPhotosTextBox.Name = "totalPhotosTextBox";
            this.totalPhotosTextBox.ReadOnly = true;
            this.totalPhotosTextBox.Size = new System.Drawing.Size(100, 20);
            this.totalPhotosTextBox.TabIndex = 5;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(16, 100);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(256, 150);
            this.descriptionTextBox.TabIndex = 6;
            // 
            // linkLabelNASA
            // 
            this.linkLabelNASA.AutoSize = true;
            this.linkLabelNASA.Location = new System.Drawing.Point(13, 258);
            this.linkLabelNASA.Name = "linkLabelNASA";
            this.linkLabelNASA.Size = new System.Drawing.Size(110, 13);
            this.linkLabelNASA.TabIndex = 8;
            this.linkLabelNASA.TabStop = true;
            this.linkLabelNASA.Text = "Link to NASA website";
            // 
            // RoverInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 280);
            this.Controls.Add(this.linkLabelNASA);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.totalPhotosTextBox);
            this.Controls.Add(this.landingDateTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.totalPhotosLabel);
            this.Controls.Add(this.landingDateLabel);
            this.Controls.Add(this.nameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RoverInfoForm";
            this.Text = "RoverInfoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label landingDateLabel;
        private System.Windows.Forms.Label totalPhotosLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox landingDateTextBox;
        private System.Windows.Forms.TextBox totalPhotosTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.LinkLabel linkLabelNASA;
    }
}