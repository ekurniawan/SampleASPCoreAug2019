using BO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class PraContractDAL : PraContract
    {
        private IConfiguration _config;
        public PraContractDAL(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnString()
        {
            return _config.GetConnectionString("DefaultConnection");
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PraContract> GetAll()
        {
            List<PraContract> lstPraContract = new List<PraContract>();
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"select Comp_ID,CIF_No,ApplicationNo from PraContract order by ApplicationNo asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PraContract objPraContract = new PraContract
                        {
                            Comp_ID = dr["Comp_ID"].ToString(),
                            CIF_No = dr["CIF_No"].ToString(),
                            ApplicationNo = dr["ApplicationNo"].ToString()
                        };
                        lstPraContract.Add(objPraContract);
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();

                return lstPraContract;
            }
        }

        public PraContract GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(PraContract obj)
        {
            throw new NotImplementedException();
        }

        public void Update(PraContract obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PraContract> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
