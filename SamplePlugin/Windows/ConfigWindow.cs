using System;
using System.Numerics;
using System.Reflection.Emit;
using Dalamud.Interface.Components;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace Eorzap.Windows;

public class ConfigWindow : Window, IDisposable
{
    private Configuration Configuration;

    public ConfigWindow(Plugin plugin) : base(
        "Eorzap settings",
        ImGuiWindowFlags.NoCollapse)
    {
        this.SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(700, 400),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };

        this.Configuration = plugin.Configuration;
    }

    public void Dispose() 
    {
        this.Configuration.InfoChannel();
    }

    /// <summary>
    /// Check that the value of the duration doesnt 
    /// exceed the max Apishock value
    /// </summary>
    /// <param name="duration"> duration of a shock in seconds</param>
    /// <returns>Duration of a shock in seconds</returns>
    public int checkDuration(int duration)
    {
        if (duration < 0)
        {
            return duration = 0;
        }
        else if (duration > 15)
        {
            return duration = 15;
        }
        return duration;
    }


    /// <summary>
    /// Check that the intensity isnt over the
    /// api shock limite
    /// </summary>
    /// <param name="intensity">intensity of a shock</param>
    /// <returns>Intensity of a shock inside the apishocks limits</returns>
    public int checkIntensity(int intensity)
    {
        if (intensity < 0)
        {
            return intensity = 0;
        }
        else if (intensity > 100)
        {
            return intensity = 100;
        }
        return intensity;
    }

    public override void Draw()
    {
        //part for the shockpi API
        ImGui.Text("Api info:");
        ImGui.Spacing();
        ImGui.Indent(30);
        var apiKey = this.Configuration.ApiKey;
        if (ImGui.InputTextWithHint("ApiKey", "ApiKey, found on your pishock profile", ref apiKey, 255))
        {
            this.Configuration.ApiKey = apiKey;
            this.Configuration.Save();
        }
        var username = this.Configuration.ShockUsername;
        if(ImGui.InputTextWithHint("Username","The username used on Pishock, case sensitive",ref username, 255))
        {
            this.Configuration.ShockUsername = username;
            this.Configuration.Save();
        }
        ImGui.Spacing();
        var shockCode = this.Configuration.ShockerCode;
        if (ImGui.InputTextWithHint("Code", "Code for the shocker you want controlled, can be generated on the pishock page", ref shockCode, 255))
        {
            this.Configuration.ShockerCode = shockCode;
            this.Configuration.Save();
        }
        ImGui.Unindent(30);

        //Part for the listener

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
        ImGui.Unindent(10);
        ImGui.Text("Linkshells :");
        ImGui.Indent(10);


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
        ImGui.Unindent(10);
        ImGui.Text("CrossLinkshells :");
        ImGui.Indent(10);

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
        ImGui.Text("Main Keyword to listen to:");
        ImGui.Spacing();
        var configKeyword = this.Configuration.mainKeyWord;
        if(ImGui.InputText("Main Keyword", ref configKeyword, 255))
        {
            this.Configuration.mainKeyWord = configKeyword;
            this.Configuration.Save();
        }
        ImGui.Spacing();
        ImGui.Text("Trigger after keywoard");
        ImGui.Spacing();
        ImGui.Indent(15);
        ImGui.Spacing();
        ImGui.Text("Triger1");
        var configTriger1 = this.Configuration.triggerWords[0];
        if (ImGui.InputText("Triger1", ref configTriger1, 255))
        {
            this.Configuration.triggerWords[0] = configTriger1;
            this.Configuration.Save();
        }
        ImGui.Spacing();
        var configIntensity1 = this.Configuration.intensityArray[0];
        if (ImGui.InputInt("Intensity 1",ref configIntensity1,1))
        {
            configIntensity1 = this.checkIntensity(configIntensity1);
            this.Configuration.intensityArray[0] = configIntensity1;
            this.Configuration.Save();
        }
        ImGui.Spacing();
        var configDuration1 = this.Configuration.durationArray[0];
        if (ImGui.InputInt("Duration 1", ref configDuration1, 1))
        {
            configDuration1 = this.checkDuration(configDuration1);
            this.Configuration.durationArray[0] = configDuration1;
            this.Configuration.Save();
        }
        ImGui.Spacing();

        // 2nd trigger

        ImGui.Spacing();
        ImGui.Text("Trigger2");
        var configTriger2 = this.Configuration.triggerWords[1];
        if (ImGui.InputText("Trigger 2", ref configTriger2, 255))
        {
            this.Configuration.triggerWords[1] = configTriger2;
            this.Configuration.Save();
        }
        ImGui.Spacing();
        var configIntensity2 = this.Configuration.intensityArray[1];
        if (ImGui.InputInt("Intensity 2", ref configIntensity2, 2))
        {
            configIntensity2 = this.checkIntensity(configIntensity2);
            this.Configuration.intensityArray[1] = configIntensity2;
            this.Configuration.Save();
        }
        ImGui.Spacing();
        var configDuration2 = this.Configuration.durationArray[1];
        if (ImGui.InputInt("Duration 2", ref configDuration2, 1))
        {
            configDuration2 = this.checkDuration(configDuration2);
            this.Configuration.durationArray[1] = configDuration2;
            this.Configuration.Save();
        }
        // 3rd trigger

        ImGui.Spacing();
        ImGui.Text("Trigger3");
        var configTriger3 = this.Configuration.triggerWords[2];
        if (ImGui.InputText("Trigger 3", ref configTriger3, 255))
        {
            this.Configuration.triggerWords[2] = configTriger3;
            this.Configuration.Save();
        }
        ImGui.Spacing();
        var configIntensity3 = this.Configuration.intensityArray[2];
        if (ImGui.InputInt("Intensity 3", ref configIntensity3, 1))
        {
            configIntensity3 = this.checkIntensity(configIntensity3);
            this.Configuration.intensityArray[2] = configIntensity3;
            this.Configuration.Save();
        }
        ImGui.Spacing();
        var configDuration3 = this.Configuration.durationArray[2];
        if (ImGui.InputInt("Duration 3", ref configDuration3, 1))
        {
            configDuration3 = this.checkDuration(configDuration3);
            this.Configuration.durationArray[2] = configDuration3;
            this.Configuration.Save();
        }

        // 4th trigger

        ImGui.Spacing();
        ImGui.Text("Trigger4");
        var configTriger4 = this.Configuration.triggerWords[3];
        if (ImGui.InputText("Trigger 4", ref configTriger4, 255))
        {
            this.Configuration.triggerWords[3] = configTriger4;
            this.Configuration.Save();
        }
        ImGui.Spacing();
        var configIntensity4 = this.Configuration.intensityArray[3];
        if (ImGui.InputInt("Intensity 4", ref configIntensity4, 1))
        {
            configIntensity4 = this.checkIntensity(configIntensity4);
            this.Configuration.intensityArray[3] = configIntensity4;
            this.Configuration.Save();
        }
        ImGui.Spacing();
        var configDuration4 = this.Configuration.durationArray[3];
        if (ImGui.InputInt("Duration 4", ref configDuration4, 1))
        {
            configDuration4 = this.checkDuration(configDuration4);
            this.Configuration.durationArray[3] = configDuration4;
            this.Configuration.Save();
        }



    }
}
