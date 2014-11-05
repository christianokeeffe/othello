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
        Regex username_string = new Regex(@"@[\w_]+",RegexOptions.IgnoreCase);
        Regex hashtag_string = new Regex(@"\#+[\w_]+[\w\'_\-]*[\w_]+", RegexOptions.IgnoreCase);


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
                returnlist.Add(words.Value);
                words = words.NextMatch();
            }

            return returnlist;
        }
    }
}
