namespace CASAFramework.Senders.FileExtension
{
    public class FileRequest
    {
        public Guid RequestId { get; set; } = Guid.NewGuid();

        public string SenderUsername { get; set; }

        public string Uri { get; set; }
        public string Token { get; set; }
        public Dictionary<string, object> Content = new Dictionary<string, object>();

    }
}