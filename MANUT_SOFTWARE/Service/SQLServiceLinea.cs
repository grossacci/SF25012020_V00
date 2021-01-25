using MANUT_SOFTWARE.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MANUT_SOFTWARE.Service
{
    class SQLServiceLinea : SQLClass_ServiceConnect
    {
        public void Insert_INTO(string Codice, string Nome)
        {

            LineaViewModel Linea = new LineaViewModel();
     
            
            string query = "INSERT INTO LineaSQL ("+ nameof(Linea.Codice)+"," + nameof(Linea.Nome)+") VALUES(@Codice, @Nome)";
            SqlCommand cmd = new SqlCommand(query,Open());

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@Codice", Codice);
            cmd.Parameters.AddWithValue("@Nome", Nome);

            try
            {
                 cmd.ExecuteNonQuery();
                MessageBox.Show("Records Inserted Successfully");
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                Dispose();
            }
            
        }

        public void Select()
        {


            using (SqlCommand command = new SqlCommand("select * from LineaSQL", Open()))
            {
              
                using (SqlDataReader reader = myCommand.ExecuteReader())
                {
                    // iterate your results here
                }
            }




        }
    }
}
