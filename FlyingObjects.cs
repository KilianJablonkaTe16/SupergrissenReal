using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringandeGris
{
    class FlyingObjects:ObjektBasklassen
    {
        //Samuel har gjort det här
        
       



        public FlyingObjects(Texture2D texture, Vector2 position):base(texture)
        {
            this.texture = texture;
            this.position = position;
            velocity = new Vector2(-5, 0);
            
        }

        public override void Update(Player player, GameTime gameTime)
        {
<<<<<<< HEAD

            position += velocity;

            if (ObjectHitbox.Intersects(player.PlayerHitbox))
                health = -1;


            //Ändrar på playerns position när den träffar översidan av ett objekt
            if (ObjectHitbox.Intersects(player.PlayerHitbox) && hitboxes == Hitboxes.Up)
            {


                player.harhoppat = false;
               
                if (player.ärodödlig == false)
                {
                    //Playern tar 1 damage
                    player.health--;
                    player.timer = 1000;

                }

                
            }

            //Ändrar på playerns position när den träffar undersidan av ett objekt
            else if (ObjectHitbox.Intersects(player.PlayerHitbox) && hitboxes == Hitboxes.Down)
            {

                 
                if (player.ärodödlig == false)
                {
                    //Playern tar 1 damage
                    player.health--;
                    player.timer = 1000;
                }
            }
            else if (ObjectHitbox.Intersects(player.PlayerHitbox) && hitboxes == Hitboxes.Left)
            {

                
                player.harhoppat = true;
                //Playern tar 1 damage;
                player.health--;
                if (player.ärodödlig == false)
                {

                    player.timer = 1000;
                }

            }
            else if (ObjectHitbox.Intersects(player.PlayerHitbox) && hitboxes == Hitboxes.Right)
            {
                
                player.harhoppat = true;
                player.health--;
                if (player.ärodödlig == false)
                {
                    player.timer = 1000;
                }

            }
=======
            player.position += velocity;
            
>>>>>>> 34c712f9df52516fbf08a595707b6cf405d40e8c

        }





        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
