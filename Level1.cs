using Microsoft.Xna.Framework;
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
        int positionx = 0;
        public Level1(Player  player)
        {
           
            for (int i = 0; i < 10; i++)
            {

                Game1.Objekten.Add(new Block(Game1.objectSprite, new Vector2(player.position.X + Game1.rng.Next(100,10000), 100)));

                Game1.Objekten.Add(new DamageBlock(Game1.damagesprite, new Vector2(positionx, 424)));

                positionx += Game1.Objekten[i].ObjectHitbox.Width + 200;
            }
            

        }


        public Gamestates Update(GameTime gameTime, Player player, SoundEffect effect)
        {

            player.Update(gameTime, effect);



            //Kollar när värdet på timer är mindre än 0 och då lägger ut blocks i random positioner
            //Annars så tar den timerns värde minus hur lång tid som har gått.
            if (timer < 0)
            {
                Game1.Objekten.Add(new FlyingObjects(Game1.flyingsprite, new Vector2(15000, Game1.rng.Next(400, 600))));
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
