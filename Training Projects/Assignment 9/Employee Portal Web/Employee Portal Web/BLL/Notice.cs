using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Notice
    {
        int _noticeId;
        string _title;
        string _description;
        DateTime _startDate;
        DateTime _expirationDate;
        int _postedById;
        string _postedByName;

        public int NoticeId
        {
            get { return _noticeId; }
            set { _noticeId = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set { _expirationDate = value; }
        }

        public int PostedById
        {
            get { return _postedById; }
            set { _postedById = value; }
        }

        public string PostedByName
        {
            get { return _postedByName; }
            set { _postedByName = value; }
        }

        public static Notice GetNotice(int noticeId)
        {
            if (noticeId > 0)
            {
                Notice notice = new Notice();
                notice.Fetch(noticeId);
                return notice;
            }
            else
            {
                return NewNotice();
            }
        }

        public static Notice NewNotice()
        {
            Notice notice = new Notice();
            notice.StartDate = DateTime.Now.Date;
            notice.ExpirationDate = DateTime.Now.Date;
            return notice;
        }

        public static void UpdateNotice(Notice notice)
        {
            notice.Save();
        }

        public static void InsertNotice(Notice notice)
        {
            notice.Save();
        }

        internal static Notice GetNotice(NoticeManager.Notice noticeData)
        {
            Notice notice = new Notice();
            notice._noticeId = noticeData.NoticeId;
            notice._title = noticeData.Title;
            notice._description = noticeData.Description;
            notice._startDate = noticeData.StartDate;
            notice._expirationDate = noticeData.ExpirationDate;
            notice._postedById = noticeData.PostedById;
            notice._postedByName = noticeData.PostedByName;
            return notice;
        }

        public void Save()
        {
            if (_noticeId > 0)
                Update();
            else
                Insert();
        }

        public static void DeleteNotice(int noticeId)
        {
            NoticeManager.DeleteNotice(noticeId);
        }

        public Notice()
        {
        }

        private void Fetch(int noticeId)
        {
            NoticeManager.Notice noticeData = NoticeManager.GetNotice(noticeId);

            _noticeId = noticeData.NoticeId;
            _title = noticeData.Title;
            _description = noticeData.Description;
            _startDate = noticeData.StartDate;
            _expirationDate = noticeData.ExpirationDate;
            _postedById = noticeData.PostedById;
            _postedByName = noticeData.PostedByName;
        }

        private void Insert()
        {
            NoticeManager.Notice noticeData = new NoticeManager.Notice();

            noticeData.Title = _title;
            noticeData.Description = _description;
            noticeData.StartDate = _startDate;
            noticeData.ExpirationDate = _expirationDate;
            noticeData.PostedById = _postedById;

            noticeData = NoticeManager.InsertNotice(noticeData);

            _noticeId = noticeData.NoticeId;
        }

        private void Update()
        {
            NoticeManager.Notice noticeData = new NoticeManager.Notice();

            noticeData.NoticeId = _noticeId;
            noticeData.Title = _title;
            noticeData.Description = _description;
            noticeData.StartDate = _startDate;
            noticeData.ExpirationDate = _expirationDate;
            noticeData.PostedById = _postedById;

            NoticeManager.UpdateNotice(noticeData);
        }
    }
}
