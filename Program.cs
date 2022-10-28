
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

//Dodanie kontekstu bazy danych
builder.Services.AddDbContext<SQLiteContext>(ServiceLifetime.Scoped);

//Dodanie usługi opcji serializacji JSONów.
builder.Services.AddSingleton<JsonSerializerOptionsService>();

//Dodanie obsługi ustawień.
builder.Services.AddSingleton<SettingsService>();

//Dodanie obsługi bazy danych.
builder.Services.AddScoped<IProductRepository, ProductService>();

//Usługa wysyłania maili.
builder.Services.AddScoped<IMailRepository, NetMailService>();

//Dodanie obsługi zamówień.
builder.Services.AddScoped<IOrderRepository, OrderService>();

//Dodanie obsługi zapytań.
builder.Services.AddScoped<IQuestionRepository, QuestionService>();

var app = builder.Build();

app.UseCors(corsPolicyName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
