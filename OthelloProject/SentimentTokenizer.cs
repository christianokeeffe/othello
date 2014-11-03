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
        Regex emoticon_string = new Regex(@"[<>]?[:;=8][\-o\*\']?[\)\]\(\[dDpP/\:\}\{@\|\\]|[\)\]\(\[dDpP/\:\}\{@\|\\][\-o\*\']?[:;=8][<>]?",RegexOptions.IgnoreCase);
        Regex username_string = new Regex(@"@[\w_]+",RegexOptions.IgnoreCase);
        Regex hashtag_string = new Regex(@"\#+[\w_]+[\w\'_\-]*[\w_]+", RegexOptions.IgnoreCase);
        Regex remaining_string = new Regex(@"[a-z][a-z'\-_]+[a-z]|[+\-]?\d+[,/.:-]\d+[+\-]?|[\w_]+|\.(?:\s*\.){1,}|\S");

        void noget() 
        {
        List<Regex> regex_strings = new List<Regex>();
        regex_strings.Add(emoticon_string);
        regex_strings.Add(username_string);
        regex_strings.Add(hashtag_string);
        regex_strings.Add(remaining_string);

        }
    }
}
