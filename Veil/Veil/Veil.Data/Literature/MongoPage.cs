using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Veil.Data.Literature
{
    public class Begins
    {
        public string text { get; set; }
    }

    public class Country
    {
        public string text { get; set; }
    }

    public class Ends
    {
        public string text { get; set; }
    }

    public class Formatting
    {
        public List<string> bold { get; set; }
        public List<string> italic { get; set; }
    }

    public class Genre
    {
        public string text { get; set; }
        public List<Link> links { get; set; }
    }

    public class Infobox
    {
        public Name name { get; set; }
        public Genre genre { get; set; }
        public Begins begins { get; set; }
        public Ends ends { get; set; }
        public Venue venue { get; set; }
        public Location location { get; set; }
        public Country country { get; set; }
        public Prev prev { get; set; }
        public Next next { get; set; }
        public Organized organized { get; set; }
        public BsonDocument image { get; set; }
    }

    public class Link
    {
        public string text { get; set; }
        public string type { get; set; }
        public string page { get; set; }
        public string anchor { get; set; }
    }

    public class Location
    {
        public string text { get; set; }
        public List<Link> links { get; set; }
    }

    public class Name
    {
        public string text { get; set; }
        public List<Link> links { get; set; }
    }

    public class Next
    {
        public string text { get; set; }
        public List<Link> links { get; set; }
    }

    public class Organized
    {
        public string text { get; set; }
        public List<Link> links { get; set; }
    }

    public class Paragraph
    {
        public List<Sentence> sentences { get; set; }
    }

    public class Prev
    {
        public string text { get; set; }
        public List<Link> links { get; set; }
    }

    public class Reference
    {
        public string url { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public string publisher { get; set; }

        [BsonElement("access-date")]
        public string accessdate { get; set; }

        [BsonElement("archive-url")]
        public string archiveurl { get; set; }

        [BsonElement("archive-date")]
        public string archivedate { get; set; }

        [BsonElement("url-status")]
        public string urlstatus { get; set; }
        public string template { get; set; }
        public string type { get; set; }
        public string last { get; set; }
        public string work { get; set; }
    }

    public class WikipediaArticle
    {
        public string _id { get; set; }
        public string title { get; set; }
        public string pageID { get; set; }
        public List<string> categories { get; set; }
        public List<Section> sections { get; set; }
        public List<object> coordinates { get; set; }
        public List<BsonDocument> infoboxes { get; set; }
        public List<BsonDocument> images { get; set; } 
        public List<BsonDocument> references { get; set; }
    }

    public class Section
    {
        public string title { get; set; }
        public int depth { get; set; }
        public List<Paragraph> paragraphs { get; set; }
        public List<BsonDocument> templates { get; set; }
        public List<BsonDocument> infoboxes { get; set; }
        public List<List<BsonDocument>> tables { get; set; }
        public List<BsonDocument> references { get; set; }
        public List<List<BsonDocument>>? lists { get; set; }
        public List<BsonDocument> images { get; set; } 
    }

    public class Sentence
    {
        public string text { get; set; }
        public List<BsonDocument> links { get; set; }
        public BsonDocument formatting { get; set; }
    }

    public class Template
    {
        public string description { get; set; }
        public string template { get; set; }
        public string date { get; set; }
        public string region { get; set; }
        public string small { get; set; }
        public string direction { get; set; }
    }

    public class Venue
    {
        public string text { get; set; }
        public List<Link> links { get; set; }
    }
}
