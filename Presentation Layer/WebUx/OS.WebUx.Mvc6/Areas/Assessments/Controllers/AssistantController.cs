﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OS.Common.EvaluationServices;
using OS.Common.AssessementServices.TransfertObjects;

namespace OS.WebUx.Mvc6.Areas.Assessments.Controllers
{
    [Area("Assessments")]
    public class AssistantController : Controller
    {
        private readonly IASSAssistantRole assistantRole;

        public AssistantController(IASSAssistantRole assistantRole)
        {
            this.assistantRole = assistantRole;
        }

        [HttpGet]
        public IActionResult GetAllForms()
        {
            return View(assistantRole.GetAllForms());
        }

        public IActionResult GetFormById(int id)
        {
            return View(assistantRole.GetFormById(id));
        }

        public IActionResult DeleteFormById(int id)
        {
            var result = assistantRole.RemoveFormById(id);
            return RedirectToAction("GetAllForms");
        }
        [HttpGet]
        public IActionResult AddForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddForm(FormTO form)
        {
            assistantRole.AddForm(form);
            return RedirectToAction("GetAllForms");
        }
        [HttpGet]
        public IActionResult AddQuestion(int id)
        {
            int position = 1;
            if (assistantRole.GetFormById(id).Questions.Count > 0)
            {
                position += assistantRole.GetFormById(id).Questions.Max(q => q.Position);

            }
            var question = new QuestionTO { FormId = id, Position = position };

            return View(question);
        }
        [HttpPost]
        public IActionResult AddQuestion(QuestionTO question)
        {
            assistantRole.AddQuestionByForm(question);
            return RedirectToAction("GetFormById", new { id = question.FormId });
        }

        [HttpGet]
        public IActionResult AddProposition(int id)
        {
            int position = 1;
            if (assistantRole.GetQuestionById(id).Propositions.Count > 0)
            {
                position += assistantRole.GetQuestionById(id).Propositions.Max(q => q.Position);

            }
            var proposition = new QuestionPropositionTO { QuestionId = id, Position = position };

            return View(proposition);
        }

        [HttpPost]
        public IActionResult AddProposition(QuestionPropositionTO proposition)
        {
            assistantRole.AddPropositionByQuestion(proposition);
            return RedirectToAction("GetFormById", new { id = assistantRole.GetQuestionById(proposition.QuestionId).FormId });
        }
        public IActionResult RemovePropositionById(int id)
        {
            var result = assistantRole.RemovePropositionById(id);
            return RedirectToAction("GetAllForms");
        }
        public IActionResult DeleteQuestionById(int id)
        {
            var result = assistantRole.RemoveQuestionById(id);
            return RedirectToAction("GetAllForms");
        }
    }
}