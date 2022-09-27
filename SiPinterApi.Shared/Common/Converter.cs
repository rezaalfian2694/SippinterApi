using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Linq;

namespace SiPinterApi.Shared.Common
{
    public class Converter
    {
        public static DateTime StringToDateTime(string DateString)
        {
            DateTime result = new DateTime();

            if (DateString.Length == 19)
            {
                string[] arrDateTime = DateString.Split(' ');
                string[] arrDate = arrDateTime[0].Split('.');
                string year = arrDate[2].ToString();
                string month = arrDate[1].ToString();
                string date = arrDate[0].ToString();
                string time = arrDateTime[1].ToString();
                string dateTime = $"{year}/{month}/{date} {time}";

                result = Convert.ToDateTime(dateTime);
            }

            return result;
        }

        public static DataTable ListToDataTable<T>(List<T> data) where T : new()
        {
            DataTable dt = new DataTable();

            var proplist = typeof(T).GetProperties();

            foreach (var item in proplist)
            {
                if (item.CanRead)
                {
                    dt.Columns.Add(item.Name);
                }
            }

            foreach (var item in data)
            {
                var nr = dt.NewRow();

                foreach (DataColumn col in dt.Columns)
                {
                    var theProp = proplist.FirstOrDefault(t => t.Name == col.ColumnName);
                    nr[col] = theProp.GetValue(item);
                }

                dt.Rows.Add(nr);
            }

            return dt;
        }
    }
}
