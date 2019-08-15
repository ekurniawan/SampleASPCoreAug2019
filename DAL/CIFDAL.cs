using System;
using System.Collections.Generic;
using System.Text;
using BO;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class CIFDAL : ICIF
    {
        private IConfiguration _config;
        public CIFDAL(IConfiguration config)
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

        public IEnumerable<CIF> GetAll()
        {
            List<CIF> lstCIF = new List<CIF>();
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"select Comp_ID,CIF_No,CIF_Name,CIF_Type from CIF order by CIF_Name asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        CIF objCIF = new CIF
                        {
                            Comp_ID = dr["Comp_ID"].ToString(),
                            CIF_No = dr["CIF_No"].ToString(),
                            CIF_Name = dr["CIF_Name"].ToString(),
                            CIF_Type = Convert.ToByte(dr["CIF_Type"])
                            /*CIF_Group = dr["CIF_Group"].ToString(),
                            CIF_Branch = dr["CIF_Branch"].ToString(),
                            CIF_UKMB = dr["CIF_UKMB"].ToString(),
                            CIF_EstablishDate = Convert.ToDateTime(dr["CIF_EstablishDate"])*/
                        };
                        lstCIF.Add(objCIF);
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();

                return lstCIF;
            }
        }

        public CIF GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(CIF obj)
        {
            throw new NotImplementedException();
        }

        public void Update(CIF obj)
        {
            throw new NotImplementedException();
        }
    }
}
