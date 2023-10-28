using System;
using System.Numerics;
using Dalamud.Interface.Internal;
using Dalamud.Interface.Windowing;
using FFXIVClientStructs.FFXIV.Common.Configuration;
using ImGuiNET;

namespace Eorzap.Windows;

public class MainWindow : Window, IDisposable
{
    private Plugin Plugin;

    public MainWindow(Plugin plugin) : base(
        "Eorzap Main window", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        this.SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(375, 330),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };

        this.Plugin = plugin;
    }

    public void Dispose()
    {
    }

    public override void Draw()
    {

        ImGui.Spacing();
        if (this.Plugin.Configuration.ApiKey.Length > 0)
        {
            ImGui.Text("Api Key is set");
            ImGui.Spacing();
        }
        if(this.Plugin.Configuration.ShockUsername.Length > 0)
        {
            ImGui.Text("Username is set");
            ImGui.Spacing();
        }
        if (this.Plugin.Configuration.ShockerCode.Length > 0)
        {
            ImGui.Text("Code is set");
            ImGui.Spacing();
        }
        ImGui.Text($"Last ApiCall answer: {this.Plugin.Configuration.resultApiCall}");

        if (ImGui.Button("Show Settings"))
        {
            this.Plugin.DrawConfigUI();
        }

    }
}
