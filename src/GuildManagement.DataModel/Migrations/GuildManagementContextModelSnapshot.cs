using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using GuildManagement.DataModel;

namespace GuildManagement.DataModel.Migrations
{
    [DbContext(typeof(GuildManagementContext))]
    partial class GuildManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuildManagement.Framework.Character", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Battlegroup");

                    b.Property<int>("Class");

                    b.Property<int>("ClassID");

                    b.Property<int>("Faction");

                    b.Property<int>("Gender");

                    b.Property<int>("GenderID");

                    b.Property<Guid?>("GuildKey");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<int>("Race");

                    b.Property<int>("RaceID");

                    b.Property<string>("Realm");

                    b.HasKey("Key");
                });

            modelBuilder.Entity("GuildManagement.Framework.Guild", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Battlegroup");

                    b.Property<string>("Name");

                    b.Property<Guid?>("Owner");

                    b.Property<string>("Realm");

                    b.Property<string>("Website");

                    b.HasKey("Key");
                });

            modelBuilder.Entity("GuildManagement.Framework.User", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Key");
                });

            modelBuilder.Entity("GuildManagement.Framework.Character", b =>
                {
                    b.HasOne("GuildManagement.Framework.Guild")
                        .WithMany()
                        .HasForeignKey("GuildKey");
                });
        }
    }
}
