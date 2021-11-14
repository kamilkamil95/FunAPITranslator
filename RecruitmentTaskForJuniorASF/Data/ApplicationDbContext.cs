using Microsoft.EntityFrameworkCore;
using RecruitmentTaskForJuniorASF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTaskForJuniorASF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            NLogCommunicator.Info("Database call");
        }
        public DbSet<TranslationRequestModel> TranslationRequests { get; set; }
        public DbSet<LanguageModel> Languages { get; set; }
       
    }
}
