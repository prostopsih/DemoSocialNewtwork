using BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.User
{
    public class UserDTO : BaseNotifyPropertyChanged
    {
        private UserPublicInfo userPublicInfo;
        private UserAuthorizationInfo userAuthorizationInfo;
        public UserPublicInfo UserPublicInfo
        {
            get => userPublicInfo;
            set
            {
                userPublicInfo = value;
                Notify();
            }
        }
        public UserAuthorizationInfo UserAuthorizationInfo
        {
            get => userAuthorizationInfo;
            set
            {
                userAuthorizationInfo = value;
                Notify();
            }
        }
    }
}
