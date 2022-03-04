using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace Lesson13
{
class Program
{
        private static string xml;

        static void Main(string[] args)
        {
            
            IWeapon bow = new Bow();
            //bow.Sharpen();
            IWeapon[] weapons = new IWeapon[] { new Bow(), new Gun(), new Knife() };
            Type type = typeof(IWeapon);
            object[] attributes = type.GetCustomAttributes(inherit:true);
            foreach (object attribute in attributes)
                Console.WriteLine(attribute);



        }
    }
}
