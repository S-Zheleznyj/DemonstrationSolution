using ProcessMe.Infrastructure.Enums;
using ProcessMe.Models.Entities;

namespace ProcessMe.Models.Dto
{
    public class AppealRequest
    {
        public string ClientName { get; private set; }
        public string ClientPhone { get; private set; }
        public string ClientEmail { get; private set; }
        public string Description { get; private set; }
        public CommunicationType? CommunicationWay { get; private set; }
    }
}
