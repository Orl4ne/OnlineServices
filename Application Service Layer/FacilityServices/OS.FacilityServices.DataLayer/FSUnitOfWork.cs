﻿using FacilityServices.DataLayer.Repositories;
using OS.Common.FacilityServices.Interfaces;
using OS.Common.FacilityServices.Interfaces.Repositories;
using System;

namespace FacilityServices.DataLayer
{
    public class FSUnitOfWork : IFSUnitOfWork

    {
        private readonly FacilityContext facilityContext;

        public FSUnitOfWork(FacilityContext context)
        {
            this.facilityContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        private IComponentTypeRepository componentTypeRepository;
        public IComponentTypeRepository ComponentTypeRepository
            => componentTypeRepository ??= new ComponentTypeRepository(facilityContext);

        private ICommentRepository commentRepository;
        public ICommentRepository CommentRepository
            => commentRepository ??= new CommentRepository(facilityContext);

        private IFloorRepository floorRepository;
        public IFloorRepository FloorRepository
            => floorRepository ??= new FloorRepository(facilityContext);

        private IIssueRepository issueRepository;
        public IIssueRepository IssueRepository
             => issueRepository ??= new IssueRepository(facilityContext);

        private IRoomRepository roomRepository;
        public IRoomRepository RoomRepository
            => roomRepository ??= new RoomRepository(facilityContext);

        private IIncidentRepository incidentRepository;
        public IIncidentRepository IncidentRepository
            => incidentRepository ??= new IncidentRepository(facilityContext);

        public void Save()
        {
            facilityContext.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    facilityContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
