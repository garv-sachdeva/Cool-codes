using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class NoticeList : List<Notice>
    {
        private NoticeList()
        {
        }

        public static NoticeList GetAllNotices()
        {
            NoticeList list = new NoticeList();
            list.FetchAll();
            return list;
        }

        public static NoticeList GetActiveNotices()
        {
            NoticeList list = new NoticeList();
            list.FetchActive();
            return list;
        }

        private void FetchActive()
        {
            List<NoticeManager.Notice> allNotices = NoticeManager.GetAllNotices();

            foreach (var item in allNotices)
            {
                if (item.ExpirationDate > DateTime.Today)
                {
                    Notice notice = Notice.GetNotice(item);
                    this.Add(notice);
                }
            }
            
        }

        private void FetchAll()
        {
            List<NoticeManager.Notice> allNotices = NoticeManager.GetAllNotices();

            foreach (var item in allNotices)
            {
                Notice notice = Notice.GetNotice(item);
                this.Add(notice);
            }
        }
    }
    
}
