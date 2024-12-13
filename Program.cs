/************************************
 *                v.1               *
 *      API ZA IZHOD FireFox-a      *
 *           Izdelava A.K           *
 ***********************************/
using System.Diagnostics;
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseWindowsService(); //za potrebe delovanja API-ja kot service - Microsoft Extension hosting windows services
builder.Services.AddWindowsService(); //za potrebe delovanja API-ja kot service - Microsoft AspNetCore Hosting windowsServices
builder.Services.AddCors();
var app = builder.Build(); app.UseHttpsRedirection();
//app.UseCors(MyAllowSpecificOrigins); // za produkcijo
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod());
static string UbijProces()
{
    //ubijanje procesa firefox-a
    Process.Start("taskkill", "/F /IM FireFox.exe");
    return "proces konèan";
}
app.MapGet("/exit", () =>
  UbijProces()
);

app.Run();
