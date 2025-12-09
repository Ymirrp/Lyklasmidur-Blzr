using Lyklasmidur_Blzr.Components;
using Lyklasmidur_Blzr.Core.Repositories;
using Lyklasmidur_Blzr.Core.Services;
using Lyklasmidur_Blzr.Infrastructure.Repositories;
using Lyklasmidur_Blzr.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

// Add services to the container.
services.AddRazorComponents()
   .AddInteractiveServerComponents();

services.AddSingleton<IWordRepository, WordRepository>();
services.AddScoped<IWordService, WordService>();
services.AddScoped<ClipboardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   app.UseExceptionHandler("/Error", createScopeForErrors: true);
   // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
   app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

await app.RunAsync();
