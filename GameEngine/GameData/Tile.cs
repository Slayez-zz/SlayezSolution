using Microsoft.Xna.Framework;

namespace GameEngine
{
    public class Tile
    {
        public static int tileSize = 16;
        private int _id = 0;

        internal static uint width = 16;
        internal static uint height = 16;

        public int Id { get => _id; set => _id = value; }

        public Tile(int id = 0)
        {
            _id = id;
        }

        public Tile(Tile copy)
        {
            _id = copy._id;
        }

        public static int GetIdFromByteString(string bytestr)
        {
            return CheckTileByteString(bytestr.Substring(0, 4), bytestr.Substring(4, 4)).ToInt(2);
        }

        public static readonly Point GroundTileSetSize = new Point(4, 13);

        public static int GetNormalId(int id)
        {
            return ResourseManager.TileIdDictionary[id];
        }

        public static int GetTileId2D(bool[,] table, Point pos)
        {
            int i = 0, i2 = 0;
            string bytestr = "";
            string bytestr2 = "";

            if (table[pos.X, pos.Y])
            {
                /*     
                     
                 0--1--2
                 |     |
                 3  X  4
                 |     |
                 5--6--7 

                0---=---1
                |       |
                =       =
                |       |
                2---=---3

                *---0---*
                |       |
                1       2
                |       |
                *---3---*                
                
                */
                ;
                for (int y = pos.Y - 1; y < pos.Y + 2; y++)
                    for (int x = pos.X - 1; x < pos.X + 2; x++)
                    {
                        if (x == pos.X | y == pos.Y)
                        {
                            if (x != pos.X | y != pos.Y)
                                if (((x >= 0) & (x < table.GetLength(0))) & ((y >= 0) & (y < table.GetLength(1))))
                                {
                                    bytestr2 =  (table[x, y]).ToBit() + bytestr2;
                                }
                                else
                                    bytestr2 =  "0" + bytestr2;
                        }
                        else
                        {
                            if (x != pos.X | y != pos.Y)
                                if (((x >= 0) & (x < table.GetLength(0))) & ((y >= 0) & (y < table.GetLength(1))))
                                {
                                    bytestr = (table[x, y]).ToBit() + bytestr;
                                }
                                else
                                    bytestr = "0" + bytestr;
                        }
                    }
                bytestr = RevertByteString(bytestr);
                bytestr2 = RevertByteString(bytestr2);
                bytestr = CheckTileByteString(bytestr2, bytestr);
                i = GetIdFromByteString(bytestr);
            }
            return i;
        }

        public static string RevertByteString(string str)
        {
            char[] c = str.ToCharArray();

            for (int i = 0; i < c.Length; i++)
                c[i] = c[i] == '1' ? '0' : '1';
            return new string(c);
        }

        public static string CheckTileByteString(string line, string dot)
        {
            char[] cdot = dot.ToCharArray();
            char[] cline = line.ToCharArray();
            if (cline[0] == '1')
            {
                cdot[0] = '0';
                cdot[1] = '0';
            }
            if (cline[1] == '1')
            {
                cdot[0] = '0';
                cdot[2] = '0';
            }
            if (cline[2] == '1')
            {
                cdot[1] = '0';
                cdot[3] = '0';
            }
            if (cline[3] == '1')
            {
                cdot[3] = '0';
                cdot[2] = '0';
            }
            return new string(cline) + new string(cdot);
        }

        public string GetTexture()
        {
            switch (this._id)
            {
                case 0:
                    return "Void";
                case 1:
                    return "Earth";
                case 2:
                    return "Grass";
                case 3:
                    return "Stone";
            }
            return null;
        }

        public bool IsSolid()
        {
            switch (this._id)
            {
                case 0:
                    return true;
                case 1:
                    return false;
                case 2:
                    return false;
                case 3:
                    return true;
            }
            return true;
        }
    }
}
