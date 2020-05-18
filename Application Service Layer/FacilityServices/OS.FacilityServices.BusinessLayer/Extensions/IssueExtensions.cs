﻿using FacilityServices.BusinessLayer.Domain;
using OS.Common.FacilityServices.Exceptions;
using OS.Common.FacilityServices.TransfertObjects;

namespace FacilityServices.BusinessLayer.Extensions
{
    public static class IssueExtensions
    {
        public static Issue ToDomain(this IssueTO IssueTO)
        {
            if (IssueTO is null)
                throw new NullIssueException(nameof(IssueTO));

            return new Issue(IssueTO.Name)
            {
                Id = IssueTO.Id,
                Description = IssueTO.Description,
                Archived = IssueTO.Archived,
                ComponentType = IssueTO.ComponentType.ToDomain(),
                Name = IssueTO.Name,
            };
        }
        public static IssueTO ToTransfertObject(this Issue Issue)
        {
            if (Issue is null)
                throw new NullIssueException(nameof(Issue));

            return new IssueTO()
            {
                Id = Issue.Id,
                Name = Issue.Name,
                Description = Issue.Description,
                Archived = Issue.Archived,
                ComponentType = Issue.ComponentType.ToTransfertObject(),
            };
        }
    }
}
