using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;


namespace TheoryProtocol.Models
{
    [FirestoreData]
    public class Fact
    {
        [FirestoreProperty] public int Id { get; set; }
        [FirestoreProperty] public string Title { get; set; }
        [FirestoreProperty] public string Description { get; set; }

    }
}