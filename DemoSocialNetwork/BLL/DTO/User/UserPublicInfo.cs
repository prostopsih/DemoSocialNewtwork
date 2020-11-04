using BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.User
{
    public class UserPublicInfo : BaseNotifyPropertyChanged
    {
        private string userName;
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                Notify();
            }
        }
    }
}
