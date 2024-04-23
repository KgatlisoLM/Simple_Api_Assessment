using Microsoft.EntityFrameworkCore;
using Simple_Api_Assessment.Data;
using Simple_Api_Assessment.Data.Repository;
using Simple_Api_Assessment.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => {
     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
     options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Repository 
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddScoped<ISkillsRepository, SkillsRepository>();

// add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfiles));


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
