

using SSA.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowSpecificOrigins",
        policy =>
        {
            //policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
           policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        });
    //options.AddDefaultPolicy(policy=>policy.AllowAnyOrigin());
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

StartUp.Configure(builder.Configuration,builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigins");
app.UseAuthentication();
app.UseMiddleware<TokenManagerMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
