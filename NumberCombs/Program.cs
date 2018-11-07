using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberCombs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var limit = 3 * 3;
                limit *= limit;
                limit *= limit;

                for (int i = 0; i < limit; ++i)
                {
                    var opers = GetInBase3(i);

                    var result = 1;
                    var digit = 2;

                    var list = new List<int>();
                    Console.WriteLine($"op: {opers}");
                    if (opers == "01200200")
                    {
                        Console.WriteLine();
                    }
                    foreach (var op in opers)
                    {
                        if (op == '0')
                        {
                            list.Add(result);
                            result = digit;
                        }
                        else if (op == '1')
                        {
                            list.Add(result);
                            result = -digit;
                        }
                        if (op == '2')
                        {
                            var sign = result < 0 ? -1 : 1;
                            result = result * 10 + sign * digit;
                        }
                        digit++;
                    }
                    list.Add(result);

                    Console.Write($"{list.First()} ");

                    foreach (var entry in list.Skip(1))
                    {
                        var sign = entry < 0 ? '-' : '+';
                        Console.Write($"{sign} {Math.Abs(entry)} ");
                    }

                    var sum = list.Sum();
                    Console.WriteLine($" = {sum}");
                }
            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }

        private static string GetInBase3(int n)
        {
            string s = "";
            for (int i = 0; i < 8; i++)
            {
                var c = (char)('0' + (n % 3));
                s += c;
                n /= 3;
            }
            var arr = s.ToCharArray();
            Array.Reverse(arr);
            s = new string(arr);

            return s;
        }
    }
}
