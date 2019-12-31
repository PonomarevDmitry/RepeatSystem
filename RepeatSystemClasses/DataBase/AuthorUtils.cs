using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepeatSystem.Classes;
using System.Data.SqlClient;
using System.Data;

namespace RepeatSystem.DataBase
{
    public class AuthorUtils
    {
        private Session session { get; set; }

        internal AuthorUtils(Session session)
        {
            this.session = session;
        }

        private const string viewName = "V_AUTHORS";
        internal static string ViewNameWithScheme
        {
            get { return SchemeUtils.SchemePrefix(viewName); }
        }

        public const string tableName = "AUTHORS";
        internal static string TableNameWithScheme
        {
            get { return SchemeUtils.SchemePrefix(tableName); }
        }

        internal const string tableFieldID = "ID";

        private const string tableFieldSURNAME = "SURNAME";
        private const string tableFieldFIRSTNAME = "FIRSTNAME";
        private const string tableFieldSECONDNAME = "SECONDNAME";

        private const string tableFieldSURNAME_ENGLISH = "SURNAME_ENGLISH";
        private const string tableFieldFIRSTNAME_ENGLISH = "FIRSTNAME_ENGLISH";
        private const string tableFieldSECONDNAME_ENGLISH = "SECONDNAME_ENGLISH";

        internal const string viewFieldFULLNAME = "FULLNAME";
        private const string viewFieldFULLNAME_ENGLISH = "FULLNAME_ENGLISH";

        public Author GetById(int id)
        {
            Author result = null;

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select *");
            sqlStr.AppendLine("from " + TableNameWithScheme);
            sqlStr.AppendLine(string.Format("where {0} = @p_id", tableFieldID));

            if (this.session != null && this.session.Connection != null && this.session.Connection.State == ConnectionState.Open)
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlStr.ToString(), this.session.Connection);
                    command.Parameters.AddWithValue("p_id", id);

                    DataSet dataSet = new DataSet();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                    DataTable table;

                    dataAdapter.Fill(dataSet);

                    if (dataSet.Tables.Count > 0)
                    {
                        table = dataSet.Tables[0];

                        if (table.Rows.Count == 1)
                        {
                            DataRow row = table.Rows[0];

                            result = new Author();

                            ReadFields(result, row);
                        }
                    }
                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        private void ReadFields(Author result, DataRow row)
        {
            result.Id = Utilities.GetIntFromRow(row, tableFieldID).Value;

            result.Surname = Utilities.GetStringFromRow(row, tableFieldSURNAME);
            result.FirstName = Utilities.GetStringFromRow(row, tableFieldFIRSTNAME);
            result.SecondName = Utilities.GetStringFromRow(row, tableFieldSECONDNAME);

            result.SurnameEnglish = Utilities.GetStringFromRow(row, tableFieldSURNAME_ENGLISH);
            result.FirstNameEnglish = Utilities.GetStringFromRow(row, tableFieldFIRSTNAME_ENGLISH);
            result.SecondNameEnglish = Utilities.GetStringFromRow(row, tableFieldSECONDNAME_ENGLISH);
        }

        public bool GetTable(out DataTable table, out string message)
        {
            bool result = false;
            table = null;
            message = string.Empty;

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select *");
            sqlStr.AppendLine("from " + ViewNameWithScheme);
            sqlStr.AppendLine(string.Format("order by {0}, {1}, {2}", tableFieldSURNAME, tableFieldFIRSTNAME, tableFieldSECONDNAME));

            if (this.session != null && this.session.Connection != null && this.session.Connection.State == ConnectionState.Open)
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlStr.ToString(), this.session.Connection);

                    DataSet dataSet = new DataSet();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                    dataAdapter.Fill(dataSet);

                    if (dataSet.Tables.Count > 0)
                    {
                        table = dataSet.Tables[0];
                    }

                    result = true;
                }
                catch (Exception exception)
                {
                    message = exception.Message;
                }
            }

            return result;
        }

        #region Сохранение в базу.

        public bool Save(Author obj, out string message)
        {
            message = string.Empty;

            if (obj != null)
            {
                if (obj.Id.HasValue)
                {
                    return Update(obj, out message);
                }
                else
                {
                    return Add(obj, out message);
                }
            }
            else
            {
                message = "Отсутствует объект для сохранения.";
                return false;
            }
        }

        private bool Add(Author obj, out string message)
        {
            message = string.Empty;
            bool result = false;

            if (this.session != null && this.session.Connection != null && this.session.Connection.State == ConnectionState.Open)
            {
                SqlCommand command = new SqlCommand(string.Empty, this.session.Connection);

                SQLCommandBuilder builder = new SQLCommandBuilder(TableNameWithScheme);


                FillCommandBuilder(builder, command, obj);

                builder.FinishString = "SELECT @@IDENTITY AS 'Identity'";


                command.CommandText = builder.GenerateInsertText();

                try
                {
                    object value = command.ExecuteScalar();
                    if (value != null && value != DBNull.Value)
                    {
                        try
                        {
                            int id = Convert.ToInt32(value);
                            obj.Id = id;

                            result = true;
                        }
                        catch (Exception ex)
                        {
                            result = false;
                            message = ex.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                    message = ex.Message;
                }
            }

            return result;
        }

        private bool Update(Author obj, out string message)
        {
            bool result = false;
            message = string.Empty;

            if (this.session != null && this.session.Connection != null && this.session.Connection.State == ConnectionState.Open)
            {
                SqlCommand command = new SqlCommand(string.Empty, this.session.Connection);

                SQLCommandBuilder builder = new SQLCommandBuilder(TableNameWithScheme);

                FillCommandBuilder(builder, command, obj);

                builder.FinishString = string.Format("where {0} = @p_id", tableFieldID);
                command.Parameters.AddWithValue("p_id", obj.Id.Value);


                command.CommandText = builder.GenerateUpdateText();


                try
                {
                    int numberOfRowsAffected = command.ExecuteNonQuery();
                    if (numberOfRowsAffected == 1)
                    {
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                    message = ex.Message;
                }
            }

            return result;
        }

        private void FillCommandBuilder(SQLCommandBuilder builder, SqlCommand command, Author obj)
        {
            if (builder == null || command == null || obj == null)
            {
                return;
            }

            builder.AddParameter(tableFieldSURNAME, "@p_surname");
            command.Parameters.AddWithValue("p_surname", obj.Surname);

            builder.AddParameter(tableFieldFIRSTNAME, "@p_firstname");
            command.Parameters.AddWithValue("p_firstname", obj.FirstName);

            builder.AddParameter(tableFieldSECONDNAME, "@p_secondname");
            command.Parameters.AddWithValue("p_secondname", obj.SecondName);


            builder.AddParameter(tableFieldSURNAME_ENGLISH, "@p_surname_eng");
            command.Parameters.AddWithValue("p_surname_eng", obj.SurnameEnglish);

            builder.AddParameter(tableFieldFIRSTNAME_ENGLISH, "@p_firstname_eng");
            command.Parameters.AddWithValue("p_firstname_eng", obj.FirstNameEnglish);

            builder.AddParameter(tableFieldSECONDNAME_ENGLISH, "@p_secondname_eng");
            command.Parameters.AddWithValue("p_secondname_eng", obj.SecondNameEnglish);
        }

        public void Delete(Author obj)
        {
            if (obj != null && obj.Id.HasValue)
            {
                StringBuilder sqlStr = new StringBuilder();
                sqlStr.AppendLine("delete from " + TableNameWithScheme);
                sqlStr.AppendLine(string.Format("where {0} = @p_id", tableFieldID));

                if (this.session != null && this.session.Connection != null && this.session.Connection.State == ConnectionState.Open)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(sqlStr.ToString(), this.session.Connection);
                        command.Parameters.AddWithValue("p_id", obj.Id.Value);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        #endregion Сохранение в базу.

        //public  bool CheckObjectExistence(int id, out string description)
        //{
        //    bool result = false;

        //    description = string.Empty;

        //    if (this.session != null && this.session.Connection != null && this.session.Connection.State == ConnectionState.Open)
        //    {
        //        StringBuilder sqlStr = new StringBuilder();
        //        sqlStr.AppendLine("select *");
        //        sqlStr.AppendLine("from " + ViewNameWithScheme);
        //        sqlStr.AppendLine(string.Format("where {0} = @p_id", tableFieldID));

        //        SqlCommand command = new SqlCommand(sqlStr.ToString(), this.session.Connection);
        //        command.Parameters.AddWithValue("p_id", id);

        //        try
        //        {
        //            DataSet dataSet = new DataSet();
        //            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

        //            command.ExecuteReader();
        //            dataAdapter.Fill(dataSet);

        //            if (dataSet.Tables.Count > 0)
        //            {
        //                DataTable table = dataSet.Tables[0];

        //                if (table.Rows.Count == 1)
        //                {
        //                    result = true;

        //                    DataRow row = table.Rows[0];

        //                    StringBuilder strBuilder = new StringBuilder();
        //                    strBuilder.AppendFormat("Ребенок {0}", row[tableFieldcityFIO].ToString());
        //                    strBuilder.AppendFormat(", Пол {0}", row[viewFieldPOL_NAME].ToString());

        //                    {
        //                        DateTime? date = Utilities.GetDateOnlyFromRow(row, tableFieldCHBIRTH);

        //                        if (date.HasValue)
        //                        {
        //                            strBuilder.AppendFormat(", ДР {0}", date.Value.ToShortDateString());
        //                        }
        //                    }
        //                    strBuilder.AppendFormat(", Возраст {0}.", row[viewFieldAGE].ToString());

        //                    description = strBuilder.ToString();
        //                }
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            result = false;
        //        }
        //    }

        //    return result;
        //}
    }
}
