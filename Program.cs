using OllamaSharp;

namespace LlamaSample;

internal class Program
{
    private static async Task Main(string[] args)
    {
        await GenerateText();
        //await CustomTask();
    }

    private static async Task GenerateText()
    {
        var uri = new Uri("http://localhost:11434");
        var ollama = new OllamaApiClient(uri)
        {
            SelectedModel = "llama3"
        };

        var prompt = "Once upon a time, in a land far, far away...";
        ConversationContext? context = null;
        context = await ollama.StreamCompletion(prompt, context, stream => Console.Write(stream?.Response));
        Console.ReadLine();
    }

    private static async Task CustomTask()
    {
        var uri = new Uri("http://localhost:11434");
        var ollama = new OllamaApiClient(uri)
        {
            SelectedModel = "llama3"
        };
        var prompt = "Translate the following English sentence to French: 'Hello, world!'";
        ConversationContext? context = null;
        context = await ollama.StreamCompletion(prompt, context, stream => Console.Write(stream?.Response));
        Console.ReadLine();
    }
}