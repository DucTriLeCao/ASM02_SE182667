using CandidateManagement.BussinessObject;
using CandidateManagement.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Services
{
    public interface ICandidateProfileService
    {
        public bool AddCandidateProfile(CandidateProfile candidateProfile);
        public bool DeleteCandidateProfile(string profileID);

        public CandidateProfile GetCandidateProfileById(string id);

        public List<CandidateProfile> GetCandidateProfiles();

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile);
    }
}
