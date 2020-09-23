using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreBLR.Extentions {
    public static class FileExtentions {
        private static readonly FileExtensionContentTypeProvider Provider = new FileExtensionContentTypeProvider();

        public static string GetContentType(this string fileName) {
            if (!Provider.TryGetContentType(fileName, out var contentType)) {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
