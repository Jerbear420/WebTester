using Microsoft.EntityFrameworkCore;
using WebTester.Services;
using WebTester.Services.Organizations.Interfaces;
using WebTester.Services.Organizations.Repositories;
using WebTester.Services.Tickets.Interfaces;
using WebTester.Services.Tickets.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOrganizationRepository, SQLOrganizationRepository>();
builder.Services.AddScoped<ITicketRepository, SQLTicketRepository>();
builder.Services.AddScoped<ITicketNoteRepository, SQLTicketNoteRepository>();
builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
builder.Services.AddScoped<IMasterSettingsRepository, SQLMasterSettingsRepository>();
builder.Services.AddScoped<IServiceProvidedRepository, SQLServiceProvidedRepository>();
builder.Services.AddScoped<IPurchasedServices, SQLPurchasedServiceRepository>();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; options.LowercaseQueryStrings = true; options.AppendTrailingSlash = true; });
builder.Services.AddDbContextPool<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDBConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
