using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13
{
    class Gunshot : System.Attribute
    {
            private string name;
            

            public Gunshot(string name)
            {
                this.name = name;
                
            }
        
    }
}
