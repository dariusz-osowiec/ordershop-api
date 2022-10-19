using Microsoft.AspNetCore.Authentication.Certificate;

var builder = WebApplication.CreateBuilder(args);

var corsPolicyName = "CorsPolicy";

// Add services to the container.

//Dodanie Cors.
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dodanie usługi opcji serializacji JSONów.
builder.Services.AddSingleton<JsonSerializerOptionsService>();

//Dodanie obsługi ustawień.
builder.Services.AddSingleton<SettingsService>();

//Dodanie obsługi bazy danych.
builder.Services.AddScoped<IDbOperable, DbService>();

//Dodanie usługi obsługi wysyłania maili.
builder.Services.AddScoped<IMailOperable, NetMailService>();

//Dodanie obsługi zamówień.
builder.Services.AddScoped<IOrderOperable, OrderService>();

//Dodanie obsługi zapytań.
builder.Services.AddScoped<IQuestionOperable, QuestionService>();

var app = builder.Build();

app.UseCors(corsPolicyName);

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
