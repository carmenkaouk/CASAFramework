
namespace CASAFramework.Senders.FileExtension;

internal class EncryptedRequestWrapper
{
    public byte[] EncryptedRequest;
    public byte[] Iv;
    public byte[] EncryptedSymmetricKey;
}
