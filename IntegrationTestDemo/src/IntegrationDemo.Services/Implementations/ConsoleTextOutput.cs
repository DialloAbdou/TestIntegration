using IntegrationDemo.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationDemo.Services.Implementations;

public class ConsoleTextOutput : ITextOutput
{
    public void WriteLine(string line)
        => Console.WriteLine(line);
}
