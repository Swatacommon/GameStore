using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Models {
    public class BlobInfo {
        public BlobInfo(Stream content, string contentType) {
            Content = content;
            ContentType = contentType;
        }

        public Stream Content {
            get;
        }

        public string ContentType {
            get;
        }
    }
}
