using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; 

namespace LillyVKR
{
    public class Illness
    {
        public Dictionary<int, bool> Presnce;
        public Dictionary<int, double> Coefficients;
    
        public string Name;
        int id;
        public Illness(int id, string name)
        {

            this.id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));

            DataTable symps = myDB.SELECT(
                new List<string>() { "SymptomId", "Presence", "Coefficient" },
                new List<string>() { "SymptomForIllness" },
                new List<string>() { $"IllnessId={id}" }
                );


            Presnce = new Dictionary<int, bool>();
            Coefficients = new Dictionary<int, double>();

            for(int i =0; i<symps.Rows.Count; i++)
            {
                int sid = int.Parse((string)symps.Rows[i][0]);
                bool symP = bool.Parse((string)symps.Rows[i][1]);
                double symC = double.Parse((string)symps.Rows[i][2]);

                Presnce.Add(sid, symP);
                Coefficients.Add(sid, symC);
            }

        }
    }
}
