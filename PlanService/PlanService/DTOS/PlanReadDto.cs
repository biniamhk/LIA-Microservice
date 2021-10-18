using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using PlanService.Models;

namespace PlanService.DTOS
{
    public class PlanReadDto
    {
        [BsonElement("_id")]
        [JsonProperty("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FromDate { get; set; }        
        public DateTime ToDate { get; set; }   
        public List<Member> Members { get; set; }             
        public string CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}