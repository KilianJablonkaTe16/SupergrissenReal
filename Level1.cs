﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace SpringandeGris
{
     class Level1
    {
        
        static int  timer = 300;
        int positionx = 100;
        public Level1(Player  player)
        {
           
            for (int i = 0; i < 100; i++)
            {

                //Game1.Objekten.Add(new Block(Game1.objectSprite, new Vector2(player.position.X + Game1.rng.Next(100,10000), Game1.rng.Next(Convert.ToInt32(player.position.X) + player.PlayerHitbox.Height - 50, Convert.ToInt32(player.position.X) + player.PlayerHitbox.Height + 50))));

                Game1.Objekten.Add(new DamageBlock(Game1.damagesprite, new Vector2(positionx, 700)));

                positionx += 200;
            }
            

        }


        public Gamestates Update(GameTime gameTime, Player player, SoundEffect effect)
        {

            player.Update(gameTime, effect);



            //Kollar när värdet på timer är mindre än 0 och då lägger ut blocks i random positioner
            //Annars så tar den timerns värde minus hur lång tid som har gått.
            if (timer < 0)
            {
                Game1.Objekten.Add(new FlyingObjects(Game1.flyingsprite, new Vector2(30000, Game1.rng.Next(100, 300))));
                timer = Game1.rng.Next(3000, 4000);
            }
            else
            {
                timer -= gameTime.ElapsedGameTime.Milliseconds;
            }


            foreach (ObjektBasklassen objekten in Game1.Objekten)
            {
                objekten.Update(player, gameTime);
                objekten.CheckHitboxes(objekten.ObjectHitbox, player);

            }

            foreach (ObjektBasklassen objekten in Game1.Objekten.ToArray())
            {
                if (objekten.health < 0)
                {
                    Game1.Objekten.Remove(objekten);
                }

            }


            //Pausar spelet. 
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                return Gamestates.pausemenu;
            }

            else
            {
                return Gamestates.inGame;
            }

        }



    }
}
