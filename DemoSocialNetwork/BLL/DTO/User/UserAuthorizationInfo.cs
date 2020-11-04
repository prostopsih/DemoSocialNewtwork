using BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.User
{
    public class UserAuthorizationInfo : BaseNotifyPropertyChanged
    {
        private string login;
        private string password;
        public string Login
        {
            get => login;
            set
            {
                login = value;
                Notify();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                Notify();
            }
        }
    }
}
