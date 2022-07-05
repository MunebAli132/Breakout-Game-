using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout
{
    class SimpleBrick : Brick
    {
        public override void Draw(Graphics g)
        {
            Draw(g, Brushes.BurlyWood);
        }
        public override void OnHit()
        {
            Deleted = true;
            Game.Instance.Score += 2;
        }

        public override int PackState() => Deleted ? 0 : 1;

        public override void UpdateFromNetwork(int state) => Deleted = state == 0;
    }
}
