using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductService.Core.Enums;
using ProductService.Core.Models;
using System;

#nullable disable

namespace ProductService.Infrastructure.Context
{
    public partial class FidelityContext : DbContext
    {
        public FidelityContext()
        {
        }

        public FidelityContext(DbContextOptions<FidelityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderHistory> OrderHistories { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Subcategory> Subcategories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<UserPointCompany> UserPointCompanies { get; set; }
        public virtual DbSet<UserPointHistory> UserPointHistories { get; set; }
        public virtual DbSet<UserPointStatus> UserPointStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=127.0.0.1;uid=root;pwd=1234;database=fidelity");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.HasIndex(e => e.Name, "name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Active)
                    .HasColumnType("tinyint")
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.HasIndex(e => e.EmployerIdentificationNumber, "employer_identification_number_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Active)
                    .HasColumnType("tinyint")
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("company_name");

                entity.Property(e => e.EmployerIdentificationNumber)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("employer_identification_number");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnName("registration_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.TradeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("trade_name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => e.OrderStatusId, "FK_ID_ORD_UST_idx");

                entity.HasIndex(e => e.UserAddressId, "FK_ORD_USD_idx");

                entity.HasIndex(e => e.UserId, "FK_ORD_USE_idx");

                entity.HasIndex(e => e.ProductId, "FK_ORD__idx");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                
                entity.Property(e => e.OrderStatusId)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("order_status_id")
                    .HasDefaultValueSql("'P'")
                    .HasConversion<string>()
                    .IsFixedLength(true);

                entity.Property(e => e.PointsValue)
                    .HasColumnType("decimal(15,2)")
                    .HasColumnName("points_value");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnName("registration_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UserAddressId).HasColumnName("user_address_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_ORD_UST");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_ORD_PRO");

                entity.HasOne(d => d.UserAddress)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_ORD_UAD");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_ORD_USE");
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.ToTable("order_history");

                entity.HasIndex(e => e.OrderStatusId, "FK_ID_ORH_OST_idx");

                entity.HasIndex(e => e.OrderId, "FK_ORH_ORD_idx");

                entity.Property(e => e.OrderHistoryId).HasColumnName("order_history_id");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("details");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.OrderStatusId)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("order_status_id")
                    .HasConversion<string>()
                    .IsFixedLength(true);

                entity.Property(e => e.RegistrationDate)
                    .HasColumnName("registration_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_ORH_ORD");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_ORH_OST");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("order_status");

                entity.Property(e => e.OrderStatusId)
                    .HasMaxLength(1)
                    .HasColumnName("order_status_id")
                    .HasConversion<string>()
                    .IsFixedLength(true);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.SubcategoryId, "subcategory_id_idx");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Active)
                    .HasColumnType("tinyint")
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.PointsValue)
                    .HasColumnType("decimal(15,2)")
                    .HasColumnName("points_value");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnName("registration_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.SubcategoryId).HasColumnName("subcategory_id");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SubcategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PRO_SUB");
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.ToTable("subcategory");

                entity.HasIndex(e => e.CategoryId, "FK_ID_SUB_CAT_idx");

                entity.Property(e => e.SubcategoryId).HasColumnName("subcategory_id");

                entity.Property(e => e.Active)
                    .HasColumnType("tinyint")
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Subcategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_SUB_CAT");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Email, "email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IndividualTaxpayerRegistration, "individual_taxpayer_registration_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Active)
                    .HasColumnType("tinyint")
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.Cellphone)
                    .HasMaxLength(15)
                    .HasColumnName("cellphone");

                entity.Property(e => e.CurrentPointsBalance)
                    .HasColumnType("decimal(15,2)")
                    .HasColumnName("current_points_balance");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.IndividualTaxpayerRegistration)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("individual_taxpayer_registration");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnName("registration_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.ToTable("user_address");

                entity.HasIndex(e => e.UserId, "FK_ID_ADR_USE_idx");

                entity.Property(e => e.UserAddressId).HasColumnName("user_address_id");

                entity.Property(e => e.Active)
                    .HasColumnType("tinyint")
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("city");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("district");

                entity.Property(e => e.InformationAdditional)
                    .HasMaxLength(100)
                    .HasColumnName("information_additional");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnName("registration_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("state");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(8)
                    .HasColumnName("zip_code");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAddresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_ADR_USE");
            });

            modelBuilder.Entity<UserPointCompany>(entity =>
            {
                entity.ToTable("user_point_company");

                entity.HasIndex(e => e.UserPointStatusId, "FK_ID_UPC_UPS_idx");

                entity.HasIndex(e => e.CompanyId, "FK_UPH_PAC_idx");

                entity.HasIndex(e => e.UserId, "FK_UPH_USE_idx");

                entity.Property(e => e.UserPointCompanyId).HasColumnName("user_point_company_id");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasComment("Companhia parceira em que o usuário adquiriu os pontos.");

                entity.Property(e => e.PointsValue)
                    .HasColumnType("decimal(15,2)")
                    .HasColumnName("points_value");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnName("registration_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserPointStatusId)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("user_point_status_id")
                    .HasDefaultValueSql("'P'")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.UserPointCompanies)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_UPC_PAC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPointCompanies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_UPC_USE");

                entity.HasOne(d => d.UserPointStatus)
                    .WithMany(p => p.UserPointCompanies)
                    .HasForeignKey(d => d.UserPointStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_UPC_UPS");
            });

            modelBuilder.Entity<UserPointHistory>(entity =>
            {
                entity.ToTable("user_point_history");

                entity.HasIndex(e => e.UserId, "FK_UPH_USE_idx");

                entity.Property(e => e.UserPointHistoryId).HasColumnName("user_point_history_id");

                entity.Property(e => e.PointBalance)
                    .HasColumnType("decimal(15,2)")
                    .HasColumnName("point_balance");

                entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPointHistories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_UPH_USE");
            });

            modelBuilder.Entity<UserPointStatus>(entity =>
            {
                entity.ToTable("user_point_status");

                entity.Property(e => e.UserPointStatusId)
                    .HasMaxLength(1)
                    .HasColumnName("user_point_status_id")
                    .IsFixedLength(true);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
