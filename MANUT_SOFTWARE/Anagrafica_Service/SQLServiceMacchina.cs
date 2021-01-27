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
    class SQLServiceMacchina : SQLClass_ServiceConnect
    {
        public void MacchinaSQL_INSERT(string Codice, string Fornitore ,DateTime DataArrivo, string Denominazione, string Reparto, string Linea, string Taratura, string _Manutenzione, string Verifica, string Dismissione, string Modello, string Matricola, DateTime AnnoDiCostruzione)
        {

            MacchineViewModel Macchina = new MacchineViewModel();
            NomeTabelle Manutenzione = new NomeTabelle();

            string query = "INSERT INTO " + Manutenzione.MacchineSQL+" ("+ nameof(Macchina.Codice)+"," + nameof(Macchina.Fornitore) + "," + nameof(Macchina.DataArrivo)+ " "+ nameof(Macchina.Denominazione) + "," + nameof(Macchina.Reparto) + " " + nameof(Macchina.Linea) + "," + nameof(Macchina.Taratura) + " " + nameof(Macchina.Manutenzione) + "," + nameof(Macchina.Verifica) + " " + nameof(Macchina.Dismissione) + "," + nameof(Macchina.Modello) + "," + nameof(Macchina.Matricola) + "," + nameof(Macchina.AnnoDiCostruzione) + ") VALUES(@Codice, @DataArrivo,@Denominazione,@Reparto,@Linea,@Taratura,@Manutenzione,@Verifica,@Dismissione,@Modello,@Matricola,@AnnoDiCostruzione)";
            SqlCommand cmd = new SqlCommand(query,Open());

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@Codice", Codice);
            cmd.Parameters.AddWithValue("@Fornitore", Fornitore);
            cmd.Parameters.AddWithValue("@DataArrivo", DataArrivo);
            cmd.Parameters.AddWithValue("@Denominazione", Denominazione);
            cmd.Parameters.AddWithValue("@Reparto", Reparto);
            cmd.Parameters.AddWithValue("@Linea", Linea);
            cmd.Parameters.AddWithValue("@Taratura", Taratura);
            cmd.Parameters.AddWithValue("@Manutenzione", Manutenzione);
            cmd.Parameters.AddWithValue("@Verifica", Verifica);
            cmd.Parameters.AddWithValue("@Dismissione", Dismissione);
            cmd.Parameters.AddWithValue("@Modello", Modello);
            cmd.Parameters.AddWithValue("@Matricola", Matricola);
            cmd.Parameters.AddWithValue("@AnnoDiCostruzione", AnnoDiCostruzione);

            try
            {
                 cmd.ExecuteNonQuery();
                MessageBox.Show("La Macchina è stata inserita correttamente");
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


        public List<MacchineViewModel> MacchinaSQL_SELECT()

        {

            List<MacchineViewModel> LM = new List<MacchineViewModel>();
            DataTable dr = new DataTable();
            NomeTabelle Manutenzione = new NomeTabelle();

            using (SqlCommand command = new SqlCommand("SELECT* FROM " + Manutenzione.MacchineSQL, Open()))
            {
                // result gives the -1 output.. but on insert its 1
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // iterate your results here
                    while (reader.Read())
                    {
                        MacchineViewModel M = new MacchineViewModel();
                        M.ID = (Int32)reader["ID"];
                        M.Codice = reader["Codice"].ToString();
                        M.Fornitore= reader["Fornitore"].ToString();
                        M.DataArrivo=(DateTime)reader["DataArrivo"];
                        M.Denominazione= reader["Denominazione"].ToString();
                        M.Reparto = reader["Reparto"].ToString();
                        M.Linea = reader["Linea"].ToString();
                        M.Taratura= reader["Taratura"].ToString();
                        M.Manutenzione= reader["Manutenzione"].ToString();
                        M.Verifica= reader["Verifica"].ToString();
                        M.Dismissione= reader["Dismissione"].ToString();
                        M.Modello= reader["Modello"].ToString();
                        M.Matricola= reader["Matricola"].ToString();
                        M.AnnoDiCostruzione= (DateTime)reader["AnnoDiCostruzione"];
                        LM.Add(M);


                    }
                    return LM;
                }

            }
            }




        
  


    }
}
