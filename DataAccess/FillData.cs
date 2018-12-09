using DataAcces;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccess
{
    public class FillData
    {
        public static void Main()
        {
            IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();


            var optionsBuilder = new DbContextOptionsBuilder<FirstFantasyDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("FirstFantasyDBConnection"));

            using (var db = new FirstFantasyDBContext(optionsBuilder.Options))
            {
                List<LevelText> LevelsTexts = new List<LevelText>()
                {
                    new LevelText
                    {
                        LineColor = "Red",
                        StoryLevel = 1,
                        StoryText = "test"
                    }
                    ,new LevelText
                    {
                        LineColor = "Orange",
                        StoryLevel = 2,
                        StoryText = "test2"
                    }
                };



                LevelsTexts.Add(new LevelText()
               );

                db.LevelsTexts.AddRange(LevelsTexts);
                db.SaveChanges();
            }
        }
    }
}
