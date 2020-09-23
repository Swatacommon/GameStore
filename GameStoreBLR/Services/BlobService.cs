using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using GameStoreBLR.Extentions;
using System.Text;
using System.IO;

namespace GameStoreBLR.Services {
    public class BlobService : IBlobService {

        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient) {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<Models.BlobInfo> GetBlobAsync(string name) {
            var containerClient = _blobServiceClient.GetBlobContainerClient("images");
            var blobClinet = containerClient.GetBlobClient(name);
            var blobDownloadInfo = await blobClinet.DownloadAsync();
            return new Models.BlobInfo(blobDownloadInfo.Value.Content, blobDownloadInfo.Value.ContentType);
        }

        public async Task<IEnumerable<string>> ListBlobAsync() {
            var containerClient = _blobServiceClient.GetBlobContainerClient("images");
            var items = new List<string>();
            await foreach (var blobItem in containerClient.GetBlobsAsync()) {
                items.Add(blobItem.Name);
            }
            return items;
        }

        public async Task UploadContentBlobAsync(string content, string fileName) {
            var containerClient = _blobServiceClient.GetBlobContainerClient("images");
            var blobClinet = containerClient.GetBlobClient(fileName);
            var bytes = Encoding.UTF8.GetBytes(content);
            using var memoryStream = new MemoryStream(bytes);
            await blobClinet.UploadAsync(memoryStream, new BlobHttpHeaders { ContentType = fileName.GetContentType() });
        }

        public async Task UploadFileBlobAsync(string filePath, string fileName) {
            var containerClient = _blobServiceClient.GetBlobContainerClient("images");
            var blobClinet = containerClient.GetBlobClient(fileName);
            await blobClinet.UploadAsync(filePath, new BlobHttpHeaders { ContentType = filePath.GetContentType() });
        }

        public async Task DeleteBlobAsync(string blobName) {
            var containerClient = _blobServiceClient.GetBlobContainerClient("images");
            var blobClinet = containerClient.GetBlobClient(blobName);
            await blobClinet.DeleteIfExistsAsync();
        }
    }
}
