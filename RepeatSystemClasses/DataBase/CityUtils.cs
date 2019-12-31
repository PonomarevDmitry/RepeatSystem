﻿using System;
using System.Data;
using System.Text;
using RepeatSystem.Classes;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace RepeatSystem.DataBase
{
    public class CityUtils
    {
        private Session session { get; set; }

        internal CityUtils(Session session)
        {
            this.session = session;
        }

        public const string tableName = "CITIES";
        internal string TableNameWithScheme
        {
            get { return SchemeUtils.SchemePrefix(tableName); }
        }

        private const string tableFieldID = "ID";

        private const string tableFieldNAME = "NAME";

        public City GetById(int id)
        {
            City result = null;

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select *");
            sqlStr.AppendLine("from " + TableNameWithScheme);
            sqlStr.AppendLine(string.Format("where {0} = @p_id", tableFieldID));

            if (this.session != null && this.session.Connection != null && this.session.Connection.State == ConnectionState.Open)
            {
                SqlCommand command = new SqlCommand(sqlStr.ToString(), this.session.Connection);
                command.Parameters.AddWithValue("p_id", id);

                DataSet dataSet = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable table;

                try
                {
                    dataAdapter.Fill(dataSet);

                    if (dataSet.Tables.Count > 0)
                    {
                        table = dataSet.Tables[0];

                        if (table.Rows.Count == 1)
                        {
                            DataRow row = table.Rows[0];

                            result = new City();

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

        private void ReadFields(City result, DataRow row)
        {
            result.Id = Utilities.GetIntFromRow(row, tableFieldID).Value;

            result.Name = Utilities.GetStringFromRow(row, tableFieldNAME);
        }

        public bool GetTable(out DataTable table, out string message)
        {
            bool result = false;
            table = null;
            message = string.Empty;

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select *");
            sqlStr.AppendLine("from " + TableNameWithScheme);
            sqlStr.AppendLine(string.Format("order by {0}", tableFieldNAME));

            if (this.session != null && this.session.Connection != null && this.session.Connection.State == ConnectionState.Open)
            {
                SqlCommand command = new SqlCommand(sqlStr.ToString(), this.session.Connection);

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

        public Collection<City> GetAll()
        {
            Collection<City> result = new Collection<City>();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select *");
            sqlStr.AppendLine("from " + TableNameWithScheme);
            sqlStr.AppendLine(string.Format("order by {0}", tableFieldID));

            if (this.session != null && this.session.Connection != null && this.session.Connection.State == ConnectionState.Open)
            {
                SqlCommand command = new SqlCommand(sqlStr.ToString(), this.session.Connection);

                DataSet dataSet = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable table;

                try
                {
                    dataAdapter.Fill(dataSet);

                    if (dataSet.Tables.Count > 0)
                    {
                        table = dataSet.Tables[0];

                        foreach (DataRow row in table.Rows)
                        {
                            City status = new City();

                            ReadFields(status, row);

                            result.Add(status);
                        }
                    }
                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        #region Сохранение в базу.

        public bool Save(City obj, out string message)
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

        private bool Add(City obj, out string message)
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

        private bool Update(City obj, out string message)
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

        private void FillCommandBuilder(SQLCommandBuilder builder, SqlCommand command, City obj)
        {
            if (builder == null || command == null || obj == null)
            {
                return;
            }

            builder.AddParameter(tableFieldNAME, "@p_name");
            command.Parameters.AddWithValue("p_name", obj.Name);
        }

        public void Delete(City obj)
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
