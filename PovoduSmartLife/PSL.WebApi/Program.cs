using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PSL.Core.Utilities.Security.Encryption;
using PSL.Core.Utilities.Security.Jwt;
using PSL.DataAccess.Concrete.EntityFramework.Context;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration configuration = builder.Configuration;

var connectionString = configuration.GetSection("DefaultConnection").Value;

builder.Services.AddDbContext<SmartHomeManagementContext>(options =>
{
    options.UseSqlServer(connectionString, sqlOptions => sqlOptions.CommandTimeout(180));
}, ServiceLifetime.Singleton);//ersen => singleton mu scope mu bakalým.


var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
    };
});

builder.Services.AddApiVersioning(
    options =>
    {
        // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
        options.ReportApiVersions = true;
    });


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<SmartHomeManagementContext>();
    dataContext.Database.Migrate();
}

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(
        options =>
        {
            options.RouteTemplate = "api/swagger/{documentName}/swagger.json";
            options.PreSerializeFilters.Add((swagger, httpReq) =>
            {
                swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"https://{httpReq.Host.Value}" }, new OpenApiServer { Url = $"http://{httpReq.Host.Value}" } };
            });
        }
        );
    app.UseSwaggerUI();
    //        options =>
    //        {
    //            options.DocExpansion(DocExpansion.None);
    //                        // build a swagger endpoint for each discovered API version
    //            foreach (var description in provider.ApiVersionDescriptions)
    //            {
    //                options.SwaggerEndpoint($"/api/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    //                options.RoutePrefix = $"api/swagger";
    //            }
    //        });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
