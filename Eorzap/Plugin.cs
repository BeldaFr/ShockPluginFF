using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;
using System.IO;
using System.Net.Http;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin.Services;
using Eorzap.Windows;
using Dalamud.Game.Gui;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using System.Collections.Generic;
using System;
using Dalamud.Logging;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;

namespace Eorzap
{
    public sealed class Plugin : IDalamudPlugin
    {
        public string Name => "Eorzap";
        private const string CommandName = "/eorzap";

        private IDalamudPluginInterface PluginInterface { get; init; }
        private ICommandManager CommandManager { get; init; }
        private IChatGui Chat { get; init; } = null!;
        public Configuration Configuration { get; init; }
        public WindowSystem WindowSystem = new("Eorzap");

        private ConfigWindow ConfigWindow { get; init; }
        private MainWindow MainWindow { get; init; }

        public Plugin(
            IDalamudPluginInterface pluginInterface,
            ICommandManager commandManager,
            IChatGui chat)
        {
            this.PluginInterface = pluginInterface;
            this.CommandManager = commandManager;

            this.Configuration = this.PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
            this.Configuration.Initialize(this.PluginInterface);
            this.Chat = chat;


            ConfigWindow = new ConfigWindow(this);
            MainWindow = new MainWindow(this);
            
            WindowSystem.AddWindow(ConfigWindow);
            WindowSystem.AddWindow(MainWindow);

            this.CommandManager.AddHandler(CommandName, new CommandInfo(OnCommand)
            {
                HelpMessage = "Open Eorzap main window"
            });

            this.PluginInterface.UiBuilder.Draw += DrawUI;
            this.PluginInterface.UiBuilder.OpenConfigUi += DrawConfigUI;
            this.Chat.ChatMessage += this.OnChatMessage;
        }

        public void Dispose()
        {
            this.WindowSystem.RemoveAllWindows();
            
            ConfigWindow.Dispose();
            MainWindow.Dispose();
            
            this.CommandManager.RemoveHandler(CommandName);
            //this.Chat.ChatMessage -= OnChatMessage;
        }

        private void OnCommand(string command, string args)
        {
            // in response to the slash command, just display our main ui
            MainWindow.IsOpen = true;
        }

        private void DrawUI()
        {
            this.WindowSystem.Draw();
        }

        public void DrawConfigUI()
        {
            ConfigWindow.IsOpen = true;
        }

        //public delegate void OnMessageDelegate(XivChatType type, uint senderId, ref SeString sender, ref SeString message, ref bool isHandled);
        public void OnChatMessage(XivChatType type, int timestamp, ref SeString sender, ref SeString message, ref bool isHandled)
        {
            // for now only check a message if in a FC
            // Need to add a config file to check which chat to check

            // Also need to check for the trigger word that is setup + Do the actual shock with
            // the post request
            this.Configuration.InfoChannel();
            string[] Channels = this.Configuration.ChatName; //All the name of the channels that can be listened 
            int index = Array.IndexOf(Channels, type.ToString());
            if (index>=0 && this.Configuration.ChannelBool[index]==true) //If the channel can be selected and is activated by the user
            {
                string keyword = this.Configuration.mainKeyWord.ToLower(); //Get the keyword
                string[] triggers = this.Configuration.triggerWords;
                string[] triggersModifier = new string[triggers.Length]; //That way it does not modify the triggers value
                for(int i = 0; i < triggers.Length; i++)
                {
                    triggersModifier[i] = keyword+" " + triggers[i].ToLower(); //Put every keyword with the triggers like "testing trigger1"
                }
                int indexTrigger = Array.IndexOf(triggersModifier,message.ToString().ToLower());
                if (indexTrigger >= 0 && triggersModifier[indexTrigger].Split(" ").Length > 1) //If the message correspond to an actual keyword + trigger combination
                {
                    //Get list of itensity and duration
                    int[] intensity = this.Configuration.intensityArray;
                    int[] duration = this.Configuration.durationArray;
                    //Actual shock part
                    // Call the shock with the duration and intensity for the keyword + trigger combination
                    string jsonContent = $"{{ \"Username\": \"{this.Configuration.ShockUsername}\", \"Name\": \"{sender.ToString()}\",\"Code\":\"{this.Configuration.ShockerCode}\",\"Intensity\": {intensity[indexTrigger]},\"Duration\": {duration[indexTrigger]},\"ApiKey\":\"{this.Configuration.ApiKey}\",\"Op\":0 }}";
                    var reponse = this.PostJsonData(jsonContent);
                    this.Configuration.resultApiCall = reponse;

                }
            }
        }

        public string PostJsonData(string jsonContent)
        {
            using (var client = new HttpClient())
            {
                // Configure the base address of the API
                client.BaseAddress = new Uri("https://do.pishock.com/api/apioperate/");

                // Set the content type to JSON
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Create a StringContent with the JSON data
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Send the POST request and get the response
                var response = client.PostAsync("https://do.pishock.com/api/apioperate/", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Read and return the response content as a string
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    // Handle the error or throw an exception
                    throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
                }
            }
        }
    }
}
