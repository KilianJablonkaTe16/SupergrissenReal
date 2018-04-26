using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringandeGris
{
    class Player
    {
        //Gabriel har gjort playern

       public bool harhoppat;
       public Texture2D texture, whichTexture, crouchTexture;
       public Vector2 position, velocity;
       float crouchpositiony;
        public int health = 3;
       KeyboardState nowbuttonpressed,lastbuttonpressed;
        
    






        //Konstruktor
        public Player(Texture2D texture, Texture2D crouchTexture)
        {
            this.texture = texture;
            this.crouchTexture = crouchTexture;
            position = new Vector2(50, 320);
            velocity = new Vector2(3, 0);
            harhoppat = false;
            whichTexture = texture;

        }

        public Rectangle PlayerHitbox
        {
            get
            {
                Rectangle playerhitbox = new Rectangle();
                playerhitbox.Location = position.ToPoint();

                playerhitbox.Width = texture.Width;
                playerhitbox.Height = texture.Height;

                return playerhitbox;
            }
        }


        public Gamestates Update()
        {

           nowbuttonpressed = Keyboard.GetState();


            //crouchpositiony = (position.Y + texture.Height) / 2;

            //Gravitation
            velocity += Game1.gravity;
            //Playern rör sig
            position += velocity;
          
            //gör så att bilden rör sig uppåt när jag håller in space.
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && harhoppat == false && nowbuttonpressed != lastbuttonpressed)
            {
                // velocity.Y = -3;
                //position.Y -= 8f;
                velocity.Y = -19f;
                harhoppat = true;
                
            }

            //if (harhoppat == true)
            //{

            //    float i = 1;
            // velocity.Y += 0.5f * i;

            //}

            if (harhoppat == false)
            {

                velocity.Y = 0f;
            }



           // Lägger till en "backe" så att bilden inte rör sig neråt ur bild.
            if (position.Y >= 320)
            {
                position.Y = 320;
                harhoppat = false;

            }



            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                whichTexture = crouchTexture;
                harhoppat = true;
            }
            else
            {
                
                whichTexture = texture;
            }

            lastbuttonpressed = nowbuttonpressed;

            // Pausar spelet. 
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                return Gamestates.pausemenu;
            }

            else
            {
                return Gamestates.inGame;
            }
        }


    public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(whichTexture, position, Color.White);
        }
    }

}
