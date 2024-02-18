using OpenAI_API;
using ScreenSound.Modelos;
namespace ScreenSound.Menus;

    internal class MenuRegistrarBanda: Menu
    {
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new Banda(nomeDaBanda);
        bandasRegistradas.Add(nomeDaBanda, banda);

        var client = new OpenAIAPI("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");

        var chat = client.Chat.CreateConversation();
        chat.AppendSystemMessage($"fale sobre a banda {nomeDaBanda} em um paragrafo");

        string response = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
        banda.Resumo = response;


        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }

}

