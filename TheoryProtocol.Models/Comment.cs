using Google.Cloud.Firestore;

namespace TheoryProtocol.Models
{
    [FirestoreData]
    public class Comment
    {
        [FirestoreProperty] public int Id { get; set; }
        [FirestoreProperty] public int UserId { get; set; }
        [FirestoreProperty] public int ConnetionId { get; set; }
        [FirestoreProperty] public string? Content { get; set; }
    }
}