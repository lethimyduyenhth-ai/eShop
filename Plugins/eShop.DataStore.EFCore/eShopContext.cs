using eShop_coreBusiness.models;
using Microsoft.EntityFrameworkCore;

namespace eShop.DataStore.EFCore
{
    public class eShopContext : DbContext
    {
        public eShopContext(DbContextOptions<eShopContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLineItem> OrderLineItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table mappings
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderLineItem>().ToTable("OrderLineItem");

            // Primary keys & Column mappings
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .HasColumnName("ProductId")
                .ValueGeneratedNever();

            modelBuilder.Entity<Order>()
                .HasKey(o => o.IdOrder);
            modelBuilder.Entity<Order>()
                .Property(o => o.IdOrder)
                .HasColumnName("OrderId");

            modelBuilder.Entity<OrderLineItem>()
                .HasKey(li => li.LineItemId);
            modelBuilder.Entity<OrderLineItem>()
                .Property(li => li.LineItemId)
                .HasColumnName("LineItemId");

            // Relationships
            modelBuilder.Entity<Order>()
                .HasMany(o => o.LineItems)
                .WithOne()
                .HasForeignKey(li => li.OrderId);

            modelBuilder.Entity<OrderLineItem>()
                .HasOne(li => li.Product)
                .WithMany()
                .HasForeignKey(li => li.ProductId);

            // Initial Seed Data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 286, Brand = "maybelline", Name = "Maybelline The Nudes Eyeshadow Palette in The Blushed Nudes", Price = 17.99m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/49d98e112e77d2a9a0c8fad28df89a1e_ra,w158,h184_pa,w158,h184.png", Description = "Create looks from day to night and deep to light with Maybelline's The Blushed Nudes Eyeshadow Palette.Features:13 looks in one eyeshadow paletteExtraordinary colour from ultra-blendable pigmentsLong wear with sensual finish that lasts up to 12 hours" },
                new Product { Id = 291, Brand = "maybelline", Name = "Maybelline Eye Studio Color Tattoo 24HR Cream Gel Shadow Leather", Price = 8.99m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/cf21d194ab14ee3c527d02682c358a7a_ra,w158,h184_pa,w158,h184.png", Description = "So rich. So creamy. Only Maybelline's cream gel eye shadow formula gets the look of couture leather so right!" },
                new Product { Id = 295, Brand = "maybelline", Name = "Maybelline The Nudes Eye Shadow Palette", Price = 17.99m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/201350fd3e173307ade44520dc87d8fb_ra,w158,h184_pa,w158,h184.png", Description = "Maybelline The Nudes Eye Shadow Palette let's you create looks from day to night. Deep to light. So try it out and create your ideal eye look today!" },
                new Product { Id = 307, Brand = "maybelline", Name = "Maybelline Eyestudio Color Tattoo Concentrated Crayon", Price = 10.99m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/3f9f894b56e0616e44c5ee01dea45217_ra,w158,h184_pa,w158,h184.png", Description = "Maybelline Eyestudio Color Tattoo Concentrated Crayons give you high-intensity color that looks vibrant all-day long." },
                new Product { Id = 309, Brand = "maybelline", Name = "Maybelline Expert Wear Eye Shadow Quad", Price = 8.99m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/c924006882e8e313d445a3a5394e4729_ra,w158,h184_pa,w158,h184.png", Description = "Easy to use, lots to choose! Maybelline Expert Wear Eye Shadow Quads have 4 coordinating shades." },
                new Product { Id = 317, Brand = "maybelline", Name = "Maybelline Fit Me Foundation with SPF", Price = 10.99m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/eccb88d484b8c929fd349b0995a5dba2_ra,w158,h184_pa,w158,h184.png", Description = "It's face makeup that fits you! Features: No oils, no waxes, no nonsense." },
                new Product { Id = 320, Brand = "maybelline", Name = "Maybelline FIT ME! Matte + Poreless Foundation", Price = 10.99m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/257993e12625cc45a72ec03636ffa5c5_ra,w158,h184_pa,w158,h184.jpg", Description = "Maybelline FIT ME! Matte + Poreless Foundation goes beyond skin tone matching to fit the unique texture issues of normal to oily skin." },
                new Product { Id = 321, Brand = "maybelline", Name = "Maybelline Dream Liquid Mousse", Price = 14.79m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/1ca6a4a442b9aa6b5f3d94da77d8846c_ra,w158,h184_pa,w158,h184.png", Description = "Airbrushed perfection made possible: Air-whipped liquid makeup for 100% poreless skin." },
                new Product { Id = 339, Brand = "maybelline", Name = "Maybelline Dream Wonder Liquid Touch Foundation", Price = 14.99m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/ccb99ad6ac7f31a2a73454bdbda01d99_ra,w158,h184_pa,w158,h184.jpeg", Description = "Maybelline Dream Wonder Liquid Touch Foundation's breakthrough texture fuses with skin." },
                new Product { Id = 353, Brand = "maybelline", Name = "Maybelline Superstay Better Skin Foundation", Price = 14.99m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/c7d967ef502ecd79ab7ab466c4952d82_ra,w158,h184_pa,w158,h184.png", Description = "The Maybelline Superstay Better Skin Foundation reduces the appearance of spots, bumps, dullness and redness." },
                new Product { Id = 354, Brand = "maybelline", Name = "Maybelline Dream Velvet Foundation", Price = 18.49m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/24517c6c81c92eda31cd32b6327c1298_ra,w158,h184_pa,w158,h184.png", Description = "This Maybelline Dream Velvet Foundation is a refreshing gel-whipped foundation." },
                new Product { Id = 366, Brand = "maybelline", Name = "Maybelline Mineral Power Natural Perfecting Powder Foundation", Price = 14.99m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/c77ad2da76259cfd67a9a9432f635bfb_ra,w158,h184_pa,w158,h184.png", Description = "Mineral Power Powder Foundation with micro-minerals provides a more natural, healthier, luminous look." },
                new Product { Id = 379, Brand = "maybelline", Name = "Maybelline Dream Matte Mousse Foundation", Price = 14.79m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/029889b345c76a70e8bb978b73ed1a87_ra,w158,h184_pa,w158,h184.png", Description = "Maybelline Dream Matte Mouse Foundation is a revolutionary air-soft mousse." },
                new Product { Id = 380, Brand = "maybelline", Name = "Maybelline Fit Me Shine-Free Foundation Stick", Price = 10.99m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/d04e7c2ed65dabe1dca4eed9aa268e95_ra,w158,h184_pa,w158,h184.png", Description = "Get flawless, shine-free skin instantly and on-the-go for tailor-made mattifying coverage." },
                new Product { Id = 414, Brand = "maybelline", Name = "Maybelline Dream Bouncy Blush", Price = 11.99m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/51eacb9efebbaee39399e65ffe3d9416_ra,w158,h184_pa,w158,h184.png", Description = "Now, blush has bounce! Freshest flush ever." },
                new Product { Id = 439, Brand = "maybelline", Name = "Maybelline Fit Me Blush", Price = 10.29m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/53d5f825461117c0d96946e1029510b0_ra,w158,h184_pa,w158,h184.png", Description = "Maybelline Fit Me Blush has lightweight pigments blend easily and wear evenly." },
                new Product { Id = 468, Brand = "maybelline", Name = "Maybelline Face Studio Master Hi-Light Light Booster Blush", Price = 14.99m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/4621032a92cb428ad640c105b944b39c_ra,w158,h184_pa,w158,h184.png", Description = "Maybelline Face Studio Master Hi-Light Light Boosting blush formula has an expert balance of shade + shimmer illuminator." },
                new Product { Id = 477, Brand = "maybelline", Name = "Maybelline Facestudio Master Contour Kit", Price = 15.99m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/4f731de249cbd4cb819ea7f5f4cfb5c3_ra,w158,h184_pa,w158,h184.png", Description = "Maybelline Facestudio Master Contour Kit is the ultimate on the go all-in-one palette." },
                new Product { Id = 488, Brand = "maybelline", Name = "Maybelline Fit Me Bronzer", Price = 10.29m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/d4f7d82b4858c622bb3c1cef07b9d850_ra,w158,h184_pa,w158,h184.png", Description = "Lightweight pigments blend easily and wear evenly. Provides a natural, fade-proof bronzed color." },
                new Product { Id = 495, Brand = "maybelline", Name = "Maybelline Face Studio Master Hi-Light Light Booster Bronzer", Price = 14.99m, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/991799d3e70b8856686979f8ff6dcfe0_ra,w158,h184_pa,w158,h184.png", Description = "Maybelline Face Studio Master Hi-Light Light Boosting bronzer formula has an expert balance of shade + shimmer illuminator." }
            );
        }
    }
}
