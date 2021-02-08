using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PredmetnoPoslovanjeNET
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        //public int InsertRadnik(Radnik obj)
        public int InsertRadnik(string imeIPrezime, string pozicija, string sektor, int brojTelefona, DateTime datumZaposljavanja) // za potrebe testiranja, simulacije
        {
            Radnik obj = new Radnik(imeIPrezime, pozicija, sektor, brojTelefona, datumZaposljavanja);

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                DynamicParameters p = new DynamicParameters();
                p.Add("@IdRadnika", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new { ImeIPrezime = obj.ImeIPrezime, Pozicija = obj.Pozicija, Sektor = obj.Sektor, BrojTelefona = obj.BrojTelefona, DatumZaposljavanja = obj.DatumZaposljavanja });
                int result = db.Execute("sp_Radnik_Insert", p, commandType: CommandType.StoredProcedure);
                if (result != 0)
                    return p.Get<int>("@IdRadnika");
                return 0;
            }
        }

        [WebMethod]
        //public bool UpdateRadnik(Radnik obj)
        public bool UpdateRadnik(string imeIPrezime, string pozicija, string sektor, int brojTelefona, DateTime datumZaposljavanja)
        {
            Radnik obj = new Radnik(imeIPrezime, pozicija, sektor, brojTelefona, datumZaposljavanja);
            obj.IdRadnika = 1;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute("sp_Radnik_Update", new { IdRadnika = obj.IdRadnika, ImeIPrezime = obj.ImeIPrezime, Pozicija = obj.Pozicija, Sektor = obj.Sektor, BrojTelefona = obj.BrojTelefona, DatumZaposljavanja = obj.DatumZaposljavanja }, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        [WebMethod]
        public List<Radnik> GetAllRadniks()
        {
            string sql = "select * from Radnik";
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<Radnik>(sql, commandType: CommandType.Text).ToList();
            }
        }

        [WebMethod]
        public bool DeleteRadnik(int radnikId)
        {
            string sql = "delete from Radnik where IdRadnika = @IdRadnika";
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute(sql, new { IdRadnika = radnikId }, commandType: CommandType.Text);
                return result != 0;
            }
        }
    }
}
