using System.IO;
using Xamarin.Forms;

namespace CameraTutorial
{
    public interface ISaveImage
    {
        void SaveImageToCameraRoll(Stream stream);
    }
}
