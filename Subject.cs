using DynamicLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSubject
{
    public class Subject : ISubjectBase
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public void Show(string txt)
        {
            Console.WriteLine(txt);
        }
    }
}
