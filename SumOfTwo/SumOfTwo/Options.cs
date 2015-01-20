using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfTwo
{
    public class Options
    {
        [Option('f', "file", Required=true, HelpText="name of the file containing the values")]
        public string FileName { get; set; }

        [Option('y', "max", Required=true, HelpText="Maximum value for the sum of two numbers.")]
        public long MaxValue { get; set; }

        [Option('x', "min", Required=true, HelpText="Minimum value for the sum of two numbers.")]
        public long MinValue { get; set; }

        [Option('v', "verbose", Required=false, DefaultValue=false)]
        public bool Verbose { get; set; }
    }
}
