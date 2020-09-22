using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStoreBLR.Services {
    public interface IBlobService {
        public Task<BlobInfo> GetBlobAsync(string name);
        public Task<IEnumerable<string>> ListBlobAsync();
        public Task UploadFileBlobAsync(string filePathm, string fileName);
        public Task UploadContentBlobAsync(string content, string fileName);
        public Task DeleteBlobAsync(string blobName);
    }
}
