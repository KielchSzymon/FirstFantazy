using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryCommon
{
    public class RepositoryLevelText : IRepositoryLevelText
    {
        FirstFantasyDBContext db;

        public RepositoryLevelText(FirstFantasyDBContext db)
        {
            this.db = db;   
        }

        public bool DeleteLevelText(int Id)
        {
            throw new NotImplementedException();
        }

        public string GetLevelText(int level, int storyLevel)
        {
           
           var text = db.LevelText.Where(x => x.LevelNumber == level 
            && x.StoryLevel == storyLevel).Select(x => x.StoryText).First();

            return text.ToString();
        }

        public bool InsertLevelText()
        {
            throw new NotImplementedException();
        }

        public bool UpdateLevelText(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
