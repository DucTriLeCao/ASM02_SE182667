using CandidateManagement.BussinessObject;
using CandidateManagement.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Services
{
    public interface IHRAccountServices
    {
        public Hraccount GetHraccountByEmail(string email)=>HRAccountDAO.Instance.GetHraccountByEmail(email);

        public List<Hraccount> GetHraccounts()=>HRAccountDAO.Instance.GetHraccounts();
    }
}
