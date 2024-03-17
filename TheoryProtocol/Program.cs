using Google.Cloud.Firestore;
using MudBlazor.Services;
using Syncfusion.Blazor;
using Syncfusion.Licensing;
using TheoryProtocol.Components;
using TheoryProtocol.Models;
using TheoryProtocol.Repositories;
using TheoryProtocol.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
.AddInteractiveServerComponents();

builder.Services.AddMudServices();
builder.Services.AddSyncfusionBlazor();
SyncfusionLicenseProvider.RegisterLicense(
	"MzE2MzM5N0AzMjM1MmUzMDJlMzBlSmJ5NGtYQkxzWVlDSHMrZURybUFnTjluenUxdU5Jd215ZDFBeG5OUTg4PQ==");

string filePath = Directory.GetFiles("./Credentials")[0];
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
string projectId = "theorycontrol-8248e";
FirestoreDb db = FirestoreDb.Create(projectId);

// Repository objects
CanvasRepository canvasRepository = new CanvasRepository(projectId);
CommentRepository commentRepository = new CommentRepository(projectId);
ConnectionRepository connectionRepository = new ConnectionRepository(projectId);
FactRepository factRepository = new FactRepository(projectId);
UserRepository userRepository = new UserRepository(projectId);
VoteReposisory voteReposisory = new VoteReposisory(projectId);

// Repositories
builder.Services.AddScoped<IFirestoreRepository<Canvas>>(sp => canvasRepository);
builder.Services.AddScoped<IFirestoreRepository<Comment>>(sp => commentRepository);
builder.Services.AddScoped<IFirestoreRepository<Connection>>(sp => connectionRepository);
builder.Services.AddScoped<IFirestoreRepository<Fact>>(sp => factRepository);
builder.Services.AddScoped<IFirestoreRepository<User>>(sp => userRepository);
builder.Services.AddScoped<IFirestoreRepository<Vote>>(sp => voteReposisory);

// Services
builder.Services.AddScoped<ConnectionService>(sp => new ConnectionService(connectionRepository));
builder.Services.AddScoped<FactService>(sp => new FactService(factRepository));
builder.Services.AddScoped<UserService>(sp => new UserService(userRepository));
builder.Services.AddScoped<CanvasService>(sp => new CanvasService(canvasRepository));
builder.Services.AddScoped<FirestoreService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
