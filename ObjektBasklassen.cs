﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringandeGris
{
    //Samuel har gjort det här 

   public enum Hitboxes { Left, Right, Up, Down }
      public class ObjektBasklassen
    {
        protected Vector2 position, oldposition, velocity;
        protected Texture2D texture;
        protected Hitboxes hitboxes;


        public ObjektBasklassen(Texture2D texture)
        {
            this.texture = texture;


        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public Rectangle ObjectHitbox
        {
            get
            {
                Rectangle objecthitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
                objecthitbox.Location = position.ToPoint();

                objecthitbox.Width = texture.Width;
                objecthitbox.Height = texture.Height;



                return objecthitbox;
            }
        }






         public virtual void Update(Player player, GameTime gameTime)
        {

            //Ändrar på playerns position när den träffar översidan av ett objekt
            if (ObjectHitbox.Intersects(player.PlayerHitbox) && hitboxes == Hitboxes.Up)
            {


                player.harhoppat = false;


                player.position.Y = ObjectHitbox.Location.Y - player.PlayerHitbox.Height;
                player.velocity.Y = 0;

            }

            //Ändrar på playerns position när den träffar undersidan av ett objekt
            if (ObjectHitbox.Intersects(player.PlayerHitbox) && hitboxes == Hitboxes.Down)
            {

                player.position.Y = ObjectHitbox.Location.X + player.PlayerHitbox.Height;
            }

            if (ObjectHitbox.Intersects(player.PlayerHitbox) && hitboxes == Hitboxes.Left)
            {

                player.position.X = ObjectHitbox.Location.X - player.PlayerHitbox.Width;
                //player.harhoppat = true;


            }

            player.harhoppat = true;            
        }




        //Använder enums för att se vilken sida om objektet som spelaren befinner sig om
        //Skapar även nya rektanglar så att se om man är innuti den rektangeln
        public Hitboxes CheckHitboxes(Rectangle collision, Player player)
        {
            if (player.PlayerHitbox.Intersects(new Rectangle(collision.X - ObjectHitbox.Width, collision.Y, ObjectHitbox.Width, ObjectHitbox.Height)))
            {
                hitboxes = Hitboxes.Left;
                return Hitboxes.Left;
            }
            else if (player.PlayerHitbox.Intersects(new Rectangle(collision.X, collision.Y - ObjectHitbox.Height, ObjectHitbox.Width, ObjectHitbox.Height)))
            {
                hitboxes = Hitboxes.Up;
                return Hitboxes.Up;
            }
            else
            {
                hitboxes = Hitboxes.Down;
                return Hitboxes.Down;
            }
        }


    }
}





        

    

     
    

    



