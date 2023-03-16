using System.Linq;
using System.Text.RegularExpressions;

namespace RegexSolving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // #1
            Console.WriteLine(No_1("he he goes to school to sunday"));

            // #2
            //Console.WriteLine(No_2("x@x"));

            // #3
            //Console.WriteLine(No_3("10.10.10.10"));

            // #4
            //Console.WriteLine(No_4("02:60:59"));

            // #5
            //Console.WriteLine(No_5("32/12/1212"));

            // #6
            //Console.WriteLine(No_6(""));

            // #7
            //Console.WriteLine(No_7("3/29"));

            // #8
            //Console.WriteLine(No_8("VHJUHHKNMONBVB"));
        }

        private static string No_1(string str) 
        {
            Regex findDuplicate = new(@"\b(\w+)\b(?=.*\b\1\b)");
            MatchCollection matchDuplicates = findDuplicate.Matches(str);
            foreach (Match match in matchDuplicates)
            {
                GroupCollection group = match.Groups; 
            }




            //string input = "he he goes on to school on on sunday";
            //Regex regex = new(@"\b(\w+)\b(?=.*\b\1\b)");

            //MatchCollection matches = regex.Matches(input);

            //foreach (Match match in matches)
            //{
            //    GroupCollection groups = match.Groups;
            //    Console.WriteLine("{0}: {1}", groups[1].Value, match.Captures.Count);
            //}

            //string input1 = "he he goes to school";
            //Regex regex1 = new(@"\b\w+\b");
            //MatchCollection match1 = regex1.Matches(input1);
            //var duplicates = match1
            //    .Cast<Match>()
            //    .GroupBy(m => m.Value)
            //    .Where(g => g.Count() > 1)
            //    .Select(g => new { Word = g.Key, Count = g.Count() });

            //foreach (var duplicate in duplicates)
            //{
            //    Console.WriteLine("{0}: {1}", duplicate.Word, duplicate.Count);
            //}
            return "";
        }

        private static string No_2(string str)
        {
            Regex regex = new(@"^(?!.*\.\.)[\w.]{1,35}@[\w.\-]+\.[a-zA-Z]{2,15}$");
            MatchCollection matches = regex.Matches(str);
            
            if (matches.Count > 0)
            {
                return "valid";
            }

            return "invalid";
        }

        private static string No_3(string str)
        {
            Regex regex = new(@"^(25[0-5]|2[0-4][0-9]|[0-1]?[0-9]?[0-9]?)\.(25[0-5]|2[0-4][0-9]|[0-1]?[0-9]?[0-9]?)\.(25[0-5]|2[0-4][0-9]|[0-1]?[0-9]?[0-9]?)\.(25[0-5]|2[0-4][0-9]|[0-1]?[0-9]?[0-9]?)$");
            MatchCollection matches = regex.Matches(str);

            if (matches.Count > 0)
            {
                return "valid";
            }

            return "invalid";
        }

        private static string No_4(string str)
        {
            Regex regex = new(@"^(0?[1-9]|1[0-2]):([0-5]?[0-9]):([0-5]?[0-9])$");
            MatchCollection matches = regex.Matches(str);

            if (matches.Count > 0)
            {
                return "valid";
            }

            return "invalid";
        }

        private static string No_5(string str)
        {
            Regex regex = new(@"^(3[01]|[12][\d]|0?[1-9])\/(0?[1-9]|1[0-2])\/[\d]{4}$"); // dd (3[01]|[12][\d]|0?[1-9])  mm (0?[1-9]|1[0-2])  yyyy
            MatchCollection matches = regex.Matches(str);

            if (matches.Count > 0)
            {
                return "valid";
            }

            return "invalid";
        }

        private static string No_6(string str) 
        {
            Regex regex = new(@"");
            MatchCollection matches = regex.Matches(str);

            return "";
        }

        private static string No_7(string str)
        {
            Regex regex = new(@"^(3[01]|[12][\d]|0?[1-9])\/(0?[1-9]|1[0-2])$"); // dd (3[01]|[12][\d]|0?[1-9])  mm (0?[1-9]|1[0-2])  yyyy
            MatchCollection matches = regex.Matches(str);

            if (matches.Count > 0)
            {
                return "valid";
            }

            return "invalid";
        }

        private static string No_8(string str)
        {
            Regex regex = new(@"(?=[^AEIOUaeiou])[A-Za-z]");  // char set intersection is not available in .net. So we've to achieve it using positive look ahead asserttion
            MatchCollection matches = regex.Matches(str);

            if (matches.Count > 0)
            {
                return string.Join(" ", matches);
            }
            return "";
        }

        private static string No_9(string str)
        {
            Regex regex = new(@"(?=[^AEIOUaeiou])[A-Za-z]");  // char set intersection is not available in .net. So we've to achieve it using positive look ahead asserttion
            MatchCollection matches = regex.Matches(str);

            if (matches.Count > 0)
            {
                return string.Join(" ", matches);
            }
            return "";
        }
    }
}