﻿using MANUT_SOFTWARE.ViewModels;
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
    class SQLServiceLinea : SQLClass_ServiceConnect
    {
        public void LineaSQL_INSERT(string Codice, string Nome)
        {

            LineaViewModel Linea = new LineaViewModel();
            NomeTabelle Manutenzione = new NomeTabelle();

            string query = "INSERT INTO " + Manutenzione.LineaSQL+" ("+ nameof(Linea.Codice)+"," + nameof(Linea.Nome)+") VALUES(@Codice, @Nome)";
            SqlCommand cmd = new SqlCommand(query,Open());

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@Codice", Codice);
            cmd.Parameters.AddWithValue("@Nome", Nome);

            try
            {
                 cmd.ExecuteNonQuery();
                MessageBox.Show("La linea è stata inserita correttamente");
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

        public List<LineaViewModel> LineaSQL_SELECT()

        {

            List<LineaViewModel> LL = new List<LineaViewModel>();
            DataTable dr = new DataTable();
            NomeTabelle Manutenzione = new NomeTabelle();

            using (SqlCommand command = new SqlCommand("SELECT* FROM " + Manutenzione.LineaSQL, Open()))
            {
                // result gives the -1 output.. but on insert its 1
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // iterate your results here
                    while (reader.Read())
                    {
                        LineaViewModel L = new LineaViewModel();
                        L.ID = (Int32)reader["ID"];
                        L.Codice = reader["Codice"].ToString();
                        L.Nome = reader["Nome"].ToString();
                        LL.Add(L);

                    }
                    return LL;
                }

            }
            }




        
  


    }
}
