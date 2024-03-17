using ChatGPT.Net;

namespace TheoryProtocol.Services;

public class OpenAiService
{
    string openAiKeyPath = Directory.GetFiles("./Credentials").Where(x => x.EndsWith("txt")).FirstOrDefault();
    private readonly string openAiKey;
    public OpenAiService()
    {
        openAiKey = File.ReadAllText(openAiKeyPath);
    }

    public async Task<string> Prompt(string prompt)
    {
        var openAi = new ChatGpt(openAiKey);
        var res = await openAi.Ask(prompt);
        return res;
    }
    
    
}