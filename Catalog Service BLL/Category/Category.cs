using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Service_BLL
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name 
        { 
          get { return Name; }
          set 
            {  
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("value"); 
                if (value.Length > 50) throw new ArgumentOutOfRangeException("value");
                Name = value; 
            }
        }
        public string Image { get; set; }
        public Category? Parent { get; set; }
    }
}
