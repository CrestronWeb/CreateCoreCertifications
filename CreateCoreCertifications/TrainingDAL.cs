using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CreateCoreCertifications.Model;
using System.Configuration;

namespace CreateCoreCertifications.DAL
{
    class TrainingDAL
    {
        public List<Trainee> GetTrainees()
        {
            List<Trainee> trainees = new List<Trainee>();
            int counter = 0;

            try
            {
                DataConnection connection = new DataConnection();
                connection.Open();
                SqlDataReader reader1 = connection.ProcedureExecuteReader("sp_tempTrainee_GetAll");
                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        Trainee trainee = new Trainee();
                        SqlDataReader reader2 = connection.ProcedureExecuteReader("sp_TraineeCertification _Certify", new SqlParameter[] { new SqlParameter("@pTraineeId", reader1["TraineeID"]), new SqlParameter("@pLocationId", ConfigurationManager.AppSettings["LocationId"]), new SqlParameter("@pCertificationID", ConfigurationManager.AppSettings["CertificationID"]), new SqlParameter("@pClassEndDate", ConfigurationManager.AppSettings["ClassEndDate"]), new SqlParameter("@pEmployee", ConfigurationManager.AppSettings["Employee"]) });
                        reader2.Close();
                        reader2.Dispose();

                        SqlDataReader reader3 = connection.ProcedureExecuteReader("sp_TraineeCertificationCompletionDates_Insert", new SqlParameter[] { new SqlParameter("@pTraineeId", reader1["TraineeID"]), new SqlParameter("@pCertified", 2), new SqlParameter("@pCertificationID", ConfigurationManager.AppSettings["CertificationID"])  });
                        reader3.Close();
                        reader3.Dispose();

                        trainee.traineeid = reader1["TraineeID"].ToString();
                        counter = counter++;
                        trainees.Add(trainee);
                    }
                }

                // Close and Dispose of the Reader and Connection
                reader1.Close();
                reader1.Dispose();
                connection.Close();
                connection.Dispose();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Occurred Retrieving Customer Data: " + e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred Retrieving Customer Data: " + e.ToString());
            }
            return trainees;
        }
    }
}
