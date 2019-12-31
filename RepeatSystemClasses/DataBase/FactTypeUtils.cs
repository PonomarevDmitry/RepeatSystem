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
    public class FactTypeUtils
    {
        private Session session { get; set; }

        internal FactTypeUtils(Session session)
        {
            this.session = session;
        }

        private const string tableName = "FACTTYPES";
        internal string TableNameWithScheme
        {
            get { return SchemeUtils.SchemePrefix(tableName); }
        }

        private const string tableFieldID = "ID";
        public const string tableFieldNAME = "NAME";

        private const int idTypeFact = 1;
        private const int idTypePuzzle = 2;
        private const int idTypeQuestionWhatWhereWhen = 3;

        private FactType typeFact = null;
        public FactType TypeFact
        {
            get
            {
                if (typeFact == null)
                {
                    typeFact = GetById(idTypeFact);
                }

                return typeFact;
            }
        }

        private FactType typePuzzle = null;
        public FactType TypePuzzle
        {
            get
            {
                if (typePuzzle == null)
                {
                    typePuzzle = GetById(idTypePuzzle);
                }

                return typePuzzle;
            }
        }

        private FactType typeQuestionWhatWhereWhen = null;
        public FactType TypeQuestionWhatWhereWhen
        {
            get
            {
                if (typeQuestionWhatWhereWhen == null)
                {
                    typeQuestionWhatWhereWhen = GetById(idTypeQuestionWhatWhereWhen);
                }

                return typeQuestionWhatWhereWhen;
            }
        }

        public FactType GetById(int id)
        {
            FactType result = null;

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

                            result = new FactType();

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

        private void ReadFields(FactType result, DataRow row)
        {
            result.Id = Utilities.GetIntFromRow(row, tableFieldID).Value;
            result.Name = Utilities.GetStringFromRow(row, tableFieldNAME);
        }

        public Collection<FactType> GetAll()
        {
            if (all == null)
            {
                all = GetAllFromBase();
            }

            return all;
        }

        private Collection<FactType> all = null;

        private Collection<FactType> GetAllFromBase()
        {
            Collection<FactType> result = new Collection<FactType>();

            DataTable table;
            string message = string.Empty;

            if (GetAllByTable(out table, out message))
            {
                if (table != null)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        FactType status = new FactType();

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
