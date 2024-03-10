using LMS_WEBAPI_NETCORE_REACT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem_Using_NETCoreWebAPI.Data
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(250)]
        public string FirstName { get; set; }
        [StringLength(250)]
        public string Lastname { get; set; }
        [StringLength(250)]
        public string Address1 { get; set; }
        [StringLength(250)]
        public string Address2 { get; set; }
        [StringLength(10)]
        public string Postcode { get; set; }

        [ForeignKey("UserId")]
        public ICollection<UserCategory> UserCategory { get; set; }
    }
    public class DataContext : IdentityDbContext<IdentityUser>
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryItem> CategoryItem { get; set; }
        public DbSet<UserCategory> UserCategory { get; set; }

        public DbSet<MediaType> MediaType { get; set; }

        public DbSet<Content> Content { get; set; }
    }
}
