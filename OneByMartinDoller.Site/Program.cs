using OneByMartinDoller.GoogleSheet;
using OneByMartinDoller.Shared.Services;
using OneByMartinDoller.Site.Services;
using OneByMartinDoller.Site.Services.IServices;

var builder = WebApplication.CreateBuilder(args);
var GoogleSheets = builder.Configuration.GetSection("GoogleSheets");
LibraryParametrs.Initialize(builder.Configuration);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<FailLoadLimits>();
builder.Services.AddSingleton(provider => new GoogleSheetInit(
	GoogleSheets.GetValue<string>("SpreadSheetId"),
	GoogleSheets.GetValue<string>("SheetName"),
	GoogleSheets.GetValue<string>("CredentialsPath"),
	GoogleSheets.GetValue<string>("ProjectName"),
	null,
	GoogleSheets.GetValue<string>("StartCell")));





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
