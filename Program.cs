using Steeltoe.Management.Endpoint;
using Steeltoe.Management.Tracing;

var builder = WebApplication.CreateBuilder(args);

var MyCorsPolicy = "_myCorsPolicy";

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyCorsPolicy,
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.

// Steeltoe distributed tracing
builder.Services.AddDistributedTracingAspNetCore();

// Steeltoe actuators
builder.AddAllActuators();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
