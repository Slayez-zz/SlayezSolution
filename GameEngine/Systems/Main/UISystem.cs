using GameEngine.Generators;
using GameEngine.Systems.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

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

            //elements.Add(new TrackBar());
            //((TrackBar)elements[0]).transform.Position = new Vector3(50,50,0);


            elements.Add(new Label());
            elements[0].transform.Position = new Vector3(0, 0, 0);
            ((Label)elements[0]).SetValue("RAM <$! 250,0,0>{0}<$=> Mb\nFPS {1}", "MemoryUse;FramePerSecond", RenderSystem.window);
            ((Label)elements[0]).Scale = 0.5f;
            ((Label)elements[0]).Align = UserInterfaceElement.EAlignUI.leftTop;

            elements.Add(new TrackBar());
            ((TrackBar)elements[1]).transform.Position = new Vector3(50, 50, 0);
            ((TrackBar)elements[1]).MinValue = 1;
            ((TrackBar)elements[1]).MaxValue = 100;
            ((TrackBar)elements[1]).Step = 1;

            elements.Add(new TrackBar());
            ((TrackBar)elements[2]).transform.Position = new Vector3(50, 100, 0);
            ((TrackBar)elements[2]).MinValue = 1;
            ((TrackBar)elements[2]).MaxValue = 100;
            ((TrackBar)elements[2]).Step = 1;

            elements.Add(new Button());
            elements[3].transform.Position = new Vector3(50, 150, 0);
            ((Button)elements[3]).LabelText = "Generate";
            ((Button)elements[3]).ClickAction = test;
            ((Button)elements[3]).LabelScale = 0.5f;

            elements.Add(new Label());
            elements[4].transform.Position = new Vector3(350, 50, 0);
            ((Label)elements[4]).SetValue("HignArea :{0}", "Value", ((TrackBar)elements[1]));
            ((Label)elements[4]).Scale = 0.5f;
            ((Label)elements[4]).Align = UserInterfaceElement.EAlignUI.leftTop;

            elements.Add(new Label());
            elements[5].transform.Position = new Vector3(350, 100, 0);
            ((Label)elements[5]).SetValue("IslandSize :{0}", "Value", ((TrackBar)elements[2]));
            ((Label)elements[5]).Scale = 0.5f;
            ((Label)elements[5]).Align = UserInterfaceElement.EAlignUI.leftTop;
        }

        public void test()
        {

            float[,] hm = DiamondGenerator.ConvertToIsland(DiamondGenerator.DiamondSquare(5, 50, 0.6f), ((TrackBar)elements[1]).Value, ((TrackBar)elements[2]).Value);
            SystemManager.map = new bool[65, 65, 20];
            SystemManager.rm = new bool[65, 65, 20];

            hm = HeightMap.GenIsland(65, 10);

            //hm = HeightMap.Normilize(hm);
            //hm = HeightMap.RoundHeightMap(hm, 1);
            //hm = HeightMap.SetHeight(hm,20);
            
            for (int y = 0; y < SystemManager.map.GetLength(1); y++)
                for (int x = 0; x < SystemManager.map.GetLength(0); x++)
                {
                    hm[x, y] = (int)(hm[x, y]);
                }

            for (int z = 0; z < SystemManager.map.GetLength(2); z++)
                for (int y = 0; y < SystemManager.map.GetLength(1); y++)
                    for (int x = 0; x < SystemManager.map.GetLength(0); x++)
                    {
                        if (z <= hm[x, y])
                        {
                            SystemManager.map[x, y, z] = true;
                        }
                        else
                            SystemManager.map[x, y, z] = false;

                        if (z == 0)
                            SystemManager.map[x, y, z] = true;
                    }
            

            for (int z = 0; z < SystemManager.map.GetLength(2); z++)
                for (int y = 0; y < SystemManager.map.GetLength(1); y++)
                    for (int x = 0; x < SystemManager.map.GetLength(0); x++)
                        if (SystemManager.map[x, y, z])
                        {
                            SystemManager.rm[x, y, z] = Utilites.IsoIsVisible(SystemManager.map, x, y, z);
                        }

        }

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
