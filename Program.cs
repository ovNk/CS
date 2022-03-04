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
            //XmlDocument xDoc = new XmlDocument();
            //xDoc.Load(@"D:\Users\oniki\Desktop\Тест\LessonXML.xml");
            //// получим корневой элемент
            //XmlElement? xRoot = xDoc.DocumentElement;
            //if (xRoot != null)
            //{
            //    // обход всех узлов в корневом элементе
            //    foreach (XmlElement xnode in xRoot)
            //    {
            //        // получаем атрибут name
            //        XmlNode? attr = xnode.Attributes.GetNamedItem("name");
            //        Console.WriteLine(attr?.Value);

            //        // обходим все дочерние узлы элемента user
            //        foreach (XmlNode childnode in xnode.ChildNodes)
            //        {
            //            // если узел - company
            //            if (childnode.Name == "company")
            //            {
            //                Console.WriteLine($"Company: {childnode.InnerText}");
            //            }
            //            // если узел age
            //            if (childnode.Name == "age")
            //            {
            //                Console.WriteLine($"Age: {childnode.InnerText}");
            //            }
            //        }
            //        Console.WriteLine();
            //    }
            //}
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
