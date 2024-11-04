using CandidateManagement.BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace CandidateManagement.DAO
{
    public class CandidateProfileDAO
    {
        private List<JobPosting> jobPostings;
        private List<CandidateProfile> candidateProfiles;
        string candidateFilePath = "CANDIDATEPROFILE.txt";
        string jobPostingFilePath = "JOBPOSTING.txt";
        private static CandidateProfileDAO instance;
        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();

                }
                return instance;
            }
        }


        public CandidateProfileDAO()
        {
            candidateProfiles = new List<CandidateProfile>();
            jobPostings = LoadJobPostings();
            LoadFileData();
        }

        private void LoadFileData()
        {
            if (File.Exists(candidateFilePath))
            {
                var lines = File.ReadAllLines(candidateFilePath);
                foreach (var line in lines) 
                {
                    var data = line.Split(new string[] { "//" }, StringSplitOptions.None);
                    if (data.Length >= 6)
                    {
                        var candidateProfile = new CandidateProfile
                        {
                            CandidateId = data[0].Trim(),
                            Fullname = data[1].Trim(),
                            Birthday = DateTime.Parse(data[2].Trim()),
                            ProfileShortDescription = data[3].Trim(),
                            ProfileUrl = data[4].Trim(),
                            PostingId = data[5].Trim()
                        };
                        candidateProfiles.Add(candidateProfile);
                    }
                }
            }
        }

        private List<JobPosting> LoadJobPostings()
        {
            var postings = new List<JobPosting>();
            if (File.Exists(jobPostingFilePath))
            {
                var lines = File.ReadAllLines(jobPostingFilePath);
                foreach (var line in lines.Skip(1))
                {
                    var data = line.Split(new string[] { "//" }, StringSplitOptions.None);
                    if (data.Length >= 2)
                    {
                        var jobPosting = new JobPosting
                        {
                            PostingId = data[0].Trim(),
                            JobPostingTitle = data[1].Trim(),
                        };
                        postings.Add(jobPosting);
                    }
                }
            }
            return postings;
        }


        public CandidateProfile GetCandidateProfileById(string id)
        {
            return candidateProfiles.Cast<CandidateProfile>().SingleOrDefault(t=> t.CandidateId.Equals(id));
        }
        public List<CandidateProfile> GetCandidateProfiles()
        {
            foreach (CandidateProfile candidate in candidateProfiles)
            {

                var posting = jobPostings.SingleOrDefault(p => p.PostingId.ToString() == candidate.PostingId);
                candidate.Posting = posting;
            }

            return candidateProfiles.Cast<CandidateProfile>().ToList();
        }


        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            try
            {
                if (candidateProfile != null)
                {
                    candidateProfiles.Add(candidateProfile);
                    SaveDataToFile();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            return isSuccess;
        }

        //public bool DeleteCandidateProfile(string profileID)
        //{
        //    bool isSuccess = false;
        //    CandidateProfile candidateProfile = this.GetCandidateProfileById(profileID);
        //    try
        //    {
        //        if (candidateProfile != null)
        //        {
        //            context.CandidateProfiles.Remove(candidateProfile);
        //            context.SaveChanges();
        //            isSuccess = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return isSuccess;
        //}
        public bool DeleteCandidateProfile(string profileID)
        {
            bool isSuccess = false;

            try
            {
                CandidateProfile candidate = GetCandidateProfileById(profileID);
                if (candidate != null)
                {
                    candidateProfiles.Remove(candidate);
                    SaveDataToFile();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }


        public bool UpdateCandidateProfile(CandidateProfile candidate)
        {
            bool isSuccess = false;
            CandidateProfile candidateProfile = this.GetCandidateProfileById(candidate.CandidateId);
            try
            {
                if (candidateProfile != null)
                {
                    candidateProfiles.Remove(candidateProfile);
                    candidateProfiles.Add(candidate);
                    SaveDataToFile();
                    isSuccess = true;
                }

            }
            catch (Exception ex)
            {
                //Write log
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }


        private void SaveDataToFile()
        {
            var lines = candidateProfiles.Cast<CandidateProfile>()
                                         .Select(cp => $"{cp.CandidateId}// {cp.Fullname}// {cp.Birthday:yyyy-MM-dd HH:mm:ss.fff}// {cp.ProfileShortDescription}// {cp.ProfileUrl}// {cp.PostingId}");
            File.WriteAllLines(candidateFilePath, lines);
        }

    }
}
