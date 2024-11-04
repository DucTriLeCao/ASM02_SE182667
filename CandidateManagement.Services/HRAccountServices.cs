using CandidateManagement.BussinessObject;
using CandidateManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Services
{
    public class HRAccountServices : IHRAccountServices
    {
        private IHRAccountRepo IAccountRepo;
        public HRAccountServices()
            {
                IAccountRepo = new HRAccountRepo();
            }
    Hraccount IHRAccountServices.GetHraccountByEmail(string email)
    {
            return IAccountRepo.GetHraccountByEmail(email);
    }
    public List<Hraccount> GetHraccounts()
    {
            return IAccountRepo.GetHraccounts();
    }
}
}
