using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepeatSystem.Classes;
using System.Data.SqlClient;
using System.Data;

namespace RepeatSystem.DataBase
{
    public class ReadingUtils
    {
        private Session session { get; set; }

        internal ReadingUtils(Session session)
        {
            this.session = session;
        }

        private const string viewName = "V_READINGS";
        private string ViewNameWithScheme
        {
            get { return SchemeUtils.SchemePrefix(viewName); }
        }

        public const string tableName = "READINGS";
        internal string TableNameWithScheme
        {
            get { return SchemeUtils.SchemePrefix(tableName); }
        }

        private const string tableFieldID = "ID";

        private const string tableFieldCREATION_DATE = "CREATION_DATE";
        private const string tableFieldID_BOOK = "ID_BOOK";
        private const string tableFieldNUMBER = "NUMBER";
        private const string tableFieldNAME = "NAME";
        private const string tableFieldFIRSTPAGE = "FIRSTPAGE";
        private const string tableFieldLASTPAGE = "LASTPAGE";
        private const string tableFieldRETELLING = "RETELLING";
        private const string tableFieldSUMMARY = "SUMMARY";
        private const string tableFieldHINT = "HINT";
        private const string tableFieldNOTE = "NOTE";


        private const string viewFieldCITY_NAME = "CITY_NAME";

        public Reading GetById(int id)
        {
            Reading result = null;

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select *");
            sqlStr.AppendLine("from " + ViewNameWithScheme);
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

                            result = new Reading();

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

        private void ReadFields(Reading result, DataRow row)
        {
            result.Id = Utilities.GetIntFromRow(row, tableFieldID).Value;

            result.Name = Utilities.GetStringFromRow(row, tableFieldNAME);
            result.CreationDate = Utilities.GetDateWithTimeFromRow(row, tableFieldCREATION_DATE).Value;

            {
                result.Book = null;

                int? value = Utilities.GetIntFromRow(row, tableFieldID_BOOK);

                if (value.HasValue)
                {
                    result.Book = this.session.BookUtils.GetById(value.Value);
                }
            }

            result.Number = Utilities.GetIntFromRow(row, tableFieldNUMBER);

            result.FirstPage = Utilities.GetIntFromRow(row, tableFieldFIRSTPAGE);
            result.LastPage = Utilities.GetIntFromRow(row, tableFieldLASTPAGE);

            result.Retelling = Utilities.GetStringFromRow(row, tableFieldRETELLING);
            result.Summary = Utilities.GetStringFromRow(row, tableFieldSUMMARY);
            result.Hint = Utilities.GetStringFromRow(row, tableFieldHINT);
            result.Note = Utilities.GetStringFromRow(row, tableFieldNOTE);
        }

        public bool GetTable(out DataTable table, out string message)
        {
            bool result = false;
            table = null;
            message = string.Empty;

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select *");
            sqlStr.AppendLine("from " + ViewNameWithScheme);
            sqlStr.AppendLine(string.Format("order by {0}", tableFieldNAME));

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

        public bool GetTableForBook(int idBook, out DataTable table, out string message)
        {
            bool result = false;
            table = null;
            message = string.Empty;

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select *");
            sqlStr.AppendLine("from " + ViewNameWithScheme);
            sqlStr.AppendLine(string.Format("where {0} = @p_id_book", tableFieldID_BOOK));
            sqlStr.AppendLine(string.Format("order by {0}", tableFieldNAME));

            if (this.session != null && this.session.Connection != null && this.session.Connection.State == ConnectionState.Open)
            {
                SqlCommand command = new SqlCommand(sqlStr.ToString(), this.session.Connection);
                command.Parameters.AddWithValue("p_id_book", idBook);

                DataSet dataSet = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                try
                {
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

        public bool Save(Reading obj, out string message)
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

        private bool Add(Reading obj, out string message)
        {
            message = string.Empty;
            bool result = false;

            if (this.session != null && this.session.Connection != null && this.session.Connection.State == ConnectionState.Open)
            {
                SqlCommand command = new SqlCommand(string.Empty, this.session.Connection);

                SQLCommandBuilder builder = new SQLCommandBuilder(TableNameWithScheme);

                builder.AddParameter(tableFieldCREATION_DATE, "@p_create_date");
                command.Parameters.AddWithValue("p_create_date", obj.CreationDate);

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

        private bool Update(Reading obj, out string message)
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

        private void FillCommandBuilder(SQLCommandBuilder builder, SqlCommand command, Reading obj)
        {
            if (builder == null || command == null || obj == null)
            {
                return;
            }

            builder.AddParameter(tableFieldNAME, "@p_name");
            command.Parameters.AddWithValue("p_name", obj.Name);

            builder.AddParameter(tableFieldID_BOOK, "@p_id_book");
            {
                object value = DBNull.Value;
                if (obj.Book != null)
                {
                    value = obj.Book.Id;
                }

                command.Parameters.AddWithValue("p_id_book", value);
            }

            builder.AddParameter(tableFieldNUMBER, "@p_number");
            command.Parameters.AddWithValue("p_number", (object)obj.Number ?? DBNull.Value);

            builder.AddParameter(tableFieldFIRSTPAGE, "@p_firstpage");
            command.Parameters.AddWithValue("p_firstpage", (object)obj.FirstPage ?? DBNull.Value);

            builder.AddParameter(tableFieldLASTPAGE, "@p_lastpage");
            command.Parameters.AddWithValue("p_lastpage", (object)obj.LastPage ?? DBNull.Value);

            builder.AddParameter(tableFieldRETELLING, "@p_retelling");
            command.Parameters.AddWithValue("p_retelling", obj.Retelling);

            builder.AddParameter(tableFieldSUMMARY, "@p_summary");
            command.Parameters.AddWithValue("p_summary", obj.Summary);

            builder.AddParameter(tableFieldHINT, "@p_hint");
            command.Parameters.AddWithValue("p_hint", obj.Hint);

            builder.AddParameter(tableFieldNOTE, "@p_note");
            command.Parameters.AddWithValue("p_note", obj.Note);
        }

        public void Delete(Reading obj)
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