using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepeatSystem.Classes;
using System.Data.SqlClient;
using System.Data;

namespace RepeatSystem.DataBase
{
    public class PersonUtils
    {
        private Session session { get; set; }

        internal PersonUtils(Session session)
        {
            this.session = session;
        }

        public const string tableName = "PERSONS";
        internal string TableNameWithScheme
        {
            get { return SchemeUtils.SchemePrefix(tableName); }
        }

        private const string tableFieldID = "ID";

        private const string tableFieldCREATION_DATE = "CREATION_DATE";

        private const string tableFieldSURNAME = "SURNAME";
        private const string tableFieldFIRSTNAME = "FIRSTNAME";
        private const string tableFieldSECONDNAME = "SECONDNAME";

        private const string tableFieldBIRTHDAY = "BIRTHDAY";

        private const string tableFieldMEETINGPLACE = "MEETINGPLACE";
        private const string tableFieldMEETINGDATE = "MEETINGDATE";

        private const string tableFieldADDRESS = "ADDRESS";
        private const string tableFieldPHONENUMBER = "PHONENUMBER";
        private const string tableFieldDESCRIPTION = "DESCRIPTION";
        private const string tableFieldNOTE = "NOTE";
        private const string tableFieldPHOTOFILENAME = "PHOTOFILENAME";

        public Person GetById(int id)
        {
            Person result = null;

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

                            result = new Person();

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

        private void ReadFields(Person result, DataRow row)
        {
            result.Id = Utilities.GetIntFromRow(row, tableFieldID).Value;

            result.CreationDate = Utilities.GetDateWithTimeFromRow(row, tableFieldCREATION_DATE).Value;

            result.Surname = Utilities.GetStringFromRow(row, tableFieldSURNAME);
            result.FirstName = Utilities.GetStringFromRow(row, tableFieldFIRSTNAME);
            result.SecondName = Utilities.GetStringFromRow(row, tableFieldSECONDNAME);

            result.BirthDay = Utilities.GetDateOnlyFromRow(row, tableFieldBIRTHDAY);

            result.MeetingPlace = Utilities.GetStringFromRow(row, tableFieldMEETINGPLACE);
            result.MeetingDate = Utilities.GetDateOnlyFromRow(row, tableFieldMEETINGDATE);

            result.Address = Utilities.GetStringFromRow(row, tableFieldADDRESS);
            result.PhoneNumber = Utilities.GetStringFromRow(row, tableFieldPHONENUMBER);
            result.Description = Utilities.GetStringFromRow(row, tableFieldDESCRIPTION);
            result.Note = Utilities.GetStringFromRow(row, tableFieldNOTE);
            result.PhotoFileName = Utilities.GetStringFromRow(row, tableFieldPHOTOFILENAME);
        }

        public bool GetTable(out DataTable table, out string message)
        {
            bool result = false;
            table = null;
            message = string.Empty;

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select *");
            sqlStr.AppendLine("from " + TableNameWithScheme);
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

        public bool Save(Person obj, out string message)
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

        private bool Add(Person obj, out string message)
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

        private bool Update(Person obj, out string message)
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

        private void FillCommandBuilder(SQLCommandBuilder builder, SqlCommand command, Person obj)
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

            builder.AddParameter(tableFieldBIRTHDAY, "@p_birthday");
            command.Parameters.AddWithValue("p_birthday", (object)obj.BirthDay ?? DBNull.Value);

            builder.AddParameter(tableFieldMEETINGPLACE, "@p_meetingplace");
            command.Parameters.AddWithValue("p_meetingplace", obj.MeetingPlace);

            builder.AddParameter(tableFieldMEETINGDATE, "@p_meetingdate");
            command.Parameters.AddWithValue("p_meetingdate", (object)obj.MeetingDate ?? DBNull.Value);

            builder.AddParameter(tableFieldADDRESS, "@p_address");
            command.Parameters.AddWithValue("p_address", obj.Address);

            builder.AddParameter(tableFieldPHONENUMBER, "@p_phonenumber");
            command.Parameters.AddWithValue("p_phonenumber", obj.PhoneNumber);

            builder.AddParameter(tableFieldDESCRIPTION, "@p_description");
            command.Parameters.AddWithValue("p_description", obj.Description);

            builder.AddParameter(tableFieldNOTE, "@p_note");
            command.Parameters.AddWithValue("p_note", obj.Note);

            builder.AddParameter(tableFieldPHOTOFILENAME, "@p_photofilename");
            command.Parameters.AddWithValue("p_photofilename", obj.PhotoFileName);
        }

        public void Delete(Person obj)
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
