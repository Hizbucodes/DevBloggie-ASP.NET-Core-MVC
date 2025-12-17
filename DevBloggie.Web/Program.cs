using DevBloggie.Web.Data;
using DevBloggie.Web.Repositories;
using DevBloggie.Web.Settings;
using dotenv.net;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

DotEnv.Load(new DotEnvOptions(
    probeForEnv: true
));


builder.Configuration.AddEnvironmentVariables();


builder.Services.AddDbContext<DevBloggieDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DevBloggieDbConnectionString")));


builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
builder.Services.AddScoped<IImageRepository, CloudinaryImageRepository>();


builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("Cloudinary"));


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
