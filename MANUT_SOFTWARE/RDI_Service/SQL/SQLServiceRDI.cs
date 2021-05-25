using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MANUT_SOFTWARE.RDIViewModels;
using MANUT_SOFTWARE;
namespace MANUT_SOFTWARE.RDI_Service.SQL
{
    class SQLServiceRDI
    {
        public void RDISQL_INSERT(string CodRdi, DateTime DataIns, DateTime OraInizio, DateTime OraFine,DateTime DataVerifica,bool EffSINO,bool ChiusoSINO, string Macchina,string CodMacchina,string DescrizioneIntervento,string MaterialeImpiegato,string Note,string NomeCognomeOP,string FirmaOP,string FirmaRespManut)
        {
            RDIViewModel RDI = new RDIViewModel();

            
             Manutenzione = new SQLServiceNomeTabelle();

            string query = "INSERT INTO " + Manutenzione.LineaSQL + " (" + nameof(Linea.Codice) + "," + nameof(Linea.Nome) + "," + nameof(Linea.RepartoAssociato) + ") VALUES(@Codice, @Nome,@RepartoAssociato)";
            SqlCommand cmd = new SqlCommand(query, Open());

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@Codice", Codice);
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@RepartoAssociato", RepartoAssociato);
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

    }
}
