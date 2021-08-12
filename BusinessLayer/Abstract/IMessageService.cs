using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInBox(string p);
        List<Message> GetListSendBox(string p);
        void Add(Message message);
        void Delete(Message message);
        void Remove(Message message);
        Message GetById(int messageId);
        void Update(Message message);
    }
}
