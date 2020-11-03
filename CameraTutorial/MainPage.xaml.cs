using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace CameraTutorial
{
    public partial class MainPage : ContentPage
    {
        private FileResult _photo;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCameraBtnClicked(object sender, EventArgs e)
        {
            _photo = await MediaPicker.CapturePhotoAsync();

            if (_photo != null)
            {
                var stream = await _photo.OpenReadAsync();
                PhotoImage.Source = ImageSource.FromStream(() =>
                {
                    return stream;
                });
            }
            SaveBtn.IsEnabled = true;
        }

        private async void OnSaveBtnClicked(object sender, EventArgs e)
        {
            if (_photo != null)
            {
                // save the file into 'Camera Roll'
                var stream = await _photo.OpenReadAsync();
                DependencyService.Get<ISaveImage>().SaveImageToCameraRoll(stream);
            }
            SaveBtn.IsEnabled = false;
        }
    }
}
