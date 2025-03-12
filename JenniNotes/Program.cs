using JenniNotes.Infrastructure;
using JenniNotes.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["Jenninotes_ConnectionString"];
builder.Services.AddMigration(connectionString);
builder.Services.BuildDependencies();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var databaseOperator = scope.ServiceProvider.GetService<DatabaseOperator>();
    databaseOperator.MigrateUp();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
