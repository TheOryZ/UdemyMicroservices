using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace UM.Services.CatalogAPI.Models
{
    public class Course
    {
        [BsonId]    //: this property is Identity and will be produced automatically
        [BsonRepresentation(BsonType.ObjectId)]     //: mongoDb type
        public string Id { get; set; }
        public string Name { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]   //: mongoDb type
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
        [BsonRepresentation(BsonType.DateTime)]     //: mongoDb type
        public DateTime CreatedTime { get; set; }
        public Feature Feature { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        [BsonIgnore]    //: that it does not create on the database side
        public Category Category { get; set; }
    }
}
