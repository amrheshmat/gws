using ElmahCore;
using ElmahCore.Mvc;
using Microsoft.OpenApi.Models;
using MWS.ALJU.Service;
using MWS.Shared;
using System.Data.Common;


var builder = WebApplication.CreateBuilder(args);
DbProviderFactories.RegisterFactory("Oracle.ManagedDataAccess.Client", new Oracle.ManagedDataAccess.Client.OracleClientFactory());

// Add services to the container.
//TODO add not changing to camelcase (copy from log service)
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//authorize using swagger...
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Next Driven API", Version = "v1" });
    c.ResolveConflictingActions(x => x.First());
    // Swagger 2.+ support
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                //Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new string[] {}
        }
    });
});
// add Dependencies ...
builder.Services.AddDbContextsDependencies(builder.Configuration).AddBusinessDependencies().AddInfrastructureDependencies().AddGlobalDependencies();
// add elmah log ...
builder.Services.AddElmah<XmlFileErrorLog>(options =>
{
    options.LogPath = "~/ElmahLogs";
});
builder.Services.AddMemoryCache();
var app = builder.Build();
app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
//custom middleware to validate token ...
app.UseMiddleware<JwtMiddleware>();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();


app.MapControllers();
app.UseElmah(); //use elmah log ...

app.Run();
