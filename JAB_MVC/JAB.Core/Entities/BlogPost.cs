using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAB.Core.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public DateTime Date { get; set; }
        public bool Publish { get; set; }
    }
}
