using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using Dapper;

namespace PredmetnoPoslovanjeNET
{
    /// <summary>
    /// Summary description for WebServicePredmetnoPoslovanjeAkt
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServicePredmetnoPoslovanjeAkt : System.Web.Services.WebService
    {
        [WebMethod]
        //public int InsertAkt(Akt akt)
        public int InsertAkt(DateTime datumPrijema, string nazivAkta, string posiljalac, int idPredmeta) // za potrebe testiranja, simulacije
        {
            Akt obj = new Akt(datumPrijema, nazivAkta, posiljalac, idPredmeta);

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                DynamicParameters p = new DynamicParameters();
                p.Add("@IdAkta", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new { DatumPrijema = obj.DatumPrijema, NazivAkta = obj.NazivAkta, Posiljalac = obj.Posiljalac, IdPredmeta = obj.IdPredmeta });
                int result = db.Execute("sp_Akt_Insert", p, commandType: CommandType.StoredProcedure);
                if (result != 0)
                    return p.Get<int>("@IdAkta");
                return 0;
            }
        }

        [WebMethod]
        //public bool UpdateAkt(Akt obj)
        public bool UpdateAkt(DateTime datumPrijema, string nazivAkta, string posiljalac, int idPredmeta)
        {
            Akt obj = new Akt(datumPrijema, nazivAkta, posiljalac, idPredmeta);
            obj.IdAkta = 2;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute("sp_Akt_Update", new { IdAkta = obj.IdAkta, DatumPrijema = obj.DatumPrijema, NazivAkta = obj.NazivAkta, Posiljalac = obj.Posiljalac, IdPredmeta = obj.IdPredmeta }, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        [WebMethod]
        public List<Akt> GetAllAkts()
        {
            string sql = "select * from Akt";
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<Akt>(sql, commandType: CommandType.Text).ToList();
            }
        }

        [WebMethod]
        public bool DeleteAkt(int aktId)
        {
            string sql = "delete from Akt where IdAkta = @IdAkta";
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute(sql, new { IdAkta = aktId }, commandType: CommandType.Text);
                return result != 0;
            }
        }
    }
}
