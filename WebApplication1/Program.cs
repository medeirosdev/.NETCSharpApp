var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
       name: "produtos_importados",
       pattern: "Home/ProdutosImportados",
       defaults: new { controller = "Home", action = "ProdutosImportados" }
   );
    endpoints.MapControllerRoute(
       name: "produtos_importados2",
       pattern: "Home/ListadeProdutos",
       defaults: new { controller = "Home", action = "ListadeProdutos" }
   );
});

app.Run();
