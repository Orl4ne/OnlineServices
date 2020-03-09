using OS.AssessementServices.DataLayer.Entities;
using OS.Common.AssessementServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;
using OS.Common.TranslationServices.TransfertObjects;
using OS.Common.AssessementServices.Enumerations;
using System.Linq;
using OS.Common.Extensions;

using OS.AssessementServices.DataLayer.Extensions;

namespace OS.AssessementServices.DataLayer.Extensions
{
    public static class QuestionExtensions
    {
        public static QuestionTO ToTransfertObject(this QuestionEF question)
        {
            if (question is null)
                throw new ArgumentNullException(nameof(question));

            var questionTO = new QuestionTO
            {
                Id = question.Id,
                Libelle = new MultiLanguageString(question.NameEnglish, question.NameFrench, question.NameDutch),
                FormId = question.Form.Id,
                Position = question.Position,
                Type = question.Type,
                Propositions = question.Propositions?.Select(x => x.ToTransfertObject()).ToList(),
            };

            return questionTO;
        }

        public static QuestionEF ToEF(this QuestionTO question)
        {
            if (question is null)
                throw new ArgumentNullException(nameof(question));

            var q = new QuestionEF();
            q.Id = question.Id;
            q.NameEnglish = question.Libelle.English;
            q.NameFrench = question.Libelle.French;
            q.NameDutch = question.Libelle.Dutch;
            q.Position = question.Position;
            q.Type = question.Type;
            //q.Form.Id = question.FormId;

            if (question.Propositions != null)
            {
                q.Propositions = question.Propositions.Select(x => x.ToEF()).ToList();
                q.Propositions.Select(x => x.Question = q);
            }

            return q;
        }
    }
}