﻿using OS.AssessementServices.DataLayer.Repositories;
using OS.Common.AssessementServices.Interfaces;
using OS.Common.AssessementServices.Interfaces.Repositories;
using System;

namespace OS.AssessementServices.DataLayer
{
	public class ESUnitOfWork : IASSUnitOfWork, IDisposable
	{
		private readonly EvaluationContext evaluationContext;

		private IFormRepository formRepository;
		private IQuestionRepository questionRepository;
		private IQuestionPropositionRepository questionPropositionRepository;

		private IResponseRepository responseRepository;
		private ISubmissionRepository submissionRepository;
		private ICommentRepository commentRepository;

		private bool disposed = false;

		public ESUnitOfWork(EvaluationContext evaluationContext)
		{
			this.evaluationContext = evaluationContext ?? throw new ArgumentNullException(nameof(evaluationContext));
		}

		public IFormRepository FormRepository => formRepository = new FormRepository(evaluationContext);
		public IQuestionRepository QuestionRepository => questionRepository = new QuestionRepository(evaluationContext);
		public IQuestionPropositionRepository QuestionPropositionRepository
			=> questionPropositionRepository = new QuestionPropositionRepository(evaluationContext);

		public IResponseRepository ResponseRepository => responseRepository = new ResponseRepository(evaluationContext);
		public ISubmissionRepository SubmissionRepository => submissionRepository = new SubmissionRepository(evaluationContext);
		public ICommentRepository CommentRepository => commentRepository = new CommentRepository(evaluationContext);

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)

				{
					evaluationContext.Dispose();
				}
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public int SaveChanges()
		{
			return evaluationContext.SaveChanges();
		}
	}
}
