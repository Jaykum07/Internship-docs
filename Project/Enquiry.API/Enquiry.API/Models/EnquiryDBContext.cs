using Microsoft.EntityFrameworkCore;

namespace Enquiry.API.Models
{
    public class EnquiryDBContext : DbContext
    {
        public EnquiryDBContext(DbContextOptions<EnquiryDBContext> opt): base(opt)
        {

        }

        public DbSet<EnquiryMaster> EnquiryMasters { get; set; }

        public DbSet<Services> Services { get; set; }

    }
}
