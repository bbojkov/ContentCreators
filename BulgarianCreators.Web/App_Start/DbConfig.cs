using BulgarianCreators.Data;
using BulgarianCreators.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BulgarianCreators.Web.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CreatorsDbContext, Configuration>());
            CreatorsDbContext.Create().Database.CreateIfNotExists();
        }
    }
}