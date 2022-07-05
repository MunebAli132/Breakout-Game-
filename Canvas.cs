using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout
{
    class Canvas : Control
    {
        Bat bat = new Bat { Width = 100, X = Game.Instance.MapSize.X / 2 };
        float maxSpeed = 150;
        float lastMouseX;
        bool mouseControlled = false;
        bool leftDown, rightDown;

        public Canvas()
        {
            DoubleBuffered = true;
            BackColor = Color.Black;
        }

        public void Start()
        {             
            if (DesignMode)
                return;
            Game.Instance.Start();
            Game.Instance.Add(bat);
            Application.Idle += (s, e) => Invalidate();
            KeyDown += Canvas_KeyDown;
            KeyUp += Canvas_KeyUp;
            MouseMove += Canvas_MouseMove;
        }

        private void Canvas_MouseMove(object? sender, MouseEventArgs e)
        {
            lastMouseX = e.X;
            mouseControlled = true;
        }

        private void Canvas_KeyDown(object? sender, KeyEventArgs e)
        {
            mouseControlled = false;
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                leftDown = true;
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                rightDown = true;
        }
        private void Canvas_KeyUp(object? sender, KeyEventArgs e)
        {
            mouseControlled = false;
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                leftDown = false;
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                rightDown = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (DesignMode)
                return;

            if (mouseControlled)
            {
                var x = lastMouseX / Width * (Game.Instance.MapSize.X + 20) - 10;
                var speed = x < bat.X - 1 ? -maxSpeed : x > bat.X + 1 ? maxSpeed : 0;
                bat.Speed = speed;
            }
            else
            {
                bat.Speed = (leftDown ? -maxSpeed : 0) + (rightDown ? maxSpeed : 0);
            }

            Game.Instance.Update();
            e.Graphics.Transform = new Matrix(
                new RectangleF(-10, -50, Game.Instance.MapSize.X + 20, Game.Instance.MapSize.Y + 60),
                new PointF[] {
                    new PointF( 0, Bounds.Height ),
                    new PointF( Bounds.Width, Bounds.Height ),
                    new PointF( )
            });
            Game.Instance.Draw(e.Graphics);
        }


    }
}
