
using System;
using System.IO;
using Xamarin.Forms;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(CameraTutorial.iOS.SaveImage_iOS))]

namespace CameraTutorial.iOS
{ 

    public class SaveImage_iOS : ISaveImage
    {

        public void SaveImageToCameraRoll(Stream stream)
        {
            var imageData = NSData.FromStream(stream);
            var image = UIImage.LoadFromData(imageData);
            image.SaveToPhotosAlbum((img, error) =>
            {
 
            });
        }
    }
}
