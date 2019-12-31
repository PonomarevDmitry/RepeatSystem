using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.IO;

namespace RepeatSystem.DataBase
{
    public class Session
    {
        private SqlConnection connection = null;
        internal SqlConnection Connection
        {
            get
            {
                if (connection != null && connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                return connection;
            }

            private set { connection = value; }
        }

        public bool Connect(string filePath, out string errorMessage)
        {
            bool result = false;
            errorMessage = string.Empty;

            if (File.Exists(filePath))
            {
                string connectionString = string.Format(@"Data Source=.\SQLEXPRESS;AttachDbFilename={0};Integrated Security=True;Connect Timeout=30;User Instance=True", filePath);

                this.connection = new SqlConnection(connectionString);

                try
                {
                    this.connection.Open();

                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    errorMessage = ex.Message;
                }

                if (!result)
                {
                    try
                    {
                        this.connection.Close();
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                errorMessage = "Файл базы данных отсутсвует.";
            }

            return result;
        }

        public bool Disconnect(out string errorMessage)
        {
            bool result = false;
            errorMessage = string.Empty;

            if (this.connection != null)
            {
                try
                {
                    connection.Close();
                    result = false;
                }
                catch (Exception)
                {
                    result = false;
                }
            }

            return result;
        }

        private AuthorUtils _AuthorUtils;
        public AuthorUtils AuthorUtils
        {
            get
            {
                if (_AuthorUtils == null)
                {
                    _AuthorUtils = new AuthorUtils(this);
                }

                return _AuthorUtils;
            }
        }

        private ThoughtUtils _ThoughtUtils;
        public ThoughtUtils ThoughtUtils
        {
            get
            {
                if (_ThoughtUtils == null)
                {
                    _ThoughtUtils = new ThoughtUtils(this);
                }

                return _ThoughtUtils;
            }
        }

        private BookAuthorCompositionUtils _BookAuthorCompositionUtils;
        public BookAuthorCompositionUtils BookAuthorCompositionUtils
        {
            get
            {
                if (_BookAuthorCompositionUtils == null)
                {
                    _BookAuthorCompositionUtils = new BookAuthorCompositionUtils(this);
                }

                return _BookAuthorCompositionUtils;
            }
        }

        private BookTagCompositionUtils _BookTagCompositionUtils;
        public BookTagCompositionUtils BookTagCompositionUtils
        {
            get
            {
                if (_BookTagCompositionUtils == null)
                {
                    _BookTagCompositionUtils = new BookTagCompositionUtils(this);
                }

                return _BookTagCompositionUtils;
            }
        }

        private BookUtils _BookUtils;
        public BookUtils BookUtils
        {
            get
            {
                if (_BookUtils == null)
                {
                    _BookUtils = new BookUtils(this);
                }

                return _BookUtils;
            }
        }

        private CityUtils _CityUtils;
        public CityUtils CityUtils
        {
            get
            {
                if (_CityUtils == null)
                {
                    _CityUtils = new CityUtils(this);
                }

                return _CityUtils;
            }
        }

        private FactTypeUtils _FactTypeUtils;
        public FactTypeUtils FactTypeUtils
        {
            get
            {
                if (_FactTypeUtils == null)
                {
                    _FactTypeUtils = new FactTypeUtils(this);
                }

                return _FactTypeUtils;
            }
        }

        private FactUtils _FactUtils;
        public FactUtils FactUtils
        {
            get
            {
                if (_FactUtils == null)
                {
                    _FactUtils = new FactUtils(this);
                }

                return _FactUtils;
            }
        }

        private PersonUtils _PersonUtils;
        public PersonUtils PersonUtils
        {
            get
            {
                if (_PersonUtils == null)
                {
                    _PersonUtils = new PersonUtils(this);
                }

                return _PersonUtils;
            }
        }

        private PublisherUtils _PublisherUtils;
        public PublisherUtils PublisherUtils
        {
            get
            {
                if (_PublisherUtils == null)
                {
                    _PublisherUtils = new PublisherUtils(this);
                }

                return _PublisherUtils;
            }
        }

        private ReadingUtils _ReadingUtils;
        public ReadingUtils ReadingUtils
        {
            get
            {
                if (_ReadingUtils == null)
                {
                    _ReadingUtils = new ReadingUtils(this);
                }

                return _ReadingUtils;
            }
        }

        private TagUtils _TagUtils;
        public TagUtils TagUtils
        {
            get
            {
                if (_TagUtils == null)
                {
                    _TagUtils = new TagUtils(this);
                }

                return _TagUtils;
            }
        }

        private ThoughtTypeUtils _ThoughtTypeUtils;
        public ThoughtTypeUtils ThoughtTypeUtils
        {
            get
            {
                if (_ThoughtTypeUtils == null)
                {
                    _ThoughtTypeUtils = new ThoughtTypeUtils(this);
                }

                return _ThoughtTypeUtils;
            }
        }

        //private ChiefTypeUtils _ChiefTypeUtils;
        //public ChiefTypeUtils ChiefTypeUtils
        //{
        //    get
        //    {
        //        if (_ChiefTypeUtils == null)
        //        {
        //            _ChiefTypeUtils = new ChiefTypeUtils(this);
        //        }

        //        return _ChiefTypeUtils;
        //    }
        //}
    }
}
