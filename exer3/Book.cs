using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exer3
{
    public class Book
    {
        public string? ID { get; set; }
        public string? Etag { get; set; }
        public string Title { get; set; }
        public List<string>? Authors { get; set; }
        public string? Publisher { get; set; }
        public string? PublishedDate { get; set; }
    }
}
