using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyFestivalWCFHost
{
    public class MyFestivalService : IMyFestivalData
    {
        public List<Festival> GetAllMyFestivalList()
        {
            List<Festival> mylist = new List<Festival>();

            using (SqlConnection conn = new SqlConnection("server=(local);database=MyFestivalDb;Integrated Security=SSPI;"))
            {
                conn.Open();

                string cmdStr = String.Format("Select fname, sdate, edate, des from Festivals");
                SqlCommand cmd = new SqlCommand(cmdStr, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        mylist.Add(new Festival(rd.GetString(0), rd.GetDateTime(1), rd.GetDateTime(2), rd.GetString(3)));
                    }
                }
                conn.Close();
            }

            return mylist;
        }
    }
    [DataContract]
    public class Festival
    {
        [DataMember]
        public string FestivalName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public Festival(string fname, DateTime sdate, DateTime edate, string des)
        {
            FestivalName = fname;
            StartDate = sdate;
            EndDate = edate;
            Description = des;
        }
    }
}
