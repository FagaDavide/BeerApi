/*====================================================================*\
Name ........ : Program.cs
Role ........ : 
Author ...... : Davide Faga
Date ........ : 05.05.2022
\*====================================================================*/
using BeerApi.DataBase;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

/*======================================================================*\
|*			                     VARIABLE         	 					*|
\*======================================================================*/
var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

/*======================================================================*\
|*			                     SERVICES         	 					*|
\*======================================================================*/
// Add services to the container.
builder.Services.AddControllers();
// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add DbContext (config in BeerDbContext.cs)
builder.Services.AddDbContext<BeerDbContext>();
// Add Authentication (JWT)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });
// Add mvc
builder.Services.AddMvc();
var app = builder.Build();

/*======================================================================*\
|*			                     CONFIGURE         	 					*|
\*======================================================================*/
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
