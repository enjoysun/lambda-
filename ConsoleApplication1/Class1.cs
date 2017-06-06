using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public delegate void SayhelloHandler(string name);
    public class Class1
    {
        public event SayhelloHandler Sayhello;
        public void Onchange(string name)
        {
            if (Sayhello != null)
            {
                Sayhello(name);
            }
        }
    }
}
