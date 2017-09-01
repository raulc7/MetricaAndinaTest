using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessEntity;
using System.Data;
using System.Data.SqlClient;

namespace RepositoryLibrary
{
    public class BankRepository
    {
        public List<BankBE> GetAllBank()
        {
            List<BankBE> bankList = new List<BankBE>();

            using (SqlConnection conn = new SqlConnection(ConnectionData.dbCn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_bankList", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    BankBE b;
                    while (dr.Read())
                    {
                        b = new BankBE();
                        b.Id = Convert.ToInt32(dr["id"].ToString());
                        b.Name = dr["name"].ToString();
                        b.Address = dr["address"].ToString();
                        b.RegistrationDate = Convert.ToDateTime(dr["registration_date"]);

                        bankList.Add(b);
                    }
                }
            }

            return bankList;
        }

        public void AddBank(BankBE b)
        {
            Int32 r = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionData.dbCn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_addBank", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = b.Name;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = b.Address;
                cmd.Parameters.Add("@registration_date", SqlDbType.DateTime).Value = b.RegistrationDate;

                r = cmd.ExecuteNonQuery();
            }
        }

        public void UpdateBank(BankBE b)
        {
            Int32 r = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionData.dbCn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_updateBank", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = b.Id;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = b.Name;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = b.Address;

                r = cmd.ExecuteNonQuery();
            }

        }

        public void DeleteBank(Int32 Id)
        {
            Int32 r = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionData.dbCn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_deleteBank", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = Id;

                r = cmd.ExecuteNonQuery();
            }
        }
    }
}
