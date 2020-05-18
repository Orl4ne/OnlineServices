﻿using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OS.Common.Exceptions;
using OS.Common.FacilityServices.TransfertObjects;
using OS.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FacilityServices.DataLayerTests.RepositoriesTests.IssueRepositoryTests
{
    [TestClass]
    public class UpdateIssuesTests
    {
        [TestMethod]
        public void UpdateIssueByTransfertObject_Successfull()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                   .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                   .Options;

            using (var memoryCtx = new FacilityContext(options))
            {
                var componentTypeRepository = new ComponentTypeRepository(memoryCtx);

                var componentType = new ComponentTypeTO
                {
                    Archived = false,
                    Name = new MultiLanguageString("Name1En", "Name1Fr", "Name1Nl"),
                };
                var componentType2 = new ComponentTypeTO
                {
                    Archived = false,
                    Name = new MultiLanguageString("Name2En", "Name2Fr", "Name2Nl"),
                };
                var addedComponentType1 = componentTypeRepository.Add(componentType);
                var addedComponentType2 = componentTypeRepository.Add(componentType2);
                memoryCtx.SaveChanges();

                var IssueToUseInTest = new IssueTO
                {
                    Description = "prout",
                    Name = new MultiLanguageString("Issue1EN", "Issue1FR", "Issue1NL"),
                    ComponentType = addedComponentType1,


                };
                var IssueToUseInTest2 = new IssueTO
                {
                    Description = "proutprout",
                    Name = new MultiLanguageString("Issue2EN", "Issue2FR", "Issue2NL"),
                    ComponentType = addedComponentType1,
                };
                var IssueToUseInTest3 = new IssueTO
                {
                    Description = "proutproutprout",
                    Name = new MultiLanguageString("Issue3EN", "Issue3FR", "Issue3NL"),
                    ComponentType = addedComponentType2,
                };
                var issueRepository = new IssueRepository(memoryCtx);

                var f1 = issueRepository.Add(IssueToUseInTest);
                var f2 = issueRepository.Add(IssueToUseInTest2);
                memoryCtx.SaveChanges();
                f2.Description = "PASProut";
                issueRepository.Update(f2);

                Assert.AreEqual(2, issueRepository.GetAll().Count());
                Assert.AreEqual("PASProut", f2.Description);
            }
        }

        [TestMethod]
        public void UpdateIssueByTransfertObject_ThrowException_WhenUnexistingIssueIsSupplied()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FacilityContext>()
                   .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                   .Options;

            using var memoryCtx = new FacilityContext(options);
            var issueRepository = new IssueRepository(memoryCtx);
            var issue = new IssueTO { Id = 999 };

            //ACT & ASSERT
            Assert.ThrowsException<LoggedException>(() => issueRepository.Update(issue));
        }
    }
}
