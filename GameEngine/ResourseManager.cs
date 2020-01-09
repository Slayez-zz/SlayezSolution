using GameEngine.Systems.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace GameEngine
{
    public static class ResourseManager
    {
        public const string FONT_DIR = "Fonts";
        public const string TEXTURE_DIR = "Textures";

        public const string DEFAULT_FONT_NAME = "Vollkorn-Regular";
        public static SpriteFont DEFAULT_FONT { get => _fonts[DEFAULT_FONT_NAME]; }

        public static Color OutlineColor = Color.Black;
        public static Color DisabledColor = new Color(50, 50, 50);
        public static Color NormalColor = new Color(150, 150, 150);
        public static Color MouseOverColor = new Color(200, 200, 200);
        public static Color PressedColor = Color.Firebrick;
        public static Color TextColor = Color.White;

        public static Vector2 MeasureString(this SpriteFont font, string text, float scale)
        {
            return font.MeasureString(text).Multiply(scale);
        }

        public static Vector2 MeasureString(this SpriteFont font, List<string> lines, float scale)
        {
            Vector2 size = new Vector2(0, 0);

            foreach (string text in lines)
            {
                size.Y += font.MeasureString(text, scale).Y;
                if (size.X < font.MeasureString(text, scale).X)
                    size.X = font.MeasureString(text, scale).X;
            }

            return size;
        }

        public static SpriteFont Font(string name)
        {
            return _fonts.ContainsKey(name) ? _fonts[name] : DEFAULT_FONT;
        }

        public static bool LoadedTexture(string name)
        {
            return (_textures.ContainsKey(name));
        }

        public static Texture2D Texture(string name)
        {
            if (_textures.ContainsKey(name))
            {
                return _textures[name];
            }
            else
            {
                return Texture("not_found");
            }
        }

        private static Dictionary<string, SpriteFont> _fonts = new Dictionary<string, SpriteFont>();

        public static List<Texture2D> Textures => new List<Texture2D>(_textures.Values);
        private static Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();

        public static void Instalize()
        {
            LoadTilesId();
            LoadFont("Vollkorn-Regular");
            LoadFont("alagard");
            Texture2D pixel = new Texture2D(RenderSystem.window.GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { new Color(255, 255, 255) });
            _textures.Add("pixel", pixel);
            pixel = new Texture2D(RenderSystem.window.GraphicsDevice, 2, 2);
            pixel.SetData(new Color[] { new Color(255, 0, 255), new Color(0, 0, 0), new Color(0, 0, 0), new Color(255, 0, 255) });
            _textures.Add("not_found", pixel);
            pixel = null;
            LoadTexture("isotransform");
            LoadTexture("isoselected");
            LoadTexture("isocube");
            LoadTexture("isoearth");
            LoadTexture("isograss"); 
            LoadTexture("isostone");
            LoadTexture("isowater");
            LoadTexture("isosand");
            LoadTexture("player");
        }

        public static Dictionary<int, byte> TileIdDictionary = new Dictionary<int, byte>();

        public static void LoadGroundTileSet(string name)
        {
            LoadTexture(name);

            int id = 0;

            for (int y = 0; y < Tile.GroundTileSetSize.Y; y++)
                for (int x = 0; x < Tile.GroundTileSetSize.X; x++)
                {
                    Texture2D newtexture = new Texture2D(RenderSystem.window.GraphicsDevice, Tile.tileSize, Tile.tileSize);
                    Color[] colors = new Color[Tile.tileSize * Tile.tileSize];
                    Rectangle extractRegion = new Rectangle(x * Tile.tileSize, y * Tile.tileSize, Tile.tileSize, Tile.tileSize);
                    _textures[name].GetData<Color>(0, extractRegion, colors, 0, Tile.tileSize * Tile.tileSize);
                    newtexture.SetData(colors);

                    if (id > 3) // Совмещаем текстуру
                    {
                        Color[] newcolors = new Color[Tile.tileSize * Tile.tileSize];
                        extractRegion = new Rectangle(3 * Tile.tileSize, 0, Tile.tileSize, Tile.tileSize);
                        _textures[name].GetData<Color>(0, extractRegion, newcolors, 0, Tile.tileSize * Tile.tileSize);
                        for (int i = 0; i < newcolors.Length; i++)
                        {
                            if (colors[i] != new Color(0, 0, 0, 0))
                                newcolors[i] = colors[i];
                        }
                        newtexture.SetData(newcolors);
                    }
                    _textures.Add(name + "_" + id.ToString(), newtexture);

                    newtexture = null;
                    id++;
                    if (id == Tile.GroundTileSetSize.X * Tile.GroundTileSetSize.Y - 1)
                        return;
                }
        }

        private static void LoadTilesId()
        {
            int count = 0;
            int y = 0;

            int line = 4;

            for (int i = 0; i < 300; i++)
            {
                string bytestr = Convert.ToString(i, 2);

                while (bytestr.Length < 8)
                    bytestr = "0" + bytestr;

                bytestr = Tile.CheckTileByteString(bytestr.Substring(0, 4), bytestr.Substring(4, 4));
                if (i == (bytestr).ToInt(2))
                {
                    TileIdDictionary.Add(i, (byte)(count + y * line));
                    count++;
                    if (count == line)
                    {
                        count = 0;
                        y++;
                    }
                }
            }
        }

        public static bool LoadFont(string name)
        {
            bool a = true;
            if (!_fonts.ContainsKey(name))
            {
                _fonts.Add(name, RenderSystem.window.Content.Load<SpriteFont>($"{FONT_DIR}/{name}"));
            }
            else
                a = false;
            return a;
        }

        public static bool LoadTexture(string name)
        {
            bool a = true;
            if (!_textures.ContainsKey(name))
            {
                _textures.Add(name, RenderSystem.window.Content.Load<Texture2D>($"{TEXTURE_DIR}/{name}"));
            }
            else
                a = false;
            return a;
        }
    }
}
