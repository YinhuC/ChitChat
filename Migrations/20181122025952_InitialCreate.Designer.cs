﻿// <auto-generated />
using ChitChat.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChitChat.Migrations
{
    [DbContext(typeof(ChitChatContext))]
    [Migration("20181122025952_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("ChitChat.Models.PostItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Downvotes");

                    b.Property<string>("Msg");

                    b.Property<string>("Time");

                    b.Property<string>("Title");

                    b.Property<int>("Upvotes");

                    b.Property<int>("UserID");

                    b.HasKey("Id");

                    b.ToTable("PostItem");
                });
#pragma warning restore 612, 618
        }
    }
}
