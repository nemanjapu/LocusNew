using System.Collections.Generic;
using LocusNew.Core.Models;

namespace LocusNew.Core.Repositories
{
    public interface ISellerLeadsRepository
    {
        void AddSellerLead(SellerLead lead);
        SellerLead GetSellerLead(int id);
        IEnumerable<SellerLead> GetSellerLeadsWithPropertyType();
        void RemoveSellerLead(int id);
    }
}