using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json;

using CreateCoreCertifications.Model;

namespace CreateCoreCertifications
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Trainee> trainees = TrainingBL.GetTrainees();
            //HttpResponseMessage response;
            int RecCount = 0;

            foreach (Trainee trainee in trainees)
            {
                try
                {
                    //QueryResult account = JsonConvert.DeserializeObject<QueryResult>(client.Query("SELECT Id,OwnerId from Account WHERE SAP_CUST_ID__c ='" + customer.customer_id + "'"));
                    //AccountId accid = new AccountId();
                    //Account acc = new Account();
                    //if (account.records.Count == 1) // always expect 1   
                    //{
                    //    accid = JsonConvert.DeserializeObject<AccountId>(account.records[0].ToString());
                    //}
                    //if (accid.Id != "")
                    //{
                    //    string crestron_dealer_data = null;
                    //    if (customer.customer_count.Count > 0)
                    //    {
                    //        foreach (CustomerCount customercount in customer.customer_count)
                    //        {
                    //            crestron_dealer_data += " " + customercount.PageLit.PadRight(8) +
                    //                                                "      Qtr 1:       " + customercount.qtr1.ToString().PadLeft(5) +
                    //                                                "      Qtr 2:       " + customercount.qtr2.ToString().PadLeft(5) +
                    //                                                "      Qtr 3:       " + customercount.qtr3.ToString().PadLeft(5) +
                    //                                                "      Qtr 4:       " + customercount.qtr4.ToString().PadLeft(5) +
                    //                                                "      Total:       " + customercount.current_year.ToString().PadLeft(5) +
                    //                                                "      Prior Year Total: " + customercount.prior_year.ToString().PadLeft(5) + CarriageReturn.ToString(); ;
                    //        }
                    //        crestron_dealer_data += " Certified Programmers: " + customer.certified_programmers.ToString().PadLeft(5) + CarriageReturn.ToString();
                    //    }
                    //    else
                    //    {
                    //        crestron_dealer_data += " No Data Available " + CarriageReturn.ToString();
                    //    }

                    //    crestron_dealer_data += " Data current as of " + DateTime.Now.ToString("MM/dd/yyyy") + CarriageReturn.ToString();
                    //    acc.Crestron_Dealer_Trainings__c = crestron_dealer_data;
                    //}
                    //string content = JsonConvert.SerializeObject(acc);
                    //response = client.Update("Account", accid.Id, content);
                    //RecCount++;
                }

                catch (Exception e)
                {
                    Console.WriteLine("Error Occurred during JsonConvert.DeserializeObject: customer id " + trainee.traineeid + " error" + e.ToString());
                }


            }

            Console.WriteLine("Create Core Certification Training records processed: '" + RecCount.ToString());
        }
    }
}
