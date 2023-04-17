using ProcessMe.Infrastructure.Enums;

namespace ProcessMe.Models.DTOs.Incoming
{
    public class AppealForCreationDto
    {
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string ClientEmail { get; set; }
        public string Description { get; set; }
        public CommunicationType? CommunicationWay { get; set; }
    }
}
