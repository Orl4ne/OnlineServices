using OS.Common.FacilityServices.Enumerations;
using OS.Common.FacilityServices.TransfertObjects;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class FSAssistantRole
    {
        public IncidentTO ChangeIncidentStatus(IncidentStatus statusToSubmit, int incidentId)
        {
            var incident = unitOfWork.IncidentRepository.GetById(incidentId);
            incident.Status = statusToSubmit;
            var updatedIncident = unitOfWork.IncidentRepository.Update(incident);

            return updatedIncident;
        }
    }
}