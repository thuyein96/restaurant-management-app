using Microsoft.AspNetCore.HttpOverrides;
using RestaurantManagementApp.Modules.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddDependencyInjection(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

// app.UseSwagger();
// app.UseSwaggerUI();
app.MapHub<QueueHub>("/queueHub");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
