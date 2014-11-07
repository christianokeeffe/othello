using edu.stanford.nlp.ling;
using edu.stanford.nlp.tagger.maxent;
using java.io;
using java.util;
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
        public const string Model = @"C:\\Users\\Christian\\Source\\Repos\\othello\\OthelloProject\\stanford-postagger-full-2014-06-16\\models\\wsj-0-18-bidirectional-nodistsim.tagger";
        MaxentTagger tagger;
        public SentimentTokenizer()
        {
            tagger = new MaxentTagger(Model);
        }

        public List<string> tokenize(string input)
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


            foreach (List sentence in MaxentTagger.tokenizeText(new StringReader(inputlist)).toArray())
            {
                var tSentence = tagger.tagSentence(sentence).ToString();
            }  

            bool negation = false;
            Regex negationwords = new Regex(@"never|no|nothing|nowhere|noone|none|not|havent|hasnt|hadnt|cant|couldnt|shouldnt|wont|wouldnt|dont|doesnt|didnt|isnt|arent|aint");
            Regex punctuations = new Regex(@"[.:;?!]");
            Match words = Regex.Match(inputlist, @"[a-z][a-z'\-_]+[a-z]|[+\-]?\d+[,/.:-]\d+[+\-]?|[\w_]+|\.(?:\s*\.){1,}|\S");
            while (words.Success)
            {
                if (words.Value.EndsWith("'t") || negationwords.IsMatch(words.Value))
                {
                    negation = true;
                }
                if (punctuations.IsMatch(words.Value))
                {
                    negation = false;
                }
                string poststring = "";
                if(negation)
                {
                    poststring = "_NEG";
                }
                if (IsAllUpper(words.Value))
                {
                    returnlist.Add(words.Value + poststring);
                }
                else{
                    returnlist.Add(words.Value.ToLower() + poststring);
                }
                words = words.NextMatch();
            }

            return noStopWords(returnlist);
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

        private static List<string> noStopWords(List<string> tokens)
        {
            string[] stopWords = {"a", "about", "after", "again", "all", "am", "an", "and", "any", "are", "as", "at", "be", "because", "been", "before",
            "being", "between", "both", "but", "by", "could", "did", "do", "does", "doing", "during", "each",
            "few", "for", "from", "further", "had", "has", "have", "having", "he", "he'd", "he'll", "he's", "her", "here", "here's", "hers", "herself", "him",
            "himself", "his", "how", "how's", "i", "i'm", "i've", "if", "in", "into", "is", "it", "it's", "itself", "let's", "me", "my", "myself",
            "of", "off", "on", "once", "only", "or", "other", "ought", "our", "ours", "ourselves", "out", "over", "own", "same", "she", "she's", "should",
            "so", "some", "such", "than", "that", "that's", "the", "their", "their's", "them", "themselves", "then", "there", "there's", "these", "they", "they'd", "they'll", "they're", "they've",
            "this", "those", "through", "to", "too", "under", "until", "up", "very", "was", "we", "we've", "we're", "were", "what", "what's", "when", "when's", "where", "where's",
            "which", "while", "who", "who's", "whom", "why", "why's", "with", "would", "you", "you'd", "you'll", "you're", "you've", "your", "your's", "yourself", "yourselves"};
            foreach (string word in stopWords)
                tokens = tokens.FindAll(w => w != word);
            return tokens;
        }
    }
}
