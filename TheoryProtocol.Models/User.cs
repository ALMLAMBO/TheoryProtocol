using System;
using Google.Cloud.Firestore;

namespace TheoryProtocol.Models {
	[FirestoreData]
	public class User {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public string Pass { get; set; }

        [FirestoreProperty]
        public string Email { get; set; }
    }
}
