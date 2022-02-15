using Newtonsoft.Json;

namespace StratGen2kTurbo
{
    public static class StrategyGenerator
    {
        public static async Task<string> GetNewPhrase() 
        {
            var client = new HttpClient();

            var response = await client.GetAsync("https://corporatebs-generator.sameerkumar.website/");
        
            var rawJson = await response.Content.ReadAsStringAsync();

            dynamic data = JsonConvert.DeserializeObject(rawJson);

            return data.phrase;
        }

        public static string GetRandomBridgeWord() 
        {
            string[] words =
                {
                    " to ",
                    " hereby ",
                    " therefore ",
                    " always ",
                    " no one has ",
                    " but ",
                    " while ",
                    " disregard ",
                    " never ",
                    " but why would you not "
                    
                };
            return words[System.Random.Shared.Next(0, words.Length - 1)];
        }

        public static string GetRandomHandover(string toName) 
        {
            string[] handovers =
                  {
                    $". What do you think {toName}? ",
                    $". {toName}, ",
                    $". Your highness {toName}!, ",
                    $". {toName}! {toName} {toName}!!! ",
                    $". {toName}! "
                    
                };
            return handovers[System.Random.Shared.Next(0, handovers.Length - 1)];


        }
        public static async Task<string> GetRandomPhraseChain(int length) 
        {
            var sb = new System.Text.StringBuilder();
            while (length > 1) 
            {
                sb.Append(await GetNewPhrase());    
                sb.Append(GetRandomBridgeWord());
                length--;
            }
            sb.Append(await GetNewPhrase());
            return sb.ToString();
        
        }

        

    }
}
