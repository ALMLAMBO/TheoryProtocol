using Google.Cloud.Firestore;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using System.Text.Json;

namespace TheoryProtocol.Repositories
{
    public class FirestoreRepository<T> : IFirestoreRepository<T> where T : class
    {
        private readonly FirestoreDb _firestoreDb;
        private readonly string _collectionName;
        private const string ID_COLLECTION_NAME = "ids";

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
        /*public async Task<List<T>> GetAllAsyncUpg()
        {
            DocumentReference ds = await _firestoreDb
                .Collection(_collectionName)
                .GetSnapshotAsync();
        }*/

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
                    if(t.ContainsKey("Created"))
                    {
                        t["Created"] = ((Google.Cloud.Firestore.Timestamp)t["Created"]).ToDateTime();
                    }
                    string json = JsonConvert.SerializeObject(t);
                    T newT = JsonConvert.DeserializeObject<T>(json);
                    lstT.Add(newT);
                }
            }
            return lstT;
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                CollectionReference collectionRef = _firestoreDb.Collection(_collectionName);
                await collectionRef.AddAsync(entity);
            }
            catch
            {
                throw;
            }
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

        public async Task UpdateIdAsync(string idDocumentName)
        {
            DocumentReference df = _firestoreDb
                .Collection(ID_COLLECTION_NAME)
                .Document(idDocumentName);

            int prevId = await GetIdAsync(idDocumentName);
            prevId++;
            await df.UpdateAsync("Id", prevId);
        }

        public async Task<int> GetIdAsync(string idDocumentName)
        {
            DocumentSnapshot ds = await _firestoreDb
                .Collection(ID_COLLECTION_NAME)
                .Document(idDocumentName)
                .GetSnapshotAsync();

            Dictionary<string, object> dictionary = ds.ToDictionary();
            return int.Parse(dictionary["Id"].ToString());
        }
    }
}
