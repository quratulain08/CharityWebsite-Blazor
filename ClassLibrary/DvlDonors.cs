using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using  ClassLibraryModel;

namespace ClassLibrary
{
    public class DvlDonors
    {
        //@DonorName, @DonorEmail, @DonorContact, @OrganizationName, @DonorCNIC, @AccountNumber, @BankName, @Amount
        public static void SaveDonorInformation(ModelDonors md)
        {
            SqlConnection con = DbHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SaveDonorInformation",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DonorName",md.DonorName);
            cmd.Parameters.AddWithValue("@DonorEmail", md.DonorEmail);
            cmd.Parameters.AddWithValue("@DonorContact", md.DonorContact);
            cmd.Parameters.AddWithValue("@OrganizationName", md.OrganizationName);
            cmd.Parameters.AddWithValue("@DonorCNIC", md.DonorCNIC);
            cmd.Parameters.AddWithValue("@AccountNumber",md.AccountNumber);
            cmd.Parameters.AddWithValue("@BankName", md.BankName);
            cmd.Parameters.AddWithValue("@Amount", md.Amount);
            cmd.ExecuteNonQuery();
            con.Close();

        }  
        public static List<ModelDonors> GetDonorInformationList()
        {

            SqlConnection con = DbHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("GetDonorInformationList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<ModelDonors> listDonors = new List<ModelDonors>();
            while (reader.Read()) { 
                ModelDonors donor= new ModelDonors();
                donor.DonorId = Convert.ToInt32(reader["DonorId"]);
                donor.DonorName = reader["DonorName"].ToString();
                donor.DonorEmail = reader["DonorEmail"].ToString();
                donor.DonorContact = reader["DonorContact"].ToString();
                donor.OrganizationName = reader["OrganizationName"].ToString();
                donor.DonorCNIC = reader["DonorCNIC"].ToString();
                donor.AccountNumber = reader["AccountNumber"].ToString();
                donor.BankName = reader["BankName"].ToString();
                donor.Amount = reader["Amount"].ToString();
                listDonors.Add(donor);
            }
            con.Close();
            return listDonors;
        }
        public static void UpdateDonorInformation()
        {

        }
        public static void DeleteDonorInformation(int id)
        {
            SqlConnection con = DbHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteDonorInformation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DonorId", id);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}
