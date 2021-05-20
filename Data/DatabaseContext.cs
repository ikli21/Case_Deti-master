using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Case_Deti.Data
{
    /// <summary>
    /// TODO: разделить на файлы для удобства
    /// </summary>
    #region DB
    public class DetiContext : DbContext
    {

        public DetiContext(DbContextOptions<DetiContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseSkills>()
                .HasKey(cs => new { cs.CourseID, cs.SkillID });

            modelBuilder.Entity<ProfessionCategory>()
                .HasKey(pc => new { pc.ProfessionID, pc.CategoryID });

            modelBuilder.Entity<ProfessionCourse>()
                .HasKey(pc => new { pc.ProfessionID, pc.CourseID });

            modelBuilder.Entity<UserAchievements>()
                .HasKey(ua => new { ua.UserID, ua.AchievementID });

            modelBuilder.Entity<Schedule>()
                .HasOne<Course>(s => s.Course)
                .WithMany(c => c.ScheduleList)
                .HasForeignKey(s => s.CourseID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<ProfessionCategory> ProfessionCategories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ProfessionCourse> ProfessionCourses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CourseSkills> CourseSkills { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<UserAchievements> UserAchievements { get; set; }
    }
    #endregion

    #region Profile
    public class User
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public byte[] Password { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Role Role { get; set; }
        public IList<UserAchievements> UserAchievements { get; set; }
    }

    public enum Role
    {
        Admin,
        User
    }

    public class Achievement
    {
        public int AchievementID { get; set; }
        public string Title { get; set; }
        public IList<UserAchievements> UserAchievements { get; set; }
        public string ImgURL { get; set; }
    }
    public class UserAchievements
    {
        public int AchievementID { get; set; }
        public Achievement Achievement { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
    #endregion

    #region Uncat
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string ImgURL { get; set; }
        public IList<ProfessionCategory> CategoryProfessions { get; set; }
    }

    public class Profession
    {
        public int ProfessionID { get; set; }
        public string Name { get; set; }
        public string ImgURL { get; set; }
        public IList<ProfessionCategory> CategoryProfessions { get; set; }
        public IList<ProfessionCourse> ProfessionCourses { get; set; }
    }

    public class ProfessionCategory
    {
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int ProfessionID { get; set; }
        public Profession Profession { get; set; }
    }

    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Address { get; set; }
        public string DifficultyLevel { get; set; }
        public IList<ProfessionCourse> ProfessionCourses { get; set; }
        public IList<CourseSkills> CourseSkills { get; set; }
        public IList<Schedule> ScheduleList { get; set; }
        public string ApproxTime { get; set; }
        public string ImgURL { get; set; }
    }

    public class ProfessionCourse
    {
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public int ProfessionID { get; set; }
        public Profession Profession { get; set; }
    }
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public string Time { get; set; }
        public string Marker { get; set; }
    }

    public class Skill
    {
        public int SkillID { get; set; }
        public string Name { get; set; }
        public IList<CourseSkills> CourseSkills { get; set; }
    }

    public class CourseSkills
    {
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public int SkillID { get; set; }
        public Skill Skill { get; set; }
    }
    #endregion
}
