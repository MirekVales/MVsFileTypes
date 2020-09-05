using MVsFileTypes.Contracts;
using MVsFileTypes.Contracts.Collections;
using System.Collections.Generic;

namespace MVsFileTypes.Predefined.FileTypes
{
    public static class Image
    {
        public static string ID = "IMG";
        public static string UserName = "Image File Types";

        public static IEnumerable<FileType> GetFileTypes()
        {
            yield return (ID + "01", "bmp", "Bitmap File");
            yield return (ID + "02", "jpg;jpeg;jpe", "JPEG File");
            yield return (ID + "03", "gif", "GIF File");
            yield return (ID + "04", "png", "PNG File");
            yield return (ID + "05", "tif;tiff", "Tagged Image File");
            yield return (ID + "06", "pcx", "PCX File");
            yield return (ID + "07", "rle", "RLE File").Legacy();
            yield return (ID + "08", "dib", "DIB File").Legacy();
            yield return (ID + "09", "ps", "Adobe PostScript File");
            yield return (ID + "10", "eps", "Adobe PostScript File");
            yield return (ID + "11", "prs", "Adobe PostScript File");
            yield return (ID + "12", "psd", "Adobe Photoshop File");
            yield return (ID + "13", "ai", "Adobe Illustrator File");
            yield return (ID + "14", "svg", "Scalable Vector Graphics File");
            yield return (ID + "15", "tga", "Targa File");
            yield return (ID + "16", "eps", "EPS File");
        }

        public static FileTypeGroup Get()
            => new FileTypeGroup()
            {
                ID = Image.ID,
                Name = Image.UserName,
                FileTypes = GetFileTypes()
            };
    }
}
