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

        public BotEngine(string accessToken)
        {
            _botClient = new TelegramBotClient(accessToken);
        }

        public async Task<User> CheckBotAsync()
        {
            var botInfo = await _botClient.GetMeAsync();

            return botInfo;
        }
    }
}
