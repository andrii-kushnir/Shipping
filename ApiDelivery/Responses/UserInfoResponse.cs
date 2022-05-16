using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDelivery.Responses
{
    public class UserInfoResponse : BaseResponse
    {
        public UserInfo data { get; set; }
    }

    public class UserInfo
    {
        public int Id { get; set; }
        public string AccessLevel { get; set; }
        public string UserName { get; set; }
        public int SmsPhoneNumber { get; set; }
        public bool ClientType { get; set; }
        public string ClientNumber { get; set; }
        public int PhoneNumber { get; set; }
        public string CrmUserId { get; set; }
        public string Email { get; set; }
        public object showHelpHide { get; set; }
        public object Photo { get; set; }
        public string RoleName { get; set; }
        public bool IsLoyaltyProgram { get; set; }
        public int AvailablePoints { get; set; }
        public int CurrentPoints { get; set; }
        public string City { get; set; }
        public string ConfirmedPhone { get; set; }
    }

}
