////////////////////////////////////Disclaimer////////////////////////////////////////////
using Newtonsoft.Json;
///This library has been wrote by : Anas Reslan Bahsas  if you are going to use it		//	
///please dont remove this line .														//					
///you have to add this class to a asp.net web project to work well.					//
///I will be grateful to receive any commments or suggestion to anasbahsas@hotmail.com	//								//	
//////////////////////////////////////////////////////////////////////////////////////////
using System.Globalization;
using System.Text.RegularExpressions;

namespace MWS.Business.Shared.Business
{

    public interface IDateConverter
    {
        bool IsHijri(string dateStr);


        string GregDateNow();

        string HijriDateNow();

        DateTime ToDateTime(string dateString);

        DateTime ToDateTime(string dateString, string format);
        string HijriToGregHijri(string hijri);




        string HijriToGreg(string hijri, string format = "dd-MM-yyyy");


        string HijriToGreg(DateTime hijri, string format = "dd-MM-yyyy");


        DateTime HijriToGregDate(string hijri, string format = "dd-MM-yyyy");
        DateTime? HijriToGregDateNull(string hijri, string format = "dd-MM-yyyy");


        DateTime HijriToGregDate(DateTime hijri);








        string GregToHijri(string greg, string format = "dd-MM-yyyy");


        string GregToHijri(DateTime greg, string format = "dd-MM-yyyy");



        DateTime GregToHijriDate(string greg, string format = "dd-MM-yyyy");
        DateTime? GregToHijriDateNull(string greg, string format = "dd-MM-yyyy");

        DateTime GregToHijriDate(DateTime greg);
        int[] getDateParts(string dateStr);

        string convertDateString(string dateStr, Calendar calFrom, Calendar calTo);
        DateTime? getDateFromString(string dateStr, Calendar calFrom);


        string ToMonthYear(string date);
        string FromMonthYear(string date);


        string convertDateFromJsToDB(string date);


        string convertDateFromDBToJs(string date);

        DateTime GetGregDate(string greg, string[] formats = null);
        string DateToString(DateTime? date, string format = "dd-MM-yyyy");

        DateTime? ClearMilliSecond(DateTime? date);

        DateTime GregNowWithoutFraction();


        DateTime? FromJSONDate(string jsonDate);


    }

    /// <summary>
    /// Summary description for Dates.
    /// </summary>
    public class DateConverter : IDateConverter
    {


        private const int startGreg = 1900;
        private const int endGreg = 2200;
        private string[] allFormats = { "yyyy/MM/dd", "yyyy/M/d", "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "yyyy-MM-dd", "yyyy-M-d", "dd-MM-yyyy", "d-M-yyyy", "dd-M-yyyy", "d-MM-yyyy", "yyyy MM dd", "yyyy M d", "dd MM yyyy", "d M yyyy", "dd M yyyy", "d MM yyyy", "dd-MMM-yyyy", "yyyy-MMM-dd", "dd/MMM/yyyy", "yyyy/MMM/dd" };
        private CultureInfo arCul;
        private CultureInfo enCul;
        private UmAlQuraCalendar h;
        private GregorianCalendar g;



        public DateTime? FromJSONDate(string jsonDate)
        {
            try
            {

                var ret = JsonConvert.DeserializeObject<DateTime>("\"" + jsonDate + "\"");

                return ret;
            }
            catch
            {
                return null;
            }
        }

        public DateConverter()
        {


            arCul = new CultureInfo("ar-SA");
            enCul = new CultureInfo("en-US");

            h = new UmAlQuraCalendar();
            g = new GregorianCalendar(GregorianCalendarTypes.USEnglish);

            arCul.DateTimeFormat.Calendar = h;


        }



        public int[] getDateParts(string dateStr)
        {
            int year = 0;
            int month = 1;
            int day = 1;
            var arr = dateStr.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length > 0)
            {
                year = int.Parse(arr[0]);
            }

            if (arr.Length > 1)
            {
                month = int.Parse(arr[1]);
            }

            if (arr.Length > 2)
            {
                day = int.Parse(arr[2]);
            }
            return new int[] { year, month, day };
        }


        public string convertDateString(string dateStr, Calendar calFrom, Calendar calTo)
        {
            DateTime date = getDateFromString(dateStr, calFrom).Value;
            return calTo.GetYear(date).ToString("d4") + "-"
                + calTo.GetMonth(date).ToString("d2") + "-"
                + calTo.GetDayOfMonth(date).ToString("d2");
        }

        public DateTime GetGregDate(string greg, string[] formats = null)
        {
            if (formats == null)
            {
                formats = allFormats;
            }
            return DateTime.ParseExact(greg, formats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
        }



        public DateTime? getDateFromString(string dateStr, Calendar calFrom)
        {
            try
            {


                int[] dateComp = this.getDateParts(dateStr);
                DateTime date = calFrom.ToDateTime(dateComp[0], dateComp[1], dateComp[2], 0, 0, 0, 0);
                return date;
            }
            catch
            {
                return null;
            }
        }


        private string convertMonthYearFromJsToDB(string dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(dateOfBirth))
                return "";
            string reversedDateOfBirth = "";
            int[] dateOfBirthComp = getDateParts(dateOfBirth);

            reversedDateOfBirth = dateOfBirthComp[1].ToString("d2") + "-" + dateOfBirthComp[0].ToString("d4");
            return reversedDateOfBirth;
        }


        private string convertFullDateFromDBToJs(string dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(dateOfBirth))
                return "";
            string reversedDateOfBirth = "";
            int[] dateOfBirthComp = getDateParts(dateOfBirth);

            reversedDateOfBirth = dateOfBirthComp[2].ToString("d4") + "-" + dateOfBirthComp[1].ToString("d2") + "-" + dateOfBirthComp[0].ToString("d2");
            return reversedDateOfBirth;
        }

        private string convertFullDateFromJsToDB(string dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(dateOfBirth))
                return "";
            string reversedDateOfBirth = "";
            int[] dateOfBirthComp = getDateParts(dateOfBirth);

            reversedDateOfBirth = dateOfBirthComp[2].ToString("d2") + "-" + dateOfBirthComp[1].ToString("d2") + "-" + dateOfBirthComp[0].ToString("d4");
            return reversedDateOfBirth;
        }

        public bool IsHijri(string dateStr)
        {
            if (string.IsNullOrWhiteSpace(dateStr))
            {

                return false;
            }
            try
            {
                dateStr = dateStr.Replace("30-02-", "28-02-").Replace("29-02-", "28-02-");

                DateTime tempDate = DateTime.ParseExact(dateStr, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
                if (tempDate.Year < startGreg)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }

        }


        public string GregDateNow()
        {
            try
            {
                return DateTime.Now.ToString("dd-MM-yyyy", enCul.DateTimeFormat);
            }
            catch (Exception ex)
            {

                return "";
            }
        }

        public string HijriDateNow()
        {
            try
            {
                return DateTime.Now.ToString("dd-MM-yyyy", arCul.DateTimeFormat);
            }
            catch (Exception ex)
            {

                return "";
            }

        }

        public DateTime ToDateTime(string dateString)
        {
            if (IsHijri(dateString))
            {
                dateString = dateString.Trim().Replace("30-02-", "28-02-").Replace("29-02-", "28-02-");
            }

            return DateTime.ParseExact(dateString, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);

        }

        public DateTime ToDateTime(string dateString, string format)
        {
            if (IsHijri(dateString))
            {
                dateString = dateString.Trim().Replace("30-02-", "28-02-").Replace("29-02-", "28-02-");
            }

            return DateTime.ParseExact(dateString, format, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);

        }

        public string HijriToGregHijri(string hijri)
        {

            if (string.IsNullOrWhiteSpace(hijri))
            {
                return "";
            }

            return hijri.Replace("30-02-", "28-02-").Replace("29-02-", "28-02-");
        }

        public string DateToString(DateTime? date, string format = "dd-MM-yyyy")
        {
            try
            {
                if (date != null && date.HasValue)
                {
                    return date.Value.ToString(format, enCul.DateTimeFormat);
                }
            }
            catch (Exception ex)
            {

            }
            return "";
        }


        #region Hijri to Greg

        public string HijriToGreg(string hijri, string format = "dd-MM-yyyy")
        {

            if (string.IsNullOrWhiteSpace(hijri))
            {


                return "";
            }
            try
            {
                hijri = hijri.Trim();


                if (!IsHijri(hijri))
                {
                    return hijri;
                }
                bool isAddDay = false;
                try
                {

                    Regex find30 = new Regex(@"[^0-9\:]+(30)[^0-9\:]+");
                    var date30 = " " + hijri + " ";
                    Match mch30 = find30.Match(date30);
                    if (mch30.Success)
                    {
                        int i30 = mch30.Groups[1].Index;
                        date30 = date30.Substring(0, i30) + "29" + date30.Substring(i30 + 2);
                        hijri = date30.Trim();
                        isAddDay = true;
                    }
                }
                catch
                {

                }

                DateTime tempDate = DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
                if (isAddDay)
                {
                    tempDate = tempDate.AddDays(1);
                }
                return tempDate.ToString(format, enCul.DateTimeFormat);

            }
            catch (Exception ex)
            {

                return "";
            }
        }

        public string HijriToGreg(DateTime hijri, string format = "dd-MM-yyyy")
        {
            try
            {
                var hijriDate = hijri.ToString(format, enCul.DateTimeFormat);

                return HijriToGreg(hijriDate);
            }
            catch (Exception ex)
            {

                return "";
            }

        }

        public DateTime HijriToGregDate(string hijri, string format = "dd-MM-yyyy")
        {
            return ToDateTime(HijriToGreg(hijri, format));
        }
        public DateTime? HijriToGregDateNull(string hijri, string format = "dd-MM-yyyy")
        {
            try
            {
                return ToDateTime(HijriToGreg(hijri, format));
            }
            catch
            {
                return null;
            }
        }

        public DateTime HijriToGregDate(DateTime hijri)
        {
            var hijriDate = hijri.ToString("dd-MM-yyyy", enCul.DateTimeFormat);

            return ToDateTime(HijriToGreg(hijriDate));

        }



        #endregion


        #region Greg to Hijri

        public string GregToHijri(string greg, string format = "dd-MM-yyyy")
        {

            if (string.IsNullOrWhiteSpace(greg))
            {

                return "";
            }
            try
            {
                greg = greg.Trim();

                if (IsHijri(greg))
                {
                    return greg;
                }

                DateTime tempDate = DateTime.ParseExact(greg, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
                return tempDate.ToString(format, arCul.DateTimeFormat);

            }
            catch (Exception ex)
            {

                return "";
            }
        }

        public string GregToHijri(DateTime greg, string format = "dd-MM-yyyy")
        {
            try
            {
                var gregDate = greg.ToString(format, enCul.DateTimeFormat);

                return GregToHijri(gregDate);

            }
            catch (Exception ex)
            {
                return "";
            }
        }


        public DateTime GregToHijriDate(string greg, string format = "dd-MM-yyyy")
        {
            return ToDateTime(GregToHijri(greg, format));
        }

        public DateTime? GregToHijriDateNull(string greg, string format = "dd-MM-yyyy")
        {
            try
            {
                return ToDateTime(GregToHijri(greg, format));
            }
            catch
            {
                return null;
            }
        }


        public DateTime GregToHijriDate(DateTime greg)
        {
            var gregDate = greg.ToString("dd-MM-yyyy", enCul.DateTimeFormat);

            return ToDateTime(GregToHijri(gregDate));
        }


        #endregion



        public string ToMonthYear(string date)
        {
            if (string.IsNullOrWhiteSpace(date))
                return "";

            Regex regBirth = new Regex("^[0-9]{1,2}\\-[0-9]{4,4}$");
            Regex regBirthFull = new Regex("^[0-9]{1,2}\\-[0-9]{1,2}\\-[0-9]{4,4}$");
            date = date.Trim();
            if (regBirth.IsMatch(date))
                return date;

            var firstIndex = date.IndexOf('-');


            return date.Substring(firstIndex + 1);


        }


        public string FromMonthYear(string date)
        {
            if (string.IsNullOrWhiteSpace(date))
                return "";
            Regex regBirth = new Regex("^[0-9]{1,2}\\-[0-9]{4,4}$");
            Regex regBirthFull = new Regex("^[0-9]{1,2}\\-[0-9]{1,2}\\-[0-9]{4,4}$");
            date = date.Trim();
            if (regBirthFull.IsMatch(date))
                return date;

            return string.Format("01-{0}", date);
        }


        public string convertDateFromJsToDB(string date)
        {
            if (string.IsNullOrWhiteSpace(date))
                return "";
            Regex regBirth = new Regex("^[0-9]{4,4}\\-[0-9]{1,2}$");
            Regex regBirthFull = new Regex("^[0-9]{4,4}\\-[0-9]{1,2}\\-[0-9]{1,2}$");
            if (regBirth.IsMatch(date))
            {
                return convertMonthYearFromJsToDB(date);
            }
            else if (regBirthFull.IsMatch(date))
            {
                return convertFullDateFromJsToDB(date);
            }
            else
            {
                return date;
            }

        }

        public string convertDateFromDBToJs(string date)
        {
            if (string.IsNullOrWhiteSpace(date))
                return "";
            Regex regBirth = new Regex("^[0-9]{1,2}\\-[0-9]{4,4}$");
            Regex regBirthFull = new Regex("^[0-9]{1,2}\\-[0-9]{1,2}\\-[0-9]{4,4}$");
            if (regBirth.IsMatch(date))
            {
                return date;
            }
            else if (regBirthFull.IsMatch(date))
            {
                return convertFullDateFromDBToJs(date);
            }
            else
            {
                return date;
            }
        }


        public string convertDateToStringByFormat(DateTime date, string format)
        {
            return date.ToString(format, enCul.DateTimeFormat);
        }

        public DateTime? ClearMilliSecond(DateTime? date)
        {
            if (date == null)
            {
                return null;
            }

            DateTime ret = date.Value;
            GregorianCalendar cal = new GregorianCalendar();
            int year = cal.GetYear(ret);
            int month = cal.GetMonth(ret);
            int day = cal.GetDayOfMonth(ret);
            int hour = cal.GetHour(ret);
            int minute = cal.GetMinute(ret);
            int second = cal.GetSecond(ret);

            ret = cal.ToDateTime(year, month, day, hour, minute, second, 0);


            //ret = ret.ToLocalTime();

            return ret;

        }

        public DateTime GregNowWithoutFraction()
        {
            //return DateTime.Now;
            return this.ClearMilliSecond(DateTime.Now).Value;
        }
    }
}
