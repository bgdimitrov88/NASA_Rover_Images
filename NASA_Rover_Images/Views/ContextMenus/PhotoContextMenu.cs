using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NASA_Rover_Images.Views.ContextMenus
{
    public class PhotoContextMenu : ContextMenu
    {
        private SaveFileDialog _saveFileDialog;
        private Image _image;

        public PhotoContextMenu(string imageName, Image image)
        {
            MenuItems.Add(new MenuItem("Save as...", OnSaveAsClick));
            _saveFileDialog = new SaveFileDialog()
            {
                AddExtension = true,
                CheckPathExists = true,
                DefaultExt = ".JPG",
                FileName = imageName,
                OverwritePrompt = true,
                Title = "Save Rover Image",
                Filter = "JPG files (*.jpg)|*.jpg|All files (*.*)|*.*"
            };
            _image = image;
        }

        private void OnSaveAsClick(object sender, EventArgs e)
        {
            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream stream = _saveFileDialog.OpenFile())
                {
                    if (stream != null)
                    {
                         _image.Save(stream, _image.RawFormat);
                    }
                }
            }
        }
    }
}
