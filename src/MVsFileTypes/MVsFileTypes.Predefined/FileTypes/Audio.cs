using MVsFileTypes.Contracts;
using System.Collections.Generic;
using MVsFileTypes.Contracts.Collections;

namespace MVsFileTypes.Predefined.FileTypes
{
    public static class Audio
    {
        public static string ID = "AUD";
        public static string UserName = "Audio File Types";

        public static IEnumerable<FileType> GetFileTypes()
        {
            yield return (ID + "01", "aac", "Advanced Audio Coding");
            yield return (ID + "02", "aiff", "Apple Audio File");
            yield return (ID + "03", "flac", "Free Lossless Audio Codec");
            yield return (ID + "04", "mp3", "MPEG Layer III Audio");
            yield return (ID + "05", "ogg;oga;mogg", "Ogg-Vorbis");
            yield return (ID + "06", "ra;rm", "RealAudio");
            yield return (ID + "07", "wav", "WAV File");
            yield return (ID + "08", "wma", "Windows Media Audio File");
            yield return (ID + "09", "cda", "CDA File");
            yield return (ID + "10", "midi", "MIDI File");
        }

        public static FileTypeGroup Get()
            => new FileTypeGroup()
            {
                ID = Audio.ID,
                Name = Audio.UserName,
                FileTypes = GetFileTypes()
            };
    }
}
