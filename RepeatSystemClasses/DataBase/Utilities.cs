using System;
using System.Data;

namespace RepeatSystem.DataBase
{
    public static class Utilities
    {
        public static DateTime? GetDateOnlyFromRow(DataRow row, string fieldName)
        {
            DateTime? result = null;

            if (row.Table.Columns.Contains(fieldName) && row[fieldName] != null && row[fieldName] != DBNull.Value)
            {
                try
                {
                    result = Convert.ToDateTime(row[fieldName]);
                    result = result.Value.Date;
                }
                catch (Exception)
                {
                    result = null;
                }
            }

            return result;
        }

        public static DateTime? GetDateWithTimeFromRow(DataRow row, string fieldName)
        {
            DateTime? result = null;

            if (row.Table.Columns.Contains(fieldName) && row[fieldName] != null && row[fieldName] != DBNull.Value)
            {
                try
                {
                    result = Convert.ToDateTime(row[fieldName]);
                }
                catch (Exception)
                {
                    result = null;
                }
            }

            return result;
        }

        public static string GetStringFromRow(DataRow row, string fieldName)
        {
            string result = string.Empty;

            if (row.Table.Columns.Contains(fieldName) && row[fieldName] != null && row[fieldName] != DBNull.Value)
            {
                result = row[fieldName].ToString().Trim();
            }

            return result;
        }

        public static int? GetIntFromRow(DataRow row, string fieldName)
        {
            int? result = null;

            if (row.Table.Columns.Contains(fieldName) && row[fieldName] != null && row[fieldName] != DBNull.Value)
            {
                try
                {
                    result = Convert.ToInt32(row[fieldName]);
                }
                catch (Exception)
                {
                    result = null;
                }
            }

            return result;
        }

        public static int? GetIntFromRowWithoutZero(DataRow row, string fieldName)
        {
            int? result = null;

            if (row.Table.Columns.Contains(fieldName) && row[fieldName] != null && row[fieldName] != DBNull.Value)
            {
                try
                {
                    result = Convert.ToInt32(row[fieldName]);
                }
                catch (Exception)
                {
                    result = null;
                }

                if (result.HasValue && result.Value == 0)
                {
                    result = null;
                }
            }

            return result;
        }

        public static long? GetLongFromRow(DataRow row, string fieldName)
        {
            long? result = null;

            if (row.Table.Columns.Contains(fieldName) && row[fieldName] != null && row[fieldName] != DBNull.Value)
            {
                try
                {
                    result = Convert.ToInt64(row[fieldName]);
                }
                catch (Exception)
                {
                    result = null;
                }

                if (result.HasValue && result.Value == 0)
                {
                    result = null;
                }
            }

            return result;
        }

        public static double? GetDoubleFromRow(DataRow row, string fieldName)
        {
            double? result = null;

            if (row.Table.Columns.Contains(fieldName) && row[fieldName] != null && row[fieldName] != DBNull.Value)
            {
                result = Convert.ToDouble(row[fieldName]);
            }

            return result;
        }
    }
}
