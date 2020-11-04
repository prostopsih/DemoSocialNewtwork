using BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Post
{
    public class PostDTO : BaseNotifyPropertyChanged, IDTO
    {
        private int id;
        private string header;
        private string text;
        public int Id
        {
            get => id;
            set
            {
                id = value;
                Notify();
            }
        }
        public string Header
        {
            get => header;
            set
            {
                header = value;
                Notify();
            }
        }
        public string Text
        {
            get => text;
            set
            {
                text = value;
                Notify();
            }
        }
    }
}
