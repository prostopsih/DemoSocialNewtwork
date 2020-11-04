using BLL.DTO.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    internal class LoginnedUser
    {
        public int UserId { get; private set; }
        public UserPublicInfo UserPublicInfo { get; private set; }

        private LoginnedUser()
        {

        }


        public static void Clear()
        {
            loginnedUser = null;
        }
        public static void CreateNewOne(int userId, UserPublicInfo userPublicInfo)
        {
            loginnedUser = new LoginnedUser 
            { 
                UserId = userId, 
                UserPublicInfo = new UserPublicInfo 
                { 
                    UserName = userPublicInfo.UserName
                } 
            };
        }
        private static LoginnedUser loginnedUser;
        public static LoginnedUser LoggedUser => loginnedUser;
    }
}
