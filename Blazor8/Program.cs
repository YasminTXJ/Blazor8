using Blazor8.Client.Pages;
using Blazor8.Components;
using Blazor8.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton<NumeroAleatorio>();
builder.Services.AddSingleton<IMensagem, MensagemSMS>();
///para quando alguns componentes querem enviar mensagem por sma e outros
///por whatsapp usamos a injeção de dependência chaveada
builder.Services.AddKeyedScoped<IMensagem, MensagemWhatsApp>("whatsapp");
builder.Services.AddKeyedScoped<IMensagem, MensagemSMS>("sms");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Blazor8.Client._Imports).Assembly);

app.Run();
