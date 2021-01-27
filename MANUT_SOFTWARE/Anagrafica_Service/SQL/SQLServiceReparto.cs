using MANUT_SOFTWARE.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MANUT_SOFTWARE.Service
{
    class SQLServiceReparto : SQLClass_ServiceConnect
    {
        public void RepartoSQL_INSERT(string Codice, string Nome)
        {

            RepartoViewModel Reparto = new RepartoViewModel();
            NomeTabelle Manutenzione = new NomeTabelle();

            string query = "INSERT INTO " + Manutenzione.RepartoSQL+" ("+ nameof(Reparto.Codice)+"," + nameof(Reparto.Nome)+") VALUES(@Codice, @Nome)";
            SqlCommand cmd = new SqlCommand(query,Open());

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@Codice", Codice);
            cmd.Parameters.AddWithValue("@Nome", Nome);

            try
            {
                 cmd.ExecuteNonQuery();
                MessageBox.Show("Il reparto è stato inserito correttamente");
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

        public List<RepartoViewModel> RepartoSQL_SELECT()

        {

            List<RepartoViewModel> LP = new List<RepartoViewModel>();
            DataTable dr = new DataTable();
            NomeTabelle Manutenzione = new NomeTabelle();

            using (SqlCommand command = new SqlCommand("SELECT* FROM " + Manutenzione.RepartoSQL, Open()))
            {
                // result gives the -1 output.. but on insert its 1
                using (SqlDataReader reader = command.ExecuteReader())
                {
               
                    // iterate your results here
                    while (reader.Read())
                    {
                        RepartoViewModel R = new RepartoViewModel();
                        R.ID = (Int32)reader["ID"];
                        R.Codice = reader["Codice"].ToString();
                        R.Nome = reader["Nome"].ToString();
                        LP.Add(R);

                    }

                    return LP;
                }

            }
            }




        
  


    }
}
