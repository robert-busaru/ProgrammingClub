using Microsoft.EntityFrameworkCore;
using ProgrammingClub.DatabaseDataContext;
using ProgrammingClub.Repositories;
using ProgrammingClub.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ProgrammingClubDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IMembersRepository, MembersRepository>();
builder.Services.AddTransient<IMembersService, MembersService>();
builder.Services.AddTransient<IAnnouncementsRepository, AnnouncementsRepository>();
builder.Services.AddTransient<IAnnouncementsService, AnnouncementsSerivce>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
