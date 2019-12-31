
namespace RepeatSystem.DataBase
{
    internal static class SchemeUtils
    {
        private const string scheme = "DBO";

        internal static string SchemePrefix(string name)
        {
            return string.Format("{0}.{1}", scheme, name);
        }

        internal static string RemovePrefix(string paramTableName)
        {
            string result = paramTableName.ToUpper().Replace(scheme + ".", string.Empty);

            return result;
        }
    }
}
