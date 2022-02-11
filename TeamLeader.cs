using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8_Task1
{
    class TeamLeader: IWorker
    {
        public override string ToString()
        {
            return "Hi! I am a team leader!\nAt the moment, the team has built:";
        }
    }
}
