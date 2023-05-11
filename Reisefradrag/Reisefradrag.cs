using Microsoft.AspNetCore.Mvc;
using Reisefradrag.Dto;
using Reisefradrag.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IReisefradragBeregner>(new ReisefradragBeregner2017());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapPost("/Reisefradrag", ([FromServices] IReisefradragBeregner beregner, [FromBody] ReisefradragRequest request) =>
{
    return new ReisefradragResponse
    {
        reisefradrag = beregner.BeregnFradrag(request.arbeidsreiser, request.besoeksreiser, request.utgifterBomFergeEtc)
    };
})
.WithName("Reisefradrag")
.WithOpenApi();

app.Run();

public record struct ReisefradragRequest
{
    public List<Arbeidsreise> arbeidsreiser { get; set; }
    public List<Besoeksreise> besoeksreiser { get; set; }
    public decimal utgifterBomFergeEtc { get; set; }
}

public record struct ReisefradragResponse
{
    public decimal reisefradrag { get; set; }
}