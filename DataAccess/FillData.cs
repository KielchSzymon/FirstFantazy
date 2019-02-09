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
            FirstFantasyDBContextFactory dbFactory = new FirstFantasyDBContextFactory();

            using (var db = dbFactory.CreateDbContext(null))
            {
                List<LevelText> LevelText = new List<LevelText>()
                {
                    new LevelText
                    {
                        LineColor = "White",
                        StoryLevel = 1,
                        LevelNumber = 0,
                        StoryText = "Budzisz się jedyne co pamiętasz to, że masz na imię {0}"
                    }
                    ,new LevelText
                    {
                        LineColor = "Orange",
                        StoryLevel = 2,
                        LevelNumber = 0,
                        StoryText = "test2"
                    }
                };

                db.LevelText.AddRange(LevelText);
                db.SaveChanges();
            }
        }
    }
}
