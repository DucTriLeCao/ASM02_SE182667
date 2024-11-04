using CandidateManagement.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Services
{
    public interface IJobPostingService
    {
        public JobPosting GetJobPostingById(string jobId);
        public List<JobPosting> GetJobPostings();
    }
}
