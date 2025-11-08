using Microsoft.EntityFrameworkCore;



namespace api.Models
{
    public partial class db_a7e6f8_hotelContext : DbContext
    {
        public db_a7e6f8_hotelContext()
        {
        }

        public db_a7e6f8_hotelContext(DbContextOptions<db_a7e6f8_hotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounting> Accountings { get; set; }
        public virtual DbSet<BillForService> BillForServices { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Departament> Departaments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<OrderingFood> OrderingFoods { get; set; }
        public virtual DbSet<OrderingRoom> OrderingRooms { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoomNumber> RoomNumbers { get; set; }
        public virtual DbSet<TypeOfService> TypeOfServices { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=SQL5109.site4now.net;Database=db_a7e6f8_hotel;User Id=db_a7e6f8_hotel_admin;Password=123456789Topol;Trusted_Connection=false;Integrated Security=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Accounting>(entity =>
            {
                entity.HasKey(e => e.IdAccounting);

                entity.ToTable("Accounting");

                entity.Property(e => e.IdAccounting).HasColumnName("ID_Accounting");

                entity.Property(e => e.DateIssue).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

            });

            modelBuilder.Entity<BillForService>(entity =>
            {
                entity.HasKey(e => e.IdBillForServices);

                entity.Property(e => e.IdBillForServices).HasColumnName("ID_BillForServices");

                entity.Property(e => e.ClientId).HasColumnName("Client_ID");

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

                entity.Property(e => e.TypeOfServicesId).HasColumnName("TypeOfServices_ID");

            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient);

                entity.ToTable("Client");

                entity.Property(e => e.IdClient).HasColumnName("ID_Client");

                entity.Property(e => e.DateBirthClient).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberPass)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SeriaPass)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Departament>(entity =>
            {
                entity.HasKey(e => e.IdDepartament);

                entity.ToTable("Departament");

                entity.Property(e => e.IdDepartament).HasColumnName("ID_Departament");

                entity.Property(e => e.DepartamentPhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);

                entity.ToTable("Employee");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.DateBirthEmployee).HasColumnType("date");

                entity.Property(e => e.DepartamentId).HasColumnName("Departament_ID");

                entity.Property(e => e.EmployeeEmail)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeePhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberPasport)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PostId).HasColumnName("Post_ID");

                entity.Property(e => e.SeriaPasport)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_ID");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasKey(e => e.IdFood);

                entity.ToTable("Food");

                entity.Property(e => e.IdFood).HasColumnName("ID_Food");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderingFood>(entity =>
            {
                entity.HasKey(e => e.IdOrderingFood);

                entity.ToTable("OrderingFood");

                entity.Property(e => e.IdOrderingFood).HasColumnName("ID_OrderingFood");

                entity.Property(e => e.ClientId).HasColumnName("Client_ID");

                entity.Property(e => e.FoodId).HasColumnName("Food_ID");
            });

            modelBuilder.Entity<OrderingRoom>(entity =>
            {
                entity.HasKey(e => e.IdOrderingRoom);

                entity.ToTable("OrderingRoom");

                entity.Property(e => e.IdOrderingRoom).HasColumnName("ID_OrderingRoom");

                entity.Property(e => e.ArrivalDate).HasColumnType("date");

                entity.Property(e => e.ClientId).HasColumnName("Client_ID");

                entity.Property(e => e.DepartureDate).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.NumberId).HasColumnName("Number_ID");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost);

                entity.ToTable("Post");

                entity.Property(e => e.IdPost).HasColumnName("ID_Post");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.ToTable("Role");

                entity.Property(e => e.IdRole).HasColumnName("ID_Role");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomNumber>(entity =>
            {
                entity.HasKey(e => e.IdNumber)
                    .HasName("PK_Number");

                entity.ToTable("RoomNumber");

                entity.Property(e => e.IdNumber).HasColumnName("ID_Number");

                entity.Property(e => e.RoomNumber1).HasColumnName("RoomNumber");
            });

            modelBuilder.Entity<TypeOfService>(entity =>
            {
                entity.HasKey(e => e.IdTypeOfServices);

                entity.Property(e => e.IdTypeOfServices).HasColumnName("ID_TypeOfServices");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
