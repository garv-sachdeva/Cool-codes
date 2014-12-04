using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BLL
{
    public class Issue
    {
        public Issue()
        {
        }
        int _issueId;
        string _title;
        string _description;
        DateTime _datePosted;
        int _postedBy;
        int _assignedTo;
        short _status;
        string _statusName;
        short _priority;
        string _employeeName;
        string _comments;

        public int IssueId
        {
            get { return _issueId; }
            set { _issueId = value; }
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

        public DateTime DatePosted
        {
            get { return _datePosted; }
            set { _datePosted = value; }
        }

        public int PostedBy
        {
            get { return _postedBy; }
            set { _postedBy = value; }
        }

        public int AssignedTo
        {
            get { return _assignedTo; }
            set { _assignedTo = value; }
        }

        public short Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string StatusName
        {
            get { return _statusName; }
            set { _statusName = value; }
        }

        public short Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public static Issue GetIssue(int issueId)
        {
            if (issueId > 0)
            {
                Issue issue = new Issue();
                issue.Fetch(issueId);
                return issue;
            }
            else
            {
                return NewIssue();
            }
        }

        private void Fetch(int issueId)
        {
            IssueManager.Issue issueData = IssueManager.GetIssue(issueId);
            _assignedTo = issueData.AssignedTo;
            _datePosted = issueData.DatePosted;
            _description = issueData.Description;
            _issueId = issueData.IssueId;
            _postedBy = issueData.PostedBy;
            _priority = issueData.Priority;
            _status = issueData.Status;
            _statusName = issueData.StatusName;
            _title = issueData.Title;
            _employeeName = issueData.EmployeeName;
        }
        internal static Issue GetIssue(IssueManager.Issue issueData)
        {
            Issue issue = new Issue();
            issue._assignedTo = issueData.AssignedTo;
            issue._datePosted = issueData.DatePosted;
            issue._description = issueData.Description;
            issue._issueId = issueData.IssueId;
            issue._postedBy = issueData.PostedBy;
            issue._priority = issueData.Priority;
            issue._status = issueData.Status;
            issue._statusName = issueData.StatusName;
            issue._title = issueData.Title;
            issue._employeeName = issueData.EmployeeName;
            return issue;
        }
        public static Issue NewIssue()
        {
            Issue issue = new Issue();
            issue.DatePosted = DateTime.Now.Date;
            return issue;
        }

        public static void UpdateIssue(Issue issue)
        {
            issue.Update();
        }

        public static void InsertIssue(Issue issue)
        {
            issue.Insert();
        }

        public void Save()
        {
            if (this._issueId > 0)
                Update();
            else
                Insert();
        }

        private void Insert()
        {
            IssueManager.Issue issueData = new IssueManager.Issue();
            issueData.AssignedTo = _assignedTo;
            issueData.Description = _description;
            issueData.PostedBy = _postedBy;
            issueData.Priority = _priority;
            issueData.Status = _status;
            issueData.Title = _title;
            issueData = IssueManager.AddIssue(issueData);
            _issueId = issueData.IssueId;
        }

        private void Update()
        {
            IssueManager.Issue issueData = new IssueManager.Issue();

            issueData.AssignedTo = _assignedTo;
            issueData.Description = _description;
            issueData.IssueId = _issueId;
            issueData.PostedBy = _postedBy;
            issueData.Priority = _priority;
            issueData.Status = _status;
            issueData.Title = _title;
            issueData.Comment = _comments;
            IssueManager.UpdateIssue(issueData);
        }
        public static void Delete(int issueId)
        {
            IssueManager.DeleteIssue(issueId);
        }
    }
}
