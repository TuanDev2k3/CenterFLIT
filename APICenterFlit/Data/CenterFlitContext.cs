using System;
using System.Collections.Generic;
using APICenterFlit.Entities;
using Microsoft.EntityFrameworkCore;

namespace APICenterFlit.Data;

public partial class CenterFlitContext : DbContext
{
    public CenterFlitContext()
    {
    }

    public CenterFlitContext(DbContextOptions<CenterFlitContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessFail> AccessFails { get; set; }

    public virtual DbSet<AccessLog> AccessLogs { get; set; }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Content> Contents { get; set; }

    public virtual DbSet<ContentType> ContentTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<FileType> FileTypes { get; set; }

    public virtual DbSet<Folk> Folks { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsType> NewsTypes { get; set; }

    public virtual DbSet<Portal> Portals { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Religion> Religions { get; set; }

    public virtual DbSet<StatusList> StatusLists { get; set; }

    public virtual DbSet<TblFile> TblFiles { get; set; }

    public virtual DbSet<VertifyAccount> VertifyAccounts { get; set; }

    public virtual DbSet<ViewLogPortal> ViewLogPortals { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=CenterFLIT;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessFail>(entity =>
        {
            entity.ToTable("AccessFail");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BrowserName)
                .HasMaxLength(15)
                .HasColumnName("browser_name");
            entity.Property(e => e.DeviceName)
                .HasMaxLength(50)
                .HasColumnName("device_name");
            entity.Property(e => e.DeviceType)
                .HasMaxLength(10)
                .HasColumnName("device_type");
            entity.Property(e => e.IpPublic)
                .HasMaxLength(40)
                .HasColumnName("ip_public");
            entity.Property(e => e.SystemType)
                .HasComment("0-admin, 1-portal")
                .HasColumnName("system_type");
            entity.Property(e => e.TimeActive).HasColumnName("time_active");
            entity.Property(e => e.Timer)
                .HasColumnType("datetime")
                .HasColumnName("timer");
            entity.Property(e => e.UserAgent)
                .HasMaxLength(300)
                .HasColumnName("user_agent");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<AccessLog>(entity =>
        {
            entity.ToTable("AccessLog");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.BrowserName)
                .HasMaxLength(15)
                .HasColumnName("browser_name");
            entity.Property(e => e.DeviceName)
                .HasMaxLength(50)
                .HasColumnName("device_name");
            entity.Property(e => e.DeviceType)
                .HasMaxLength(10)
                .HasColumnName("device_type");
            entity.Property(e => e.IpPublic)
                .HasMaxLength(40)
                .HasColumnName("ip_public");
            entity.Property(e => e.LocationAddress)
                .HasMaxLength(50)
                .HasColumnName("location_address");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.SystemType)
                .HasComment("0-admin, 1-portal")
                .HasColumnName("system_type");
            entity.Property(e => e.Timer)
                .HasColumnType("datetime")
                .HasColumnName("timer");
            entity.Property(e => e.UserAgent)
                .HasMaxLength(300)
                .HasColumnName("user_agent");
        });

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Account");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Email, "IX_Account_Email").IsUnique();

            entity.HasIndex(e => e.UserName, "IX_Account_Username").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AccountType)
                .HasMaxLength(10)
                .HasDefaultValue("USR")
                .HasColumnName("account_type");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.Birthday)
                .HasColumnType("datetime")
                .HasColumnName("birthday");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("full_name");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.Remark)
                .HasMaxLength(250)
                .HasColumnName("remark");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<AccountType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_AccountType");

            entity.ToTable("AccountType");

            entity.HasIndex(e => e.Code, "IX_AccountType").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Remark)
                .HasMaxLength(250)
                .HasColumnName("remark");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Addresses");

            entity.ToTable("Address");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AddressText)
                .HasMaxLength(100)
                .HasColumnName("address_text");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.ProvinceId).HasColumnName("province_id");
            entity.Property(e => e.Remark)
                .HasMaxLength(255)
                .HasColumnName("remark");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TownId).HasColumnName("town_id");
            entity.Property(e => e.WardId).HasColumnName("ward_id");
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.ToTable("Banner");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ClickNumber).HasColumnName("click_number");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DescShort)
                .HasMaxLength(250)
                .HasColumnName("desc_short");
            entity.Property(e => e.EndAt)
                .HasColumnType("datetime")
                .HasColumnName("end_at");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.IsNeverExpired).HasColumnName("is_never_expired");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.RefId)
                .HasMaxLength(36)
                .HasColumnName("ref_id");
            entity.Property(e => e.SerialId).HasColumnName("serial_id");
            entity.Property(e => e.StartAt)
                .HasColumnType("datetime")
                .HasColumnName("start_at");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Timer)
                .HasColumnType("datetime")
                .HasColumnName("timer");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .HasColumnName("url");

            entity.HasOne(d => d.Location).WithMany(p => p.Banners)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_Banner_Location");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("Contact");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AdviseId).HasColumnName("advise_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValue(0)
                .HasColumnName("created_by");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("full_name");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Reply).HasColumnName("reply");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Content>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Detail).HasColumnName("detail");
            entity.Property(e => e.HomePage).HasColumnName("home_page");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.ImageList)
                .HasMaxLength(100)
                .HasColumnName("image_list");
            entity.Property(e => e.LikeNumber).HasColumnName("like_number");
            entity.Property(e => e.LinkRef)
                .HasMaxLength(200)
                .HasColumnName("link_ref");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("datetime")
                .HasColumnName("published_at");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
            entity.Property(e => e.TitleSlug)
                .HasMaxLength(200)
                .HasColumnName("title_slug");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.ViewNumber).HasColumnName("view_number");

            entity.HasOne(d => d.ContentType).WithMany(p => p.Contents)
                .HasForeignKey(d => d.ContentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contents_ContentType");
        });

        modelBuilder.Entity<ContentType>(entity =>
        {
            entity.ToTable("ContentType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.PortalId).HasColumnName("portal_id");
            entity.Property(e => e.Remark)
                .HasMaxLength(150)
                .HasColumnName("remark");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.TitleSlug)
                .HasMaxLength(100)
                .HasColumnName("title_slug");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(5)
                .HasColumnName("country_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_District");

            entity.ToTable("District");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DistrictCode)
                .HasMaxLength(5)
                .HasColumnName("district_code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ProvinceId).HasColumnName("province_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Province).WithMany(p => p.Districts)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_District_Province");
        });

        modelBuilder.Entity<FileType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DocumentType");

            entity.ToTable("FileType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Extension)
                .HasMaxLength(5)
                .HasColumnName("extension");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Folk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Folk");

            entity.ToTable("Folk");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Remark)
                .HasMaxLength(250)
                .HasColumnName("remark");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Images__3213E83F47534C37");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.MediumUrl)
                .HasMaxLength(250)
                .HasColumnName("medium_url");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.RefId)
                .HasMaxLength(36)
                .HasColumnName("ref_id");
            entity.Property(e => e.RelativeUrl)
                .HasMaxLength(250)
                .HasColumnName("relative_url");
            entity.Property(e => e.SerialId).HasColumnName("serial_id");
            entity.Property(e => e.SmallUrl)
                .HasMaxLength(250)
                .HasColumnName("small_url");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Timer)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("timer");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.ReOrder).HasColumnName("re_order");
            entity.Property(e => e.RefId)
                .HasMaxLength(36)
                .HasColumnName("ref_id");
            entity.Property(e => e.Remark)
                .HasMaxLength(250)
                .HasColumnName("remark");
            entity.Property(e => e.SerialId).HasColumnName("serial_id");
            entity.Property(e => e.ShowUi).HasColumnName("show_ui");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Timer)
                .HasColumnType("datetime")
                .HasColumnName("timer");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Detail).HasColumnName("detail");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.ImageList)
                .HasMaxLength(100)
                .HasColumnName("image_list");
            entity.Property(e => e.IsHot).HasColumnName("is_hot");
            entity.Property(e => e.LikeNumber).HasColumnName("like_number");
            entity.Property(e => e.LinkRef)
                .HasMaxLength(200)
                .HasColumnName("link_ref");
            entity.Property(e => e.NewsTypeId).HasColumnName("news_type_id");
            entity.Property(e => e.NewstypeIdList)
                .HasMaxLength(50)
                .HasColumnName("newstype_id_list");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("datetime")
                .HasColumnName("published_at");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");
            entity.Property(e => e.TitleSlug)
                .HasMaxLength(500)
                .HasColumnName("title_slug");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.ViewNumber).HasColumnName("view_number");

            entity.HasOne(d => d.NewsType).WithMany(p => p.News)
                .HasForeignKey(d => d.NewsTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_News_NewsType");
        });

        modelBuilder.Entity<NewsType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_NewsCategory");

            entity.ToTable("NewsType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.ParentId)
                .HasDefaultValue(0)
                .HasColumnName("parent_id");
            entity.Property(e => e.PortalId).HasColumnName("portal_id");
            entity.Property(e => e.Remark)
                .HasMaxLength(150)
                .HasColumnName("remark");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.TitleSlug)
                .HasMaxLength(100)
                .HasColumnName("title_slug");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Portal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Customer");

            entity.ToTable("Portal");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.BannerUrl)
                .HasMaxLength(200)
                .HasColumnName("banner_url");
            entity.Property(e => e.ContactName)
                .HasMaxLength(150)
                .HasColumnName("contact_name");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Facebook)
                .HasMaxLength(200)
                .HasColumnName("facebook");
            entity.Property(e => e.Hotline)
                .HasMaxLength(20)
                .HasColumnName("hotline");
            entity.Property(e => e.ImageFavicon)
                .HasMaxLength(200)
                .HasColumnName("image_favicon");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.ImageList)
                .HasMaxLength(200)
                .HasColumnName("image_list");
            entity.Property(e => e.Instagram)
                .HasMaxLength(200)
                .HasColumnName("instagram");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.NameSlug)
                .HasMaxLength(300)
                .HasColumnName("name_slug");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.PostCode)
                .HasMaxLength(10)
                .HasColumnName("post_code");
            entity.Property(e => e.RefCode)
                .HasMaxLength(36)
                .HasColumnName("ref_code");
            entity.Property(e => e.SiteUrl)
                .HasMaxLength(200)
                .HasColumnName("site_url");
            entity.Property(e => e.SocialNetwork).HasColumnName("social_network");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(20)
                .HasColumnName("tax_number");
            entity.Property(e => e.Twitter)
                .HasMaxLength(200)
                .HasColumnName("twitter");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.Youtube)
                .HasMaxLength(200)
                .HasColumnName("youtube");
            entity.Property(e => e.Zalo)
                .HasMaxLength(200)
                .HasColumnName("zalo");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Province");

            entity.ToTable("Province");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AxisMeridian)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("axis_meridian");
            entity.Property(e => e.CountryId)
                .HasDefaultValue(1)
                .HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ProvinceCode)
                .HasMaxLength(5)
                .HasColumnName("province_code");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.ToTable("RefreshToken");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ExpiredAt).HasColumnName("expiredAt");
            entity.Property(e => e.IsRevoked).HasColumnName("isRevoked");
            entity.Property(e => e.IsUsed).HasColumnName("isUsed");
            entity.Property(e => e.IssuedAt).HasColumnName("issuedAt");
            entity.Property(e => e.JwtId)
                .HasMaxLength(50)
                .HasColumnName("jwtId");
            entity.Property(e => e.Token)
                .HasMaxLength(50)
                .HasColumnName("token");
        });

        modelBuilder.Entity<Religion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Religion");

            entity.ToTable("Religion");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Remark)
                .HasMaxLength(150)
                .HasColumnName("remark");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<StatusList>(entity =>
        {
            entity.ToTable("StatusList");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Del).HasColumnName("del");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Remark)
                .HasMaxLength(150)
                .HasColumnName("remark");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TableName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("table_name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<TblFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblFiles");

            entity.ToTable("tblFile");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Fcontent).HasColumnName("fcontent");
            entity.Property(e => e.FcontentType)
                .HasMaxLength(200)
                .HasColumnName("fcontentType");
            entity.Property(e => e.Fextension)
                .HasMaxLength(50)
                .HasColumnName("fextension");
            entity.Property(e => e.Fname)
                .HasMaxLength(200)
                .HasColumnName("fname");
            entity.Property(e => e.Fsize).HasColumnName("fsize");
            entity.Property(e => e.Guid)
                .HasMaxLength(40)
                .HasColumnName("guid");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TableId)
                .HasComment("Các id của table nào muốn dùng file")
                .HasColumnName("table_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<VertifyAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_VertifyPhone");

            entity.ToTable("VertifyAccount");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ActiveCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("active_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Deadline).HasColumnName("deadline");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.VertifyType).HasColumnName("vertify_type");
        });

        modelBuilder.Entity<ViewLogPortal>(entity =>
        {
            entity.HasKey(e => new { e.Year, e.Month, e.Day });

            entity.ToTable("ViewLogPortal");

            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.Day).HasColumnName("day");
            entity.Property(e => e.ViewNumber).HasColumnName("view_number");
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Wards");

            entity.ToTable("Ward");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.WardCode)
                .HasMaxLength(5)
                .HasColumnName("ward_code");

            entity.HasOne(d => d.District).WithMany(p => p.Wards)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ward_District");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
