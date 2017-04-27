using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using WpfApplication1.Models;

namespace WpfApplication1.Helpers
{
    public class LiteDBDriver
    {
        const string DBFileName = "USD.db";
        const string collectionName = "reports";

        public static void InsertReportIntoDb(ReportData report)
        {
            using (var db = new LiteDatabase(DBFileName))
            {
                var reportCollection = db.GetCollection<ReportData>(collectionName);

                reportCollection.Insert(report);
            }
        }

        public static ReportData SearchReportInDb(string keyword)
        {
            using (var db = new LiteDatabase(DBFileName))
            {
                var reportCollection = db.GetCollection<ReportData>(collectionName);

                var searchReport = reportCollection.FindAll().FirstOrDefault(x => x.FIO.Contains(keyword));
                return searchReport;
            }
        }

        public static void DeleteReportFromDB(ReportData keyword)
        {

             using (var db = new LiteDatabase(DBFileName))
             {
                 var reportCollection = db.GetCollection<ReportData>(collectionName);

                var searchReport = reportCollection.Delete(x => x.GUID==keyword.GUID);
              }
        }
        public static List<ReportData> SearchAllReportsInDB()
        {
            using (var db = new LiteDatabase(DBFileName))
            {
                var reportCollection = db.GetCollection<ReportData>(collectionName);

                List<ReportData> searchReports = reportCollection.FindAll().ToList();
                return searchReports;
            }
        }
    }
}
