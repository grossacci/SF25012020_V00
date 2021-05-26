using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MANUT_SOFTWARE.RDIViewModels;
using MANUT_SOFTWARE;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MANUT_SOFTWARE.RDI_Service.SQL
{
    class SQLServiceRDI : SQLClass_ServiceConnect
    {
        public void RDISQL_INSERT(string CodRdi, DateTime DataIns, DateTime OraInizio, DateTime OraFine,DateTime DataVerifica,bool EffSINO,bool ChiusoSINO, string Macchina,string CodMacchina,string DescrizioneIntervento,string MaterialeImpiegato,string Note,string NomeCognomeOP,string FirmaOP,string FirmaRespManut)
        {
            RDIViewModel RDI = new RDIViewModel();
            SQLServiceNomeTabelle Manutenzione = new SQLServiceNomeTabelle();
            Manutenzione = new SQLServiceNomeTabelle();
            string query = "INSERT INTO " + Manutenzione.RdiSQL + " (" + nameof(RDI.CodRdi) + "," + nameof(RDI.DataIns) + "," + nameof(RDI.OraInizio) + "," + nameof(RDI.OraFine) + "," + nameof(RDI.DataVerifica) + "," + nameof(RDI.EffSINO) + "," + nameof(RDI.ChiusoSINO) + "," + nameof(RDI.Macchina) + "," + nameof(RDI.CodMacchina) + "," + nameof(RDI.DescrizioneIntervento) + "," + nameof(RDI.MaterialeImpiegato) + "," + nameof(RDI.Note) + "," + nameof(RDI.NomeCognomeOP) + "," + nameof(RDI.FirmaOP) + "," + nameof(RDI.FirmaRespManut) + ") VALUES(@CodRdi, @DataIns,@OraInizio,@OraFine,@DataVerifica,@EffSINO,@ChiusoSINO,@Macchina,@CodMacchina,@DescrizioneIntervento,@MaterialeImpiegato,@Note,@NomeCognomeOP,@FirmaOP,@FirmaRespManut)";
            SqlCommand cmd = new SqlCommand(query, Open());

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@CodRdi", CodRdi);
            cmd.Parameters.AddWithValue("@DataIns", DataIns);
            cmd.Parameters.AddWithValue("@OraInizio", OraInizio);
            cmd.Parameters.AddWithValue("@OraFine", OraFine);
            cmd.Parameters.AddWithValue("@DataVerifica", DataVerifica);
            cmd.Parameters.AddWithValue("@EffSINO", EffSINO);
            cmd.Parameters.AddWithValue("@ChiusoSINO", ChiusoSINO);
            cmd.Parameters.AddWithValue("@Macchina", Macchina);
            cmd.Parameters.AddWithValue("@CodMacchina", CodMacchina);
            cmd.Parameters.AddWithValue("@DescrizioneIntervento", DescrizioneIntervento);
            cmd.Parameters.AddWithValue("@MaterialeImpiegato", MaterialeImpiegato);
            cmd.Parameters.AddWithValue("@Note", Note);
            cmd.Parameters.AddWithValue("@NomeCognomeOP", NomeCognomeOP);
            cmd.Parameters.AddWithValue("@FirmaOP", FirmaOP);
            cmd.Parameters.AddWithValue("@FirmaRespManut", FirmaRespManut);

            
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("L'RDI è stato inserito correttamente!");
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
