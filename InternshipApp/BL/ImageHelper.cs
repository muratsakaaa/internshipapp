using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using DAL;
using System.Windows.Media.Imaging;
using Logging;

namespace BL
{
    public static class ImageHelper
    {
        public static byte[] ConvertImageToByte(String imagefile)
        {
            MemoryStream ms = new MemoryStream();
            ExceptionCatcher.ExceptionFinder(() =>
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(imagefile);
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            });                     
            return ms.ToArray();
        }

        public static BitmapImage ConvertByteToImage(byte[] byteArr)
        {
            BitmapImage btm=null;
            ExceptionCatcher.ExceptionFinder(() => {
                using (MemoryStream ms = new MemoryStream(byteArr))
                {
                    btm = new BitmapImage();
                    btm.BeginInit();
                    btm.StreamSource = ms;
                    btm.CacheOption = BitmapCacheOption.OnLoad;
                    btm.EndInit();
                    btm.Freeze();
                }

            });           
            return btm;
        }
    }
}
