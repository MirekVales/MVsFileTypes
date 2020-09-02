using System.Linq;

namespace MVsFileTypes.Contracts
{
    public class Extension
    {
        public string Value { get; }

        public string[] FileExtensions
            => Value?
            .Split(';')
            .OrderBy(item => item)
            .ToArray()
            ?? new string[0];

        public Extension(string value)
            => Value = value?.Trim('.').ToLower() ?? string.Empty;

        public static implicit operator Extension(string extension)
            => new Extension(extension);

        public bool Matches(string extension)
            => FileExtensions.Contains(extension);

        public override bool Equals(object obj)
        {
            if (obj is Extension e)
                return e.FileExtensions.SequenceEqual(FileExtensions);

            return false;
        }

        public override int GetHashCode()
            => string.Concat(FileExtensions).GetHashCode();
    }
}
