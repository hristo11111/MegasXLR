using CrowdSourcedNews.Data;
using CrowdSourcedNews.Data.Migrations;
using CrowdSourcedNews.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CrowdSourcedNewsContext, Configuration>());

            CrowdSourcedNewsContext con = new CrowdSourcedNewsContext();

            User user = new User()
            {
                Username = "Name1",
                Nickname = "nickname1",
                AuthCode = "123",
                SessionKey = "456"
            };

            con.Users.Add(user);
            con.SaveChanges();

        }
    }
}
