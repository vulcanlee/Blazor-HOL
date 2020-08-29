using System;

namespace PureDI
{
    class ConsoleWriter
    {
        public void Output()
        {
            Console.WriteLine($"   ConsoleWriter 執行結果");
        }
    }
    class FileWriter
    {
        public void Output()
        {
            Console.WriteLine($"   FileWriter 執行結果");
        }
    }
    class MyClass
    {
        private readonly string outputType;
        private readonly FileWriter fileWriter;
        private readonly ConsoleWriter consoleWriter;
        public MyClass(string outputType)
        {
            this.outputType = outputType;
            // 此會造成 MyClass 與 FileWriter 有緊密耦合關係
            fileWriter = new FileWriter();
            // 此會造成 MyClass 與 ConsoleWriter 有緊密耦合關係
            consoleWriter = new ConsoleWriter();
        }
        public void DoSomething()
        {
            Console.WriteLine("DoSomething 正在執行中");
            // 當需要將結果寫入到資料庫、Web API 的時候，又該如何修改呢？
            if (outputType == "Console") consoleWriter.Output();
            if (outputType == "File") fileWriter.Output();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 建立 MyClass 類別的時候，需要相依一個字串常數
            // 會有甚麼問題呢？
            MyClass myClass = new MyClass("Console");
            myClass.DoSomething();

            myClass = new MyClass("File");
            myClass.DoSomething();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
