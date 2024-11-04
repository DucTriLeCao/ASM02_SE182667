using CandidateManagement.BussinessObject;
using CandidateManagement.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Repository
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public bool AddCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.AddCandidateProfile(candidateProfile);

        public bool DeleteCandidateProfile(string profileID) => CandidateProfileDAO.Instance.DeleteCandidateProfile(profileID);

        public CandidateProfile GetCandidateProfileById(string id) => CandidateProfileDAO.Instance.GetCandidateProfileById(id);

        public List<CandidateProfile> GetCandidateProfiles() => CandidateProfileDAO.Instance.GetCandidateProfiles();

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.UpdateCandidateProfile(candidateProfile);
    }
}
