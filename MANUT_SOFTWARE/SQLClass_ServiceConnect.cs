using MANUT_SOFTWARE.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MANUT_SOFTWARE
{
    class SQLClass_ServiceConnect : IDisposable
    {

        public SqlConnection cnn;
        public List<NomeTabelle> _NomeTabelle = new List<NomeTabelle>
        {
            
        };

        



        public SqlConnection Open()
        {
             
    
            if ((cnn = _cnn()) == null)
            {
                this.Dispose();
            }
            return cnn;
        }

        public SqlConnection _cnn()
        {
            SqlConnection conn = null;
             string   server = @"DESKTOP-I3EQ1DG\SQLEXPRESS";
             string db = "Manutenzione";

           string cnnString = string.Format("Server={0};Database={1};Trusted_Connection=SSPI;", server, db);
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = cnnString;
                conn.Open();
                return conn;
            }
            catch
            {
                conn.Dispose();
                return null;
            }
        }


        public void Dispose()
        {
            if (cnn != null)
            {
                cnn.Dispose();
            }
        }
    }
}
