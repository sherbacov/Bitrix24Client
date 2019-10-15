using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitrix24.Requests
{
    public class BitrixLead : IBitrixEntity
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string Comments { get; set; }
        public string StatusId { get; set; }
        public int AssignedById { get; set; }
        public string PhoneMobile { get; set; }
        public string EmailWork { get; set; }

        public Dictionary<string, string> ToDictionary()
        {
            return new Dictionary<string, string>
            {
                { "TITLE", Title },
                { "NAME", Name },
                { "LAST_NAME", LastName },
                { "SECOND_NAME", SecondName },
                { "COMMENTS", Comments },
                { "STATUS_ID", StatusId },
                { "ASSIGNED_BY_ID", AssignedById.ToString() },
                { "PHONE_MOBILE", PhoneMobile },
                { "EMAIL_WORK", EmailWork }
            };
        }

        public string GetMethod()
        {
            return "/crm/configs/import/lead.php";
        }
    }
}
