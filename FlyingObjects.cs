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
            player.position += velocity;
            

        }





        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
