using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TCT.Data;
using Microsoft.AspNetCore.Identity;
using TCT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using TCT.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<TCTContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TCTContext") ?? throw new InvalidOperationException("Connection string 'TCTContext' not found.")));

builder.Services.AddDefaultIdentity<TCTUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TCTContext>();
//.AddRoles<TCTUser>();
//builder.Services.AddIdentity<TCTUser, TCTRole>();

//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();
//});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}
//else
//{
//    app.UseDeveloperExceptionPage();
//    app.UseMigrationsEndPoint();
//}

app.UseDeveloperExceptionPage();
app.UseMigrationsEndPoint();
//app.UseDatabaseErrorPage();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<TCTContext>();
<<<<<<< HEAD
    //context.Database.EnsureCreated();

    context.Database.Migrate();
    //// requires using Microsoft.Extensions.Configuration;
    //// Set password with the Secret Manager tool.
    //// dotnet user-secrets set SeedUserPW <pw>

    //var testUserPw = builder.Configuration.GetValue<string>("SeedUserPW");

    //await DbInitializer.Initialize(services, testUserPw);
=======
    context.Database.EnsureCreated();
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
