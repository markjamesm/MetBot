using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MetBot
{
    public class BotEngine
    {
        private readonly TelegramBotClient _botClient;
        private static IMetApi? _metApi;

        public BotEngine(TelegramBotClient botClient, IMetApi metApi)
        {
            _botClient = botClient;
            _metApi = metApi;
        }

        // Create a listener so that we can wait for messages to be sent to the bot
        public async Task ListenForMessagesAsync()
        {
            using var cts = new CancellationTokenSource();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
            };
            _botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );

            var me = await _botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Message is not { } message)
                return;

            // Only process text messages
            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            var objectList = await _metApi.GetCollectionObjectsAsync();
            var collectionObject = HelperMethods.RandomNumberFromList(objectList.objectIDs);

            var collectionItem = await _metApi.GetCollectionItemAsync(collectionObject.ToString());

            if (String.IsNullOrEmpty(collectionItem.primaryImage))
            {
                Message sendMessage = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "<b>" + collectionItem.artistDisplayName + "</b>." + "<i>Artwork</i>:" + collectionItem.title,
                    parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
            }

            if (!String.IsNullOrEmpty(collectionItem.primaryImage))
            {
                Message sendArtwork = await botClient.SendPhotoAsync(
                    chatId: chatId,
                    photo: collectionItem.primaryImage,
                    caption: "<b>" + collectionItem.artistDisplayName + "</b>" + " <i>Artwork</i>: " + collectionItem.title,
                    parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
            }
        }

        private Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}
