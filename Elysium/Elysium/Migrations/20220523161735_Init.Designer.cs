﻿// <auto-generated />
using System;
using Elysium.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Elysium.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220523161735_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CategoryRoute", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoutesId")
                        .HasColumnType("uuid");

                    b.HasKey("CategoriesId", "RoutesId");

                    b.HasIndex("RoutesId");

                    b.ToTable("CategoryRoute");
                });

            modelBuilder.Entity("Elysium.Model.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ArchivedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Elysium.Model.Currency", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Code");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("Elysium.Model.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double?>("Longitide")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Region");

                    b.HasIndex("Country", "Region");

                    b.HasIndex("Longitide", "Latitude")
                        .HasFilter("NOT Longitude IS NULL AND NOT Latitude IS NULL");

                    b.HasIndex("Name", "Region");

                    b.HasIndex("Region", "Name");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Elysium.Model.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ArchivedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoutePointId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("RoutePointId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Elysium.Model.Provider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("FBId")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("InstagramId")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<int>("Rate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("VKId")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Rate");

                    b.ToTable("Proviers");
                });

            modelBuilder.Entity("Elysium.Model.Route", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly?>("ArchivedAt")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<int>("Difficulty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uuid");

                    b.Property<string>("MainPhotoLink")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("MainPhotoTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("ProviderId")
                        .HasColumnType("uuid");

                    b.Property<int>("Rate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("VisaDetails")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<bool>("VisaMandatory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("Difficulty");

                    b.HasIndex("LocationId");

                    b.HasIndex("Name");

                    b.HasIndex("ProviderId");

                    b.HasIndex("Rate");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Elysium.Model.RoutePoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RouteId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("RouteId");

                    b.ToTable("RoutePoint");
                });

            modelBuilder.Entity("Elysium.Model.TeamMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("PhotoLink")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("Elysium.Model.Tour", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ArchivedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("AvailableTicketNumber")
                        .HasColumnType("integer");

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasColumnType("character varying(5)");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("EndedAt")
                        .HasColumnType("date");

                    b.Property<Guid>("MeetPointId")
                        .HasColumnType("uuid");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("ProviderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RouteId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("StartedAt")
                        .HasColumnType("date");

                    b.Property<int>("TicketNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AvailableTicketNumber");

                    b.HasIndex("CurrencyCode");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("MeetPointId");

                    b.HasIndex("ProviderId");

                    b.HasIndex("RouteId");

                    b.HasIndex("Price", "CurrencyId");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("TeamMemberTour", b =>
                {
                    b.Property<Guid>("TeamMembersId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ToursId")
                        .HasColumnType("uuid");

                    b.HasKey("TeamMembersId", "ToursId");

                    b.HasIndex("ToursId");

                    b.ToTable("TeamMemberTour");
                });

            modelBuilder.Entity("CategoryRoute", b =>
                {
                    b.HasOne("Elysium.Model.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Elysium.Model.Route", null)
                        .WithMany()
                        .HasForeignKey("RoutesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Elysium.Model.Photo", b =>
                {
                    b.HasOne("Elysium.Model.Location", null)
                        .WithMany("Photos")
                        .HasForeignKey("LocationId");

                    b.HasOne("Elysium.Model.RoutePoint", "Point")
                        .WithMany()
                        .HasForeignKey("RoutePointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Point");
                });

            modelBuilder.Entity("Elysium.Model.Route", b =>
                {
                    b.HasOne("Elysium.Model.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Elysium.Model.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("Elysium.Model.RoutePoint", b =>
                {
                    b.HasOne("Elysium.Model.Location", "Location")
                        .WithMany("Points")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Elysium.Model.Route", "Route")
                        .WithMany("Points")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Elysium.Model.Tour", b =>
                {
                    b.HasOne("Elysium.Model.Currency", "Currency")
                        .WithMany("Tours")
                        .HasForeignKey("CurrencyCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Elysium.Model.Location", "MeetPoint")
                        .WithMany()
                        .HasForeignKey("MeetPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Elysium.Model.Provider", null)
                        .WithMany("Tours")
                        .HasForeignKey("ProviderId");

                    b.HasOne("Elysium.Model.Route", "Route")
                        .WithMany("Tours")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("MeetPoint");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("TeamMemberTour", b =>
                {
                    b.HasOne("Elysium.Model.TeamMember", null)
                        .WithMany()
                        .HasForeignKey("TeamMembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Elysium.Model.Tour", null)
                        .WithMany()
                        .HasForeignKey("ToursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Elysium.Model.Currency", b =>
                {
                    b.Navigation("Tours");
                });

            modelBuilder.Entity("Elysium.Model.Location", b =>
                {
                    b.Navigation("Photos");

                    b.Navigation("Points");
                });

            modelBuilder.Entity("Elysium.Model.Provider", b =>
                {
                    b.Navigation("Tours");
                });

            modelBuilder.Entity("Elysium.Model.Route", b =>
                {
                    b.Navigation("Points");

                    b.Navigation("Tours");
                });
#pragma warning restore 612, 618
        }
    }
}
