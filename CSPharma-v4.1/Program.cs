using CSPharma_v4._1_DAL.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CSPharma_v4._1.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Añadimos nuestra conexión a la BBDD de PostgreSQL
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<CspharmaInformacionalContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection"));
    });

// Añadimos nuestra conexión a la BBDD de PostgreSQL
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<LoginRegisterContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection"));
    });


//builder.Services.AddDefaultIdentity<UserAuthentication>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<LoginRegisterContext>();

builder.Services.AddDefaultIdentity<UserAuthentication>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<LoginRegisterContext>();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // para evitar posibles errores en la vista Create por el Datetime
// AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true); // desactiva todas las conversiones del Datetime
// https://www.npgsql.org/doc/types/datetime.html

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
