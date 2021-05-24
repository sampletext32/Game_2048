using System;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Game_2048
{
    enum Direction
    {
        Right,
        Down,
        Left,
        Up
    }
    class GameEngine
    {
        #region Colors
        Color Color_EmptyCell = Color.FromArgb(35, 238, 228, 218);
        Color Color_FieldBG = Color.FromArgb(187, 173, 160);
        Color Color_CellText = Color.FromArgb(119, 110, 101);
        Color Color_Cell_2 = Color.FromArgb(238, 228, 218);
        Color Color_Cell_4 = Color.FromArgb(237, 224, 200);
        Color Color_Cell_8 = Color.FromArgb(242, 177, 121);
        Color Color_Cell_16 = Color.FromArgb(245, 149, 99);
        Color Color_Cell_32 = Color.FromArgb(246, 124, 95);
        Color Color_Cell_64 = Color.FromArgb(246, 94, 59);
        Color Color_Cell_128 = Color.FromArgb(237, 207, 114);
        Color Color_Cell_256 = Color.FromArgb(237, 204, 97);
        Color Color_Cell_512 = Color.FromArgb(237, 200, 80);
        Color Color_Cell_1024 = Color.FromArgb(237, 197, 63);
        Color Color_Cell_2048 = Color.FromArgb(237, 194, 46);
        #endregion
        private Random rnd = new Random(DateTime.Now.Millisecond);
        const int FieldSize = 4;
        const int DistanceBetweenCells = 5;
        const int CellTextSize = 24;
        const int GameOverTextSize = 44;
        public bool Over
        {
            get;
            private set;
        }
        private int[,] field;

        private bool HasEmpty()
        {
            int countEmpty = 0;
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    if (field[i, j] == -1)
                    {
                        countEmpty++;
                    }
                }
            }
            if (countEmpty == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CanBeAdded()
        {            
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    if (i > 0 && field[i, j] == field[i - 1, j])
                    {
                        return true;
                    }
                    if (i < FieldSize - 1 && field[i, j] == field[i + 1, j])
                    {
                        return true;
                    }
                    if (j > 0 && field[i, j] == field[i, j - 1])
                    {
                        return true;
                    }
                    if (j < FieldSize - 1 && field[i, j] == field[i, j + 1])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private Brush ColorToBrush(Color color)
        {
            return new SolidBrush(color);
        }
        private bool Probability(int percentage)
        {
            if (rnd.Next(0, 101) < percentage)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Init()
        {
            field = new int[FieldSize, FieldSize];
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    field[i, j] = -1;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                int X = 0, Y = 0;
                GetRandomEmpty(ref X, ref Y);
                field[X, Y] = 2;
            }
        }
        public void Restart()
        {
            Init();
            Over = false;
        }
        public void GetRandomEmpty(ref int X, ref int Y)
        {
            if (HasEmpty())
            {
                do
                {
                    X = rnd.Next(0, FieldSize);
                    Y = rnd.Next(0, FieldSize);
                }
                while (field[X, Y] != -1);
            }
        }
        public void PlaceAtRandomPoint(int whatToPlace)
        {
            int X = 0, Y = 0;
            GetRandomEmpty(ref X, ref Y);
            field[X, Y] = whatToPlace;
        }
        public void Draw(Graphics g, int width, int height)
        {
            g.FillRectangle(ColorToBrush(Color_FieldBG), 0, 0, width, height);
            float cellSizeX = (float)(width - DistanceBetweenCells * (FieldSize + 1)) / FieldSize;
            float cellSizeY = (float)(height - DistanceBetweenCells * (FieldSize + 1)) / FieldSize;
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    float XCell = DistanceBetweenCells + i * (cellSizeX + DistanceBetweenCells);
                    float YCell = DistanceBetweenCells + j * (cellSizeX + DistanceBetweenCells);
                    int CellValue = field[i, j];

                    {
                        Brush emptyCellBrush = ColorToBrush(Color_EmptyCell);
                        FillRoundRect(g, emptyCellBrush, XCell, YCell, cellSizeX, cellSizeY, 3);
                        emptyCellBrush.Dispose();
                    }

                    if (CellValue == 2)
                    {
                        Brush CellBrush2 = ColorToBrush(Color_Cell_2);
                        FillRoundRect(g, CellBrush2, XCell, YCell, cellSizeX, cellSizeY, 3);
                        CellBrush2.Dispose();
                    }
                    else if (CellValue == 4)
                    {
                        Brush CellBrush4 = ColorToBrush(Color_Cell_4);
                        FillRoundRect(g, CellBrush4, XCell, YCell, cellSizeX, cellSizeY, 3);
                        CellBrush4.Dispose();
                    }
                    else if (CellValue == 8)
                    {
                        Brush CellBrush8 = ColorToBrush(Color_Cell_8);
                        FillRoundRect(g, CellBrush8, XCell, YCell, cellSizeX, cellSizeY, 3);
                        CellBrush8.Dispose();
                    }
                    else if (CellValue == 16)
                    {
                        Brush CellBrush16 = ColorToBrush(Color_Cell_16);
                        FillRoundRect(g, CellBrush16, XCell, YCell, cellSizeX, cellSizeY, 3);
                        CellBrush16.Dispose();
                    }
                    else if (CellValue == 32)
                    {
                        Brush CellBrush32 = ColorToBrush(Color_Cell_32);
                        FillRoundRect(g, CellBrush32, XCell, YCell, cellSizeX, cellSizeY, 3);
                        CellBrush32.Dispose();
                    }
                    else if (CellValue == 64)
                    {
                        Brush CellBrush64 = ColorToBrush(Color_Cell_64);
                        FillRoundRect(g, CellBrush64, XCell, YCell, cellSizeX, cellSizeY, 3);
                        CellBrush64.Dispose();
                    }
                    else if (CellValue == 128)
                    {
                        Brush CellBrush128 = ColorToBrush(Color_Cell_128);
                        FillRoundRect(g, CellBrush128, XCell, YCell, cellSizeX, cellSizeY, 3);
                        CellBrush128.Dispose();
                    }
                    else if (CellValue == 256)
                    {
                        Brush CellBrush256 = ColorToBrush(Color_Cell_256);
                        FillRoundRect(g, CellBrush256, XCell, YCell, cellSizeX, cellSizeY, 3);
                        CellBrush256.Dispose();
                    }
                    else if (CellValue == 512)
                    {
                        Brush CellBrush512 = ColorToBrush(Color_Cell_512);
                        FillRoundRect(g, CellBrush512, XCell, YCell, cellSizeX, cellSizeY, 3);
                        CellBrush512.Dispose();
                    }
                    else if (CellValue == 1024)
                    {
                        Brush CellBrush1024 = ColorToBrush(Color_Cell_1024);
                        FillRoundRect(g, CellBrush1024, XCell, YCell, cellSizeX, cellSizeY, 3);
                        CellBrush1024.Dispose();
                    }
                    else if (CellValue == 2048)
                    {
                        Brush CellBrush2048 = ColorToBrush(Color_Cell_2048);
                        FillRoundRect(g, CellBrush2048, XCell, YCell, cellSizeX, cellSizeY, 3);
                        CellBrush2048.Dispose();
                    }
                    if (CellValue != -1)
                    {
                        Font f = new Font(FontFamily.GenericSansSerif, CellTextSize);
                        SizeF textSize = g.MeasureString(CellValue.ToString(), f);
                        g.DrawString(CellValue.ToString(), f, ColorToBrush(Color_CellText), XCell + (cellSizeX / 2) - (textSize.Width / 2), YCell + (cellSizeY / 2) - (textSize.Height / 2));
                        f.Dispose();
                    }
                }
            }
            if (Over)
            {
                string text = "GameOver\nPress R\nTo Restart";
                Font f = new Font(FontFamily.GenericSansSerif, GameOverTextSize);
                SizeF textSize = g.MeasureString(text, f);
                g.DrawString(text, f, ColorToBrush(Color_CellText), (width / 2) - (textSize.Width / 2), (height / 2) - (textSize.Height / 2));
                f.Dispose();               
            }
        }
        public void FillRoundRect(Graphics g, Brush b, float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner
            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2)); // Line
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner
            gp.AddLine(x, y + height - (radius * 2), x, y + radius); // Line
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner
            gp.CloseFigure();

            g.FillPath(b, gp);
            gp.Dispose();
        }
        public void OnKeyDown(Direction direction)
        {
            if (!Over)
            {
                int countAffected = 0;
                #region Movement
                switch (direction)
                {
                    case Direction.Right:
                        {
                            for (int i = 0; i < FieldSize; i++)
                            {
                                //0000 <---
                                //0000 <---
                                //0000 <---
                                //0000 <---
                                for (int j = FieldSize - 1; j >= 0; j--)
                                {
                                    //Если текущая не пустая
                                    if (field[j, i] != -1)
                                    {
                                        int startindex = j;
                                        //Бежать от текущей вправо
                                        for (int k = j + 1; k < FieldSize; k++)
                                        {
                                            if (field[k, i] == -1)//Если справа пусто
                                            {
                                                field[k, i] = field[startindex, i];
                                                field[startindex, i] = -1;
                                                startindex++;
                                                countAffected++;
                                            }
                                        }
                                        if (startindex < FieldSize - 1)
                                        {
                                            if (field[startindex + 1, i] == field[startindex, i])//Если справа есть число
                                            {
                                                field[startindex + 1, i] = 2 * field[startindex, i];
                                                field[startindex, i] = -1;
                                                countAffected++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Direction.Down:
                        {
                            for (int i = 0; i < FieldSize; i++)
                            {
                                //0000 /\
                                //0000 ||
                                //0000 ||
                                //0000 ||
                                for (int j = FieldSize - 1; j >= 0; j--)
                                {
                                    //Если текущая не пустая
                                    if (field[i, j] != -1)
                                    {
                                        int startindex = j;
                                        //Бежать от текущей вниз
                                        for (int k = j + 1; k < FieldSize; k++)
                                        {
                                            if (field[i, k] == -1)//Если внизу пусто
                                            {
                                                field[i, k] = field[i, startindex];
                                                field[i, startindex] = -1;
                                                startindex++;
                                                countAffected++;
                                            }
                                        }
                                        if (startindex < FieldSize - 1)
                                        {
                                            if (field[i, startindex + 1] == field[i, startindex])//Если внизу есть число
                                            {
                                                field[i, startindex + 1] = 2 * field[i, startindex];
                                                field[i, startindex] = -1;
                                                countAffected++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Direction.Left:
                        {
                            for (int i = 0; i < FieldSize; i++)
                            {
                                //0000 --->
                                //0000 --->
                                //0000 --->
                                //0000 --->
                                for (int j = 0; j <= FieldSize - 1; j++)
                                {
                                    //Если текущая не пустая
                                    if (field[j, i] != -1)
                                    {
                                        int startindex = j;
                                        //Бежать от текущей влево
                                        for (int k = j - 1; k >= 0; k--)
                                        {
                                            if (field[k, i] == -1)//Если слева пусто
                                            {
                                                field[k, i] = field[startindex, i];
                                                field[startindex, i] = -1;
                                                startindex--;
                                                countAffected++;
                                            }
                                        }
                                        if (startindex > 0)
                                        {
                                            if (field[startindex - 1, i] == field[startindex, i])//Если слева есть число
                                            {
                                                field[startindex - 1, i] = 2 * field[startindex, i];
                                                field[startindex, i] = -1;
                                                countAffected++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Direction.Up:
                        {
                            for (int i = 0; i < FieldSize; i++)
                            {
                                //0000 ||
                                //0000 ||
                                //0000 ||
                                //0000 \/
                                for (int j = 0; j <= FieldSize - 1; j++)
                                {
                                    //Если текущая не пустая
                                    if (field[i, j] != -1)
                                    {
                                        int startindex = j;
                                        //Бежать от текущей влево
                                        for (int k = j - 1; k >= 0; k--)
                                        {
                                            if (field[i, k] == -1)//Если слева пусто
                                            {
                                                field[i, k] = field[i, startindex];
                                                field[i, startindex] = -1;
                                                startindex--;
                                                countAffected++;
                                            }
                                        }
                                        if (startindex > 0)
                                        {
                                            if (field[i, startindex - 1] == field[i, startindex])//Если слева есть число
                                            {
                                                field[i, startindex - 1] = 2 * field[i, startindex];
                                                field[i, startindex] = -1;
                                                countAffected++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
                #endregion

                if (!CanBeAdded() && !HasEmpty())
                {
                    Over = true;
                }
                else
                {
                    if (HasEmpty() && Probability(80))
                    {
                        PlaceAtRandomPoint(2);
                    }
                    if (HasEmpty() && Probability(20))
                    {
                        PlaceAtRandomPoint(4);
                    }
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    sb.Append(field[i, j].ToString("00") + " ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
        public GameEngine()
        {
            Init();
        }
    }
}