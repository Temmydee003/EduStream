using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CRUDApplication.Areas.Identity.Data;

// Add profile data for application users by adding properties to the CRUDApplicationUser class
public class CRUDApplicationUser : IdentityUser
{
    // adding two columns to the database to ask the admin when registering
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }
}

