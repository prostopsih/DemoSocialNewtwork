using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using BLL.Infrastructure;

namespace BLL.DTO.Avatar
{
    public class AvatarDTO : BaseNotifyPropertyChanged, IDTO
    {
        private int id;
        private string signature;
        private Image image;
        public int Id
        {
            get => id;
            set
            {
                id = value;
                Notify();
            }
        }
        public string Signature
        {
            get => signature;
            set
            {
                signature = value;
                Notify();
            }
        }
        public Image Image
        {
            get => image;
            set
            {
                image = value;
                Notify();
            }
        }
    }
}
