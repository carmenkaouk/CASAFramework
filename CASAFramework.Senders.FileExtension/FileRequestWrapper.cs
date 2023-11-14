using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CASAFramework.Interfaces;

namespace CASAFramework.Senders.FileExtension
{
    internal class FileRequestWrapper : IRequest
    {
        private  FileRequest request; 
        public Dictionary<string, object> GetContent()
        {
            return request.Content;
        }

        public string GetToken()
        {
            return request.Token;
        }

        public string GetUri()
        {
            return request.Uri; 
        }

        public string GetUsername()
        {
            return request.SenderUsername; 
        }
    }
}
