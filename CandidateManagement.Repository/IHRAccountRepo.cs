using CandidateManagement.BussinessObject;
using CandidateManagement.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Repository
{
    public interface IHRAccountRepo
    {
        public Hraccount GetHraccountByEmail(string email)=>HRAccountDAO.Instance.GetHraccountByEmail(email);

        public List<Hraccount> GetHraccounts()=>HRAccountDAO.Instance.GetHraccounts();


    }
}
