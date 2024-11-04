using CandidateManagement.BussinessObject;
using CandidateManagement.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Repository
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public JobPosting GetJobPostingById(string jobId) => JobPostingDAO.Instance.GetJobPostingID(jobId);
        public List<JobPosting> GetJobPostings() => JobPostingDAO.Instance.GetJobPostings();
    }
}
