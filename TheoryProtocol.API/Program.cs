using Google.Cloud.Firestore;
using TheoryProtocol.Models;
using TheoryProtocol.Repositories;
using TheoryProtocol.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string filePath = Directory.GetFiles("./Credentials")[0];
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
string projectId = "theorycontrol-8248e";
FirestoreDb db = FirestoreDb.Create(projectId);

// Repositories
builder.Services.AddScoped<IFirestoreRepository<User>>(sp => new UserRepository(projectId, "users"));
builder.Services.AddScoped<IFirestoreRepository<Canvas>>(sp => new CanvasRepository(projectId, "canvas"));


builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<TestService>();
builder.Services.AddSingleton<FirestoreService>();
// Services
//builder.Services.AddScoped<IFirestoreRepository<User>>(sp => new UserRepository(projectId, "users"));
//builder.Services.AddScoped<IFirestoreRepository<User>>(sp => new UserRepository(projectId, "users"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
