
using Microsoft.EntityFrameworkCore;
using DataAccess;
using InitialData;
using DataAccess.Repository;
using Services.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add database service.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
builder.Services.AddTransient<IDataRepository, DataRepository>();
builder.Services.AddTransient<IFacultyService, FacultyService>();

// Add controller services to build the api.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{// Takes only one of the controllers in the same route in case of conflict.
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});




var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();

    // Applies any pending migrations for the context to the database
    dbContext.Database.Migrate();
    
    var dbInitializer = new DatabaseInitializer(dbContext);
    dbInitializer.EnsureInitialData();
    //delete after deb
   
    
}

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
