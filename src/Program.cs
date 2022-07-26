using MetBot;

// Create a new bot instance
var metBot = new BotEngine(AccessTokens.Telegram);

// Verify the bot is working
var checkBot = await metBot.CheckBotAsync();
Console.WriteLine($"I am bot {checkBot.Id} and my name is {checkBot.FirstName}");