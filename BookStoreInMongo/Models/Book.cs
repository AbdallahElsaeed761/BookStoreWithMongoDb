using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace BookStoreInMongo.Models
{
    public class Book
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string _id { get; set; }
        [XmlIgnore]
        public ObjectId _id { get; set; }

        public string MongoId
        {
            get { return _id.ToString(); }
            set { _id = ObjectId.Parse(value); }
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

    }
}