using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReviewSocial.Database;
using ReviewSocial.Repositories;
using ReviewSocial.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Db_ReviewSocialContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbReviewSocial") ?? throw new InvalidOperationException("Connection string not found.")));
builder.Services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromSeconds(10);//Thời gian giữ session
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/login";
                    option.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                });

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IPostRepository, PostRepository>();
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

app.UseAuthentication();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseAuthorization();
app.UseSession();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
                name: "searchByCategory",
                pattern: "search",
                defaults: new { controller = "Home", action = "Search" });

    #region Auth
    endpoints.MapControllerRoute(
        name: "login",
        pattern: "login",
        defaults: new { controller = "Auth", action = "Login" });
    endpoints.MapControllerRoute(
        name: "logout",
        pattern: "logout",
        defaults: new { controller = "Auth", action = "Logout" });
    endpoints.MapControllerRoute(
         name: "register",
         pattern: "register",
         defaults: new { controller = "Auth", action = "Register" });
    endpoints.MapControllerRoute(
             name: "changepassword",
             pattern: "changepassword",
             defaults: new { controller = "Auth", action = "ChangePassword" });
    #endregion

    #region Post
    endpoints.MapControllerRoute(
        name: "Post",
        pattern: "post",
        defaults: new { controller = "Post", action = "Index" });
    endpoints.MapControllerRoute(
        name: "Post",
        pattern: "post/{id}",
        defaults: new { controller = "Auth", action = "Details" });
    endpoints.MapControllerRoute(
    name: "Post",
    pattern: "post/{CategoryId}",
    defaults: new { controller = "Post", action = "Index" });
    #endregion

    #region User
    endpoints.MapControllerRoute(
        name: "User",
        pattern: "user/profile",
        defaults: new { controller = "User", action = "Profile" });
    endpoints.MapControllerRoute(
        name: "User",
        pattern: "user/profile/edit",
        defaults: new { controller = "User", action = "EditProfile" });
    #endregion

    #region CategoryManagement
    endpoints.MapControllerRoute(
        name: "CategoryManagement",
        pattern: "admin/category",
        defaults: new { controller = "CategoryManagement", action = "Index" });
    endpoints.MapControllerRoute(
        name: "CategoryManagement",
        pattern: "admin/category/create",
        defaults: new { controller = "CategoryManagement", action = "Create" });
    endpoints.MapControllerRoute(
        name: "CategoryManagement",
        pattern: "admin/category/{id}",
        defaults: new { controller = "CategoryManagement", action = "GetById" });
    endpoints.MapControllerRoute(
        name: "CategoryManagement",
        pattern: "admin/category/update/{id}",
        defaults: new { controller = "CategoryManagement", action = "Update" });
    endpoints.MapControllerRoute(
        name: "CategoryManagement",
        pattern: "admin/category/delete/{id}",
        defaults: new { controller = "CategoryManagement", action = "Delete" });
    #endregion

    #region HomeAdmin
    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "admin",
        defaults: new { controller = "HomeAdmin", action = "Index" });
    #endregion

    #region PostManagement
    endpoints.MapControllerRoute(
        name: "admin/post",
        pattern: "admin/post",
        defaults: new { controller = "PostManagement", action = "Index" });
    endpoints.MapControllerRoute(
        name: "admin/post/create",
        pattern: "admin/post/create",
        defaults: new { controller = "PostManagement", action = "Create" });
    endpoints.MapControllerRoute(
        name: "admin/post/update",
        pattern: "admin/post/update/{id}",
        defaults: new { controller = "PostManagement", action = "Update" });
    endpoints.MapControllerRoute(
        name: "admin/post/delete",
        pattern: "admin/post/delete",
        defaults: new { controller = "PostManagement", action = "Delete" });
    #endregion

    #region UserManagement
    endpoints.MapControllerRoute(
        name: "UserManagement",
        pattern: "admin/user",
        defaults: new { controller = "UserManagement", action = "Index" });
    #endregion
});

app.Run();
