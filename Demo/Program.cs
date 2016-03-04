using blqw.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blqw
{
    class Program
    {
/// <summary>
/// 这是一个测试注释
/// </summary>
/// <param name="args">测试</param>
static void Main(string[] args)
{
    var method = typeof(Program).GetMethod("Main", (System.Reflection.BindingFlags)(-1));

    var comment = CSCommentReader.Create(method);

    Console.WriteLine("summary:" + comment.Summary);
    Console.WriteLine("param:");
    foreach (var param in comment.Param)
    {
        Console.WriteLine($"    {param.Key} , {param.Value}");
    }

    Console.ReadLine();
    Console.WriteLine();
}
    }
}
