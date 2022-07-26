using MetBot;
using Telegram.Bot;

var metApi = new MetApi();
var botClient = new TelegramBotClient(AccessTokens.Telegram);

// Create a new bot instance
var metBot = new BotEngine(botClient, metApi);

// Listen for messages sent to the bot
await metBot.ListenForMessages();