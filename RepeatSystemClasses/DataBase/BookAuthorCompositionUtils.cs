using System;
using System.Data;
using System.Text;
using RepeatSystem.Classes;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace RepeatSystem.DataBase
{
    public class BookAuthorCompositionUtils
    {
        private Session session { get; set; }

        internal BookAuthorCompositionUtils(Session session)
        {
            this.session = session;
        }

        public const string tableName = "BOOK_AUTHORS";
        internal static string TableNameWithScheme
        {
            get { return SchemeUtils.SchemePrefix(tableName); }
        }

        private const string tableFieldID = "ID";

        private const string tableFieldID_BOOK = "ID_BOOK";
        private const string tableFieldID_AUTHOR = "ID_AUTHOR";

        public BookAuthorComposition GetById(int id)
        {
            BookAuthorComposition result = null;

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

                            result = new BookAuthorComposition();

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

        private void ReadFields(BookAuthorComposition result, DataRow row)
        {
            result.Id = Utilities.GetIntFromRow(row, tableFieldID).Value;

            result.IdBook = Utilities.GetIntFromRow(row, tableFieldID_BOOK);
            result.IdAuthor = Utilities.GetIntFromRow(row, tableFieldID_AUTHOR);
        }

        public bool GetTableForBook(int idBook, out DataTable table, out string message)
        {
            bool result = false;
            table = null;
            message = string.Empty;

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine(string.Format("select a.*, b.{0}", AuthorUtils.viewFieldFULLNAME));
            sqlStr.AppendLine(string.Format("from {0} AS a", TableNameWithScheme));
            sqlStr.AppendLine(string.Format("INNER JOIN {0} AS b ON (a.{1} = b.{2})", AuthorUtils.ViewNameWithScheme, tableFieldID_AUTHOR, AuthorUtils.tableFieldID));
            sqlStr.AppendLine(string.Format("where a.{0} = @p_id_book", tableFieldID_BOOK));
            sqlStr.AppendLine(string.Format("order by {0}", tableFieldID));

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

        public bool Save(BookAuthorComposition obj, out string message)
        {
            message = string.Empty;

            if (obj != null)
            {
                if (obj.Id.HasValue)
                {
                    //return Update(obj, out message);
                    message = "Невозможно изменение.";
                    return false;
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

        private bool Add(BookAuthorComposition obj, out string message)
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

        //private  bool Update(City obj, out string message)
        //{
        //    bool result = false;
        //    message = string.Empty;

        //    if (this.session != null && this.session.Connection != null && this.session.Connection.State == ConnectionState.Open)
        //    {
        //        SqlCommand command = new SqlCommand(string.Empty, this.session.Connection);

        //        SQLCommandBuilder builder = new SQLCommandBuilder(TableNameWithScheme);

        //        FillCommandBuilder(builder, command, obj);

        //        builder.FinishString = string.Format("where {0} = @p_id", tableFieldID);
        //        command.Parameters.AddWithValue("p_id", obj.Id.Value);


        //        command.CommandText = builder.GenerateUpdateText();


        //        try
        //        {
        //            int numberOfRowsAffected = command.ExecuteNonQuery();
        //            if (numberOfRowsAffected == 1)
        //            {
        //                result = true;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            result = false;
        //            message = ex.Message;
        //        }
        //    }

        //    return result;
        //}

        private void FillCommandBuilder(SQLCommandBuilder builder, SqlCommand command, BookAuthorComposition obj)
        {
            if (builder == null || command == null || obj == null)
            {
                return;
            }

            builder.AddParameter(tableFieldID_BOOK, "@p_id_book");
            command.Parameters.AddWithValue("p_id_book", obj.IdBook);

            builder.AddParameter(tableFieldID_AUTHOR, "@p_id_author");
            command.Parameters.AddWithValue("p_id_author", obj.IdAuthor);
        }

        public void Delete(BookAuthorComposition obj)
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