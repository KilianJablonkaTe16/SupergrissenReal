using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringandeGris
    //Samuel har gjort det här
{
    class Block:Basklass
    {
      
        public Block(Texture2D texture, Vector2 position):base(texture)
        {
            this.texture = texture;
            this.position = position;
        }

        //public virtual void Intersect(Rectangle collision, Player player)
        //{
        //    Hitboxes hitboxes = CheckHitboxes(collision, player);
        //    if (hitboxes == Hitboxes.Up)
        //    {

        //        player.velocity.Y = 0;

        //    }
        //}


        public override void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(texture, position, Color.White);
        }

        

    }
}
