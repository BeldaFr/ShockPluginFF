using System;
using System.Numerics;
using System.Reflection.Emit;
using Dalamud.Interface.Components;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace SamplePlugin.Windows;

public class ConfigWindow : Window, IDisposable
{
    private Configuration Configuration;

    public ConfigWindow(Plugin plugin) : base(
        "A Wonderful Configuration Window",
        ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoScrollbar |
        ImGuiWindowFlags.NoScrollWithMouse)
    {
        this.Size = new Vector2(500, 300);
        this.SizeCondition = ImGuiCond.Always;

        this.Configuration = plugin.Configuration;
    }

    public void Dispose() 
    {
        this.Configuration.InfoChannel();
    }

    public override void Draw()
    {
        ImGui.BeginGroup();
        ImGui.Text("Listen to the trigger on :");
        ImGui.Indent(30);
        // can't ref a property, so use a local copy
        // Part for nomal chat
        var configValue = this.Configuration.Say;
        if (ImGui.Checkbox("Say", ref configValue))
        {
            this.Configuration.Say = configValue;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine();
        var configShout = this.Configuration.Shout;
        if (ImGui.Checkbox("Shout", ref configShout))
        {
            this.Configuration.Shout = configShout;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine();
        var configYell = this.Configuration.Yell;
        if (ImGui.Checkbox("Yell", ref configYell))
        {
            this.Configuration.Yell = configYell;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine();
        var configTell = this.Configuration.Tell;
        if (ImGui.Checkbox("Tell", ref configTell))
        {
            this.Configuration.Tell = configTell;
            this.Configuration.InfoChannel();
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.Save();
        }
        ImGui.Spacing();
        var configParty = this.Configuration.Party;
        if (ImGui.Checkbox("Party", ref configParty))
        {

            this.Configuration.Party = configParty;          // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine();
        var configAlliance = this.Configuration.AllianceChat;
        if (ImGui.Checkbox("Alliance", ref configAlliance))
        {

            this.Configuration.AllianceChat = configAlliance;          // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine();
        var configFc = this.Configuration.FcChat;
        if (ImGui.Checkbox("FC", ref configFc))
        {

            this.Configuration.FcChat = configFc;          // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }

        ImGui.Spacing();
        ImGui.NewLine();
        //Part for linkshell


        var configLs1 = this.Configuration.Ls1;
        if (ImGui.Checkbox("Linkshell1", ref configLs1))
        {
            this.Configuration.Ls1 = configLs1;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine() ;
        var configLs2 = this.Configuration.Ls2;
        if (ImGui.Checkbox("Linkshell2", ref configLs2))
        {
            this.Configuration.Ls2 = configLs2;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine();
        var configLs3 = this.Configuration.Ls3;
        if (ImGui.Checkbox("Linkshell3", ref configLs3))
        {
            this.Configuration.Ls3 = configLs3;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine();
        var configLs4 = this.Configuration.Ls4;
        if (ImGui.Checkbox("Linkshell4", ref configLs4))
        {
            this.Configuration.Ls4 = configLs4;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.Spacing();
        var configLs5 = this.Configuration.Ls5;
        if (ImGui.Checkbox("Linkshell5", ref configLs5))
        {
            this.Configuration.Ls5 = configLs5;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine();
        var configLs6 = this.Configuration.Ls6;
        if (ImGui.Checkbox("Linkshell6", ref configLs6))
        {
            this.Configuration.Ls6 = configLs6;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine();
        var configLs7 = this.Configuration.Ls7;
        if (ImGui.Checkbox("Linkshell7", ref configLs7))
        {
            this.Configuration.Ls7 = configLs7;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine();
        var configLs8 = this.Configuration.Ls8;
        if (ImGui.Checkbox("Linkshell6", ref configLs8))
        {
            this.Configuration.Ls8 = configLs8;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.NewLine();

        //Part for crossworldLinkShell

        var configCLs1 = this.Configuration.CLs1;
        if (ImGui.Checkbox("Cls1", ref configCLs1))
        {
            this.Configuration.CLs1 = configCLs1;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine();
        var configCLs2 = this.Configuration.CLs2;
        if (ImGui.Checkbox("Cls2", ref configCLs2))
        {
            this.Configuration.CLs2 = configCLs2;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine();
        var configCLs3 = this.Configuration.CLs3;
        if (ImGui.Checkbox("Cls3", ref configCLs3))
        {
            this.Configuration.CLs3 = configCLs3;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine();
        var configCLs4 = this.Configuration.CLs4;
        if (ImGui.Checkbox("Cls4", ref configCLs4))
        {
            this.Configuration.CLs4 = configCLs4;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.Spacing();
        var configCLs5 = this.Configuration.CLs5;
        if (ImGui.Checkbox("Cls5", ref configCLs5))
        {
            this.Configuration.CLs5 = configCLs5;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine();
        var configCLs6 = this.Configuration.CLs6;
        if (ImGui.Checkbox("Cls6", ref configCLs6))
        {
            this.Configuration.CLs6 = configCLs6;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine();
        var configCLs7 = this.Configuration.CLs7;
        if (ImGui.Checkbox("Cls7", ref configCLs7))
        {
            this.Configuration.CLs7 = configCLs7;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.SameLine();
        var configCLs8 = this.Configuration.CLs8;
        if (ImGui.Checkbox("Cls8", ref configCLs8))
        {
            this.Configuration.CLs8 = configCLs8;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.InfoChannel();
            this.Configuration.Save();
        }
        ImGui.NewLine();


        ImGui.Unindent(30);
        ImGui.EndGroup();

        ImGui.Spacing();
        var configTest = this.Configuration.testInput;
        if(ImGui.InputText("Test de valeur", ref configTest, 255))
        {
            this.Configuration.testInput = configTest;
            this.Configuration.Save();
        }


    }
}
