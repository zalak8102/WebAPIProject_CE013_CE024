// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TenantFinderAPI.Data;

namespace TenantFinderAPI.Migrations
{
    [DbContext(typeof(TenantContext))]
    partial class TenantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TenantFinderAPI.Models.House", b =>
                {
                    b.Property<int>("hid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("no")
                        .HasColumnType("int");

                    b.Property<float>("rent")
                        .HasColumnType("real");

                    b.Property<string>("reqtenant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("hid");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("TenantFinderAPI.Models.Tenant", b =>
                {
                    b.Property<int>("tid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("catg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phone")
                        .HasColumnType("int");

                    b.Property<string>("reqhouse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tid");

                    b.ToTable("Tenants");
                });
#pragma warning restore 612, 618
        }
    }
}
