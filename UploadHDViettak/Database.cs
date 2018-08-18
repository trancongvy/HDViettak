using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace UploadHDViettak
{
    class Database
    {
        SqlConnection connection;
        public SqlTransaction strMain = null;
        bool multiStatement = false;
        bool hasErrors = false;
        public string MasterPk = string.Empty;
        public string QueryMaster = string.Empty;
        public string DetailPk = string.Empty;
        public string QueryDetail = string.Empty;
        private const int _timeOut = 120;
        public Database(string sqlCon)
        {
            try
            {
                connection = new SqlConnection(sqlCon);
            }
            catch { }
        }
        public bool HasErrors
        {
            get { return hasErrors; }
            set
            {
                hasErrors = value;
            }
        }
        
        public SqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        public void BeginMultiTrans()
        {
            OpenConnection();
            multiStatement = true;
            hasErrors = false;
        }

        public void EndMultiTrans()
        {
            if (hasErrors == false && strMain.Connection != null)
                strMain.Commit();
            CloseConnection();
            multiStatement = false;
            hasErrors = false;
        }

        public void RollbackMultiTrans()
        {
            strMain.Rollback();
            CloseConnection();
            multiStatement = false;
            hasErrors = false;
        }
        private bool OpenConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                if (strMain == null || strMain.Connection == null)
                    strMain = connection.BeginTransaction();
                return true;
            }
            catch (SqlException se)
            {
                Utilities.WriteLogError(se.Message);
                return false;
            }
        }

        private void CloseConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
                if (strMain != null)
                    strMain = null;
            }
            catch (SqlException se)
            {
                Utilities.WriteLogError(se.Message);
            }
        }
        public bool UpdateByNonQuery(string strNonQuery)
        {
            if (!multiStatement)
                if (!OpenConnection())
                    return false;

            try
            {
                SqlCommand sCmd = new SqlCommand(strNonQuery, connection);
                sCmd.Transaction = strMain;
                sCmd.CommandTimeout = _timeOut;
                sCmd.ExecuteNonQuery();

                if (!multiStatement)
                    strMain.Commit();


                return true;
            }
            catch (SqlException se)
            {
                if (!multiStatement)
                    strMain.Rollback();
                hasErrors = true;
                Utilities.WriteLogError(se.Message);
                return false;
            }
            finally
            {
                if (!multiStatement)
                    CloseConnection();
            }
        }
        public DataTable GetDataTable(string queryString)
        {
            if (!multiStatement)
                if (!OpenConnection())
                    return null;

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(queryString, connection);
                DataTable dt = new DataTable();
                sda.SelectCommand.Transaction = strMain;
                sda.SelectCommand.CommandTimeout = _timeOut;
                sda.Fill(dt);

                if (!multiStatement)
                    strMain.Commit();
               
                return dt;
            }
            catch (SqlException se)
            {
                if (!multiStatement)
                    strMain.Rollback();
                hasErrors = true;
                Utilities.WriteLogError(se.Message);
                return null;
            }
            finally
            {
                if (!multiStatement)
                    CloseConnection();
            }
        }
    }
}
