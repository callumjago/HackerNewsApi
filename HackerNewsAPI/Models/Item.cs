using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HackerNewsAPI.Models
{
    [DataContract]
    public class Item
    {
        [DataMember(Name = "by")]
        public string by { get; set; }

        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "kids")]
        public List<int> kids { get; set; }

        [DataMember(Name = "score")]
        public int score { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "url")]
        public string url { get; set; }

        [DataMember(Name = "descendants")]
        public int descendants { get; set; }
    }
}
