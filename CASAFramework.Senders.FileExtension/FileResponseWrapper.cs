using CASAFramework.Interfaces;
using CASAFramework.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASAFramework.Senders.FileExtension
{
    internal class FileResponseWrapper : IResponse
    {
        private FileResponse _response;
        // 

        public void SendResponse()
        {
            // i don't know how i will do i  need to think about it. 
            throw new NotImplementedException();
        }

        public void SetException(Exception exception)
        {
            _response.ExceptionMessage= exception.ToString();
        }

        public void SetResponseContent(object? responseObject)
        {
            _response.Content= responseObject;
        }

        public void SetStatusCode(StatusCode statusCode)
        {
            _response.StatusCode= statusCode;
        }
    }
}
