using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepeatSystem.Classes;
using System.Data.SqlClient;
using System.Data;

namespace RepeatSystem.DataBase
{
    public class BookUtils
    {
        private Session session { get; set; }

        internal BookUtils(Session session)
        {
            this.session = session;
        }

        private const string viewName = "V_BOOKS";
        private string ViewNameWithScheme
        {
            get { return SchemeUtils.SchemePrefix(viewName); }
        }

        public const string tableName = "BOOKS";
        internal string TableNameWithScheme
        {
            get { return SchemeUtils.SchemePrefix(tableName); }
        }

        private const string tableFieldID = "ID";



        private const string tableFieldNAME = "NAME";
        private const string tableFieldID_PUBLISHER = "ID_PUBLISHER";
        private const string tableFieldPUB_YEAR = "PUB_YEAR";
        private const string tableFieldISBN = "ISBN";



        private const string tableFieldNAME_ORG = "NAME_ORG";
        private const string tableFieldID_PUBLISHER_ORG = "ID_PUBLISHER_ORG";
        private const string tableFieldPUB_YEAR_ORG = "PUB_YEAR_ORG";
        private const string tableFieldISBN_ORG = "ISBN_ORG";



        private const string tableFieldPAGE_COUNT = "PAGE_COUNT";
        private const string tableFieldEDITION = "EDITION";

        private const string tableFieldREVIEW = "REVIEW";
        private const string tableFieldESTIMATION = "ESTIMATION";
        private const string tableFieldNOTE = "NOTE";

        public Book GetById(int id)
        {
            Book result = null;

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

                            result = new Book();

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

        private void ReadFields(Book result, DataRow row)
        {
            result.Id = Utilities.GetIntFromRow(row, tableFieldID).Value;

            result.Name = Utilities.GetStringFromRow(row, tableFieldNAME);
            result.PublicationYear = Utilities.GetIntFromRow(row, tableFieldPUB_YEAR);
            result.ISBN = Utilities.GetStringFromRow(row, tableFieldISBN);
            {
                result.Publisher = null;

                int? value = Utilities.GetIntFromRow(row, tableFieldID_PUBLISHER);

                if (value.HasValue)
                {
                    result.Publisher = this.session.PublisherUtils.GetById(value.Value);
                }
            }



            result.NameOriginal = Utilities.GetStringFromRow(row, tableFieldNAME_ORG);
            result.PublicationYearOriginal = Utilities.GetIntFromRow(row, tableFieldPUB_YEAR_ORG);
            result.ISBNOriginal = Utilities.GetStringFromRow(row, tableFieldISBN_ORG);
            {
                result.PublisherOriginal = null;

                int? value = Utilities.GetIntFromRow(row, tableFieldID_PUBLISHER_ORG);

                if (value.HasValue)
                {
                    result.PublisherOriginal = this.session.PublisherUtils.GetById(value.Value);
                }
            }



            result.Edition = Utilities.GetIntFromRow(row, tableFieldEDITION) ?? 1;
            result.PageCount = Utilities.GetIntFromRow(row, tableFieldPAGE_COUNT) ?? 1;

            result.Review = Utilities.GetStringFromRow(row, tableFieldREVIEW);
            result.Estimation = Utilities.GetStringFromRow(row, tableFieldESTIMATION);
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

        #region Сохранение в базу.

        public bool Save(Book obj, out string message)
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

        private bool Add(Book obj, out string message)
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

        private bool Update(Book obj, out string message)
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

        private void FillCommandBuilder(SQLCommandBuilder builder, SqlCommand command, Book obj)
        {
            if (builder == null || command == null || obj == null)
            {
                return;
            }

            builder.AddParameter(tableFieldNAME, "@p_name");
            command.Parameters.AddWithValue("p_name", obj.Name);

            builder.AddParameter(tableFieldPUB_YEAR, "@p_pub_year");
            command.Parameters.AddWithValue("p_pub_year", (object)obj.PublicationYear ?? DBNull.Value);

            builder.AddParameter(tableFieldISBN, "@p_isbn");
            command.Parameters.AddWithValue("p_isbn", obj.ISBN);

            builder.AddParameter(tableFieldID_PUBLISHER, "@p_id_publisher");
            {
                object value = DBNull.Value;
                if (obj.Publisher != null)
                {
                    value = obj.Publisher.Id;
                }

                command.Parameters.AddWithValue("p_id_publisher", value);
            }



            builder.AddParameter(tableFieldNAME_ORG, "@p_name_org");
            command.Parameters.AddWithValue("p_name_org", obj.NameOriginal);

            builder.AddParameter(tableFieldPUB_YEAR_ORG, "@p_pub_year_org");
            command.Parameters.AddWithValue("p_pub_year_org", (object)obj.PublicationYearOriginal ?? DBNull.Value);

            builder.AddParameter(tableFieldISBN_ORG, "@p_isbn_org");
            command.Parameters.AddWithValue("p_isbn_org", obj.ISBNOriginal);

            builder.AddParameter(tableFieldID_PUBLISHER_ORG, "@p_id_publisher_org");
            {
                object value = DBNull.Value;
                if (obj.PublisherOriginal != null)
                {
                    value = obj.PublisherOriginal.Id;
                }

                command.Parameters.AddWithValue("p_id_publisher_org", value);
            }



            builder.AddParameter(tableFieldEDITION, "@p_edition");
            command.Parameters.AddWithValue("p_edition", obj.Edition);

            builder.AddParameter(tableFieldPAGE_COUNT, "@p_page_count");
            command.Parameters.AddWithValue("p_page_count", obj.PageCount);



            builder.AddParameter(tableFieldREVIEW, "@p_review");
            command.Parameters.AddWithValue("p_review", obj.Review);

            builder.AddParameter(tableFieldESTIMATION, "@p_estimation");
            command.Parameters.AddWithValue("p_estimation", obj.Estimation);

            builder.AddParameter(tableFieldNOTE, "@p_note");
            command.Parameters.AddWithValue("p_note", obj.Note);
        }

        public void Delete(Book obj)
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
