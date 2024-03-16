using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace TheoryProtocol.Repositories
{
    public class FirestoreRepository<T> : IFirestoreRepository<T> where T : class
    {
        private readonly FirestoreDb _firestoreDb;
        private readonly string _collectionName;

        public FirestoreRepository(string projectId, string collectionName)
        {
            _firestoreDb = FirestoreDb.Create(projectId);
            _collectionName = collectionName;
        }

        public async Task<List<T>> GetAllAsync()
        {
            Query query = _firestoreDb.Collection(_collectionName);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            List<T> lstT = new List<T>();

            foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> t = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(t);
                    T newT = JsonConvert.DeserializeObject<T>(json);
                    lstT.Add(newT);
                }
            }

            return lstT;
        }

        public async Task<List<T>> GetByFieldIdAsync(string field,int id)
        {
            Query query = _firestoreDb.Collection(_collectionName).WhereEqualTo(field, id);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            List<T> lstT = new List<T>();

            foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> t = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(t);
                    T newT = JsonConvert.DeserializeObject<T>(json);
                    lstT.Add(newT);
                }
            }
            return lstT;
        }

        public async Task AddAsync(T entity)
        {
            //CollectionReference collectionRef = _firestoreDb.Collection(_collectionName);
            //await collectionRef.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, T entity)
        {
            //DocumentReference docRef = _firestoreDb.Collection(_collectionName)
            //await docRef.SetAsync(entity, SetOptions.MergeAll);
        }

        public async Task DeleteAsync(int id)
        {
            //DocumentReference docRef = _firestoreDb.Collection(_collectionName).Document(id);
            //await docRef.DeleteAsync();
        }
    }
}
