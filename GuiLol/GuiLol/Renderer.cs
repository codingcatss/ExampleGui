using ClickableTransparentOverlay;
using ImGuiNET;
using System;
using System.Numerics;

namespace GuiLol
{
    internal class Renderer : Overlay
    {
        public int page = 0;
        public bool aim;
        public int smoothing;
        public bool trigger;
        public int delay;
        public bool esp;
        public bool bhop;
        public Vector4 guiColor = new Vector4(0.7f, 0.7f, 0.7f, 0.7f);
        public Vector4 titleColor = new Vector4(0.7f, 0.7f, 0.7f, 0.7f);
        public Vector4 buttonColor = new Vector4(0.7f, 0.7f, 0.7f, 0.7f);
        public float guiRounding;
        public string name = "";
        public string version = "";
        protected override void Render()
        {
            name = "GUI";
            version = "v0.1";
            ImGui.Begin(name + " - " + version);
            ImGuiStylePtr style = ImGui.GetStyle();
            style.WindowBorderSize = 0.0f;
            style.FrameBorderSize = 1.0f;
            style.WindowRounding = guiRounding;

            // Main GUI
            style.Colors[(int)ImGuiCol.WindowBg] = guiColor;

            // Resize Grip (NOT CONFIGURABLE)
            style.Colors[(int)ImGuiCol.ResizeGrip] = guiColor;
            style.Colors[(int)ImGuiCol.ResizeGripActive] = guiColor;
            style.Colors[(int)ImGuiCol.ResizeGripHovered] = guiColor;

            // Title
            style.Colors[(int)ImGuiCol.TitleBgActive] = titleColor;
            style.Colors[(int)ImGuiCol.TitleBgCollapsed] = titleColor;
            style.Colors[(int)ImGuiCol.TitleBg] = titleColor;

            // Buttons / Checkboxes / Sliders
            style.Colors[(int)ImGuiCol.Button] = buttonColor;
            style.Colors[(int)ImGuiCol.ButtonActive] = buttonColor;
            style.Colors[(int)ImGuiCol.ButtonHovered] = buttonColor;
            style.Colors[(int)ImGuiCol.CheckMark] = buttonColor;
            style.Colors[(int)ImGuiCol.SliderGrab] = buttonColor;
            style.Colors[(int)ImGuiCol.SliderGrabActive] = buttonColor;


            string pathToFont = ""; // Font used in showcase is poppins
            ReplaceFont(pathToFont, 16, FontGlyphRangeType.English);
            ImGui.Text(name + " - " + version);

            if(ImGui.Button("INFO"))
            {
                page = 0;
            }
            ImGui.SameLine();

            if (ImGui.Button("AIM"))
            {
                page = 1;
            }

            ImGui.SameLine();
            if (ImGui.Button("TRIGGER"))
            {
                page = 2;
            }
            ImGui.SameLine();

            if (ImGui.Button("VISUAL"))
            {
                page = 3;
            }
            ImGui.SameLine();

            if (ImGui.Button("MISC"))
            {
                page = 4;
            }
            ImGui.SameLine();

            if (ImGui.Button("GUI"))
            {
                page = 5;
            }

            ImGui.Separator();

            switch(page)
            {
                case 0:
                    ImGui.Text("This is an example GUI");
                    ImGui.Text("This was made in C#");
                    break;
                case 1:
                    ImGui.Checkbox("Aimbot", ref aim);
                    if(aim)
                    {
                        ImGui.SliderInt("Smoothing", ref smoothing, 0, 100);
                    }
                    break;
                case 2:
                    ImGui.Checkbox("Triggerbot", ref trigger);
                    if (trigger)
                    {
                        ImGui.SliderInt("Delay", ref delay, 0, 100);
                    }
                    break;
                case 3:
                    ImGui.Checkbox("ESP", ref esp);
                    break;
                case 4:
                    ImGui.Checkbox("BHop", ref bhop);
                    break;
                case 5:
                    if (ImGui.CollapsingHeader("GUI"))
                    {
                        ImGui.ColorPicker4("##circlecolor", ref guiColor);
                        ImGui.SliderFloat("GUI Opacity", ref guiColor.W, 0.0f, 1.0f);
                        ImGui.SliderFloat("GUI Rounding", ref guiRounding, 0.0f, 25.0f);
                    }

                    if (ImGui.CollapsingHeader("Title"))
                    {
                        ImGui.ColorPicker4("##circlecolor", ref titleColor);
                        ImGui.SliderFloat("Title Opacity", ref titleColor.W, 0.0f, 1.0f);
                    }

                    if (ImGui.CollapsingHeader("Buttons"))
                    {
                        ImGui.ColorPicker4("##circlecolor", ref buttonColor);
                    }
                    break;
            }
        }
    }
}
