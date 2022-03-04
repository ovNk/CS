using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13
{

    [Obsolete("Устаревший класс!", error:false)]class Bow : IWeapon
    {
        
        public void Sharpen()
        {
            Console.WriteLine("Work");
        }
    }
}
