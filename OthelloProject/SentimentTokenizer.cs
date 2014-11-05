using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OthelloProject
{
    class SentimentTokenizer
    {
        public static List<string> tokenize(string input)
        {
            List<string> returnlist = new List<string>();
            string inputlist = input;
            Match html = Regex.Match(input, @"<[^>]+>");
            while (html.Success)
            {
                inputlist = input.Replace(html.Value, "");
                html = html.NextMatch();
            }
            Match hashTags = Regex.Match(inputlist, @"\#+([\w_]+[\w\'_\-]*[\w_]+|[\w])");
            while (hashTags.Success)
            {
                string test = hashTags.Value;
                returnlist.Add(hashTags.Value);
                inputlist = inputlist.Replace(hashTags.Value, "");
                hashTags = hashTags.NextMatch();
            }

            Match dates = Regex.Match(inputlist, @"((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))");
            while (dates.Success)
            {
                inputlist = inputlist.Replace(dates.Value, "");
                dates = dates.NextMatch();
            }

            Match emoticon = Regex.Match(inputlist, @"[<>]?[:;=8][\-o\*\']?[\)\]\(\[dDpP/\:\}\{@\|\\]|[\)\]\(\[dDpP/\:\}\{@\|\\][\-o\*\']?[:;=8][<>]?");
            while (emoticon.Success)
            {
                returnlist.Add(emoticon.Value);
                inputlist = inputlist.Replace(emoticon.Value, "");
                emoticon = emoticon.NextMatch();
            }


            Match words = Regex.Match(inputlist, @"[a-z][a-z'\-_]+[a-z]|[+\-]?\d+[,/.:-]\d+[+\-]?|[\w_]+|\.(?:\s*\.){1,}|\S");
            while (words.Success)
            {
                if (IsAllUpper(words.Value))
                {
                    returnlist.Add(words.Value);
                }
                else{
                    returnlist.Add(words.Value.ToLower());
                }
                words = words.NextMatch();
            }

            return returnlist;
        }
        
        static bool IsAllUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]) && !Char.IsUpper(input[i]))
                    return false;
            }
            return true;
        }
    }
}
