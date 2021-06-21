using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsExtractor.Models
{
    public class News
    {
        public string Topic { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Link { get; set; }

    }
}
