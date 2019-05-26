using System.Collections.Generic;
using System.Data;

namespace LillyVKR
{
    static class Calculation
    {
        static List<Illness> Illnesses;
        public static List<Category> categories;

        static Calculation()
        {
            myDB.Init();
            Illnesses = new List<Illness>();
            categories = new List<Category>();
            DataTable categorys = myDB.SELECT_ALL("Category");
            for (int i = 0; i < categorys.Rows.Count; i++)
            {
                categories.Add(new Category(
                    int.Parse((string)categorys.Rows[i][0]),
                    (string)categorys.Rows[i][1],
                    bool.Parse((string)categorys.Rows[i][2])
                    )
                    );
            }

            DataTable illness = myDB.SELECT_ALL("Illness");
            for (int i = 0; i < illness.Rows.Count; i++)
            {
                Illnesses.Add(new Illness(int.Parse((string)illness.Rows[i][0]), (string)illness.Rows[i][1]));
            }

        }

        public static Dictionary<Illness, double> Probabilities(Dictionary<int, bool> PatientSymptoms)
        {
            Dictionary<Illness, double> diagnose = new Dictionary<Illness, double>();
            foreach (Illness ill in Illnesses)
            {
                double sum = 0;
                foreach (var par in PatientSymptoms)
                    if (par.Value && ill.Presnce[par.Key])
                        sum += ill.Coefficients[par.Key];
                diagnose.Add(ill, sum);
            }
            return diagnose;
        }

    }
}
