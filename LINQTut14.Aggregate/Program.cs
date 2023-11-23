
using Shared;

namespace LINQTut14.Aggregate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunMethod01();
            Console.WriteLine("\n***************");
            RunMethod02();
            Console.WriteLine("\n***************");
            RunMethod03();
            Console.ReadKey();
        }

        

        private static void RunMethod01()
        {
            var names = new[] { "Ali", "Salem", "Abeer", "Reem", "Jalal" };
            // Ali, Salem, ....

            //var output = "";
            //foreach (var item in names)
            //    output += $"{item},";
            //Console.WriteLine(output.TrimEnd(','));

            //var output = string.Join(',', names);
            //Console.WriteLine(output);



            // a = value befor adding , b = adding value
            var output = names.Aggregate((a, b) =>
            {
                Console.WriteLine($"a = {a}");
                Console.WriteLine($"b = {b}");
                return $"{a},{b}";
            });
            Console.WriteLine($"explain the method with print befor add and after (1): \n{output}");

            Console.WriteLine("\n--------------");
            
            var output1 = names.Aggregate((a, b) => $"{a},{b}");
            Console.WriteLine($"the same (1):\n {output}");

        }

        private static void RunMethod02()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };

            //var total = 0;
            //foreach (var n in numbers)
            //    total += n;


            //example:initial value = 0
            var total = numbers.Aggregate(0, (a, b) => a + b);
            Console.WriteLine($"Total with initial value = 0:\n{total}");

            Console.WriteLine("\n--------------");

            //example:initial value = 2
            var total1 = numbers.Aggregate(2, (a, b) => a + b);
            Console.WriteLine($"Total with initial value = 2:\n {total1}");
        }

        /// <summary>
        /// get the longest title in the all questions
        /// </summary>
        private static void RunMethod03()
        {
            var quiz = QuestionBank.All;

            //give initial value (assum first question has longest title)
            var longestTitle = quiz[0];
            Console.WriteLine($"{longestTitle}");
            Console.WriteLine("\n------------\n");
            var longestQuestionTitle = quiz.Aggregate(longestTitle,
                (longest, next) => longest.Title.Length < next.Title.Length ? next : longest, x =>x);

            Console.WriteLine(longestQuestionTitle);

        }
    }
}
