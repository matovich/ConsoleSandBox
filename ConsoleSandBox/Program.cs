using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polly;

namespace ConsoleSandBox
{
    public enum Days
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday
    }



    class Program
    {
        public class Data
        {
            public void Record(int value1, int value2)
            {
                Console.WriteLine($"{value1} {value2}");
            }

            public string Report()
            {
                var sb = new StringBuilder();
                sb.AppendLine();
                return "No report generated";
            }
        }

        public class EnvelopeTemplateFilter
        {

            public string UserFilter { get; set; }

            private string _include;
            public string Include => _include;

            public void AddInclude(string paramToInclude)
            {
                if (_include != null)
                {
                    _include += $",{paramToInclude}";
                }
                else
                {
                    _include = paramToInclude;
                }
            }
        }

        static void Main(string[] args)
        {
             var key = new byte[] { 171, 66, 187, 13, 38, 81, 245, 157, 93, 9, 213, 15, 42, 70, 86, 233, 51, 50, 66, 77, 24, 88, 81, 99, 123, 219, 187, 217, 136, 76, 73, 186, 167, 61, 26, 169, 84, 149, 223, 103, 65, 183, 26, 218, 98, 92, 9, 127, 136, 235, 254, 53, 4, 2, 212, 242, 180, 75, 246, 187, 37, 225, 19, 30 };

            foreach (var k in key)
            {
                Console.Write($"{k}, ");
            }

            JwtService.ExecuteSecurityJwt();

            /*
            var etf = new EnvelopeTemplateFilter();
            etf.AddInclude("hello");

            Console.WriteLine(etf.Include);

            int[] thing = new int[0];

            if(thing.Length == 7)
            {

            }



            // Interview questions for interns

            // Question one
            // Give two ways to console write each value in the array
            // Note: this will need - using System.Collections.Generic;
            List<string> values = new List<string> { "hello", "world", "how", "are", "things", "going" };

            Console.Write("hello");

            // answer
            foreach(string s in values)
            {
                Console.Write($"{s} ");
            }
            Console.WriteLine();

            for(int i = 0; i < values.Count; i++)
            {
                Console.Write($"{values[i]} ");
            }
            Console.WriteLine();

            values.ForEach(v => Console.Write($"{v} "));

            Console.WriteLine();
            // End of question one



            // Question two (Possibly add the two using statements before so the interviewee does not stumble on these)
            // using System.Collections.Generic;  // For List<>
            // using System.Text;                 // For StringBuilder if they decide to use it
            // Create the data structure inside the Data class to hold the values that are sent every cycle

            // this code inside of main
            var random = new Random((int)DateTime.Now.Ticks);
            var data = new Data();
            for(int i = 0; i < 10; i++)
            {
                int value1 = random.Next();
                int value2 = random.Next();
                data.Record(value1, value2);
            }

            Console.Write(data.Report());

            // Add this class stub where they will work
            //public class Data
            //{
            //    public void Record(int value1, int value2)
            //    {
            //        Console.WriteLine($"{value1} {value2}");
            //    }

            //    public string Report()
            //    {
            //        return "No report generated";
            //    }
            //}







        Days days = Days.Monday;
            

            Console.WriteLine(days);


            TestToStringOnNullableInt();

            int tryNumber = 0;

            Policy.Handle<Exception>()
                .WaitAndRetry(9, attempt => TimeSpan.FromMilliseconds(Math.Pow(2, attempt + 4)),
                    (exception, timeSpan, context) =>
                    {
                        Console.WriteLine(exception.Message);
                    }
                )
                .Execute(() =>
                {
                    tryNumber++;
                    Console.WriteLine($"TryNumber: {tryNumber}");
                    if (tryNumber < 6)
                        throw new Exception($"things went bad at TryNumber: {tryNumber}");
                });



            for (int i = 1; i < 7; i++)
            {
                Console.WriteLine($"For {i} + 4 power of 2 is {Math.Pow(2, i + 4)}");
            }


            for (int i = 1; i < 7; i++)
            {
                Console.WriteLine($"For {i} power of 4 is {Math.Pow(i, 4)}");
            }


            //int? myNullable = null;
            //int myInt = 7;
            //myNullable = myInt;
            //Console.WriteLine($"should be seven: {myNullable}");




            //var dictionary = new Dictionary<string, int> {{"hello", 1}, {"world", 2}};

            //var result = dictionary["hello"];
            //var result2 = dictionary["notThere"];

            //Console.WriteLine(result.ToString());
            //Console.WriteLine(result2.ToString());



            //var thing = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            //var tzi = TimeZoneInfo.Utc;

            //string s1 = string.Empty;

            //Console.WriteLine($"s1 has value {s1}");


            //var dtWithOutOffset = DateTime.Parse("2018-01-23 16:57:53");
            //var dtWithOffset = DateTime.Parse("2018-01-23 16:57:53 -07:00");

            //Console.WriteLine(dtWithOutOffset.ToString("yyyy-MM-dd HH:mm:ss"));
            //Console.WriteLine(dtWithOffset.ToString("yyyy-MM-dd HH:mm:ss"));

            //var dt = DateTime.Parse("2018-01-24T03:00:00-2:00", CultureInfo.CurrentCulture,  DateTimeStyles.AdjustToUniversal);

            //Console.WriteLine(dt.Kind);
            //Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss"));

            Console.ReadLine();
            */
        }

        private static void TestToStringOnNullableInt()
        {
            string nullString = null;
            try
            {
                Console.WriteLine($"Output from a null string: {nullString.Length}");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Proved you can't call length on a null string.");
            }

            int? nullInt = null;
            string result = nullInt.ToString();
            Console.WriteLine($"The length of the string result from the null int is: {result.Length}");
            Console.WriteLine("Proves this does not return a null string");
        }
    }
}
