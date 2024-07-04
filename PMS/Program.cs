using Microsoft.EntityFrameworkCore;
using PMS.Data;
using PMS.Repositories;
using PMS.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

 

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionstring")));
 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
/// interfaces and  services
builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IInvestmentPropertyService, InvestmentPropertyService>();
//builder.Services.AddScoped<IInvestmentPropertyRepository, InvestmentPropertyyRepository>();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();

}

//--Added
//app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    _ = endpoints.MapControllers();
//});

//app.UseAuthorization();

app.UseHttpsRedirection();



app.MapControllers();


app.Run();

