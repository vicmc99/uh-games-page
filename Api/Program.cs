using System.Text;
using DataAccess;
using DataAccess.Repository;
using InitialData;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.Domain;
using Services.Domain.AthleteService;
using Services.Domain.CategoryService;
using Services.Domain.CompositionsService.TeamCompositionService;
using Services.Domain.RepresentativeService;
using Services.LeaderBoardLineService;
using Services.MajorsService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add database service.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("your-secret-key")),  // Replace with your secret key
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddIdentityCore<IdentityUser>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 5;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<UserManager<IdentityUser>>();
builder.Services.AddScoped<RoleManager<IdentityRole>>();

//builder.Services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
builder.Services.AddTransient<IDataRepository, DataRepository>();
builder.Services.AddTransient<IFacultyService, FacultyService>();
builder.Services.AddTransient<IMajorsService, MajorsService>();
builder.Services.AddTransient<IAthleteService, AthleteService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ITeamCompositionService, TeamCompositionService>();
builder.Services.AddTransient<ILeaderBoardLineService, LeaderBoardLineService>();
builder.Services.AddTransient<ILeaderboardService, LeaderboardService>();
builder.Services.AddTransient<IRepresentativeService, RepresentativeService>();

// Add controller services to build the api.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Takes only one of the controllers in the same route in case of conflict.
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

//CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
    options.AddPolicy("SpecificOrigins",
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
});
//-------------

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();
    var roleManager = scope.ServiceProvider
        .GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider
        .GetRequiredService<UserManager<IdentityUser>>();

    // Applies any pending migrations for the context to the database
    dbContext.Database.Migrate();

    var dbInitializer = new DatabaseInitializer(dbContext, roleManager, userManager);
    dbInitializer.EnsureInitialData();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("SpecificOrigins");
//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();