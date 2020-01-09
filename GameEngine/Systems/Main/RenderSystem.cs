using GameEngine.Components;
using GameEngine.Components.Main;
using GameEngine.GameData;
using GameEngine.GameObjects;
using GameEngine.Generators;
using GameEngine.Systems.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static GameEngine.Systems.UI.UserInterfaceElement;

namespace GameEngine.Systems.Main
{
    public class RenderSystem : AbstractSystem
    {
        /// <summary>
        /// Окно рендера
        /// </summary> 
        public static GameWindow window = new GameWindow();
        private static SpriteBatch batch { get => window.spriteBatch; }
        /*
        public static Text textBatch = new Text();
        public static Sprite spriteBatch = new Sprite();
        public static RectangleShape rectangleBatch = new RectangleShape();

        /// <summary>
        /// Цвет очистки экрана
        /// </summary>
        public static SFML.Graphics.Color windowColor = new SFML.Graphics.Color(0, 0, 0);
        */
        /*
        /// <summary>
        /// Добавочная отрисовка (освещение)
        /// </summary>
        public static RenderStates BlendMultiply = new RenderStates(RenderStates.Default)
        {
            BlendMode = BlendMode.Multiply
        };

        public static IntRect SetSprite(Texture texture, Vector2u imageCount, Vector2u selectedSprite)
        {
            Vector2u currentImage;
            IntRect uvRect;
            uvRect.Width = (int)(texture.Size.X / imageCount.X);
            uvRect.Height = (int)(texture.Size.Y / imageCount.Y);
            currentImage.X = selectedSprite.X;
            currentImage.Y = selectedSprite.Y;
            uvRect.Left = (int)currentImage.X * uvRect.Width;
            uvRect.Top = (int)currentImage.Y * uvRect.Height;

            return uvRect;
        }
        /*
        public static FloatRect GetTextBound(GameObject obj)
        {
            textBatch.Font = Engine.FontLib[obj.Component<TextLabel>().Font];
            textBatch.DisplayedString = obj.Component<TextLabel>().Text;
            textBatch.CharacterSize = (uint)obj.Component<TextLabel>().CharacterSize;
            textBatch.Position = obj.Component<Components.Main.Transform>().Position.ToVector2i().ToVector2f();
            textBatch.Rotation = obj.Component<Components.Main.Transform>().Rotation;
            return textBatch.GetLocalBounds();
        }

        public static FloatRect GetSpriteBound(GameObject obj)
        {
            spriteBatch.Texture = Engine.TextureLib[obj.Component<ObjSprite>().Texture];
            spriteBatch.TextureRect = new IntRect(new Vector2i(0, 0), Engine.TextureLib[obj.Component<ObjSprite>().Texture].Size.ToVector2i());
            spriteBatch.Position = obj.Component<Components.Main.Transform>().Position;
            spriteBatch.Rotation = 0;
            spriteBatch.Color = Color.White;
            return spriteBatch.GetLocalBounds();
        }*/

        public override void Update()
        {
            window.BeginMyDraw();
            /*
            // - Порядок рисования
            
            // 0. Карта
            if (GameCore.map != null)
                for (int x = 0; x < GameCore.map.width; x++)
                    for (int y = 0; y < GameCore.map.height; y++)
                        if (GameCore.map.data[x, y] != null)
                            DrawTile(x, y, GameCore.map.data[x, y]);

            // 1. Всё кроме UI
            */
            foreach (GameObject obj in SystemManager.gameObjects)
                if (obj.Visible)
                    if (obj.HasComponentType(typeof(Transform)))
                        DrawObj(obj);
            /*
            // Инфо о руде при наведении мышкой
            foreach (GameObject obj in Engine.Manager.System<GameObjectManager>().gameObjects)
                if (obj.HasComponentType(new OreDeposit()))
                {
                    if (Utilites.PointInRectangle(Utilites.GetMousePositionInWorld(), new FloatRect(obj.Component<Components.Transform>().Position,
                        Engine.TextureLib[obj.Component<ObjSprite>().Texture].Size.ToVector2f())))
                    {
                        GameObject label = new GameObject("testobj", new List<Component> {
                            new Components.Transform(),                            
                            new TextLabel($"{OreDeposit.IdToName(obj.Component<OreDeposit>().Id)} {obj.Component<OreDeposit>().Count}",14,Engine.DEFAULT_FONT),
                            new ObjColor(Color.Black),
                            new UIbtn()
                            });
                        label.Component<Components.Transform>().Position = obj.Component<Components.Transform>().Position
                            + new Vector2f(Engine.TextureLib[obj.Component<ObjSprite>().Texture].Size.X / 2, 0)
                            - new Vector2f(GetTextBound(label).Width / 2,0)
                            - new Vector2f(0, GetTextBound(label).Height+10);
                            ;
                        DrawObj(label);
                        break;
                    }
                }
                
            // 2. UI
            foreach (GameObject obj in Engine.Manager.System<GameObjectManager>().gameObjects)
                if (obj.Visible)
                    if (obj.HasComponentType(new Components.Transform()))
                        if (!obj.HasComponentType(new UIbtn()))
                            if (obj.HasComponentType(new UIpanel()))
                                DrawObj(obj);

            foreach (GameObject obj in Engine.Manager.System<GameObjectManager>().gameObjects)
                if (obj.Visible)
                    if (obj.HasComponentType(new Components.Transform()))
                        if (!obj.HasComponentType(new UIpanel()))
                            if (obj.HasComponentType(new UIbtn()))
                            DrawObj(obj);*/

            //DrawUIAlign();
            //DrawTestTileMap();
            //DrawAllTextures();
            //DrawAllTestMap(SystemManager.map);

            DrawTestIsoMap();

            window.EndMyDraw();
        }

        public static void DrawTestIsoMap()
        {
            Vector2 isosize = new Vector2(32, 16);
            Point worldsize = new Point(65, 65);
            Point worldorigin = new Point(worldsize.X / 2, 5);

            Point vMouse = InputCore.mousePos;

            Point vSelected = Utilites.GetIsoPos(InputCore.mousePos - Camera.position.ToPoint(), isosize, worldorigin);

            int mhight = 20;

            //bool[,,] map = new bool[worldsize.X, worldsize.Y, mhight];


            //for (int y = 0; y < worldsize.Y; y++)
            //    for (int x = 0; x < worldsize.X; x++)
            //    {
            //        for (int z = mhight - 1; z >= 0; z--)
            //            if (map[x, y, z])
            //            {
            //                float layer = 0.5f - y * 0.001f - x * 0.001f - z * 0.002f;
            //                string texture = "isowater";

            //                if (z == 0)
            //                    if (map[x, y, z + 1])
            //                        texture = "isoearth";

            //                if (z > 0)
            //                    texture = "isoearth";
            //                if (z > 1)
            //                    texture = "isograss";
            //                if (z > 2)
            //                    texture = "isostone";
            //                batch.Draw(ResourseManager.Texture(texture), new Rectangle((Utilites.ToSpriteIsoTilePos(new Vector3(x, y, z), isosize, worldorigin)).ToPoint(), ResourseManager.Texture("isocube").Bounds.Size), null, Color.LightGreen, 0, new Vector2(), SpriteEffects.None, layer);
            //                break;
            //            }
            //    }


            for (int z = 0; z < mhight; z++)
                for (int y = 0; y < worldsize.Y; y++)
                    for (int x = 0; x < worldsize.X; x++)
                    {
                        if (SystemManager.rm[x, y, z])
                        {
                            float layer = 0.5f - y * 0.001f - x * 0.001f - z * 0.002f;
                            string texture = "isowater";

                            if (z == 0)
                                if (SystemManager.map[x, y, z + 1])
                                    texture = "isoearth";

                            if (z > 0)
                                texture = "isoearth";
                            if (z > 1)
                                texture = "isograss";
                            if (z > 2)
                                texture = "isostone";
                            batch.Draw(ResourseManager.Texture(texture), new Rectangle((Utilites.ToSpriteIsoTilePos(new Vector3(x, y, z), isosize, worldorigin)).ToPoint() - Camera.position.ToPoint(), ResourseManager.Texture(texture).Bounds.Size), null, Color.White, 0, new Vector2(), SpriteEffects.None, layer);
                        }
                    }
            Vector2 playerpos = Utilites.ToIsoMap(SystemManager.player, isosize, worldorigin);
            playerpos.X -= ResourseManager.Texture("player").Bounds.Size.X / 2;
            playerpos.Y -= ResourseManager.Texture("player").Bounds.Size.Y;
            batch.DrawString(ResourseManager.DEFAULT_FONT, playerpos.ToString(), new Vector2(0, 500), Color.White, 0, new Vector2(), 0.5f, SpriteEffects.None, 0);
            batch.Draw(ResourseManager.Texture("player"), new Rectangle( (playerpos - Camera.position).ToPoint(), ResourseManager.Texture("player").Bounds.Size), null, Color.White, 0, new Vector2(), SpriteEffects.None, 0);
            /*
            if ((vSelected.X >= 0) & (vSelected.Y >= 0))
                if ((vSelected.X < worldsize.X) & (vSelected.Y < worldsize.Y))
                {
                    Point p = Utilites.ToSpriteIsoTilePos(vSelected, isosize, worldorigin).ToPoint();
                    if (map[vSelected.X, vSelected.Y, 1])
                        p.Y -= (int)(isosize.Y / 2);
                    batch.Draw(ResourseManager.Texture("isoselected"), new Rectangle(p, isosize.ToPoint()), null, Color.White, 0, new Vector2(), SpriteEffects.None, 0.2f);
                    batch.DrawString(ResourseManager.DEFAULT_FONT, vSelected.ToString(), new Vector2(0, 500), Color.White, 0, new Vector2(), 0.5f, SpriteEffects.None, 0);
                }*/
            //        for (int x = 0; x < 10; x++)
            //    batch.Draw(ResourseManager.Texture("isotransform"), new Vector2(x * 64, 50), Color.White);
            //for (int x = 0; x < 10; x++)
            //    batch.Draw(ResourseManager.Texture("isotransform"), new Vector2(x * 64 + 32, 50 + 16), Color.White);
            //for (int x = 0; x < 10; x++)
            //    batch.Draw(ResourseManager.Texture("isotransform"), new Vector2(x * 64, 50 + 32), Color.White);
        }

        public static void DrawAllTextures()
        {
            int x = 0;
            int y = 0;
            int maxy = 0;
            foreach (Texture2D texture in ResourseManager.Textures)
            {
                batch.Draw(texture, new Rectangle(new Point(x, y), texture.Bounds.Size), null, Color.White, 0, new Vector2(), SpriteEffects.None, 0);
                x += texture.Bounds.Size.X + 5;
            }
        }

        public static void DrawAllTestMap(bool[,] map)
        {

            for (int x = 0; x < map.GetLength(0); x++)
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y])
                    {
                        Rectangle rect = new Rectangle(new Point(x * Tile.tileSize * 2, y * Tile.tileSize * 2), new Point(Tile.tileSize * 2));
                        if (rect.Intersects(new Rectangle(Camera.position.ToPoint(), RenderSystem.window.Size.ToPoint())))
                        {
                            rect = new Rectangle(new Point(x * Tile.tileSize * 2, y * Tile.tileSize * 2) - Camera.position.ToPoint(), new Point(Tile.tileSize * 2));
                            batch.Draw(ResourseManager.Texture("jail_" + (Tile.GetNormalId(Tile.GetTileId2D(map, new Point(x, y))) + 4).ToString()), rect, null, Color.White, 0, new Vector2(), SpriteEffects.None, 0.8f);
                            try
                            {
                                rect = new Rectangle(new Point(x * Tile.tileSize * 2, (y + 1) * Tile.tileSize * 2) - Camera.position.ToPoint(), new Point(Tile.tileSize * 2));
                                if (!map[x, y + 1])
                                    batch.Draw(ResourseManager.Texture("jail_1"), rect, null, Color.White, 0, new Vector2(), SpriteEffects.None, 0.6f);
                            }
                            catch { }
                        }
                        //batch.DrawRectangleWithOutline(new Rectangle(new Point(x * Tile.tileSize, y * Tile.tileSize), new Point(Tile.tileSize)), Color.Red, Color.Aqua, 1, 0.9f);
                        //batch.DrawString(ResourseManager.DEFAULT_FONT, (Tile.GetTileId2D(map, new Point(x, y))).ToString(), new Vector2(x * Tile.tileSize, y * Tile.tileSize), Color.White, 0, new Vector2(), 0.2f, SpriteEffects.None, 0.5f);
                    }
                    else
                    {
                        Rectangle rect = new Rectangle(new Point(x * Tile.tileSize * 2, y * Tile.tileSize * 2), new Point(Tile.tileSize * 2));
                        if (rect.Intersects(new Rectangle(Camera.position.ToPoint(), RenderSystem.window.Size.ToPoint())))
                        {
                            rect = new Rectangle(new Point(x * Tile.tileSize * 2, y * Tile.tileSize * 2) - Camera.position.ToPoint(), new Point(Tile.tileSize * 2));
                            batch.Draw(ResourseManager.Texture("jail_0"), rect, null, Color.White, 0, new Vector2(), SpriteEffects.None, 0.7f);

                        }
                    }
                    //    batch.DrawRectangleWithOutline(new Rectangle(new Point(x * Tile.tileSize, y * Tile.tileSize), new Point(Tile.tileSize)), Color.Black, Color.Aqua, 1, 0.9f);
                }
        }

        public static void DrawTestTileMap()
        {
            bool[,] map = new bool[20, 20];

            //for (int x = 0; x < map.GetLength(0); x++)
            //    for (int y = 0; y < map.GetLength(1); y++)
            //    {
            //        if (x >= 0)
            //            if (x < 5)
            //                if (y >= 0)
            //                    if (y < 5)
            //                        map[x, y] = true;
            //    }

            map[1, 1] = true;
            map[2, 1] = true;

            int rectsize = 36;
            int dotsize = 6;

            int count = 0;
            int yy = 0;

            int line = 4;

            //for (int i = 0; i < 300; i++)
            //{
            //    string bytestr = Convert.ToString(i, 2);

            //    while (bytestr.Length < 8)
            //        bytestr = "0" + bytestr;

            //    bytestr = Tile.CheckTileByteString(bytestr.Substring(0, 4), bytestr.Substring(4, 4));

            //    if (i == (bytestr).ToInt(2))
            //    {
            //        Rectangle rect = new Rectangle(new Point(count * rectsize + 10, yy * rectsize + 50), new Point((int)(rectsize * 0.7f)));
            //        batch.DrawRectangle(rect, Color.AliceBlue, 0, 0.9f);

            //        if (bytestr.Substring(0, 4)[3] == '1')
            //            batch.DrawRectangle(new Rectangle(new Point(rect.X, rect.Y), new Point((int)(rectsize * 0.7f), dotsize)), Color.Crimson, 0, 0.75f);
            //        if (bytestr.Substring(0, 4)[1] == '1')
            //            batch.DrawRectangle(new Rectangle(new Point(rect.X + (int)(rectsize * 0.7f) - dotsize, rect.Y), new Point(dotsize, (int)(rectsize * 0.7f))), Color.Crimson, 0, 0.75f);
            //        if (bytestr.Substring(0, 4)[0] == '1')
            //            batch.DrawRectangle(new Rectangle(new Point(rect.X, rect.Y + (int)(rectsize * 0.7f) - dotsize), new Point((int)(rectsize * 0.7f), dotsize)), Color.Crimson, 0, 0.75f);
            //        if (bytestr.Substring(0, 4)[2] == '1')
            //            batch.DrawRectangle(new Rectangle(new Point(rect.X, rect.Y), new Point(dotsize, (int)(rectsize * 0.7f))), Color.Crimson, 0, 0.75f);


            //        if (bytestr.Substring(4, 4)[3] == '1')
            //            batch.DrawRectangle(new Rectangle(new Point(rect.X - dotsize / 2, rect.Y - dotsize / 2), new Point(dotsize)), Color.Red, 0, 0.8f);
            //        if (bytestr.Substring(4, 4)[1] == '1')
            //            batch.DrawRectangle(new Rectangle(new Point(rect.X - dotsize / 2, rect.Y - dotsize / 2 + rect.Height), new Point(dotsize)), Color.Red, 0, 0.8f);
            //        if (bytestr.Substring(4, 4)[0] == '1')
            //            batch.DrawRectangle(new Rectangle(new Point(rect.X - dotsize / 2 + rect.Width, rect.Y - dotsize / 2 + rect.Height), new Point(dotsize)), Color.Red, 0, 0.8f);
            //        if (bytestr.Substring(4, 4)[2] == '1')
            //            batch.DrawRectangle(new Rectangle(new Point(rect.X - dotsize / 2 + rect.Width, rect.Y - dotsize / 2), new Point(dotsize)), Color.Red, 0, 0.8f);



            //        //batch.DrawString(ResourseManager.DEFAULT_FONT, (yy * line + count).ToString(), rect.Location.ToVector2(), Color.Blue, 0, new Vector2(), 0.28f, SpriteEffects.None, 0.7f);
            //        batch.DrawString(ResourseManager.DEFAULT_FONT, i.ToString(), rect.Location.ToVector2(), Color.Blue, 0, new Vector2(), 0.28f, SpriteEffects.None, 0.7f);
            //        count++;
            //        if (count == line)
            //        {
            //            count = 0;
            //            yy++;
            //        }
            //    }
            //}

            for (int x = 0; x < map.GetLength(0); x++)
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y])
                    {
                        batch.Draw(ResourseManager.Texture("jail_" + (Tile.GetNormalId(Tile.GetTileId2D(map, new Point(x, y))) + 4).ToString()), new Rectangle(new Point(x * Tile.tileSize, y * Tile.tileSize), new Point(Tile.tileSize)), null, Color.White, 0, new Vector2(), SpriteEffects.None, 0.8f);
                        //batch.DrawRectangleWithOutline(new Rectangle(new Point(x * Tile.tileSize, y * Tile.tileSize), new Point(Tile.tileSize)), Color.Red, Color.Aqua, 1, 0.9f);
                        batch.DrawString(ResourseManager.DEFAULT_FONT, (Tile.GetTileId2D(map, new Point(x, y))).ToString(), new Vector2(x * Tile.tileSize, y * Tile.tileSize), Color.White, 0, new Vector2(), 0.2f, SpriteEffects.None, 0.5f);

                    }
                    //else
                    //    batch.DrawRectangleWithOutline(new Rectangle(new Point(x * Tile.tileSize, y * Tile.tileSize), new Point(Tile.tileSize)), Color.Black, Color.Aqua, 1, 0.9f);
                }
        }

        public static void DrawUIAlign()
        {
            batch.DrawRectangle(new Rectangle(EAlignUI.leftTop.ToVector(new Vector2(50, 50)).ToPoint(), new Point(50, 50)), Color.YellowGreen, 0, UISystem.PanelsLayerUI01);
            batch.DrawRectangle(new Rectangle(EAlignUI.rightTop.ToVector(new Vector2(50, 50)).ToPoint(), new Point(50, 50)), Color.YellowGreen, 0, UISystem.PanelsLayerUI01);
            batch.DrawRectangle(new Rectangle(EAlignUI.leftBottom.ToVector(new Vector2(50, 50)).ToPoint(), new Point(50, 50)), Color.YellowGreen, 0, UISystem.PanelsLayerUI01);
            batch.DrawRectangle(new Rectangle(EAlignUI.rightBottom.ToVector(new Vector2(50, 50)).ToPoint(), new Point(50, 50)), Color.YellowGreen, 0, UISystem.PanelsLayerUI01);


            batch.DrawRectangle(new Rectangle(EAlignUI.center.ToVector(new Vector2(50, 50)).ToPoint(), new Point(50, 50)), Color.Yellow, 0, UISystem.PanelsLayerUI01);
            batch.DrawRectangle(new Rectangle(EAlignUI.center.ToVector(new Vector2(150, 150)).ToPoint(), new Point(150, 150)), Color.LightCoral, 0, 1);

            batch.DrawRectangle(new Rectangle(EAlignUI.left.ToVector(new Vector2(50, 50)).ToPoint(), new Point(50, 50)), Color.BurlyWood, 0, UISystem.PanelsLayerUI01);
            batch.DrawRectangle(new Rectangle(EAlignUI.top.ToVector(new Vector2(50, 50)).ToPoint(), new Point(50, 50)), Color.BurlyWood, 0, UISystem.PanelsLayerUI01);
            batch.DrawRectangle(new Rectangle(EAlignUI.right.ToVector(new Vector2(50, 50)).ToPoint(), new Point(50, 50)), Color.BurlyWood, 0, UISystem.PanelsLayerUI01);
            batch.DrawRectangle(new Rectangle(EAlignUI.bottom.ToVector(new Vector2(50, 50)).ToPoint(), new Point(50, 50)), Color.BurlyWood, 0, UISystem.PanelsLayerUI01);

            batch.DrawLine(EAlignUI.top.ToVector(), EAlignUI.center.ToVector(), Color.Blue, 2, UISystem.PanelsLayerUI02);
            batch.DrawLine(EAlignUI.center.ToVector(), EAlignUI.bottom.ToVector(), Color.DarkRed, 2, UISystem.PanelsLayerUI02);
            batch.DrawLine(EAlignUI.left.ToVector(), EAlignUI.center.ToVector(), Color.Aqua, 2, UISystem.PanelsLayerUI02);
            batch.DrawLine(EAlignUI.center.ToVector(), EAlignUI.right.ToVector(), Color.BlueViolet, 2, UISystem.PanelsLayerUI02);

            batch.DrawLine(EAlignUI.leftTop.ToVector(), EAlignUI.center.ToVector(), Color.Blue, 2, UISystem.PanelsLayerUI02);
            batch.DrawLine(EAlignUI.center.ToVector(), EAlignUI.rightBottom.ToVector(), Color.DarkRed, 2, UISystem.PanelsLayerUI02);
            batch.DrawLine(EAlignUI.rightTop.ToVector(), EAlignUI.center.ToVector(), Color.Aqua, 2, UISystem.PanelsLayerUI02);
            batch.DrawLine(EAlignUI.center.ToVector(), EAlignUI.leftBottom.ToVector(), Color.BlueViolet, 2, UISystem.PanelsLayerUI02);

            new Label("leftTop", EAlignUI.leftTop, 0.45f, Color.OrangeRed).Draw();
            new Label("rightTop", EAlignUI.rightTop, 0.45f, Color.OrangeRed).Draw();
            new Label("leftBottom", EAlignUI.leftBottom, 0.45f, Color.OrangeRed).Draw();
            new Label("rightBottom", EAlignUI.rightBottom, 0.45f, Color.OrangeRed).Draw();

            new Label("center", EAlignUI.center, 0.45f, Color.OrangeRed).Draw();

            new Label("top", EAlignUI.top, 0.45f, Color.OrangeRed).Draw();
            new Label("left", EAlignUI.left, 0.45f, Color.OrangeRed).Draw();
            new Label("right", EAlignUI.right, 0.45f, Color.OrangeRed).Draw();
            new Label("bottom", EAlignUI.bottom, 0.45f, Color.OrangeRed).Draw();
        }

        /*
        private void DrawTile(int x, int y, Tile tile)
        {
            spriteBatch.Texture = Engine.TextureLib[tile.GetTexture()];
            spriteBatch.TextureRect = new IntRect(new Vector2i(0, 0), Engine.TextureLib[tile.GetTexture()].Size.ToVector2i());
            spriteBatch.Position = new Vector2f(Tile.width * x, Tile.height * y);
            spriteBatch.Rotation = 0;
            spriteBatch.Color = Color.White;
            if (Utilites.IntersectScreen(spriteBatch.GetLocalBounds()))
            {
                Draw(spriteBatch);
            }
        }
        */
        public static void DrawObj(GameObject obj)
        {
            if (obj.HasComponentType(typeof(ObjSprite)))
            {
                Color c = Color.White;


                if (obj.HasComponentType(typeof(ObjColor)))
                {
                    c = obj.Component<ObjColor>().FillColor;
                }
                /*
                if (ResourseManager.Texture(obj.Component<ObjSprite>().Texture) == null)
                    return;*/
                Rectangle bounds = ResourseManager.Texture(obj.Component<ObjSprite>().Texture).Bounds;
                if (!ResourseManager.LoadedTexture(obj.Component<ObjSprite>().Texture))
                {
                    bounds.Size = (bounds.Size.ToVector2() * 3).ToPoint();
                }
                //batch.DrawRectangle(new Rectangle(obj.Component<Transform>().Position.ToPoint(), new Point(5,5)),c,0,0);
                batch.Draw(ResourseManager.Texture(obj.Component<ObjSprite>().Texture),
                    new Rectangle(obj.Component<Transform>().Position.ToPoint(), bounds.Size),
                    null,
                    c,
                    obj.Component<Transform>().Rotation,
                    new Vector2(),
                    SpriteEffects.None,
                    0);
                /*
                batch.Draw(ResourseManager.Texture(obj.Component<ObjSprite>().Texture), ResourseManager.Texture(obj.Component<ObjSprite>().Texture).Bounds, null, c,
                    obj.Component<Transform>().Rotation, new Vector2(), SpriteEffects.None, 0);*/
                /*
                if (Utilites.IntersectScreen(spriteBatch.GetLocalBounds()))
                {
                    Draw(spriteBatch);
                }*/
            }
            /*
            if (obj.HasComponentType(new UIpanel()))
            {

                rectangleBatch = new RectangleShape(new Vector2f(obj.Component<UIpanel>().Reactangle.Width, obj.Component<UIpanel>().Reactangle.Height));
                rectangleBatch.Position = obj.Component<Components.Transform>().Position.ToVector2i().ToVector2f() 
                    + new Vector2f(obj.Component<UIpanel>().Reactangle.Left,obj.Component<UIpanel>().Reactangle.Top);
                rectangleBatch.Rotation = obj.Component<Components.Transform>().Rotation;

                rectangleBatch.FillColor = new Color(161, 106, 72);
                rectangleBatch.OutlineColor = new Color(26, 23, 22);
                rectangleBatch.OutlineThickness = 1;

                if (Utilites.IntersectScreen(rectangleBatch.GetLocalBounds()))
                {
                    Draw(rectangleBatch);
                }
            }*/

            /*
            if (obj.HasComponentType(new UIbtn()))
            {

                rectangleBatch = new RectangleShape(new Vector2f(GetTextBound(obj).Width + 8, GetTextBound(obj).Height + 8));
                rectangleBatch.Position = obj.Component<Components.Transform>().Position.ToVector2i().ToVector2f() - new Vector2f(4, 2);
                rectangleBatch.Rotation = obj.Component<Components.Transform>().Rotation;

                rectangleBatch.FillColor = new Color(218, 189, 171);
                rectangleBatch.OutlineColor = new Color(79, 72, 67);
                rectangleBatch.OutlineThickness = 1;

                if (Utilites.IntersectScreen(rectangleBatch.GetLocalBounds()))
                {
                    Draw(rectangleBatch);
                }
            }*/
            /*
*/
            /*
            // Отрисовка текста
            if (obj.HasComponentType(new TextLabel(" ")))
            {
                textBatch.Font = Engine.FontLib[obj.Component<TextLabel>().Font];
                textBatch.DisplayedString = obj.Component<TextLabel>().Text;
                textBatch.CharacterSize = (uint)obj.Component<TextLabel>().CharacterSize;
                textBatch.Position = obj.Component<Components.Main.Transform>().Position.ToVector2i().ToVector2f();
                textBatch.Rotation = obj.Component<Components.Main.Transform>().Rotation;

                if (Utilites.IntersectScreen(textBatch.GetLocalBounds()))
                {


                    if (obj.HasComponentType(new ObjColor()))
                    {
                        textBatch.FillColor = obj.Component<ObjColor>().FillColor;
                        textBatch.OutlineColor = obj.Component<ObjColor>().OutlineColor;
                        textBatch.OutlineThickness = obj.Component<ObjColor>().OutlineThickness;
                    }
                    else
                    {
                        textBatch.FillColor = Color.White;
                        textBatch.OutlineColor = Color.White;
                        textBatch.OutlineThickness = 0;
                    }

                    window.Draw(textBatch);
                }
            }*/
        }

        internal void Draw()
        {
            throw new NotImplementedException();
        }
        /*
public override void Initialize()
{
   Vector2u ssize = new Vector2u((uint)Tile.width * 60, (uint)Tile.height * 50);
   window = new RenderWindow(new VideoMode(ssize.X, ssize.Y), GameCore.GameName, Styles.Default);
   window.SetVerticalSyncEnabled(GameSettings.VerticalSync);
   view = new View(new FloatRect(new Vector2f(0, 0), new Vector2f(ssize.X, ssize.Y)));
   window.Closed += new EventHandler(OnClose);
   window.Resized += ResizedWindow;
   Engine.ImageLib.Add("gameIcon", new Image(Engine.TEXTURE_FOLDER + "gameIcon.png"));
   window.SetIcon(64, 64, Engine.ImageLib["gameIcon"].Pixels);
}*/
        /*
        internal void ResizedWindow(object sender, SizeEventArgs e)
        {
            view = new View(new FloatRect(0, 0, e.Width, e.Height));
            window.SetView(view);
        }

        /// <summary>
        /// Действие при закрытии окна
        /// </summary>
        static void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            if (GameSettings.SaveLogs)
                IOCore.SaveLogs();
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        /// <summary>
        /// Очистка экрана
        /// </summary>
        public static void BeginFrame(Vector2f cameraPos)
        {
            window.Clear(windowColor);
            view = new View(new FloatRect(cameraPos, new Vector2f(window.Size.X, window.Size.Y)));
            window.SetView(view);
        }

        /// <summary>
        /// Очистка экрана
        /// </summary>
        public static void ClearScreen(Color color)
        {
            window.Clear(color);
        }

        /// <summary>
        /// Конец кадра
        /// </summary>
        public static void EndFrame()
        {
            window.Display();
        }

        /// <summary>
        /// Рисуем объект
        /// </summary>
        internal static void Draw(Drawable obj)
        {
            window.Draw(obj);
        }

        public static void DrawCircle(Vector2f point, float radius)
        {
            DrawCircle(point, radius, Color.White);
        }

        public static void Draw(Vector2f p1, Vector2f p2)
        {
            Draw(p1, p2, Color.White);
        }

        public static void Draw(Segment segment)
        {
            Draw(segment.A, segment.B);
        }

        public static void Draw(Segment segment, Color color)
        {
            Draw(segment.A, segment.B, color);
            DrawCircle(segment.A, 3, color, true);
            DrawCircle(segment.B, 3, color, true);
        }

        public static void Draw(Vector2f p1, Vector2f p2, Color color)
        {
            VertexArray line = new VertexArray(PrimitiveType.Lines);
            line.Append(new Vertex(p1, color));
            line.Append(new Vertex(p2, color));
            Draw(line);
        }

        public static void DrawVoidCircle(Vector2f point, float radius, Color color, bool drawOverLine = true)
        {
            CircleShape circle = new CircleShape(radius);
            circle.FillColor = new Color(255,255,255,0);
            if (drawOverLine)
            {
                circle.OutlineColor = color;
                circle.OutlineThickness = 2;
            }
            circle.Position = new Vector2f(point.X - radius, point.Y - radius).ToVector2i().ToVector2f();
            Draw(circle);
        }

        public static void DrawCircle(Vector2f point, float radius, Color color, bool drawOverLine = false)
        {
            CircleShape circle = new CircleShape(radius);
            circle.FillColor = color;
            if (drawOverLine)
            {
                circle.OutlineColor = Color.Black;
                circle.OutlineThickness = 1;
            }
            circle.Position = new Vector2f(point.X - radius, point.Y - radius);
            Draw(circle);
        }

        public static void DrawScreenCenter()
        {
            DrawCollisionSquare(Camera.position - new Vector2f(Tile.tileSize / 2, Tile.tileSize / 2) + new Vector2f(((RenderSystem.window.Size.X / Tile.tileSize)) / 2 * Tile.tileSize, ((RenderSystem.window.Size.Y / Tile.tileSize)) / 2 * Tile.tileSize), new Vector2f(Tile.tileSize, Tile.tileSize));
            Draw(new Segment(new Vector2f(RenderSystem.window.Size.X / 2, 0) + Camera.position, new Vector2f(RenderSystem.window.Size.X / 2, RenderSystem.window.Size.Y) + Camera.position));
            Draw(new Segment(new Vector2f(0, RenderSystem.window.Size.Y / 2) + Camera.position, new Vector2f(RenderSystem.window.Size.X, RenderSystem.window.Size.Y / 2) + Camera.position));
            Draw(new Segment(new Vector2f(RenderSystem.window.Size.X, 0) + Camera.position, new Vector2f(0, RenderSystem.window.Size.Y) + Camera.position));
            Draw(new Segment(new Vector2f(0, 0) + Camera.position, new Vector2f(RenderSystem.window.Size.X, RenderSystem.window.Size.Y) + Camera.position));
        }

        public static void DrawCollisionSquare(Vector2f position, Vector2f size, Color color)
        {
            VertexArray line = new VertexArray(PrimitiveType.Lines);
            line.Append(new Vertex(position, color));
            line.Append(new Vertex(new Vector2f(position.X + size.X, position.Y), color));
            line.Append(new Vertex(new Vector2f(position.X + size.X, position.Y + size.Y), color));
            line.Append(new Vertex(new Vector2f(position.X, position.Y + size.Y), color));
            line.Append(new Vertex(position, color));
            line.Append(new Vertex(new Vector2f(position.X, position.Y + size.Y), color));
            line.Append(new Vertex(new Vector2f(position.X + size.X, position.Y + size.Y), color));
            line.Append(new Vertex(new Vector2f(position.X + size.X, position.Y), color));
            Draw(line);
        }

        public static void DrawCollisionSquare(Vector2f position, Vector2f size)
        {
            VertexArray line = new VertexArray(PrimitiveType.Lines);
            line.Append(new Vertex(position, Color.Yellow));
            line.Append(new Vertex(new Vector2f(position.X + size.X, position.Y), Color.Yellow));
            line.Append(new Vertex(new Vector2f(position.X + size.X, position.Y + size.Y), Color.Yellow));
            line.Append(new Vertex(new Vector2f(position.X, position.Y + size.Y), Color.Yellow));
            line.Append(new Vertex(position, Color.Yellow));
            line.Append(new Vertex(new Vector2f(position.X, position.Y + size.Y), Color.Yellow));
            line.Append(new Vertex(new Vector2f(position.X + size.X, position.Y + size.Y), Color.Yellow));
            line.Append(new Vertex(new Vector2f(position.X + size.X, position.Y), Color.Yellow));
            Draw(line);
        }
        */
    }
}
