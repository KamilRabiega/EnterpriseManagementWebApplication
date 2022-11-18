using EnterpriseManagementApp.Data;
using EnterpriseManagementApp.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<EmaDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("EmaDbConnectionString")));

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("EmaAuthDbConnectionString")));

//Telling application to use Identity and use the User nad Role types, and to use AuthDbContext as their EF store
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    //Default password settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric= true;
    options.Password.RequiredLength= 6;
    options.Password.RequiredUniqueChars = 1;
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("useradmin", policy => policy.RequireRole("User", "Admin"));
    options.AddPolicy("productionadmin", policy => policy.RequireRole("Production", "Admin"));
    options.AddPolicy("magazineadmin", policy => policy.RequireRole("Magazine", "Admin"));
    options.AddPolicy("financeadmin", policy => policy.RequireRole("Finance", "Admin"));
    options.AddPolicy("boardadmin", policy => policy.RequireRole("Board", "Admin"));
    options.AddPolicy("allusers", policy => policy.RequireRole("User", "Production", "Magazine", "Finance", "Board", "Admin"));
});

builder.Services.ConfigureApplicationCookie(options => 
{
    options.LoginPath = "/Login";
    options.AccessDeniedPath= "/AccessDenied";
});

builder.Services.AddScoped<IProductionItemRepository, ProductionItemRepository>(); //Inject the implementation of IProductionItemRepository

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
