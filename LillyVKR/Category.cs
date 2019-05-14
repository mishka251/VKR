﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LillyVKR
{
  public  class Category
    {
       public string Name;
       public List<Symptom> Symptoms;
        int id;

        public Category(int id, string name)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            Symptoms = new List<Symptom>();

            DataTable symps = myDB.SELECT(
               new List<string>() { "Id", "Name" },
               new List<string>() { "Symptom" },
               new List<string>() { $"CategoryID = {id}" }
                );
            for(int i =0; i<symps.Rows.Count; i++)
            {
                Symptoms.Add(new Symptom(int.Parse((string)symps.Rows[i][0]), (string)symps.Rows[i][1], this));

            }
        }
    }
}