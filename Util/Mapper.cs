using CBTBlazor.Models.Response;
using CBTBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.Util
{
    public static class Mapper
    {

        public static QuestionItem Map(this QuestionManagerModel model)
        {
            return new QuestionItem
            {
                DifficultyLevelId = model.DifficultyLevelId,
                SubjectId = model.SubjectId,
                ScoreValue = model.ScoreValue,
                QuestionType = model.QuestionType,
                 Text = model.Text,
                Options = model.Options.Select(u => new Models.Request.QuestionOption { Text = u.Text, IsAnswer = u.IsAnswer }).ToList(),

            };
        }

        public static QuestionManagerModel Map(this QuestionItem model)
        {
            return new QuestionManagerModel
            {
                DifficultyLevelId = model.DifficultyLevelId,
                SubjectId = model.SubjectId,
                ScoreValue = model.ScoreValue,
                QuestionType = model.QuestionType,
                Text = model.Text,
             //   Options = model.Options.Select(u => new Models.Request.QuestionOption { Text = u.Text, IsAnswer = u.IsAnswer }).ToList(),

            };
        }

        public static QuestionItem Map(this QuestionModel model)
        {
            return new QuestionItem
            {
                DifficultyLevelId = model.DifficultyLevelId,
                SubjectId = model.SubjectId,
                ScoreValue = model.ScoreValue,
                QuestionType = model.QuestionType,
                Text = model.Text,
                Options = model.Options.Select(u => new Models.Request.QuestionOption { Text = u.Text, IsAnswer = u.IsAnswer }).ToList(),
                 Id = model.Id,
            };
        }

    }
}
