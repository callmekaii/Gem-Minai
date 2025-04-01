# Gem-Minai

![Gem Minai](https://github.com/user-attachments/assets/59f1c66a-f449-4dd4-a8dc-328869a3901c)

## 📌 About
Gem Minai is a Discord Bot Hoster with Gemini AI API Integrated.

## 🚀 Features

- AI-powered responses using Gemini API
- Interactive Discord bot commands
- Supports both prefix and slash commands


## 🛠️ Installation
### Steps
1. Clone the repository:
   ```sh
   gh repo clone Kotokahatsushima/Gem-Minai
   ```
2. Navigate to:
   ```sh
   DiscordBot\DiscordBot\bin\Release
   ```
3. Run the executable:
   ```sh
   DiscordBot.exe
   ```
## 📖 Usage

### Setting Up the Bot

1. **Obtain a Discord Bot Token:**

   - Go to the [Discord Developer Portal](https://discord.com/developers/applications).
   - Create a new bot and copy the bot token.

2. **Configure the Bot:**

   - Run the bot for the first time.
   - Enter the **Discord Token** and **Google API Key** when prompted.
   - The configuration will be saved in `config.json`.

3. **Invite the Bot to Your Server:**

   - Generate an invite link using the following URL:
     ```
     https://discord.com/oauth2/authorize?client_id=YOUR_CLIENT_ID&permissions=8&scope=bot+applications.commands
     ```
   - Replace `YOUR_CLIENT_ID` with your bot's Client ID.
   - Invite it to your server.

4. **Run the Bot:**

   ```sh
   DiscordBot\DiscordBot\bin\Release\DiscordBot.exe
   ```

### Available Commands

#### Prefix Commands

- `!Hug` - Sends a random hug image.
- `!Pat` - Sends a pat image.
- `!gem <message>` - Chat with Gem Minai
- `hey gem <message>` - Chat with Gem Minai

#### Slash Commands

- `/Hug` - Sends a hug image.

## 🛠️ Language and Libraries Used
- **C#**
- **[DSharpPlus](https://github.com/DSharpPlus/DSharpPlus)**
- **Gemini API**
- **[Google GenerativeAI (Gemini)](https://github.com/gunpal5/Google_GenerativeAI)**

## 🤝 Contributing
Contributions are welcome! Follow these steps:
1. Fork the repository
2. Create a new branch (`git checkout -b feature-name`)
3. Commit changes (`git commit -m 'Add new feature'`)
4. Push to your branch (`git push origin feature-name`)
5. Open a Pull Request

