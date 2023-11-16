using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASAFramework.Senders.FileExtension;

internal class EncryptedRequestWrapper
{
    public byte[] EncryptedRequest;
    public byte[] Iv;
    public byte[] EncryptedSymmetricKey;
}
