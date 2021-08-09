using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Core1.Models
{
    public partial class ITIContext : DbContext
    {
        public ITIContext()
        {
        }

        public ITIContext(DbContextOptions<ITIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employee1> Employees1 { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<InsCourse> InsCourses { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<LDatum> LData { get; set; }
        public virtual DbSet<Ldatum1> Ldata1 { get; set; }
        public virtual DbSet<StudCourse> StudCourses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentAudit> StudentAudits { get; set; }
        public virtual DbSet<StudentAudit1> StudentAudits1 { get; set; }
        public virtual DbSet<StudentsAudit> StudentsAudits { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<V1> V1s { get; set; }
        public virtual DbSet<Vin> Vins { get; set; }
        public virtual DbSet<Vmngr> Vmngrs { get; set; }
        public virtual DbSet<Vstud> Vstuds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-QME387U\\MSSQLSERVER01;Database=ITI;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CrsId);

                entity.ToTable("Course");

                entity.Property(e => e.CrsId)
                    .ValueGeneratedNever()
                    .HasColumnName("Crs_Id");

                entity.Property(e => e.CrsDuration).HasColumnName("Crs_Duration");

                entity.Property(e => e.CrsName)
                    .HasMaxLength(50)
                    .HasColumnName("Crs_Name");

                entity.Property(e => e.TopId).HasColumnName("Top_Id");

                entity.HasOne(d => d.Top)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.TopId)
                    .HasConstraintName("FK_Course_Topic");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId);

                entity.ToTable("Department");

                entity.Property(e => e.DeptId)
                    .ValueGeneratedNever()
                    .HasColumnName("Dept_Id");

                entity.Property(e => e.DeptDesc)
                    .HasMaxLength(100)
                    .HasColumnName("Dept_Desc");

                entity.Property(e => e.DeptLocation)
                    .HasMaxLength(50)
                    .HasColumnName("Dept_Location");

                entity.Property(e => e.DeptManager).HasColumnName("Dept_Manager");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(50)
                    .HasColumnName("Dept_Name");

                entity.Property(e => e.ManagerHiredate)
                    .HasColumnType("date")
                    .HasColumnName("Manager_hiredate");

                entity.HasOne(d => d.DeptManagerNavigation)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.DeptManager)
                    .HasConstraintName("FK_Department_Instructor");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId).HasColumnName("Manager_id");
            });

            modelBuilder.Entity<Employee1>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__Employee__7AD04F118EC4C5CF");

                entity.ToTable("Employees");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK__Employees__Manag__534D60F1");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("history");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("_date");

                entity.Property(e => e.New).HasColumnName("_New");

                entity.Property(e => e.Old).HasColumnName("_old");

                entity.Property(e => e.User)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("_user");
            });

            modelBuilder.Entity<InsCourse>(entity =>
            {
                entity.HasKey(e => new { e.InsId, e.CrsId });

                entity.ToTable("Ins_Course");

                entity.Property(e => e.InsId).HasColumnName("Ins_Id");

                entity.Property(e => e.CrsId).HasColumnName("Crs_Id");

                entity.Property(e => e.Evaluation).HasMaxLength(50);

                entity.HasOne(d => d.Crs)
                    .WithMany(p => p.InsCourses)
                    .HasForeignKey(d => d.CrsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ins_Course_Course");

                entity.HasOne(d => d.Ins)
                    .WithMany(p => p.InsCourses)
                    .HasForeignKey(d => d.InsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ins_Course_Instructor");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.HasKey(e => e.InsId);

                entity.ToTable("Instructor");

                entity.Property(e => e.InsId)
                    .ValueGeneratedNever()
                    .HasColumnName("Ins_Id");

                entity.Property(e => e.DeptId).HasColumnName("Dept_Id");

                entity.Property(e => e.InsDegree)
                    .HasMaxLength(50)
                    .HasColumnName("Ins_Degree");

                entity.Property(e => e.InsName)
                    .HasMaxLength(50)
                    .HasColumnName("Ins_Name");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Instructors)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK_Instructor_Department");
            });

            modelBuilder.Entity<LDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("L_Data");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Notes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ServerUserName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Server User Name");
            });

            modelBuilder.Entity<Ldatum1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LData");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Notes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ServerUserName)
                    .HasMaxLength(1)
                    .HasColumnName("Server User Name");
            });

            modelBuilder.Entity<StudCourse>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.StId });

                entity.ToTable("Stud_Course");

                entity.Property(e => e.CrsId).HasColumnName("Crs_Id");

                entity.Property(e => e.StId).HasColumnName("St_Id");

                entity.HasOne(d => d.Crs)
                    .WithMany(p => p.StudCourses)
                    .HasForeignKey(d => d.CrsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stud_Course_Course");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StId);

                entity.ToTable("Student");

                entity.Property(e => e.StId)
                    .ValueGeneratedNever()
                    .HasColumnName("St_Id");

                entity.Property(e => e.Cv)
                    .HasMaxLength(150)
                    .HasColumnName("CV")
                    .IsFixedLength(true);

                entity.Property(e => e.DeptId).HasColumnName("Dept_Id");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Photo)
                    .HasMaxLength(50)
                    .HasColumnName("photo");

                entity.Property(e => e.StAddress)
                    .HasMaxLength(100)
                    .HasColumnName("St_Address");

                entity.Property(e => e.StAge).HasColumnName("St_Age");

                entity.Property(e => e.StFname)
                    .HasMaxLength(50)
                    .HasColumnName("St_Fname");

                entity.Property(e => e.StLname)
                    .HasMaxLength(10)
                    .HasColumnName("St_Lname")
                    .IsFixedLength(true);

                entity.Property(e => e.StSuper).HasColumnName("St_super");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Student_Department");

                entity.HasOne(d => d.StSuperNavigation)
                    .WithMany(p => p.InverseStSuperNavigation)
                    .HasForeignKey(d => d.StSuper)
                    .HasConstraintName("FK_Student_Student1");
            });

            modelBuilder.Entity<StudentAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Student__Audit");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Notes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ServerUserName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Server User Name");
            });

            modelBuilder.Entity<StudentAudit1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Student_Audit");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Notes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ServerUserName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Server User Name");
            });

            modelBuilder.Entity<StudentsAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Students_Audit");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Notes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ServerUserName)
                    .HasMaxLength(1)
                    .HasColumnName("Server User Name");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.HasKey(e => e.TopId);

                entity.ToTable("Topic");

                entity.Property(e => e.TopId)
                    .ValueGeneratedNever()
                    .HasColumnName("Top_Id");

                entity.Property(e => e.TopName)
                    .HasMaxLength(50)
                    .HasColumnName("Top_Name");
            });

            modelBuilder.Entity<V1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V1");

                entity.Property(e => e.DeptId).HasColumnName("Dept_Id");

                entity.Property(e => e.StAddress)
                    .HasMaxLength(100)
                    .HasColumnName("St_Address");

                entity.Property(e => e.StAge).HasColumnName("St_Age");

                entity.Property(e => e.StFname)
                    .HasMaxLength(50)
                    .HasColumnName("St_Fname");

                entity.Property(e => e.StId).HasColumnName("St_Id");

                entity.Property(e => e.StLname)
                    .HasMaxLength(10)
                    .HasColumnName("St_Lname")
                    .IsFixedLength(true);

                entity.Property(e => e.StSuper).HasColumnName("St_super");
            });

            modelBuilder.Entity<Vin>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIns");

                entity.Property(e => e.Dname)
                    .HasMaxLength(50)
                    .HasColumnName("DName");

                entity.Property(e => e.Iname)
                    .HasMaxLength(50)
                    .HasColumnName("IName");
            });

            modelBuilder.Entity<Vmngr>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VMngr");

                entity.Property(e => e.Mname).HasMaxLength(50);

                entity.Property(e => e.Tname).HasMaxLength(50);
            });

            modelBuilder.Entity<Vstud>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vstud");

                entity.Property(e => e.Cname)
                    .HasMaxLength(50)
                    .HasColumnName("cname");

                entity.Property(e => e.Sname)
                    .IsRequired()
                    .HasMaxLength(61)
                    .HasColumnName("sname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
