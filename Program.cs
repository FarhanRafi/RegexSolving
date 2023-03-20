using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegexSolving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // #1
            //No_1("he he goes to school to sunday");

            // #2
            //Console.WriteLine(No_2("x@x"));

            // #3
            //Console.WriteLine(No_3("10.10.10.10"));

            // #4
            //Console.WriteLine(No_4("02:60:59"));

            // #5
            //Console.WriteLine(No_5("32/12/1212"));

            // #6
            //Console.WriteLine(No_6("<div>..</div><div>..</div><p>..</p>", "div"));

            // #7
            //Console.WriteLine(No_7("3/29"));

            // #8
            //Console.WriteLine(No_8("VHJUHHKNMONBVB"));

            // #9
            //Console.WriteLine(No_9("abcd12XY15c1552d13"));

            // #10
            //Console.WriteLine(No_10(" all ala imi"));

            // #11
            //Console.WriteLine(No_11("Mam Did You test alL Students"));

            // #12
            //Console.WriteLine(No_12("abad acdd adabdd"));

            // #13
            //Console.WriteLine(No_13("abba abbab baba"));

            // #14
            //Console.WriteLine(No_14("01.11.2014 31.10.2019"));
        }

        private static void No_1(string str) 
        {
            var strArray = str.Split(' ');
            Regex findDuplicate = new(@"\b(\w+)\b(?=.*\b\1\b)");
            MatchCollection matchDuplicates = findDuplicate.Matches(str);

            foreach (Match match in matchDuplicates.Cast<Match>())
            {
                var count = strArray.Where(a=> a== match.Value).Count();

                Console.WriteLine($"{match.Value}: {count}");

                strArray = strArray.Where(a => a != match.Value).ToArray();
            }
            foreach (var item in strArray)
            {
                Console.WriteLine($"{item}: {1}");
            }
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

        private static string No_6(string htmlBlock, string htmlTag) 
        {
            Regex regex = new($"(?:{htmlTag})");
            MatchCollection matches = regex.Matches(htmlBlock);

            if (matches.Count > 2 && matches.Count % 2 == 0)
            {
                return "duplicate";
            }
            else if (matches.Count == 2)
            {
                return "unique";
            }
            else return "";
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
            Regex regex = new(@"\d+(?!\d)(?<=[13579])");  
            MatchCollection matches = regex.Matches(str);

             if (matches.Count > 0)
            {
                return string.Join(" ", matches);
            }
            return "";
        }

        private static string No_10(string str)
        {
            Regex regex = new(@"\b(\w)\w*\1\b");
            MatchCollection matches = regex.Matches(str);

            if (matches.Count > 0)
            {
                return string.Join(" ", matches);
            }
            return "";
        }

        private static string No_11(string str)
        {
            Regex regex = new(@"[A-Z]");
            var matchedWords = "";

            foreach (var word in str.Split(' '))
            {
                if (regex.Match(word).Success) 
                {
                    if (word.Contains(regex.Match(word).Value.ToLower()))
                    {
                        matchedWords += $"{word} ";
                    }
                }
            }
            return matchedWords;
        }

        private static string No_12(string str)
        {
            Regex regex = new(@"^(?!.*ab).+$");

            var matchedString = "";

            foreach ( var s in str.Split(' ')) 
            {
                MatchCollection match = regex.Matches(s);
                if (match.Count > 0)
                {
                    matchedString += $"{match[0].Value} ";
                }
            }
            return matchedString;
        }

        private static string No_13(string str)
        {
            Regex regex = new(@"\b[^b\n]*b[^b\n]*b[^b\n]*b[^b\n]*\b");

            var matchedString = "";

            foreach (var s in str.Split(' '))
            {
                MatchCollection match = regex.Matches(s);
                if (match.Count > 0)
                {
                    matchedString += $"{match[0].Value} ";
                }
            }
            return matchedString;
        }

        private static string No_14(string str)
        {
            Regex regex = new(@"^(?<day>\d{2})\.(?<month>\d{2})\.(?<year>\d{4})$");

            var dates = str.Split(' ');
            Match match1 = regex.Match(dates[0]);
            Match match2 = regex.Match(dates[1]);

            int year1 = int.Parse(match1.Groups["year"].Value);
            int month1 = int.Parse(match1.Groups["month"].Value);
            int day1 = int.Parse(match1.Groups["day"].Value);

            int year2 = int.Parse(match2.Groups["year"].Value);
            int month2 = int.Parse(match2.Groups["month"].Value);
            int day2 = int.Parse(match2.Groups["day"].Value);

            DateTime date1 = new(year1, month1, day1);
            DateTime date2 = new(year2, month2, day2);

            if (date1 > date2)
            {
                return date1.ToShortDateString();
            }
            else if (date1 < date2)
            {
                return date2.ToShortDateString();
            }
            else { return "Both are equal"; }
        }
    }
}