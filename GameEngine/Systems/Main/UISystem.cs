using GameEngine.Components;
using GameEngine.Components.Main;
using GameEngine.GameObjects;
using GameEngine.Generators;
using GameEngine.Systems.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameEngine.Systems.Main
{
    public class UISystem : AbstractSystem
    {
        private static SpriteBatch batch { get => RenderSystem.window.spriteBatch; }

        public static List<UserInterfaceElement> elements = new List<UserInterfaceElement>();

        public static readonly float PanelsLayerUI01 = 0.9f;
        public static readonly float PanelsLayerUI02 = 0.8f;
        public static readonly float PanelsLayerUI03 = 0.7f;

        public override void Initialize()
        {

            //new GameObject(
            //    "test",
            //    new List<Component> {
            //    new Transform(),
            //    new ObjSprite("jail"),
            //    new Stats(10)
            //},
            //true
            // ).CreateInWorld(new Vector2(0, 0));

            //SystemManager.gameObjects[0].Component<Stats>().hp = 1;
            /*
            elements.Add(new Label());
            elements[0].transform.Position = new Vector2(0, 0);
            ((Label)elements[0]).SetValue("RAM {0} Mb\nFPS {1}", "MemoryUse;FramePerSecond", RenderSystem.window);
            ((Label)elements[0]).Scale = 0.5f;
            ((Label)elements[0]).Align = UserInterfaceElement.EAlignUI.leftBottom;*/
            //elements.Add(new Button());
            //elements[0].transform.Position = new Vector2(10, 0);
            //((Button)elements[0]).LabelText = "Generate Map";
            //((Button)elements[0]).LabelScale = 0.5f;
            //((Button)elements[0]).Align = UserInterfaceElement.EAlignUI.leftBottom;
            //((Button)elements[0]).ClickAction = test;
            //elements.Add(new ProgressBar());
            //((ProgressBar)elements[1]).SetValue("hp","MaxHp",SystemManager.gameObjects[0].Component<Stats>());
            //((ProgressBar)elements[1]).Size =new Vector2(RenderSystem.window.Size.X - 40,25);
            //((ProgressBar)elements[1]).transform.Position = new Vector2(0, 25);
            //((ProgressBar)elements[1]).Align = UserInterfaceElement.EAlignUI.top;

            elements.Add(new TrackBar());
            ((TrackBar)elements[0]).transform.Position = new Vector2(50,50);

            elements.Add(new Button());
            elements[1].transform.Position = new Vector2(50, 100);
            ((Button)elements[1]).LabelText = "Test BTN";
            ((Button)elements[1]).LabelScale = 0.5f;

            elements.Add(new Label());
            elements[2].transform.Position = new Vector2(50, 150);
            ((Label)elements[2]).SetValue("RAM <$! 250,0,0>{0}<$=> Mb\nFPS {1}", "MemoryUse;FramePerSecond", RenderSystem.window);
            ((Label)elements[2]).Scale = 0.5f;
            ((Label)elements[2]).Align = UserInterfaceElement.EAlignUI.leftTop;
        }

        //public void test()
        //{
        //    SystemManager.map = CaveGenerator.Generate(50, 50, 50);
        //}

        public override void Update()
        {
            foreach (UserInterfaceElement element in elements)
            {
                element.Update();
            }
        }

        internal void Draw()
        {
            RenderSystem.window.BeginMyDraw();

            foreach (UserInterfaceElement element in elements)
            {
                element.Draw();
            }            
            //batch.DrawString(ResourseManager.DEFAULT_FONT, InputCore.DragTime.ToString(), new Vector2(0, 0), new Color(255, 0, 0, 150), 0, new Vector2(), 0.5f, SpriteEffects.None, 0);
            //batch.DrawString(ResourseManager.DEFAULT_FONT, "Game objects " + SystemManager.gameObjects.Count.ToString(), new Vector2(0, 25), Color.White, 0, new Vector2(), 0.5f, SpriteEffects.None, 0);
            //batch.DrawString(ResourseManager.DEFAULT_FONT, $"11 % 2 = { ((11 - (11 % 2)) / 2)}", new Vector2(0, 50), Color.White, 0, new Vector2(), 0.5f, SpriteEffects.None, 0);

            RenderSystem.window.EndMyDraw();
        }
    }
}
