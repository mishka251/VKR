using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LillyVKR
{
  public  class Symptom
    {
        public string Name;
        public Category Category;
        public int id;

        public Symptom(int id, string name, Category category)
        {
            this.id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Category = category ?? throw new ArgumentNullException(nameof(category));
        }
    }
}
