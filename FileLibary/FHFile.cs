namespace FileLibary
{
    public abstract class FHFile
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] Data { get; set; }
    }
}