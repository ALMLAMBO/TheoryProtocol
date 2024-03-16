using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryProtocol.Models
{
    [FirestoreData]
    public class Vote
    {
        [FirestoreProperty] public int Id { get; set; }
        [FirestoreProperty] public bool? Upvote { get; set; }
        [FirestoreProperty] public int UserId { get; set; }
        [FirestoreProperty] public int ConnectionId { get; set; }
    }
}