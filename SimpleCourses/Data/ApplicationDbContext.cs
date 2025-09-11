using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleCourses.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCourses.Data
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(250)]
        public string FirstName { get; set; }
        [StringLength(250)]
        public string LastName { get; set; }
        [StringLength(250)]
        public string Address1 { get; set; }
        [StringLength(250)]
        public string Address2 { get; set; }
        [StringLength(50)]
        public string Postcode { get; set; }

        [ForeignKey("UserId")]
        public virtual ICollection<UserCategory> UserCategories { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryItem> CategoryItems { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<Content> Contents { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
