using MetBot;

// Create a new bot instance
var metBot = new BotEngine(AccessTokens.Telegram);

// Listen for messages sent to the bot
await metBot.ListenForMessages();