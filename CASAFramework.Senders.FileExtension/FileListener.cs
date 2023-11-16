using CASAFramework.Interfaces;
using CASAFramework.RequestResponse;
using CASAFramework.Senders.FileExtension.FileServices;
using Newtonsoft.Json;
using SharedLibrary.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace CASAFramework.Senders.FileExtension
{
    public class FileListener : IListener
    {
        private readonly string _path;
        private byte[] _symmetricKey;
        private byte[] _iv;
        private string _username;
        public event EventHandler<CommunicationEventArgs> OnRequestReceived;
        public FileListener(string path)
        {
            _path = path;

        }
        public FileSystemWatcher WatchRequests()
        {
            string fullPath = Path.Combine(_path,"Requests");
            FileService.ValidatePath(fullPath);
            var watchRequestFile = new FileSystemWatcher(fullPath);
            watchRequestFile.IncludeSubdirectories = false;
            watchRequestFile.Created += HandleRequests;
            watchRequestFile.EnableRaisingEvents = true;
            return watchRequestFile;
        }

        private void HandleRequests(object sender, FileSystemEventArgs e)
        { 
            string wrappedRequestAsJson = FileService.ReadFile(e.FullPath);
            FileRequest request = PrepareRequest(wrappedRequestAsJson);
            _username = request.SenderUsername;
            CommunicationEventArgs args = new CommunicationEventArgs();
            args.Response = new FileResponseWrapper(new FileResponse());
            args.Request = new FileRequestWrapper(request);
            OnRequestReceived.Invoke(this, args);
        }

        private FileRequest PrepareRequest(string wrappedRequestAsJson)
        {

            EncryptedRequestWrapper encryptedRequestWrapper = deserializeEncryptedRequestWrapper(wrappedRequestAsJson);
            string decryptedRequestAsJson = decryptedRequest(encryptedRequestWrapper);
            return  deserializeFileRequest(decryptedRequestAsJson); 

        }

        private FileRequest deserializeFileRequest(string decryptedRequestAsJson)
        {
            return JsonConvert.DeserializeObject<FileRequest>(decryptedRequestAsJson); 
        }

        private string decryptedRequest(EncryptedRequestWrapper encryptedRequestWrapper)
        {

            _symmetricKey = RsaEncryption.Decrypt(encryptedRequestWrapper.EncryptedSymmetricKey); 
            _iv= encryptedRequestWrapper.Iv;
            byte[] requestAsBytes = AesEncryption.Decrypt(encryptedRequestWrapper.EncryptedRequest, _symmetricKey, _iv);
            return UTF8Encoding.UTF8.GetString(requestAsBytes);
        }

        private EncryptedRequestWrapper deserializeEncryptedRequestWrapper(string wrappedRequestAsJson)
        {
            return JsonConvert.DeserializeObject<EncryptedRequestWrapper>(wrappedRequestAsJson); 
        }
        public void StartListening()
        {
            FileSystemWatcher watcher = WatchRequests();
            Console.ReadLine(); 
        }
        public void SendResponse(IResponse response)
        {
            //serilization
            string serilizedResponse = JsonConvert.SerializeObject(response);
            //Encryption 
            byte[] encryptedResposne = AesEncryption.Encrypt(UTF8Encoding.UTF8.GetBytes(serilizedResponse),_symmetricKey,_iv);
            //writing 
            FileService.WriteByteArray(Path.Combine(_path, _username), encryptedResposne);
        }


    }
}
