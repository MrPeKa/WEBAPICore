using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreWEBAPI.Database;

namespace CoreWEBAPI.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170113103200_AddedProducts")]
    partial class AddedProducts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreWEBAPI.Domain.Models.BillModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Sum");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("CoreWEBAPI.Domain.Models.CompanyModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("CoreWEBAPI.Domain.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BillId");

                    b.Property<string>("Name");

                    b.Property<double>("Prize");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CoreWEBAPI.Domain.Models.BillModel", b =>
                {
                    b.HasOne("CoreWEBAPI.Domain.Models.CompanyModel", "Company")
                        .WithMany("Bills")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("CoreWEBAPI.Domain.Models.ProductModel", b =>
                {
                    b.HasOne("CoreWEBAPI.Domain.Models.BillModel", "Bill")
                        .WithMany("Products")
                        .HasForeignKey("BillId");
                });
        }
    }
}
