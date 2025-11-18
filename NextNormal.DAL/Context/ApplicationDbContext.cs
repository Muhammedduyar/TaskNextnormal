using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextNormal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextNormal.DAL.Context
{
    public class ApplicationDbContext:IdentityDbContext<AppUser,IdentityRole<Guid>,Guid>
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }
    }
}
