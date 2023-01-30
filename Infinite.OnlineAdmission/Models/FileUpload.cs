namespace Infinite.OnlineAdmission.Models
{
    public class FileUpload
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
    }
}
