var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromSeconds(10);//Thời gian giữ session
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });
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
app.UseSession();
app.UseAuthorization();
app.UseAuthorization();
// app.Use(async (context, next) =>
//     {
//         var currentUser = context.Session.GetString("User");
//         var loginPath = "/Account/Login";
//         if (currentUser == null && context.Request.Path != loginPath)
//         {
//             context.Response.Redirect(loginPath);
//             return;
//         }
//     });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
