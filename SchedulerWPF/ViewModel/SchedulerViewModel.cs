using SchedulerSample.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerSample
{
    class SchedulerViewModel
    { 
        public List<Meetings> meetings { get; set; }

        public SchedulerViewModel()
        {
            try
            {
                var dataTable = ConnectPSQL.GetDataTable("select * from Meetings");
                meetings = new List<Meetings>();
                meetings = (from DataRow dr in dataTable.Rows
                            select new Meetings()
                            {
                                Subject = dr["Subject"].ToString(),
                                StartTime = dr["StartTime"] as DateTime? ?? DateTime.Now,
                                EndTime = dr["EndTime"] as DateTime? ?? DateTime.Now
                            }).ToList();
            }
            catch
            {
                // Handle exceptions
            }
        }
    }
}

