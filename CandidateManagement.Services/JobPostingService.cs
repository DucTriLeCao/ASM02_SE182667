using CandidateManagement.BussinessObject;
using CandidateManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Services
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IJobPostingRepo jobPostingRepo;
        public JobPostingService()
        {
            jobPostingRepo = new JobPostingRepo();
        }
        public JobPosting GetJobPostingById(string jobId)
        {
            return jobPostingRepo.GetJobPostingById(jobId);
        }

        public List<JobPosting> GetJobPostings()
        {
            return jobPostingRepo.GetJobPostings();
        }
    }
}
