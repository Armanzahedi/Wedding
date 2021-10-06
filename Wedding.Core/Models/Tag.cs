using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Core.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<ArticleTag> ArticleTags { get; set; }
        public ICollection<AdTag> AdTags { get; set; }
    }
}
