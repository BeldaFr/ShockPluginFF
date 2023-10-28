using Dalamud.Configuration;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Plugin;
using System;
using System.Collections.Generic;

namespace SamplePlugin
{
    [Serializable]
    public class Configuration : IPluginConfiguration
    {
        public int Version { get; set; } = 0;
        public bool SomePropertyToBeSavedAndWithADefault { get; set; } = true;

        public string MessageTest { get; set; } = "default";
        public string testInput { get; set; } = "null";
        public bool Say { get; set; } = false;
        public bool Yell { get; set; } = false;
        public bool Shout { get; set; } = false;
        public bool Tell { get; set; } = false;
        public bool Party { get; set; } = false;
        public bool AllianceChat { get; set; } = false;
        public bool FcChat {  get; set; } = false;
        public bool Ls1 { get; set; } = false;
        public bool Ls2 { get; set; } = false;
        public bool Ls3 { get; set; } = false;
        public bool Ls4 { get; set; } = false;
        public bool Ls5 { get; set; } = false;
        public bool Ls6 { get; set; } = false;
        public bool Ls7 { get; set; } = false;
        public bool Ls8 { get; set; } = false;

        public bool CLs1 { get; set; } = false;
        public bool CLs2 { get; set; } = false;
        public bool CLs3 { get; set; } = false;
        public bool CLs4 { get; set; } = false;
        public bool CLs5 { get; set; } = false;
        public bool CLs6 { get; set; } = false;
        public bool CLs7 { get; set; } = false;
        public bool CLs8 { get; set; } = false;
        public List<string> ChannelListener { get; set; } = new List<string>();
        public String[] ChatName = {"None","Say","Yell","Shout","TellIncoming","Reply","Party","Alliance","FreeCompany",
        "LinkShell1","LinkShell2","LinkShell3","LinkShell4","LinkShell5","LinkShell6","LinkShell7","LinkShell8",
        "CrossworldLinkshell1","CrossworldLinkshell2","CrossworldLinkshell3","CrossworldLinkshell4","CrossworldLinkshell5",
        "CrossworldLinkshell6","CrossworldLinkshell7","CrossworldLinkshell8"}; //Types of chat that can be filtered
        public bool[] ChannelBool = new bool[25];


        // the below exist just to make saving less cumbersome
        [NonSerialized]
        private DalamudPluginInterface? PluginInterface;

        public void Initialize(DalamudPluginInterface pluginInterface)
        {
            this.PluginInterface = pluginInterface;
        }

        public void Save()
        {
            this.PluginInterface!.SavePluginConfig(this);
        }

        public void InfoChannel()
        {
            this.ChannelBool[1] = this.Say;
            this.ChannelBool[2] = this.Shout;
            this.ChannelBool[3] = this.Tell;
            this.ChannelBool[6] = this.Party;
            this.ChannelBool[7] = this.AllianceChat;
            this.ChannelBool[8] = this.FcChat;
            this.ChannelBool[9] = this.Ls1;
            this.ChannelBool[10] = this.Ls2;
            this.ChannelBool[11] = this.Ls3;
            this.ChannelBool[12] = this.Ls4;
            this.ChannelBool[13] = this.Ls5;
            this.ChannelBool[14] = this.Ls6;
            this.ChannelBool[15] = this.Ls7;
            this.ChannelBool[16] = this.Ls8;
            this.ChannelBool[17] = this.CLs1;
            this.ChannelBool[18] = this.CLs2;
            this.ChannelBool[19] = this.CLs3;
            this.ChannelBool[20] = this.CLs4;
            this.ChannelBool[21] = this.CLs5;
            this.ChannelBool[22] = this.CLs6;
            this.ChannelBool[23] = this.CLs7;
            this.ChannelBool[24] = this.CLs8;
        }
    }
}
