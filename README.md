# blqw.CSComment
获取注释文件中的内容

```csharp
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
```
[输出](https://raw.githubusercontent.com/blqw/blqw.CSComment/master/demo.png)

### 更新说明
#### 2016.03.04
* v1.0