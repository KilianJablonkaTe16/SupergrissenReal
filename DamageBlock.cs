using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringandeGris
{

    //Samuel har gjort det här
    class DamageBlock:Basklass
    {
        public DamageBlock(Texture2D texture, Vector2 position):base(texture)
        {
            this.texture = texture;
            this.position = position;
        }

        public override void Update(Player player)
        {
            //Ändrar på playerns position när den träffar översidan av ett objekt
            if (ObjectHitbox.Intersects(player.PlayerHitbox) && hitboxes == Hitboxes.Up)
            {


                player.harhoppat = false;
                player.position.Y = ObjectHitbox.Location.Y - player.PlayerHitbox.Height;
                player.health--;

            }

            //Ändrar på playerns position när den träffar undersidan av ett objekt
            else if (ObjectHitbox.Intersects(player.PlayerHitbox) && hitboxes == Hitboxes.Down)
            {

                player.position.Y = ObjectHitbox.Location.X + player.PlayerHitbox.Height;
                player.health--;
            }
            else if (ObjectHitbox.Intersects(player.PlayerHitbox) && hitboxes == Hitboxes.Left)
            {

                player.position.X = ObjectHitbox.Location.X - player.PlayerHitbox.Width;
                player.harhoppat = true;
                player.health--;

            }


        }



        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, position, Color.White);
        }






    }
}
