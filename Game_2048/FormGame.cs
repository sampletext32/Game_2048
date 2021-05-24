using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_2048
{
    public partial class FormGame : Form
    {
        GameEngine gengine;
        public FormGame()
        {
            InitializeComponent();

            Graphics dpiGraphics = Graphics.FromHwnd(IntPtr.Zero);
            this.AutoScaleDimensions = new SizeF(dpiGraphics.DpiX, dpiGraphics.DpiX);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            dpiGraphics.Dispose();

            gengine = new GameEngine();
        }

        private void pictureBoxField_Paint(object sender, PaintEventArgs e)
        {
            gengine.Draw(e.Graphics, pictureBoxField.Width, pictureBoxField.Height);
        }

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                gengine.OnKeyDown(Direction.Right);
            }
            else if (e.KeyCode == Keys.Left)
            {
                gengine.OnKeyDown(Direction.Left);
            }
            else if (e.KeyCode == Keys.Up)
            {
                gengine.OnKeyDown(Direction.Up);
            }
            else if (e.KeyCode == Keys.Down)
            {
                gengine.OnKeyDown(Direction.Down);
            }
            else if (gengine.Over && e.KeyCode == Keys.R)
            {
                gengine.Restart();
            }
            else
            {
                return;
            }
            pictureBoxField.Refresh();
        }
    }
}
