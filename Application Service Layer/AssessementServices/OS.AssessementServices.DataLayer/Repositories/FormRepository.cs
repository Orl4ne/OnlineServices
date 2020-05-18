using System;
using System.Collections.Generic;
using OS.Common.DataAccessHelpers;
using OS.Common.AssessementServices.TransfertObjects;
using System.Linq;
using OS.AssessementServices.DataLayer.Extensions;
using OS.Common.AssessementServices.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace OS.AssessementServices.DataLayer.Repositories
{
    public class FormRepository : IFormRepository
    {
        // Context
        private readonly EvaluationContext evaluationContext;

        // Constructeur
        public FormRepository(EvaluationContext context)
        {
            evaluationContext = context ?? throw new ArgumentNullException($"{nameof(context)}in EvaluationRepository");
        }

        public FormTO Add(FormTO Entity)
        {
            if (Entity is null)
                throw new ArgumentNullException(nameof(Entity));
            return evaluationContext.Forms
            .Add(Entity.ToEF())
            .Entity
            .ToTransfertObject();
        }
	
        public IEnumerable<FormTO> GetAll()
        {
            return evaluationContext.Forms
                .Include(f => f.Questions)
                .ThenInclude(q => q.Propositions)
                .Select(f => f.ToTransfertObject())
                .ToList();
        }

        public FormTO GetById(int Id)
        {
            return evaluationContext.Forms
                .Include(f=>f.Questions)
                .ThenInclude(q=>q.Propositions)
                .FirstOrDefault(f => f.Id == Id)
                .ToTransfertObject();
        }

        public bool Remove(FormTO entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            return Remove(entity.Id);
        }

        public bool Remove(int Id)
        {
            var toRemove = evaluationContext
                .Forms
                .FirstOrDefault(f => f.Id == Id);

            var removed = evaluationContext
                .Forms
                .Remove(toRemove);

            return removed.State == EntityState.Deleted;
        }
        public FormTO Update(FormTO Entity)
        {
            if (Entity is null)
                throw new Exception();

            return evaluationContext
                .Forms
                .Update(Entity.ToEF())
                .Entity
                .ToTransfertObject();
        }
    }
}
