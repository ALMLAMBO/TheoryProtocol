using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryProtocol.Models
{
    //public enum Tag 
    //{ 
    //    EDUCATIONAL,
    //    CONSPIRACYTHEORY,
    //}
    [FirestoreData]
    public class Canvas
    {
        [FirestoreProperty] public int Id { get; set; }
        [FirestoreProperty] public int OwnerId { get; set; }
        [FirestoreProperty] public string Name { get; set; }
        //[FirestoreProperty] public DateTime EndDate { get; set; }
        //[FirestoreProperty] public Tag Tags { get; set; }
    }
}