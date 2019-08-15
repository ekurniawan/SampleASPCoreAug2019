using BO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class PraContractDAL : IPraContract
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
                string strSql = @"select ID,Comp_ID,CIF_No,ApplicationNo from PraContract order by ApplicationNo asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PraContract objPraContract = new PraContract
                        {
                            ID = dr["ID"].ToString(),
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
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"insert into PraContract(ID,Comp_ID,CIF_No,ApplicationNo) 
                   values(@ID,@Comp_ID,@CIF_No,@ApplicationNo)";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@ID", Guid.NewGuid().ToString());
                cmd.Parameters.AddWithValue("@CIF_No", obj.CIF_No);
                cmd.Parameters.AddWithValue("@Comp_ID", obj.Comp_ID);
                cmd.Parameters.AddWithValue("@ApplicationNo", obj.ApplicationNo);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Kesalahan: {sqlEx.Number}  Message: {sqlEx.Message}");
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public void Update(PraContract obj)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strsql = @"Update PraContract 
                                SET Comp_ID = @Comp_ID, CIF_No=@CIF_No, ApplicationNo=@ApplicationNo
                                WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(strsql, conn);
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@CIF_No", obj.CIF_No);
                cmd.Parameters.AddWithValue("@Comp_ID", obj.Comp_ID);
                cmd.Parameters.AddWithValue("@ApplicationNo", obj.ApplicationNo);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Kesalahan: {sqlEx.Number}  Message: {sqlEx.Message}");
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public IEnumerable<PraContract> GetByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                List<PraContract> listPraContract = new List<PraContract>();
                string strsql = @"SELECT Comp_ID, ID, CIF_No, ApplicationNo FROM PraContract 
                                WHERE ApplicationNo like @ApplicationNo order By ApplicationNo asc";
                SqlCommand cmd = new SqlCommand(strsql, conn);
                cmd.Parameters.AddWithValue("@ApplicationNo", $"%{name}%");

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
                            ID = dr["ID"].ToString(),
                            ApplicationNo = dr["ApplicationNo"].ToString()
                        };
                        listPraContract.Add(objPraContract);
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();

                return listPraContract;

            }
        }
    }
}
