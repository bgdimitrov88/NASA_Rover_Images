using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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
                        ImageCodecInfo jpegEncoder = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders().Where(encoder => encoder.FormatDescription == "JPEG").First();
                        EncoderParameters encoderParameters = new EncoderParameters(1);
                        encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 100L);

                         _image.Save(stream, jpegEncoder, encoderParameters);
                    }
                }
            }
        }
    }
}
