using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpringandeGris
{
    class LevelMenu
    {
        Texture2D level1, level2, level3, level4;

        public LevelMenu(Texture2D level1, Texture2D level2, Texture2D level3, Texture2D level4)
        {
            this.level1 = level1;
            this.level2 = level2;
            this.level3 = level3;
            this.level4 = level4;
        }

        public Gamestates Update()
        {
            return Gamestates.levelmenu;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(level1, Vector2.Zero, Color.White);
        }
    }
}
