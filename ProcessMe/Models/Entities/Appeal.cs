using ProcessMe.Infrastructure.Enums;
using ProcessMe.Models.DTOs.Incoming;

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
        public Guid? EmployeeId { get; private set; }
        public Employee Employee { get; set; }
        public Appeal() { }

        public Appeal(AppealForCreationDto appealRequest)
        {
            //Id = Guid.NewGuid();
            ClientName = appealRequest.ClientName;
            ClientPhone = appealRequest.ClientPhone;
            ClientEmail = appealRequest.ClientEmail;
            Description = appealRequest.Description;
            CommunicationWay = appealRequest.CommunicationWay;
            RecieveDate = DateTime.UtcNow;
        }

        internal static Appeal FromAppealRequest(AppealForCreationDto appealRequest)
        {
            Appeal appeal = new(appealRequest);
            appeal.Id = Guid.NewGuid();
            return appeal;
        }
        internal static Appeal FromAppealRequestAndId(Guid id, AppealForCreationDto appealRequest)
        {
            Appeal appeal = new(appealRequest);
            appeal.Id = id;
            return appeal;
        }
    }
}
