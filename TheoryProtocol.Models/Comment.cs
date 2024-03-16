using Google.Cloud.Firestore;

namespace TheoryProtocol.Models
{
    [FirestoreData]
    public class Comment
    {
        [FirestoreProperty] public int Id { get; set; }
        [FirestoreProperty] public int UserId { get; set; }
        [FirestoreProperty] public int ConnectionId { get; set; }
        [FirestoreProperty] public string? Content { get; set; }
        [FirestoreProperty] public DateTime? Created { get; set; }
    }
}