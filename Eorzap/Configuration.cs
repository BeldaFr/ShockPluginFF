using Dalamud.Configuration;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Plugin;
using System;
using System.Collections.Generic;

namespace Eorzap
{
    [Serializable]
    public class Configuration : IPluginConfiguration
    {
        public int Version { get; set; } = 0;
        public bool SomePropertyToBeSavedAndWithADefault { get; set; } = true;
        public string ApiKey { get; set; } = string.Empty;
        public string ShockerCode { get; set; } = string.Empty;
        public string ShockUsername { get; set; } = string.Empty;
        public string resultApiCall { get; set; } = string.Empty;
        public string MessageTest { get; set; } = "default";
        public string mainKeyWord { get; set; }  = "null";
        public string[] triggerWords { get; set; } = new string[] {"","","",""};
        public int[] intensityArray { get; set; } = new int[] { 0, 0, 0, 0 };
        public int[] durationArray { get; set; } = new int[] { 0, 0, 0, 0 };
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
        "Ls1","Ls2","Ls3","Ls4","Ls5","Ls6","Ls7","Ls8",
        "CrossLinkShell1","CrossLinkShell2","CrossLinkShell3","CrossLinkShell4","CrossLinkShell5",
        "CrossLinkShell6","CrossLinkShell7","CrossLinkShell8"}; //Types of chat that can be filtered
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


        /// <summary>
        /// Used to check which channel is listened on
        /// Channel bool is meant to be used with ChatName 
        /// </summary>
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
