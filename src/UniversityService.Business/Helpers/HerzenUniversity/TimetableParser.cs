using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UniversityHelper.UniversityService.Business.Helpers.HerzenUniversity
{
    public class TimetableParser
    {
        public static string DownloadCSVAsString(string dateYYYYMMDD)
        {
            string url = $"https://dev-api.herzen.spb.ru/api/schedule/schedule_csv?date={dateYYYYMMDD}"; // the URL without file name  
            //string url = $"https://dev-api.herzen.spb.ru/api/schedule/schedule_csv?date={dateYYYYMMDD}&days={days}";

            using (WebClient wc = new())
            {
                return wc.DownloadString(url);
            }
        }

        public static void DownloadCSVAsFile(string dateYYYYMMDD)
        {
            string url = $"https://dev-api.herzen.spb.ru/api/schedule/schedule_csv?date={dateYYYYMMDD}"; // the URL without file name  
            //string url = $"https://dev-api.herzen.spb.ru/api/schedule/schedule_csv?date={dateYYYYMMDD}&days={days}";

            using (WebClient wc = new())
            {
                wc.DownloadFile(url, $"Timetable{dateYYYYMMDD}.csv");
            }
        }

        public static DailyTimetable ParseTimetableCSVFromString(string csv, int group, string dateYYYYMMDD)
        {
            var fields = CSVReader.Read(csv);
            foreach (var field in fields)
            {
                CustomLoggers.ApplicationLogger.Log("Field: " + field, typeof(TimetableHelper));
            }

            //TODO
            return null;
        }

        //public static UniversityTimetableForTheDay ParseTimetableCSVFromString(string csv, int group, string dateYYYYMMDD)
        //{
        //    var sr = new StringReader(csv);
        //    using (var parser = new TextFieldParser(sr))
        //    {
        //        parser.TextFieldType = FieldType.Delimited;
        //        parser.SetDelimiters(",");
        //        parser.HasFieldsEnclosedInQuotes = true;
        //        while (!parser.EndOfData)
        //        {
        //            Debug.Log("Line:");
        //            var fields = parser.ReadFields();
        //            foreach (var field in fields)
        //            {
        //                Debug.Log("\tField: " + field);
        //            }
        //        }
        //    }

        //    //TODO
        //    return null;
        //}

        //public static UniversityTimetableForTheDay ParseTimetableCSVromFile(string dateYYYYMMDD, int group)
        //{
        //    using (TextFieldParser parser = new TextFieldParser(Application.persistentDataPath + $"Timetable{dateYYYYMMDD}.csv"))
        //    {
        //        parser.TextFieldType = FieldType.Delimited;
        //        parser.SetDelimiters(",");
        //        while (!parser.EndOfData)
        //        {
        //            Debug.Log("Line:");
        //            var fields = parser.ReadFields();
        //            foreach (var field in fields)
        //            {
        //                Debug.Log("\tField: " + field);
        //            }
        //        }
        //    }

        //    //TODO
        //    return null;
        //}
    }
}
