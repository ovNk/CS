using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13
{
    interface IWeapon
    {
        [Obsolete("Устаревший метод!", error:true)] void Sharpen();
        
    }
}
