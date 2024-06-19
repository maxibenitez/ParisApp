using ParisApp;
using ParisApp.DataAccess.CategoryRepository;
using ParisApp.DataAccess.CompetitionRepository;
using ParisApp.DataAccess.DisciplineRepository;
using ParisApp.DataAccess.EventRepository;
using ParisApp.DataAccess.PersonRepository;
using ParisApp.DataAccess.ScoreRepository;
using ParisApp.Helpers;
using ParisApp.Services.DisciplineService;
using ParisApp.Services.EventService;
using ParisApp.Services.PersonService;
using ParisApp.Services.ScoreService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DBConnection>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICompetitionRepository, CompetitionRepository>();
builder.Services.AddScoped<IDisciplineRepository, DisciplineRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IScoreRepository, ScoreRepository>();

builder.Services.AddScoped<IDisciplineService, DisciplineService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IScoreService, ScoreService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
