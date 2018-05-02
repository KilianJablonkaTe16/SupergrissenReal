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
    class LevelMenu:SuperMenu
    {
        SuperButtons levelButton;
        Texture2D level1, level2, level3, level4;

        public LevelMenu(Texture2D level1, Texture2D level2, Texture2D level3, Texture2D level4)
        {
            this.level1 = level1;
            this.level2 = level2;
            this.level3 = level3;
            this.level4 = level4;
            //buttonLista.Add(new SuperButtons(level1, new Vector2(50, 100)));
            //buttonLista.Add(new SuperButtons(shopButton, shopButtonActive, new Vector2(50, 250)));
            //buttonLista.Add(new SuperButtons(exitButton, exitButtonActive, new Vector2(50, 400)));
        }

        public Gamestates Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                return Gamestates.inGame;

            else
                return Gamestates.levelmenu;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(level1, Vector2.Zero, Color.White);
            spriteBatch.Draw(level2, new Vector2(level1.Width, 0), Color.White);
            spriteBatch.Draw(level3, new Vector2(0, level1.Height), Color.White);
            spriteBatch.Draw(level4, new Vector2(level3.Width, level2.Height), Color.White);
        }
    }
}
