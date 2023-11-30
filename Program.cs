//Khaled Dafi
//11/20/2023
//hare is the web app Run 
using BulkyWeb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//hare is the Injection for the services 
//DB services form 1-class in data : AppliacitonDbConetctxt and from appsetting.js
builder.Services.AddDbContext<ApplicationDbContext>(opions=> 
opions.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); //NOW YOU ADD THE DATA/APP TO THE SERVICSIE and tell him you use Sql Server then pass the configeration form appsetting to this parameter 


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();//redircting
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute( //Routing is when you type somtheing in URL thats mean whart to go 
    name: "default", 
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); //Run the project 
