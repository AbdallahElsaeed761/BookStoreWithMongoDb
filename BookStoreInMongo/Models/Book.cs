using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace BookStoreInMongo.Models
{
    public class Book
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string _id { get; set; }
        [BsonId]
        [DataMember]
        public MongoDB.Bson.ObjectId _id { get; set; }

        [DataMember]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(minimum:20,500)]
        public double Price { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Author { get; set; }

    }
}