using System;
using System.Collections.Generic;
using System.Text;

namespace EF2
{
     public class CategoryDetails
    {
        public int CategoryDetailID { get; set; }
        public int Used { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
        public int CountProducts { get; set; }
        public Category Category { set; get; }

    }
}
