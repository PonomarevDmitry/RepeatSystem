using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepeatSystem.Classes;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace RepeatSystem.DataBase
{
    public class ThoughtTypeUtils
    {
        private Session session { get; set; }

        internal ThoughtTypeUtils(Session session)
        {
            this.session = session;
        }

        private const string tableName = "THOUGHTTYPES";
        internal string TableNameWithScheme
        {
            get { return SchemeUtils.SchemePrefix(tableName); }
        }

        private const string tableFieldID = "ID";
        public const string tableFieldNAME = "NAME";

        private const int idTypeThought = 1;
        private const int idTypeAphorism = 2;
        private const int idTypeCitation = 3;

        private ThoughtType typeThought = null;
        public ThoughtType TypeThought
        {
            get
            {
                if (typeThought == null)
                {
                    typeThought = GetById(idTypeThought);
                }

                return typeThought;
            }
        }

        private ThoughtType typeAphorism = null;
        public ThoughtType TypeAphorism
        {
            get
            {
                if (typeAphorism == null)
                {
                    typeAphorism = GetById(idTypeAphorism);
                }

                return typeAphorism;
            }
        }

        private ThoughtType typeCitation = null;
        public ThoughtType TypeCitation
        {
            get
            {
                if (typeCitation == null)
                {
                    typeCitation = GetById(idTypeCitation);
                }

                return typeCitation;
            }
        }

        public ThoughtType GetById(int id)
        {
            ThoughtType result = null;

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select *");
            sqlStr.AppendLine("from " + TableNameWithScheme);
            sqlStr.AppendLine(string.Format("where {0} = :p_codepol", tableFieldID));

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

                            result = new ThoughtType();

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

        private void ReadFields(ThoughtType result, DataRow row)
        {
            result.Id = Utilities.GetIntFromRow(row, tableFieldID).Value;
            result.Name = Utilities.GetStringFromRow(row, tableFieldNAME);
        }

        public Collection<ThoughtType> GetAll()
        {
            if (all == null)
            {
                all = GetAllFromBase();
            }

            return all;
        }

        private Collection<ThoughtType> all = null;

        private Collection<ThoughtType> GetAllFromBase()
        {
            Collection<ThoughtType> result = new Collection<ThoughtType>();

            DataTable table;
            string message = string.Empty;

            if (GetAllByTable(out table, out message))
            {
                if (table != null)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        ThoughtType status = new ThoughtType();

                        ReadFields(status, row);

                        result.Add(status);
                    }
                }
            }

            return result;
        }

        public bool GetAllByTable(out DataTable table, out string message)
        {
            bool result = false;
            table = null;
            message = string.Empty;

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select *");
            sqlStr.AppendLine("from " + TableNameWithScheme);
            sqlStr.AppendLine(string.Format("order by {0}", tableFieldID));

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

                        result = true;
                    }
                }
                catch (Exception)
                {
                }
            }

            return result;
        }
    }
}
