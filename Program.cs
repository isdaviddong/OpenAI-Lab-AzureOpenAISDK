using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;

namespace testt
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // See https://aka.ms/new-console-template for more information
            Console.WriteLine("Ready...");

            OpenAIClient client = new OpenAIClient(
                    new Uri("https://testopenai202303.openai.azure.com/"),
                    new Azure.AzureKeyCredential("59fa2b018e2e4e028c90dfd1af88b6ac"));

            //string nonAzureOpenAIApiKey = "your-api-key-from-platform.openai.com";
            //var client = new OpenAIClient(nonAzureOpenAIApiKey, new OpenAIClientOptions());
            var chatCompletionsOptions = new ChatCompletionsOptions()
            {
                Messages =
    {
        new ChatMessage(ChatRole.System, "你是一個智能助理，你會回答任何問題，像是一個聰明的智者。"),
        new ChatMessage(ChatRole.User, "你能幫助我嗎?"),
        new ChatMessage(ChatRole.Assistant, "好的，沒有問題。您請發問，我會盡力回答~"),
        new ChatMessage(ChatRole.User, "我該如何才獲得好的成績呢?"),
    }
            };

            Response<StreamingChatCompletions> response =
                await client.GetChatCompletionsStreamingAsync(
                deploymentOrModelName: "gpt35", chatCompletionsOptions);
            using StreamingChatCompletions streamingChatCompletions = response.Value;

            await foreach (StreamingChatChoice choice in streamingChatCompletions.GetChoicesStreaming())
            {
                await foreach (ChatMessage message in choice.GetMessageStreaming())
                {
                    Console.Write(message.Content);
                }
                Console.WriteLine();
            }
        }
    }
}
