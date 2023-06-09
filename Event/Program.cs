var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); // Add the Razor runtime compilation services.
builder.Services.AddControllersWithViews();

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
    name: "My events",
    pattern: "Event/MyEvents",
    defaults: new { controller = "Event", action = "MyEvents" }
);

app.MapControllerRoute(
    name: "creatorList",
    pattern: "Event/otherEvents/{UserID}",
    defaults: new { controller = "Event", action = "otherEvents" }
);

app.MapControllerRoute(
    name: "eventfollow",
    pattern: "Event/Unfollow/{followerID}/{followingID}",
    defaults: new { controller = "Event", action = "Unfollow" }
);

app.MapControllerRoute(
    name: "eventfollow",
    pattern: "Event/Follow/{followerID}/{followingID}",
    defaults: new { controller = "Event", action = "Follow" }
);

app.MapControllerRoute(
    name: "eventcreator",
    pattern: "Event/EventCreator/{id?}",
    defaults: new { controller = "Event", action = "EventCreator" }
);

app.MapControllerRoute(
    name: "event",
    pattern: "Event/{id?}",
    defaults: new { controller = "Event", action = "Index" }
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
