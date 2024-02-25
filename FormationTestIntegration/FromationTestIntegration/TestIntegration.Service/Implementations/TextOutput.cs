using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIntegration.Service.Abstractions;

namespace TestIntegration.Service.Implementations
{
    public class TextOutput : ITextOutput
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
