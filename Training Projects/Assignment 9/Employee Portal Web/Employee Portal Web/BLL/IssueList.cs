using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class IssueList : List<Issue>
    {
        private IssueList()
        {
        }

        public static IssueList GetAllIssues()
        {
            IssueList list = new IssueList();
            list.FetchAll();
            return list;
        }

        private void FetchAll()
        {
            List<IssueManager.Issue> allIssues = IssueManager.GetAllIssues();

            foreach (var item in allIssues)
            {
                Issue issue = Issue.GetIssue(item);
                this.Add(issue);
            }
        }

        public static IssueList GetActiveIssues()
        {
            IssueList list = new IssueList();
            list.FetchActive();
            return list;
        }

        private void FetchActive()
        {
            List<IssueManager.Issue> allOpenIssues = IssueManager.GetAllOpenIssues();

            foreach (var item in allOpenIssues)
            {
                Issue issue = Issue.GetIssue(item);
                this.Add(issue);
            }
        }

        public static IssueList GetUserActiveIssues(int employeeId)
        {
            IssueList list = new IssueList();
            list.FetchUserActive(employeeId);
            return list;
        }

        private void FetchUserActive(int employeeId)
        {
            List<IssueManager.Issue> allOpenIssues = IssueManager.GetAllOpenIssues(employeeId);

            foreach (var item in allOpenIssues)
            {
                Issue issue = Issue.GetIssue(item);
                this.Add(issue);
            }
        }

    }
}
