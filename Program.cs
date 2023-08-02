using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mod10Demo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Way 1
            Task task1 = new Task(LongRunningMethod); // manages a pool of threads
            LongRunningMethod(); // synchronous
            task1.Start(); // asynchronous

            // Way 2

            Task task2 = new Task(() =>
            {
                // logic
            });

            Task<decimal> task3 = Task.Run<decimal>(() =>
            {
                // logic
                return 4.5m;
            });

            StreamReader sr = new StreamReader("c:\\test\\demo.txt");

            Parallel.Invoke(() => LongRunningMethod(),
                ()=> LongRunningMethod2()
            );

            for(int i = 0; i < 10; i++)
            {
                // sequential
            }
            int start = 0;
            int end = 99;
            int[] arr = new int[100];

            Parallel.For(start, end, index =>
            {
                arr[index] = index * index;
            });

            List<Student> students = new List<Student>();
            students.Add(new Student() { studentId = 1, name = "Test" });
            students.Add(new Student() { studentId = 2, name = "Abc" });
            students.Add(new Student() { studentId = 3, name = "Jim" });

            // sequential
            var result = from stud in students
                         where stud.name.StartsWith("A")
                         select stud;

            var result_A = from stud in students.AsParallel()
                           where stud.name.StartsWith("A")
                           select stud;


        }

        static void LongRunningMethod2()
        {

        }
        static void LongRunningMethod()
        {
            // download large files
            // calling web apis
            // uploading data
            // reading large files
            // complex mathematical calculation
            Thread.Sleep(1000);
            // logic
            Console.WriteLine("Long running method");
        }
    }
}
