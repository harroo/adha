
using System;
using System.Net;
using System.Threading;
using System.Collections.Generic;

public static class Orthoget {

    public static class Thesaurus {

        public static void GetSimilarWords (string word, Action<string[]> onComplete) {

            new Thread(()=>{

                WebClient client = new WebClient();

                string getAddress = "https://www.thesaurus.com/browse/" + word + "?s=t";

                string getCache;
                try {

                    getCache = client.DownloadString(getAddress);

                } catch {

                    onComplete(new string[]{"null"});
                    return;
                }

                string[] values0 = getCache.Split(',');

                List<string> values1 = new List<string>();
                foreach (string value in values0)
                    if (value.Contains("targetTerm"))
                        values1.Add(value);

                List<string> values2 = new List<string>();
                foreach (string value in values1)
                    if (value.Contains("\":\""))
                        values2.Add(value.Split('\"')[3]);

                onComplete(values2.ToArray());

            }).Start();
        }
    }

    public static class Dictionary {

        public static void GetWordDefinition (string word, Action<string, string> onComplete) {

            new Thread(()=>{

                WebClient client = new WebClient();

                string getAddress = "https://www.dictionary.com/browse/" + word + "?s=t";

                string getCache;
                try {

                    getCache = client.DownloadString(getAddress);

                } catch {

                    onComplete("null", "null");
                    return;
                }

                string[] values0 = getCache.Split('<');
                string[] values1 = values0[9].Split('>');
                string description = values1[0].Split('\"')[3];

                onComplete(word, description);

            }).Start();
        }
    }
}
