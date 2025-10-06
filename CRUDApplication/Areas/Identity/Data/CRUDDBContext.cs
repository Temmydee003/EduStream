using CRUDApplication.Areas.Identity.Data;
using CRUDApplication.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRUDApplication.Data;

public class CRUDDBContext : IdentityDbContext<CRUDApplicationUser>
{
    public CRUDDBContext(DbContextOptions<CRUDDBContext> options)
        : base(options)
    {
    }

    // Calling the table column and giving the table a name "FnsStudentsRecord"
    public DbSet<StudentsRecord> FnsStudentsRecord { get; set; } // name of model is in <>, while the name after is the database name

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
