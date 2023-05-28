using API.Extensions;
using AutoMapper;
using Business.Entitites.Settings;
using BusinessEntities.Mapping;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("App"));
builder.Services.AddDependencys(builder.Configuration);
builder.Services.AddSwaggerGen();

var configMapping = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
});
var mapper = configMapping.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.Routes();
app.Run();

