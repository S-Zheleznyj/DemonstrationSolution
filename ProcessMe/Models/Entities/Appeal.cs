using ProcessMe.Infrastructure.Enums;
using ProcessMe.Models.Dto;

namespace ProcessMe.Models.Entities
{
    /// <summary> Заявка на обратную связь</summary>
    public class Appeal : EntityBase
    {
        public string ClientName { get; private set; }
        public string ClientPhone { get; private set; }
        public string ClientEmail { get; private set; }
        public string Description { get; private set; }
        public CommunicationType? CommunicationWay { get; private set; }
        public DateTime RecieveDate { get; private set; }
        public DateTime? StartProcessDate { get; private set; }
        public DateTime? EndProcessDate { get; private set; }
        public Guid? EmoloyeeId { get; private set; }
        public Employee Employee { get; private set; }
        public Appeal() { }

        public Appeal(AppealRequest appealRequest)
        {
            Id = Guid.NewGuid();
            ClientName = appealRequest.ClientName;
            ClientPhone = appealRequest.ClientPhone;
            ClientEmail = appealRequest.ClientEmail;
            Description = appealRequest.Description;
            CommunicationWay = appealRequest.CommunicationWay;
            RecieveDate = DateTime.UtcNow;
        }

        internal static Appeal FromAppealRequest(AppealRequest appealRequest)
        {
            return new Appeal(appealRequest);
        }
    }
}
