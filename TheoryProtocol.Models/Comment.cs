using Google.Cloud.Firestore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TheoryProtocol.Models
{
    [FirestoreData]
    public class Comment
    {
        [FirestoreProperty] public int Id { get; set; }
        [FirestoreProperty] public int UserId { get; set; }
        [FirestoreProperty] public int ConnectionId { get; set; }
        [FirestoreProperty] public string? Content { get; set; }
        [JsonProperty("Created")][JsonConverter(typeof(IsoDateTimeConverter))][FirestoreProperty] public DateTime? Created { get; set; }
    }
}