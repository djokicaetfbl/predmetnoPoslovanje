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
    /// Summary description for WebServicePredmetnoPoslovanje
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServicePredmetnoPoslovanje : System.Web.Services.WebService
    {
        [WebMethod]
        //public int InsertPredmet(Predmet obj)
        public int InsertPredmet(DateTime datumOtvaranja, string vrstaPredmeta, string nazivPredmeta, string napomena)
        {
            Predmet obj = new Predmet(datumOtvaranja, vrstaPredmeta, nazivPredmeta, napomena);

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                DynamicParameters p = new DynamicParameters();
                p.Add("@IdPredmeta", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new { DatumOtvaranja = obj.DatumOtvaranja, VrstaPredmeta = obj.VrstaPredmeta, NazivPredmeta = obj.NazivPredmeta, Napomena = obj.Napomena });
                int result = db.Execute("sp_Predmet_Insert", p, commandType: CommandType.StoredProcedure);
                if (result != 0)
                    return p.Get<int>("@IdPredmeta");
                return 0;
            }
        }

        [WebMethod]
        //public bool UpdatePredmet(Predmet obj)
        public bool UpdatePredmet(DateTime datumOtvaranja, string vrstaPredmeta, string nazivPredmeta, string napomena)
        {
            Predmet obj = new Predmet(datumOtvaranja, vrstaPredmeta, nazivPredmeta, napomena);
            obj.IdPredmeta = 2;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute("sp_Predmet_Update", new { IdPredmeta = 2, DatumOtvaranja = obj.DatumOtvaranja, VrstaPredmeta = obj.VrstaPredmeta, NazivPredmeta = obj.NazivPredmeta, Napomena = obj.Napomena }, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        [WebMethod]
        public List<Predmet> GetAllPredmets()
        {
            string sql = "select * from Predmet";
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<Predmet>(sql, commandType: CommandType.Text).ToList();
            }
        }

        [WebMethod]
        public bool DeletePredmet(int predmetId)
        {
            string sql = "delete from Predmet where IdPredmeta = @IdPredmeta";
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute(sql, new { IdPredmeta = predmetId }, commandType: CommandType.Text);
                return result != 0;
            }
        }
    }
}
