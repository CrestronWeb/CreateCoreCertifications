using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateCoreCertifications.Model;
using CreateCoreCertifications.DAL;



namespace CreateCoreCertifications
{
    class TrainingBL
    {
        public static List<Trainee> GetTrainees()
        {
            List<Trainee> trainees = new List<Trainee>();
            TrainingDAL tDAL = new TrainingDAL();
            trainees = tDAL.GetTrainees();
            return trainees;
        }
    }
}
