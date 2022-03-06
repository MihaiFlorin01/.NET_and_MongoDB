﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace TestProject.API.Entities
{
    public class Department
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }
        public string DepartmentName { get; set; }
        public Location Location { get; set; }
    }
}
