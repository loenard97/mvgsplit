using LiveSplit.MVGSplit.GameHandling;
using LiveSplit.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace LiveSplit.UI.Components
{
    public class MVGSplitComponent : IComponent
    {
        protected InfoTextComponent InternalComponent { get; set; }
        public MVGSplitSettings Settings { get; set; }
        protected LiveSplitState CurrentState { get; set; }

        public string ComponentName => "MVG Split";

        public float HorizontalWidth => InternalComponent.HorizontalWidth;
        public float MinimumWidth => InternalComponent.MinimumWidth;
        public float VerticalHeight => InternalComponent.VerticalHeight;
        public float MinimumHeight => InternalComponent.MinimumHeight;

        public float PaddingTop => InternalComponent.PaddingTop;
        public float PaddingLeft => InternalComponent.PaddingLeft;
        public float PaddingBottom => InternalComponent.PaddingBottom;
        public float PaddingRight => InternalComponent.PaddingRight;

        public IDictionary<string, Action> ContextMenuControls => null;

        private bool GameIsAlive;
        private GameSupport Game;
        private readonly TimerModel _timer;

        public MVGSplitComponent(LiveSplitState state)
        {
            Settings = new MVGSplitSettings();
            InternalComponent = new InfoTextComponent("Reset Chance", "0%");

            CurrentState = state;

            GameIsAlive = false;

            Debug.WriteLine("connect timer");
            _timer = new TimerModel() { CurrentState = state };
            Debug.WriteLine("find game");
            Game = new GameHandling().FindAnyGame();
            Debug.WriteLine("game initialized");
            Game.PrintValues();
            var curGameTime = Game.GetGameTime();
            Debug.WriteLine("set timer to " + curGameTime);
            // _timer.Start();
            _timer.CurrentState.SetGameTime(curGameTime);
            Debug.WriteLine("timer state " + _timer.CurrentState.ToString());
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            InternalComponent.NameLabel.HasShadow
                = InternalComponent.ValueLabel.HasShadow
                = state.LayoutSettings.DropShadows;

            InternalComponent.NameLabel.ForeColor = state.LayoutSettings.TextColor;
            InternalComponent.ValueLabel.ForeColor = state.LayoutSettings.TextColor;

            InternalComponent.DrawHorizontal(g, state, height, clipRegion);
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            InternalComponent.DisplayTwoRows = Settings.Display2Rows;

            InternalComponent.NameLabel.HasShadow
                = InternalComponent.ValueLabel.HasShadow
                = state.LayoutSettings.DropShadows;

            InternalComponent.NameLabel.ForeColor = state.LayoutSettings.TextColor;
            InternalComponent.ValueLabel.ForeColor = state.LayoutSettings.TextColor;

            InternalComponent.DrawVertical(g, state, width, clipRegion);
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            if (GameIsAlive)
            {
                var timerAction = Game.TimerAction();

                if (timerAction == "1")
                    _timer.Start();
                else if (timerAction == "2")
                {
                    _timer.Reset();
                    _timer.Start();
                }
                else if (timerAction == "3")
                    _timer.Split();
                else if (timerAction == "4")
                    _timer.Pause();
                else if (timerAction == "5")
                    _timer.Reset();
            }
            else
            {
                Game = new GameHandling().FindAnyGame();
                GameIsAlive = true;
            }

            InternalComponent.Update(invalidator, state, width, height, mode);
        }

        public void Dispose()
        {
            
        }

        public Control GetSettingsControl(LayoutMode mode)
        {
            Settings.Mode = mode;
            return Settings;
        }

        public System.Xml.XmlNode GetSettings(System.Xml.XmlDocument document)
        {
            return Settings.GetSettings(document);
        }

        public void SetSettings(System.Xml.XmlNode settings)
        {
            Settings.SetSettings(settings);
        }

        public int GetSettingsHashCode() => Settings.GetSettingsHashCode();
    }
}