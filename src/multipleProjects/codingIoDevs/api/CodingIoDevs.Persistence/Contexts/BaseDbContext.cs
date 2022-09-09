using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Domain.Entities;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CodingIoDevs.Persistence.Contexts;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions options) : base(options)
    { }


    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    public DbSet<Framework> Frameworks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserLink> UserLinks { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProgrammingLanguage>(a =>
        {
            a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.Name).HasColumnName("Name");

            a.HasMany(p => p.Frameworks);
        });

        modelBuilder.Entity<Framework>(a =>
        {
            a.ToTable("Frameworks").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
            a.Property(p => p.Name).HasColumnName("Name");

            a.HasOne(p => p.ProgrammingLanguage);
        });


        modelBuilder.Entity<User>(a =>
        {
            a.ToTable("Users").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.FirstName).HasColumnName("FirstName");
            a.Property(p => p.LastName).HasColumnName("LastName");
            a.Property(p => p.Email).HasColumnName("Email");
            a.Property(p => p.NormalizedEmail).HasColumnName("NormalizedEmail");
            a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
            a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
            a.Property(p => p.Status).HasColumnName("Status");
            a.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");

            a.HasMany(p => p.UserOperationClaims);
            a.HasMany(p => p.RefreshTokens);

        });

        modelBuilder.Entity<UserLink>(a =>
        {
            a.ToTable("UserLinks").HasKey(k => k.Id);
            a.Property(p => p.UserId).HasColumnName("UserId");
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.GithubUrl).HasColumnName("GithubUrl");
            a.Property(p => p.LinkedInUrl).HasColumnName("LinkedInUrl");

            a.HasOne(p => p.User);

        });



        modelBuilder.Entity<RefreshToken>(a =>
        {
            a.ToTable("RefreshTokens").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.UserId).HasColumnName("UserId");
            a.Property(p => p.Token).HasColumnName("Token");
            a.Property(p => p.Expires).HasColumnName("Expires");
            a.Property(p => p.Created).HasColumnName("Created");
            a.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
            a.Property(p => p.Revoked).HasColumnName("Revoked");
            a.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
            a.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
            a.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");


            a.HasOne(p => p.User);
        });

        modelBuilder.Entity<OtpAuthenticator>(a =>
        {
            a.ToTable("OtpAuthenticators").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.UserId).HasColumnName("UserId");
            a.Property(p => p.SecretKey).HasColumnName("SecretKey");
            a.Property(p => p.IsVerified).HasColumnName("IsVerified");

            a.HasOne(p => p.User);
        });

        modelBuilder.Entity<OperationClaim>(a =>
        {
            a.ToTable("OperationClaims").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.Name).HasColumnName("Name");
        });

        modelBuilder.Entity<UserOperationClaim>(a =>
        {
            a.ToTable("UserOperationClaims").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.UserId).HasColumnName("UserId");
            a.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");

            a.HasOne(p => p.User);
            a.HasOne(p => p.OperationClaim);

        });
    }
}