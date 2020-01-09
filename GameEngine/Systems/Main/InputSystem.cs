using GameEngine.GameData;
using GameEngine.Generators;
using Microsoft.Xna.Framework.Input;

namespace GameEngine.Systems.Main
{
    public class InputSystem : AbstractSystem
    {
        /*
        public Vector2 mouseStartDrag;
        private float mouseDragTime = 0;
        public bool SelectState { get => mouseDragTime >= 0.08f; }*/

        //public GameObjectList objects = new GameObjectList();

        public override void Update()
        {


                //if (InputCore.isKeyTap(Keys.F))
                //{
                //    for (int i = 0; i < 5; i++)
                //    {
                //        new GameObject("id" + (SystemManager.gameObjects.Count).ToString(),
                //            new List<Component> {
                //        new Transform(),
                //        new ObjSprite("fasf"),
                //        new Particle(new Vector3(Utilites.RandomInt(-50,50), Utilites.RandomInt(-50,50),0))//,
                //        //new Lifetime(2)
                //            }
                //            , true).CreateInWorld(InputCore.mousePos.ToVector2());
                //    }
                //}

                //if (InputCore.isKeyTap(Keys.D))
                //{
                //    GameObject obj =
                //    SystemManager.gameObjects[0];
                //}

                //if (InputCore.isKeyTap(Keys.R))
                //{
                //    SystemManager.gameObjects.Clear();
                //    /*
                //    //SystemManager.GOM.gameObjects.Clear();
                //    for (int i = objects.Count -1; i >= 0; i--)
                //    {
                //        objects.Clear();
                //    }*/
                //}

                if (InputCore.isKeyDown(Keys.Left))
            {
                Camera.position += Utilites.Left * Camera.Speed * SystemManager.deltaTime;
            }
            if (InputCore.isKeyDown(Keys.Right))
            {
                Camera.position += Utilites.Right * Camera.Speed * SystemManager.deltaTime;
            }
            if (InputCore.isKeyDown(Keys.Up))
            {
                Camera.position += Utilites.Top * Camera.Speed * SystemManager.deltaTime;
            }
            if (InputCore.isKeyDown(Keys.Down))
            {
                Camera.position += Utilites.Bottom * Camera.Speed * SystemManager.deltaTime;
            }

            //if (InputCore.activeInput)
            //{
            //    //if (InputCore.OldMouseState.LeftButton == ButtonState.Released)
            //    if (InputCore.MouseState.LeftButton == ButtonState.Pressed)
            //        try
            //        {
            //            SystemManager.map[GameWindow.MouseTilePos.X, GameWindow.MouseTilePos.Y] = true;
            //        }
            //        catch { }
            //    //if (InputCore.OldMouseState.RightButton == ButtonState.Released)
            //    if (InputCore.MouseState.RightButton == ButtonState.Pressed)
            //        try
            //        {
            //            SystemManager.map[GameWindow.MouseTilePos.X, GameWindow.MouseTilePos.Y] = false;
            //        }
            //        catch { }
            //    if (InputCore.isKeyDown(Keys.G))
            //    {
            //        SystemManager.map = CaveGenerator.Generate(50, 50, 50);
            //    }
            //}


            /*
            if (InputCore.activeInput)*/
            {
                /*
                // Управление камерой
                if (InputCore.isKeyDown(Key.W))
                {
                    Camera.position += Utilites.Top.Multiply(Camera.Speed);
                }
                if (InputCore.isKeyDown(Key.A))
                {
                    Camera.position += Utilites.Left.Multiply(Camera.Speed);
                }
                if (InputCore.isKeyDown(Key.S))
                {
                    Camera.position += Utilites.Bottom.Multiply(Camera.Speed);
                }
                if (InputCore.isKeyDown(Key.D))
                {
                    Camera.position += Utilites.Right.Multiply(Camera.Speed);
                }*//*

                // Управление юнитами
                foreach (GameObject obj in SystemManager.System<GameObjectManager>().gameObjects)
                    if (obj.HasComponentType(new PlayerController()))
                        if (obj.Component<PlayerController>().Get())
                        {
                            // Управляем всеми сущностями на которых навешен PlayerController

                            if (InputCore.isKeyTap(Key.Enter))
                            {

                            }
                        }*//*
                // Управление меню
                foreach (GameObject obj in SystemManager.System<GameObjectManager>().gameObjects)
                    if (obj.HasComponentType(new UIbtn()))
                    {
                        if (InputCore.isMouseButtonTap(Mouse.Button.Left))
                        {
                            if (Utilites.PointInRectangle(InputCore.mousePos, Utilites.GetBound(obj)))
                            {
                                obj.Component<UIbtn>().BtnAction();
                                break;
                            }
                        }
                    }
                //RenderSystem.window.SetMouseCursor(new Cursor(ResourseManager.ImageLib["defCursor"].Pixels, new Vector2u(32, 32), new Vector2u(0, 0)));

                if (InputCore.isMouseButtonTap(Mouse.Button.Left) & InputCore.isMouseButtonDown(Mouse.Button.Left))
                    mouseStartDrag = Utilites.GetMousePositionInWorld();

                if (!InputCore.isMouseButtonTap(Mouse.Button.Left) & InputCore.isMouseButtonDown(Mouse.Button.Left))
                {
                    //mouseDragTime += Engine.deltaTime;
                }
                if (InputCore.isMouseButtonRelease(Mouse.Button.Left))
                {
                    mouseDragTime = 0;
                    //SelectUnits(mouseStartDrag, Utilites.GetMousePositionInWorld());
                }

                if (InputCore.isMouseButtonTap(Mouse.Button.Right))
                {
                    //MoveUnits(Utilites.GetMousePositionInWorld());
                }
            }*/
                           // TEST
                           /*
                           if (InputCore.mouseMoveDistance >= 5)
                           {
                               new GameObject(Utilites.RandomString(5, false), new List<Component> {
                               new Transform(InputCore.mousePos),
                               new Entity(false),
                               new ObjColor(Utilites.RandomColor()),
                               new Lifetime(Utilites.RandomInt(1,3)+Utilites.RandomFloat()* Utilites.RandomInt(3, 15)),
                               new TextLabel(new List<string>{ "Woop","Zap","Bip","Zzz","Bzzz" }[Utilites.RandomInt(0,4)] ,14,Engine.DEFAULT_FONT),
                               new Particle(Utilites.Normalize(InputCore.mousePos - InputCore.oldMousePos)*-3)
                               }).CreateInWorld();
                           }*/

            }
            InputCore.InputUpdate();
        }
    }
}
