using MainHomeApplication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

using MainHomeApplication.Models;
using Microsoft.EntityFrameworkCore;
using MainHomeApplication.DataProviders;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine(connection);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
builder.Services.AddRazorPages();
builder.Services.AddTransient<IGetHomeImagePath, HomePathGenerator>();
builder.Services.AddTransient<IHomeDataProvider,LocalDBProvider>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/login";
    options.AccessDeniedPath = "/denied";
    });


AuthorizationPolicyBuilder policyBuilder = new AuthorizationPolicyBuilder();
policyBuilder.RequireClaim("access-level", "admin");
AuthorizationOptions options = new AuthorizationOptions();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminAccess", policyBuilder.Build());
});
try
{
    Directory.Delete(Directory.GetCurrentDirectory() + "wwwroot/images", true);
}
catch (DirectoryNotFoundException)
{
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    context.Response.ContentType = "text/html; charset=utf-8";
    return "Вы успешно вышли <!DOCTYPE html> <html><body><a href=\"index\">Домой</a></body></html>";
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
