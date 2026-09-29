using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using eShop.DataStore.EFCore;
using eShop.Web.Components;
using eshop_UseCases.PluginInterfaces;
using eshop_UseCases.SearchProductScreen;
using eshop_UseCases.ViewProductScreen;

using eshop_UseCases.ShoppingCartScreen;
using eshop_UseCases.PluginInterfaces.UI;

using eshop_UseCases.OrderConfirmationScreen;
using eshop_UseCases.AdminPortalScreen;
using eShop_coreBusiness.services;

namespace eShop.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Configure Authentication & Authorization
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/login";
                });
            builder.Services.AddAuthorization();
            builder.Services.AddCascadingAuthenticationState();

            // Register EF Core DbContextFactory with SQL Server
            builder.Services.AddDbContextFactory<eShopContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("eShop")));

            // Register EF Core Repositories (Active SQL DataStore Plugin)
            builder.Services.AddTransient<IProductRepository, eShop.DataStore.EFCore.ProductRepository>();
            builder.Services.AddTransient<IOrderRepository, eShop.DataStore.EFCore.OrderRepository>();

            // Application Services
            builder.Services.AddScoped<IShoppingCart, eShop.DataStore.HardCode.ShoppingCart>();
            builder.Services.AddTransient<IOrderService, OrderService>();
            builder.Services.AddTransient<ISearchProduct, searchProduct>();
            builder.Services.AddTransient<IViewProduct, viewProductUseCase>();
            builder.Services.AddTransient<IAddProductToCartUseCase, AddProductToCartUseCase>();
            builder.Services.AddTransient<IViewShoppingCartUseCase, ViewShoppingCartUseCase>();
            builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
            builder.Services.AddTransient<IUpdateQuantityUseCase, UpdateQuantityUseCase>();
            builder.Services.AddTransient<IPlaceOrderUseCase, PlaceOrderUseCase>();
            builder.Services.AddTransient<IViewOrderConfirmationUseCase, ViewOrderConfirmationUseCase>();
            builder.Services.AddTransient<IViewOutstandingOrdersUseCase, ViewOutstandingOrdersUseCase>();
            builder.Services.AddTransient<IProcessOrderUseCase, ProcessOrderUseCase>();

            var app = builder.Build();

            // Automatic Database Initialization (EnsureCreated)
            try
            {
                using var scope = app.Services.CreateScope();
                var dbFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<eShopContext>>();
                using var db = dbFactory.CreateDbContext();
                db.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Server database initialization note: {ex.Message}");
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAntiforgery();

            app.MapAuthenticationEndpoints();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddAdditionalAssemblies(
                    typeof(eShop.Web.CustomerPortal.Pages.ViewProductComponent).Assembly,
                    typeof(eShop.Web.AdminPortal.OutstandingOrdersComponent).Assembly
                );

            app.Run();
        }
    }
}
