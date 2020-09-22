using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Threading.Tasks;

namespace GameStoreBLR.Services {
    public class BlobService : IBlobService {

        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient) {
            _blobServiceClient = blobServiceClient;
        }

        public Task DeleteBlobAsync(string blobName) {
            throw new NotImplementedException();
        }

        public async Task<BlobInfo> GetBlobAsync(string name) {
            var containerClient = _blobServiceClient.GetBlobContainerClient("images");
            var blobClinet = containerClient.GetBlobClient(name);
            var blobDownloadInfo = await blobClinet.DownloadAsync();
            return new BlobInfo(blobDownloadInfo.Value.Content, blobDownloadInfo.Value.ContentType);
        }

        public async Task<IEnumerable<string>> ListBlobAsync() {
            var containerClient = _blobServiceClient.GetBlobContainerClient("images");
            var items = new List<string>();
            await foreach (var blobItem in containerClient.GetBlobsAsync()) {
                items.Add(blobItem.Name);
            }
            return items;
        }

        public Task UploadContentBlobAsync(string content, string fileName) {
            throw new NotImplementedException();
        }

        public Task UploadFileBlobAsync(string filePathm, string fileName) {
            throw new NotImplementedException();
        }
    }
}
