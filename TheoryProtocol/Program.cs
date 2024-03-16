using Google.Cloud.Firestore;
using MudBlazor.Services;
using TheoryProtocol.Components;
using TheoryProtocol.Models;
using TheoryProtocol.Repositories;
using TheoryProtocol.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
.AddInteractiveServerComponents();

builder.Services.AddMudServices();

string filePath = Directory.GetFiles("./Credentials")[0];
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
string projectId = "theorycontrol-8248e";
FirestoreDb db = FirestoreDb.Create(projectId);
UserRepository userRepository = new UserRepository(projectId, "users");

// Repositories
builder.Services.AddScoped<IFirestoreRepository<User>>(sp => userRepository);
builder.Services.AddScoped<IFirestoreRepository<Canvas>>(sp => new CanvasRepository(projectId, "canvas"));

// Services
builder.Services.AddScoped<UserService>(sp => new UserService(userRepository));
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
