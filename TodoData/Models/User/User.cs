using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoData.Models.User
{
    public class User
    {
        public virtual long Id { get; set; }

        public virtual string Email { get; set; }

        [JsonIgnore]
        public virtual string Password { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual int UserType { get; set; }

        public virtual long UserInfoId { get; set; }

        public virtual int AccountPlan { get; set; }

        public virtual DateTime Registration { get; set; }

        public virtual DateTime LastUpdate { get; set; }
    }
}
