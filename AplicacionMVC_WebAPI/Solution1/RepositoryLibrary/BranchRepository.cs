using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessEntity;
using System.Data;
using System.Data.SqlClient;

namespace RepositoryLibrary
{
    public class BranchRepository
    {
        public List<BranchBE> GetAllBranch(Int32 BankId)
        {
            List<BranchBE> branchList = new List<BranchBE>();

            using (SqlConnection conn = new SqlConnection(ConnectionData.dbCn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_branchList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@bank_id", SqlDbType.Int).Value = BankId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    BranchBE br;
                    while (dr.Read())
                    {
                        br = new BranchBE();
                        br.Id = Convert.ToInt32(dr["id"].ToString());
                        br.BankId = Convert.ToInt32(dr["bank_id"].ToString());
                        br.Name = dr["name"].ToString();
                        br.Address = dr["address"].ToString();
                        br.RegistrationDate = Convert.ToDateTime(dr["registration_date"]);
                        br.BankName = dr["bank_name"].ToString();

                        branchList.Add(br);
                    }
                }
            }

            return branchList;
        }

        public void AddBranch(BranchBE br)
        {
            Int32 r = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionData.dbCn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_addBranch", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@bank_id", SqlDbType.Int).Value = br.BankId;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = br.Name;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = br.Address;
                cmd.Parameters.Add("@registration_date", SqlDbType.DateTime).Value = br.RegistrationDate;

                r = cmd.ExecuteNonQuery();
            }

        }

        public void UpdateBranch(BranchBE br)
        {
            Int32 r = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionData.dbCn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_updateBranch", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = br.Id;
                cmd.Parameters.Add("@bank_id", SqlDbType.Int).Value = br.BankId;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = br.Name;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = br.Address;

                r = cmd.ExecuteNonQuery();
            }

        }

        public void DeleteBranch(Int32 Id)
        {
            Int32 r = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionData.dbCn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_deleteBranch", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = Id;

                r = cmd.ExecuteNonQuery();
            }
        }
    }
}
