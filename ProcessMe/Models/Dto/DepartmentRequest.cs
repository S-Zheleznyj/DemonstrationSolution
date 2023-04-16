using ProcessMe.Infrastructure.Enums;
using ProcessMe.Models.Entities;

namespace ProcessMe.Models.Dto
{
    public class DepartmentRequest
    {
        public DepartmentType Type { get; private set; }
    }
}
