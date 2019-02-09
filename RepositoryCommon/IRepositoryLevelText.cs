using System;

namespace RepositoryCommon
{
    public interface IRepositoryLevelText
    {
        string GetLevelText(int level, int storyLevel);
        bool UpdateLevelText(int Id);
        bool DeleteLevelText(int Id);
        bool InsertLevelText();
    }
}
