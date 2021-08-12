using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Update(message);
        }

        public Message GetById(int messageId)
        {
            return _messageDal.Get(x => x.MessageId == messageId);
        }


        public List<Message> GetListInBox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p); //alıcısı p olan mesajları listele.gelen mesaj
        }

        public List<Message> GetListSendBox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p); //gönderen
        }

        public void Remove(Message message)
        {
            _messageDal.Remove(message);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
