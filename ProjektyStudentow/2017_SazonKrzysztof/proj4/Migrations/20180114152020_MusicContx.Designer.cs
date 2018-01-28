﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using proj4.Data;
using proj4.Models;
using System;

namespace proj4.Migrations
{
    [DbContext(typeof(MusicContext))]
    [Migration("20180114152020_MusicContx")]
    partial class MusicContx
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("proj4.Models.Band", b =>
                {
                    b.Property<string>("BandID");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<DateTime?>("FormationDate");

                    b.Property<int?>("Genre");

                    b.Property<int?>("ListenerID");

                    b.HasKey("BandID");

                    b.HasIndex("ListenerID");

                    b.ToTable("band");
                });

            modelBuilder.Entity("proj4.Models.BandListener", b =>
                {
                    b.Property<string>("BandID");

                    b.Property<int>("ListenerID");

                    b.Property<int>("Note");

                    b.HasKey("BandID", "ListenerID");

                    b.HasIndex("ListenerID");

                    b.ToTable("band_listener");
                });

            modelBuilder.Entity("proj4.Models.Listener", b =>
                {
                    b.Property<int>("ListenerID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("EmailAddress")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .HasMaxLength(30);

                    b.HasKey("ListenerID");

                    b.ToTable("listener");
                });

            modelBuilder.Entity("proj4.Models.Tour", b =>
                {
                    b.Property<int>("TourID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BandID");

                    b.Property<string>("City");

                    b.Property<DateTime>("Date");

                    b.HasKey("TourID");

                    b.HasIndex("BandID");

                    b.ToTable("tour");
                });

            modelBuilder.Entity("proj4.Models.Band", b =>
                {
                    b.HasOne("proj4.Models.Listener")
                        .WithMany("Bands")
                        .HasForeignKey("ListenerID");
                });

            modelBuilder.Entity("proj4.Models.BandListener", b =>
                {
                    b.HasOne("proj4.Models.Band", "Band")
                        .WithMany("BandsListeners")
                        .HasForeignKey("BandID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("proj4.Models.Listener", "Listener")
                        .WithMany("BandsListeners")
                        .HasForeignKey("ListenerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("proj4.Models.Tour", b =>
                {
                    b.HasOne("proj4.Models.Band", "Band")
                        .WithMany("Tours")
                        .HasForeignKey("BandID");
                });
#pragma warning restore 612, 618
        }
    }
}