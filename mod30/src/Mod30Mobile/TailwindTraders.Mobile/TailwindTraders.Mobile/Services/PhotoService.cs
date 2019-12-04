using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace TailwindTraders.Mobile.Services
{
    public class PhotoService
    {
        public async Task<Stream> TakePhoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Xamarin.Forms.Shell.Current.DisplayAlert("No Camera", "Taking photos not supported", "OK");
                return null;
            }

            var options = new StoreCameraMediaOptions { CompressionQuality = 50, PhotoSize = Plugin.Media.Abstractions.PhotoSize.Large };
            var photo = await CrossMedia.Current.TakePhotoAsync(options);

            if (photo == null)
                return null;

            return photo.GetStream();
        }

        public async Task<Stream> PickPhoto()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Xamarin.Forms.Shell.Current.DisplayAlert("No Photos", "Photo picking not supported", "OK");
                return null;
            }
            
            var options = new PickMediaOptions { CompressionQuality = 50, PhotoSize = Plugin.Media.Abstractions.PhotoSize.Large };
            var photo = await CrossMedia.Current.PickPhotosAsync(options);

            if (photo == null)
                return null;

            return photo[0].GetStream();
        }
    }
}
