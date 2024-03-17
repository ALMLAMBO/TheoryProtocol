using Google.Cloud.Firestore;
using TheoryProtocol.Models;
using Newtonsoft.Json;
using TheoryProtocol.Repositories;

namespace TheoryProtocol.Services
{
    public class FirestoreService
    {
        string? projectId;
        FirestoreDb db;
        private string _idDocumentName = "usersId";
        private FirestoreRepository<User> _repository;

        public FirestoreService()
        {
            string filePath = Directory.GetFiles("./Credentials")[0];
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            projectId = "theorycontrol-8248e";
            _repository = new FirestoreRepository<User>(projectId, "users");
            db = FirestoreDb.Create(projectId);
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                Query userQuery = db.Collection("users");
                QuerySnapshot userQuerySnapshot = await userQuery.GetSnapshotAsync();
                List<User> lstUser = new List<User>();

                foreach (DocumentSnapshot documentSnapshot in userQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> user = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(user);
                        User newuser = JsonConvert.DeserializeObject<User>(json);
                        lstUser.Add(newuser);
                    }
                }

                List<User> sortedUserList = lstUser.OrderBy(x => x.Username).ToList();
                Console.WriteLine(sortedUserList);
                return sortedUserList;
            }
            catch
            {
                throw;
            }
        }

        public async void AddUser(User user)
        {
            try
            {
                int prevId = await _repository.GetIdAsync(_idDocumentName);
                user.Id = prevId + 1;
                await _repository.UpdateIdAsync(_idDocumentName);
                CollectionReference colRef = db.Collection("users");
                await colRef.AddAsync(user);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Canvas>> GetAllCanvases()
        {
            try
            {
                Query canvasQuery = db.Collection("canvas");
                QuerySnapshot canvasQuerySnapshot = await canvasQuery.GetSnapshotAsync();
                List<Canvas> lstCanvas = new List<Canvas>();

                foreach (DocumentSnapshot documentSnapshot in canvasQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> canvas = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(canvas);
                        Canvas newCanvas = JsonConvert.DeserializeObject<Canvas>(json);
                        lstCanvas.Add(newCanvas);
                    }
                }

                List<Canvas> sortedCanvasList = lstCanvas.OrderBy(x => x.Name).ToList();
                return sortedCanvasList;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Comment>> GetAllCommentsOfCanvas(Canvas canvas)
        {
            try
            {
                Query commentQuery = db.Collection("comments").WhereEqualTo("id", canvas.Id);
                QuerySnapshot commentQuerySnapshot = await commentQuery.GetSnapshotAsync();
                List<Comment> lstComment = new List<Comment>();

                foreach (DocumentSnapshot documentSnapshot in commentQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> comment = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(comment);
                        Comment newComment = JsonConvert.DeserializeObject<Comment>(json);
                        lstComment.Add(newComment);
                    }
                }

                List<Comment> sortedCommentList = lstComment.OrderByDescending(x => x.Created).ToList();
                return sortedCommentList;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Fact>> GetAllFactsOfCanvas(Canvas canvas)
        {
            try
            {
                Query factQuery = db.Collection("facts").WhereEqualTo("id", canvas.Id);
                QuerySnapshot factQuerySnapshot = await factQuery.GetSnapshotAsync();
                List<Fact> lstFact = new List<Fact>();

                foreach (DocumentSnapshot documentSnapshot in factQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> fact = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(fact);
                        Fact newFact = JsonConvert.DeserializeObject<Fact>(json);
                        lstFact.Add(newFact);
                    }
                }

                List<Fact> sortedFactList = lstFact.OrderByDescending(x => x.Id).ToList();
                return sortedFactList;
            }
            catch
            {
                throw;
            }
        }

        public async void AddFact(Fact fact)
        {
            try
            {
                CollectionReference colRef = db.Collection("facts");
                await colRef.AddAsync(fact);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Connection>> GetAllConnections()
        {
            try
            {
                Query connectionQuery = db.Collection("connections");
                QuerySnapshot connectionQuerySnapshot = await connectionQuery.GetSnapshotAsync();
                List<Connection> lstConnection = new List<Connection>();

                foreach (DocumentSnapshot documentSnapshot in connectionQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> connection = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(connection);
                        Connection newConnection = JsonConvert.DeserializeObject<Connection>(json);
                        lstConnection.Add(newConnection);
                    }
                }

                List<Connection> sortedFactList = lstConnection.OrderByDescending(x => x.Id).ToList();
                return sortedFactList;
            }
            catch
            {
                throw;
            }
        }
    }
}
