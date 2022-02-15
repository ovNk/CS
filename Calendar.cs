using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10
{
    class Calendar
    {

        
        public event Action<string> Celebrate;
        public event Action<DateTime> Quarter;

        public void StartCelebrate()
        {
            Celebrate.Invoke("Happy New Year!");
        }
        public void StartQuarter()
        {
            Quarter.Invoke(DateTime.Now);
        }
    }
}
