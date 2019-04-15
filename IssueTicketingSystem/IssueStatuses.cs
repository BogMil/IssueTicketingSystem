using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;

namespace IssueTicketingSystem
{
    public static class IssueStatuses
    {
        public static IssueStatus Open { get;}
        public static IssueStatus Close { get; }
        public static IssueStatus AwaitingApproval { get; }
        public static IssueStatus UnderProcess { get; }

        static IssueStatuses()
        {
            Open = new IssueStatus { Text = "Open", Id = 1 };
            UnderProcess = new IssueStatus { Text = "Under Process ", Id = 2 };
            Close= new IssueStatus { Text = "Close", Id = 3 };
            AwaitingApproval= new IssueStatus { Text = "Awaiting Approval", Id = 4 };
        }

        public class IssueStatus
        {
            public string Text { get; set; }
            public int Id { get; set; }
        }
    }

    
}