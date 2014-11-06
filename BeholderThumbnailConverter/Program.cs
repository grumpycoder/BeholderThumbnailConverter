using BeholderThumbnailConverter.Data;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace BeholderThumbnailConverter
{
    class Program
    {
        private static readonly AppContext DB = new AppContext();

        static void Main(string[] args)
        {
            var list = DB.Images.Where(x => x.MimeTypeId == 6).OrderBy(o => o.Id).Take(5).ToList();
            //var list = DB.Images.Where(x => x.Thumbnail != null && x.MediaImages.Any(y => y.ChapterMediaImageRels.Any(a => a.ChapterId == 4651))).Take(5000).OrderBy(x => x.Id).ToList();
            //var list = DB.Images.Where(x => x.Thumbnail != null && x.MediaImages.Any(y => y.ChapterMediaImageRels.Any())).Take(5000).OrderBy(x => x.Id).ToList();

            var i = 0;
            Console.WriteLine("Total Record: {0}", list.Count);
            foreach (var item in list)
            {
                i++;
                Console.WriteLine("{0} or {1} - ImageId: {2}", i, list.Count, item.Id);
                item.Thumbnail = CreateThumb(Decompress(item.IMAGE1), null, 160, 240);
                DB.SaveChanges();
            }

            Console.WriteLine("Complete");
            Console.ReadLine();
        }


        public static byte[] CreateThumb(byte[] origninalImage, int? largestSide, int? height, int? width)
        {
            try
            {

                byte[] testImage;
                //var s = new MemoryStream();
                //s.Write(origninalImage, 0, origninalImage.Length);

                //var b = Image.FromStream(s);
                var startImage = Image.FromStream(new MemoryStream(origninalImage));

                int newHeight;
                int newWidth;

                if (height != null && width != null)
                {
                    newHeight = height ?? 0;
                    newWidth = width ?? 0;
                }
                else
                {
                    double hwRatio;
                    if (startImage.Height > startImage.Width)
                    {
                        newHeight = largestSide ?? 0;
                        hwRatio = (double) largestSide/startImage.Height;
                        newWidth = (int) (hwRatio*startImage.Width);
                    }
                    else
                    {
                        newWidth = largestSide ?? 0;
                        hwRatio = (double) largestSide/startImage.Width;
                        newHeight = (int) (hwRatio*startImage.Height);
                    }
                }

                //newWidth = 240;
                //newHeight = 160;
                using (var thumbnail = startImage.GetThumbnailImage(newWidth, newHeight, null, new IntPtr()))
                    //using (var thumbnail = b.GetThumbnailImage(240, 160, null, new IntPtr()))
                {
                    using (var ms = new MemoryStream())
                    {
                        thumbnail.Save(ms, ImageFormat.Jpeg);
                        testImage = ms.ToArray();
                    }
                }
                startImage = null;
                //s = null;
                return testImage;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: {0}", e.InnerException);
                return null;
            }
        }

        public static byte[] Decompress(byte[] gzip)
        {
            // Create a GZIP stream with decompression mode.
            // ... Then create a buffer and write into while reading from the GZIP stream.
            byte[] b;

            using (var mstream = new MemoryStream(gzip))
            {
                using (var zstream = new ZipInputStream(mstream))
                {
                    var myZipEntry = zstream.GetNextEntry();
                    var filename = myZipEntry.Name;

                    const int size = 4096;
                    var buffer = new byte[size];
                    using (var memory = new MemoryStream())
                    {
                        var count = 0;
                        do
                        {
                            count = zstream.Read(buffer, 0, size);
                            if (count > 0)
                            {
                                memory.Write(buffer, 0, count);
                            }
                        }
                        while (count > 0);
                        b = memory.ToArray();
                        //return memory.ToArray();
                    }
                }
            }
            return b;
        }


    }
}
