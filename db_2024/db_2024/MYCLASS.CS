using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_2024
{
    public class MYCLASS
    {
        // Private static instance of the class
        private static MYCLASS instance;

        // Private constructor to prevent instantiation outside the class
        private MYCLASS()
        {
            // Initialization code, if any
        }

        // Public method to access the singleton instance
        public static MYCLASS Instance
        {
            get
            {
                // If the instance is null, create a new instance
                if (instance == null)
                {
                    instance = new MYCLASS();
                }
                return instance;
            }
        }

        // Other members and methods of the class
        public int id { get; set; }
    }

}
