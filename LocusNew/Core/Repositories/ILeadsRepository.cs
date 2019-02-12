using System.Collections.Generic;
using LocusNew.Core.Models;

namespace LocusNew.Core.Repositories
{
    public interface ILeadsRepository
    {
        void AddLead(Lead lead);
        IEnumerable<Lead> GetLeadsList();
        Lead GetMessage(int id);
        void RemoveLead(int id);
    }
}