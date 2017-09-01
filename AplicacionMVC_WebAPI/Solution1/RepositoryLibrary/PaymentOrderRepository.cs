using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessEntity;
using System.Data;
using System.Data.SqlClient;

namespace RepositoryLibrary
{
    public class PaymentOrderRepository
    {
        public List<PaymentOrderBE> GetAllPaymentOrder(Int32 CurrencyId)
        {
            List<PaymentOrderBE> paymentOrderList = new List<PaymentOrderBE>();

            using (SqlConnection conn = new SqlConnection(ConnectionData.dbCn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_paymentOrderList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@currency_id", SqlDbType.Int).Value = CurrencyId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    PaymentOrderBE po;
                    while (dr.Read())
                    {
                        po = new PaymentOrderBE();
                        po.Id = Convert.ToInt32(dr["id"].ToString());
                        po.Amount = Convert.ToDecimal(dr["amount"].ToString());
                        po.PaymentDate = Convert.ToDateTime(dr["payment_date"]);
                        po.BranchId = Convert.ToInt32(dr["branch_id"].ToString());
                        po.BranchName = dr["branch_name"].ToString();
                        po.CurrencyId = Convert.ToInt32(dr["currency_id"].ToString());
                        po.CurrencyName = dr["currency_name"].ToString();
                        po.CurrencySymbol = dr["currency_symbol"].ToString();
                        po.CurrencyIso = dr["currency_iso"].ToString();
                        po.PaymentStateId = Convert.ToInt32(dr["payment_state_id"].ToString());
                        po.PaymentStateName = dr["payment_state_name"].ToString();

                        paymentOrderList.Add(po);
                    }
                }
            }

            return paymentOrderList;
        }

        public void AddPaymentOrder(PaymentOrderBE po)
        {
            Int32 r = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionData.dbCn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_addPaymentOrder", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@branch_id", SqlDbType.Int).Value = po.BranchId;
                cmd.Parameters.Add("@currency_id", SqlDbType.Int).Value = po.CurrencyId;
                cmd.Parameters.Add("@payment_state_id", SqlDbType.Int).Value = po.PaymentStateId;
                cmd.Parameters.Add("@amount", SqlDbType.Decimal).Value = po.Amount;

                r = cmd.ExecuteNonQuery();
            }
        }

        public void UpdatePaymentOrder(PaymentOrderBE po)
        {
            Int32 r = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionData.dbCn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_updatePaymentOrder", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = po.Id;
                cmd.Parameters.Add("@branch_id", SqlDbType.Int).Value = po.BranchId;
                cmd.Parameters.Add("@currency_id", SqlDbType.Int).Value = po.CurrencyId;
                cmd.Parameters.Add("@payment_state_id", SqlDbType.Int).Value = po.PaymentStateId;
                cmd.Parameters.Add("@amount", SqlDbType.Decimal).Value = po.Amount;

                r = cmd.ExecuteNonQuery();
            }

        }

        public void DeletePaymentOrder(Int32 Id)
        {
            Int32 r = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionData.dbCn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_deletePaymentOrder", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = Id;

                r = cmd.ExecuteNonQuery();
            }
        }

        public List<PaymentStateBE> GetAllPaymentState()
        {
            List<PaymentStateBE> paymentStateList = new List<PaymentStateBE>();

            using (SqlConnection conn = new SqlConnection(ConnectionData.dbCn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_paymentStateList", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    PaymentStateBE ps;
                    while (dr.Read())
                    {
                        ps = new PaymentStateBE();
                        ps.Id = Convert.ToInt32(dr["id"].ToString());                        
                        ps.Name = dr["name"].ToString();

                        paymentStateList.Add(ps);
                    }
                }
            }

            return paymentStateList;
        }

        public List<CurrencyBE> GetAllCurrency()
        {
            List<CurrencyBE> currencyList = new List<CurrencyBE>();

            using (SqlConnection conn = new SqlConnection(ConnectionData.dbCn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_currencyList", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    CurrencyBE c;
                    while (dr.Read())
                    {
                        c = new CurrencyBE();
                        c.Id = Convert.ToInt32(dr["id"].ToString());
                        c.Name = dr["name"].ToString();
                        c.Symbol = dr["symbol"].ToString();
                        c.Iso = dr["iso"].ToString();

                        currencyList.Add(c);
                    }
                }
            }

            return currencyList;
        }
    }
}
