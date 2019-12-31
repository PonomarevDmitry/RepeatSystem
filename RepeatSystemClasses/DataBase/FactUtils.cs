using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepeatSystem.Classes;
using System.Data.SqlClient;
using System.Data;

namespace RepeatSystem.DataBase
{
    public class FactUtils
    {
        private Session session { get; set; }

        internal FactUtils(Session session)
        {
            this.session = session;
        }

        private const string viewName = "V_FACTS";
        private string ViewNameWithScheme
        {
            get { return SchemeUtils.SchemePrefix(viewName); }
        }

        public const string tableName = "FACTS";
        internal string TableNameWithScheme
        {
            get { return SchemeUtils.SchemePrefix(tableName); }
        }

        private const string tableFieldID = "ID";

        private const string tableFieldCREATION_DATE = "CREATION_DATE";

        private const string tableFieldID_FACT_TYPE = "ID_FACT_TYPE";

        private const string tableFieldNAME = "NAME";

        private const string tableFieldNUMBER = "NUMBER";

        public const string tableFieldQUESTION = "QUESTION";
        private const string tableFieldANSWER = "ANSWER";
        private const string tableFieldHINT = "HINT";
        private const string tableFieldNOTE = "NOTE";

        private const string viewFieldFACT_TYPE_NAME = "FACT_TYPE_NAME";

        public Fact GetById(int id)
        {
            Fact result = null;

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

                            result = new Fact();

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

        private void ReadFields(Fact result, DataRow row)
        {
            result.Id = Utilities.GetIntFromRow(row, tableFieldID).Value;

            result.CreationDate = Utilities.GetDateWithTimeFromRow(row, tableFieldCREATION_DATE).Value;

            result.Name = Utilities.GetStringFromRow(row, tableFieldNAME);

            result.Number = Utilities.GetIntFromRow(row, tableFieldNUMBER);

            result.Question = Utilities.GetStringFromRow(row, tableFieldQUESTION);
            result.Answer = Utilities.GetStringFromRow(row, tableFieldANSWER);
            result.Hint = Utilities.GetStringFromRow(row, tableFieldHINT);
            result.Note = Utilities.GetStringFromRow(row, tableFieldNOTE);

            {
                result.FactType = null;

                int? value = Utilities.GetIntFromRow(row, tableFieldID_FACT_TYPE);

                if (value.HasValue)
                {
                    result.FactType = this.session.FactTypeUtils.GetById(value.Value);
                }
            }
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

        #region Сохранение в базу.

        public bool Save(Fact obj, out string message)
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

        private bool Add(Fact obj, out string message)
        {
            message = string.Empty;
            bool result = false;

            if (this.session != null && this.session.Connection != null && this.session.Connection.State == ConnectionState.Open)
            {
                SqlCommand command = new SqlCommand(string.Empty, this.session.Connection);

                SQLCommandBuilder builder = new SQLCommandBuilder(TableNameWithScheme);

                builder.AddParameter(tableFieldCREATION_DATE, "@p_create_date");
                command.Parameters.AddWithValue("p_create_date", obj.CreationDate);

                builder.AddParameter(tableFieldNUMBER, "@p_number");
                command.Parameters.AddWithValue("p_number", GetNextNumber());

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

        private int? GetNextNumber()
        {
            int? result = null;

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine(string.Format("select max({0}) {0}", tableFieldNUMBER));
            sqlStr.AppendLine("from " + TableNameWithScheme);

            if (this.session != null && this.session.Connection != null && this.session.Connection.State == ConnectionState.Open)
            {
                SqlCommand command = new SqlCommand(sqlStr.ToString(), this.session.Connection);

                try
                {
                    object obj = command.ExecuteScalar();

                    if (obj != null && obj != DBNull.Value)
                    {
                        result = Convert.ToInt32(obj) + 1;
                    }
                    else
                    {
                        result = 1;
                    }
                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        private bool Update(Fact obj, out string message)
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

        private void FillCommandBuilder(SQLCommandBuilder builder, SqlCommand command, Fact obj)
        {
            if (builder == null || command == null || obj == null)
            {
                return;
            }

            builder.AddParameter(tableFieldNAME, "@p_name");
            command.Parameters.AddWithValue("p_name", obj.Name);

            //builder.AddParameter(tableFieldNUMBER, "@p_number");
            //command.Parameters.AddWithValue("p_number", (object)obj.Number ?? DBNull.Value);

            builder.AddParameter(tableFieldQUESTION, "@p_question");
            command.Parameters.AddWithValue("p_question", obj.Question);

            builder.AddParameter(tableFieldANSWER, "@p_answer");
            command.Parameters.AddWithValue("p_answer", obj.Answer);

            builder.AddParameter(tableFieldHINT, "@p_hint");
            command.Parameters.AddWithValue("p_hint", obj.Hint);

            builder.AddParameter(tableFieldNOTE, "@p_note");
            command.Parameters.AddWithValue("p_note", obj.Note);

            builder.AddParameter(tableFieldID_FACT_TYPE, "@p_id_fact_type");
            {
                object value = DBNull.Value;
                if (obj.FactType != null)
                {
                    value = obj.FactType.Id;
                }

                command.Parameters.AddWithValue("p_id_fact_type", value);
            }
        }

        public void Delete(Fact obj)
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