using System;
using System.Linq;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
    public class AssignmentRepository :
            IssueTicketingSystemRepository<tbl_assigned_service_engineer_to_issue, AssignmentOrderByPredicateCreator, AssignmentWherePredicateCreator>,
        IAssignmentRepository
    {
        private IComplainIssueRepository _complainIssueRepository;
        public AssignmentRepository(IssueTicketingSystemEntities context, IComplainIssueRepository complainIssueRepository) : base(context)
        {
            _complainIssueRepository = complainIssueRepository;
        }

        protected override object GetPrimaryKey(tbl_assigned_service_engineer_to_issue entity)
        {
            return entity.Id;
        }

        public override void Create(tbl_assigned_service_engineer_to_issue entity)
        {
            using (var createTransaction = Db.Database.BeginTransaction())
            {
                try
                {
                    var complainIssue = _complainIssueRepository.Find(entity.IdIssue);

                    if (complainIssue.tbl_assigned_service_engineer_to_issue.Count == 0)
                    {
                        complainIssue.IdIssueStatus = IssueStatuses.UnderProcess.Id;
                        Db.SaveChanges();
                    }

                    base.Create(entity);


                    createTransaction.Commit();
                }
                catch (Exception)
                {
                    createTransaction.Rollback();
                }
            }
        }
    }
}