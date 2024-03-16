using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryProtocol.Models
{
    [FirestoreData]
    public class Connection
    {
        [FirestoreProperty] public int Id { get; set; }
        [FirestoreProperty] public int StartPointId { get; set; }
        [FirestoreProperty] public int EndPointId { get; set; }
        [FirestoreProperty] public int CanvasId {  get; set; }
    }
}