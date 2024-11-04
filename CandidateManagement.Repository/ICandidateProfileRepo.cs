using CandidateManagement.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Repository
{
    public interface ICandidateProfileRepo
    {
        public CandidateProfile GetCandidateProfileById(string id);
        public List<CandidateProfile> GetCandidateProfiles();
        public bool AddCandidateProfile(CandidateProfile candidateProfile);

        public bool DeleteCandidateProfile(string profileID);

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile);
    }
}
