using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Model.Common
{
    public class AppSession
    {
        public UserInfoSession UserInfo { get; set; }

        public AppSession()
        {
            UserInfo = new UserInfoSession();
        }
    }
}
