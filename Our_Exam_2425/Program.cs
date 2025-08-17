using GameApp.Filters;
using Microsoft.EntityFrameworkCore;
using Our_Exam_2425.Data;
using Our_Exam_2425.Model;
using Our_Exam_2425.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddScoped<IServices, Services>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

    app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/play/{a:int:range(1,10)}/{b:int:range(1,10)}", async (int a, int b, IServices gameService) =>
{
    var binding = new GameBinding
    {
        A = a,
        B = b,
        CreatedAt = DateTime.UtcNow
    };
    // Generate random X and Y values (1-10)
    var random = new Random();
    binding.X = random.Next(1, 11);
    binding.Y = random.Next(1, 11);
    binding.PlayerScore = a + b;
    binding.BotScore = binding.X + binding.Y;

    if (a+b > binding.X + binding.Y)
        binding.Winner = "Player";
    binding.Winner = "Bot";


    // Save game result in database
    var id = await gameService.AddGame(binding);

    // Return success response with winner information
    var resultMessage = binding.Winner == "Player"
        ? $"🎉 Congratulations! You won! Your score ({a}+{b}={a + b}) beat the bot's score ({binding.X}+{binding.Y}={binding.X + binding.Y})."
        : $"🤖 Bot wins! Bot's score ({binding.X}+{binding.Y}={binding.X + binding.Y}) beat your score ({a}+{b}={a + b}). Better luck next time!";

    var response = $"Winner: {binding.Winner} | Score: Player({a + b}) vs Bot({binding.X + binding.Y}) | Timestamp: {binding.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")}";
    return Results.Ok(response);
})
.AddEndpointFilter<GameValidationFilter>()
.WithName("PlayGame")
.WithSummary("Play the number game")
.WithDescription("Play the game with values A and B. Random X and Y will be generated. Winner is determined by highest sum.");

app.Run();
