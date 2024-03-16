using System;
using Google.Cloud.Firestore;

namespace TheoryProtocol.Models {
	[FirestoreData]
	public class User {
        [FirestoreProperty]
        public int Id { get; set; }

        [FirestoreProperty]
        public string Username { get; set; }

        [FirestoreProperty]
        public string Password { get; set; }

        [FirestoreProperty]
        public string Email { get; set; }
    }
}
