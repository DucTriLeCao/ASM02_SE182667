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
    public class HRAccountDAO
    {
        private List<Hraccount> hrAccs;
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HRACCOUNT.txt");
        private static HRAccountDAO instance = null;

        public static HRAccountDAO Instance
        {
            get
            {//singleton

                if (instance == null)
                {
                    instance = new HRAccountDAO();
                }
                return instance;

            }
        }


        public HRAccountDAO()
        {
            hrAccs = new List<Hraccount>();
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
                        var hrAccount = new Hraccount
                        {
                            Email = data[0].Trim(),
                            Password = data[1].Trim(),
                            FullName = data[2].Trim(),
                            MemberRole = int.Parse(data[3].Trim())
                        };
                        hrAccs.Add(hrAccount);
                    }
                }
            }
        }



        public Hraccount GetHraccountByEmail(string email)
        {
            return hrAccs.Cast<Hraccount>().SingleOrDefault(t => t.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
        public List<Hraccount> GetHraccounts()
        {
            return hrAccs.Cast<Hraccount>().ToList();
        }


    }
}
