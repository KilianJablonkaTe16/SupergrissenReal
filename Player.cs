﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringandeGris
{
    public class Player
    {
        //Gabriel har gjort playern

       public bool harhoppat;
       public Texture2D texture, whichTexture, crouchTexture;
       public Vector2 position, velocity, center, gravity;
       float rotation, sonicSpeed;
       public float sonicJump;
       public int health = 3;
       KeyboardState nowbuttonpressed,lastbuttonpressed;
       public bool ärodödlig = true;
       public int timer;
       public int munkar = 0;





        //Konstruktor
        public Player(Texture2D texture, Texture2D crouchTexture)
        {
            this.texture = texture;
            this.crouchTexture = crouchTexture;
            position = new Vector2(50, 320);
            velocity = new Vector2(3, 0);
            harhoppat = false;
            whichTexture = texture;
            center = new Vector2(texture.Height / 2, texture.Width / 2);
            sonicJump = -19;
            gravity = new Vector2(0, 0.4f);
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


        public void Update(GameTime gametime, SoundEffect effect)
        {
            if (timer < 0)
            {
                ärodödlig = false;

            }
            else
            {
                timer -= gametime.ElapsedGameTime.Milliseconds;
            }

            if (velocity.X >= 20)
            {
                if (velocity.X >= 20)
                    sonicSpeed = -25;

                if (velocity.X >= 30)
                    sonicSpeed = -15;

                if (velocity.X >= 40)
                    sonicSpeed = -5;
                rotation -= MathHelper.TwoPi / sonicSpeed;
            }






            nowbuttonpressed = Keyboard.GetState();


            //crouchpositiony = (position.Y + texture.Height) / 2;

            //Gravitation
            velocity += gravity;
            //Playern rör sig
            position += velocity;
          
            //gör så att bilden rör sig uppåt när jag håller in space.
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && harhoppat == false && nowbuttonpressed != lastbuttonpressed)
            {
                // velocity.Y = -3;
                //position.Y -= 8f;
                velocity.Y = sonicJump;
                harhoppat = true;
                effect.Play();
                
            }
            
            if (harhoppat == false)
            {
                velocity.Y = 0f;
            }
            //if (harhoppat == true)
            //{

            //    float i = 1;
            // velocity.Y += 0.5f * i;

            //}




            // Lägger till en "backe" så att bilden inte rör sig neråt ur bild.
            //if (position.Y >= 320)
            //{
            //    position.Y = 320;
            //    harhoppat = false;

            //}



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
            //if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            //{
            //    return Gamestates.pausemenu;
            //}

            //else
            //{
            //    return Gamestates.inGame;
            //}
        }


    public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(whichTexture, position, null, Color.White, rotation, center, 1, SpriteEffects.None, 1);
        }
    }

}
