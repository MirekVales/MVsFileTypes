namespace MVsFileTypes.Contracts
{
    public class FileType
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Extension Extension { get; set; }
        public FileTypeFlags Flags { get; set; }

        public static implicit operator FileType((string id, string extension, string name) definition)
            => new FileType()
            {
                ID = definition.id,
                Extension = definition.extension,
                Name = definition.name
            };
    }
}
