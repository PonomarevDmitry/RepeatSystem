using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RepeatSystem.DataBase
{
    public class SQLCommandBuilder
    {
        private string tableName = string.Empty;
        public string TableName { get { return this.tableName; } }

        private string finishString = string.Empty;
        public string FinishString { get { return this.finishString; } set { this.finishString = value; } }

        public SQLCommandBuilder(string tableName)
        {
            this.tableName = tableName;
        }

        private Collection<KeyValuePair<string, string>> commandParameters = new Collection<KeyValuePair<string, string>>();

        public void AddParameter(string field, string value)
        {
            this.commandParameters.Add(new KeyValuePair<string, string>(field, value));
        }

        public string GenerateInsertText()
        {
            if (this.commandParameters.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder fields = new StringBuilder();
            StringBuilder parameters = new StringBuilder();

            int count = 0;
            foreach (KeyValuePair<string, string> item in this.commandParameters)
            {
                if (fields.Length > 0) { fields.Append(", "); }
                if (parameters.Length > 0) { parameters.Append(", "); }

                if (count == 6)
                {
                    count = 0;
                    fields.AppendLine();
                    parameters.AppendLine();
                }

                fields.Append(item.Key);
                parameters.Append(item.Value);

                count++;
            }

            StringBuilder result = new StringBuilder();
            result.AppendLine("insert into " + tableName);
            result.AppendLine();
            result.AppendLine("(" + fields.ToString() + ")");
            result.AppendLine();
            result.AppendLine("values");
            result.AppendLine();
            result.AppendLine("(" + parameters.ToString() + ")");

            if (!string.IsNullOrEmpty(this.finishString))
            {
                result.AppendLine();
                result.AppendLine(this.finishString);
            }

            return result.ToString();
        }

        public string GenerateUpdateText()
        {
            if (this.commandParameters.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder fields = new StringBuilder();

            foreach (KeyValuePair<string, string> item in this.commandParameters)
            {
                if (fields.Length > 0)
                {
                    fields.AppendLine(",");
                    fields.AppendLine();
                }

                fields.AppendFormat("{0} = {1}", item.Key, item.Value);
            }

            StringBuilder result = new StringBuilder();
            result.AppendLine("update " + tableName + " set");
            result.AppendLine();
            result.AppendLine(fields.ToString());
            if (!string.IsNullOrEmpty(this.finishString))
            {
                result.AppendLine();
                result.AppendLine(this.finishString);
            }

            return result.ToString();
        }
    }
}
