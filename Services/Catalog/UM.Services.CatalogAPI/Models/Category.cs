using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UM.Services.CatalogAPI.Models
{
    public class Category
    {
        [BsonId]    //: this property is Identity and will be produced automatically
        [BsonRepresentation(BsonType.ObjectId)]     //: mongoDb type
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
