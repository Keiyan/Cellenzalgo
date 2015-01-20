using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfTwo
{
    public class Program
    {
        public Options args { get; set; }

        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            Program prg = new Program();

            prg.args = CommandLine.Parser.Default.ParseArguments<Options>(args).Value;

            watch.Start();
            var data = prg.ReadFile(prg.args.FileName);
            var result = prg.CountSum(data, prg.args.MinValue, prg.args.MaxValue);
            watch.Stop();

            Console.WriteLine("File " 
                + prg.args.FileName 
                + " has " 
                + result 
                + " pairs whose sum is between " 
                + prg.args.MinValue 
                + " and " 
                + prg.args.MaxValue + ".");
            Console.WriteLine("it tooks " + watch.ElapsedMilliseconds + " ms to compute.");
        }

        public long[] ReadFile(string fileName)
        {
            var result = new List<long>();
            using (var stream = File.OpenText(fileName))
            {
                
                while (!stream.EndOfStream)
                {
                    result.Add(long.Parse(stream.ReadLine()));
                } 
            }
            return result.ToArray();
        }

        public long CountSum (long[] data, long min, long max)
        {
            return 0L;
        }
    }
}
