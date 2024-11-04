using CandidateManagement.BussinessObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAO
{
    public class JobPostingDAO
    {
        private ArrayList jobPostings;
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JOBPOSTING.txt");
        private static JobPostingDAO instance = null;
        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }
        public JobPostingDAO()
        {
            jobPostings = new ArrayList();
            LoadFileData();
        }

        private void LoadFileData()
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var data = line.Split(new string[] { "//" }, StringSplitOptions.None);
                    if (data.Length >= 4)
                    {
                        var jobPosting = new JobPosting
                        {
                            PostingId = data[0].Trim(),
                            JobPostingTitle = data[1].Trim(),
                            Description = data[2].Trim(),
                            PostedDate = DateTime.Parse(data[3].Trim())
                        };
                        jobPostings.Add(jobPosting);
                    }
                }
            }
        }

        public JobPosting GetJobPostingID(string jobID)
        {
            return jobPostings.Cast<JobPosting>().SingleOrDefault(jp => jp.PostingId.Equals(jobID));
        }
        public List<JobPosting> GetJobPostings()
        {
            return jobPostings.Cast<JobPosting>().ToList();
        }
    }
}
