using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor8.Components.Pages
{
    public partial class Separation
    {
        /*
      * Razor (Engine Tamplate - ASP.NET): HTML/CSS/JS + C#
      * 
      * Blazor: .razor (components blazor)
      * ASP.NET .cshtml (MVC e Razor Pages) 
      */
        public string Texto = "Oi eu sou o código C#";

        [Inject]
        public IJSRuntime JSRuntime { get; set; } = default!;
        public async Task CarregarJS()
        {
            var modulo = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./Components/Pages/Separation.razor.js");
            //await JSRuntime.InvokeVoidAsync("ShowMessage");
            await modulo.InvokeVoidAsync("ShowMessageTwo");
        }
    }
}
