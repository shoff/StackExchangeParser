﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace StackExchangeParser.Migrations
{
    using EF;

    [DbContext(typeof(StackExchangeDbContext))]
    [Migration("20190530201625_RemovingBidirectionalNav")]
    partial class RemovingBidirectionalNav
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StackExchangeParser.Models.Badge", b =>
                {
                    b.Property<long>("Id");

                    b.Property<int>("Class");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name");

                    b.Property<string>("TagBased");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("StackExchangeParser.Models.Comment", b =>
                {
                    b.Property<long>("Id");

                    b.Property<DateTime>("CreationDate");

                    b.Property<long?>("PostId");

                    b.Property<int>("Score");

                    b.Property<string>("Text");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("StackExchangeParser.Models.Post", b =>
                {
                    b.Property<long>("Id");

                    b.Property<int>("AnswerCount");

                    b.Property<string>("Body");

                    b.Property<DateTime?>("ClosedDate");

                    b.Property<int>("CommentCount");

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("FavoriteCount");

                    b.Property<DateTime>("LastActivityDate");

                    b.Property<DateTime?>("LastEditDate");

                    b.Property<string>("LastEditorDisplayName");

                    b.Property<long?>("LastEditorUserId");

                    b.Property<string>("OwnerDisplayName");

                    b.Property<long?>("OwnerUserId");

                    b.Property<int>("PostTypeId");

                    b.Property<int>("Score");

                    b.Property<string>("Tags");

                    b.Property<string>("Title");

                    b.Property<string>("Type");

                    b.Property<int>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("OwnerUserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("StackExchangeParser.Models.PostHistory", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("PostHistoryTypeId");

                    b.Property<long?>("PostId");

                    b.Property<string>("RevisionGUID");

                    b.Property<string>("Text");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("PostHistories");
                });

            modelBuilder.Entity("StackExchangeParser.Models.Tag", b =>
                {
                    b.Property<long>("Id");

                    b.Property<int?>("Count");

                    b.Property<long?>("ExcerptPostId");

                    b.Property<string>("TagName");

                    b.Property<int?>("WikiPostId");

                    b.HasKey("Id");

                    b.HasIndex("ExcerptPostId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("StackExchangeParser.Models.User", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("AboutMe");

                    b.Property<long>("AccountId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("DisplayName");

                    b.Property<int>("DownVotes");

                    b.Property<DateTime>("LastAccessDate");

                    b.Property<string>("Location");

                    b.Property<string>("ProfileImageUrl");

                    b.Property<int>("Reputation");

                    b.Property<int>("UpVotes");

                    b.Property<int>("Views");

                    b.Property<string>("WebsiteUrl");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StackExchangeParser.Models.Vote", b =>
                {
                    b.Property<long>("Id");

                    b.Property<DateTime>("CreationDate");

                    b.Property<long?>("PostId");

                    b.Property<long?>("UserId");

                    b.Property<int>("VoteTypeId");

                    b.HasKey("Id");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("StackExchangeParser.Models.Badge", b =>
                {
                    b.HasOne("StackExchangeParser.Models.User", "User")
                        .WithMany("Badges")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("StackExchangeParser.Models.Comment", b =>
                {
                    b.HasOne("StackExchangeParser.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("StackExchangeParser.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("StackExchangeParser.Models.Post", b =>
                {
                    b.HasOne("StackExchangeParser.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerUserId");
                });

            modelBuilder.Entity("StackExchangeParser.Models.PostHistory", b =>
                {
                    b.HasOne("StackExchangeParser.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.HasOne("StackExchangeParser.Models.User", "User")
                        .WithMany("PostHistories")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("StackExchangeParser.Models.Tag", b =>
                {
                    b.HasOne("StackExchangeParser.Models.Post", "ExcerptPost")
                        .WithMany()
                        .HasForeignKey("ExcerptPostId");
                });
#pragma warning restore 612, 618
        }
    }
}
