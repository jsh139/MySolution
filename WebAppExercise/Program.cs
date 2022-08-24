using WebAppExercise.Models;
using WebAppExercise.Security;
using WebAppExercise.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.OperationFilter<ApiKeyHeaderOperationFilter>();
});

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<AuthorizationFilter>();
});

builder.Services.Configure<List<ApiKey>>(builder.Configuration.GetSection("ApiKeys"));

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
