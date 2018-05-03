using Microsoft.Xna.Framework;
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
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 


    enum Gamestates { inGame, startmenu, pausemenu, shopmenu, levelmenu, deathscreen, exitgame }



    public class Game1 : Game
    {
        public static SoundEffect effect;
        //Samuel har gjort game

        Gamestates gamestates = new Gamestates();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont buyJump;
        Level1 lvl1;
        Camera camera = new Camera();
        public static Random rng = new Random();

<<<<<<< HEAD
        public static Texture2D background, startmenuTexture, pausemenuTexture, shopmenuTexture, playButton, playButtonActive, shopButton, 
                  shopButtonActive, exitButton, exitButtonActive, resumeButton, resumeButtonActive, leaveButton, leaveButtonActive, 
                  buyButton, buyButtonActive, backButton, backButtonActive, flyingsprite, level1Texture, level2Texture, 
                  level3Texture, level4Texture, damagesprite, objectSprite,munkSprite;

=======
        Texture2D background, startmenuTexture, pausemenuTexture, shopmenuTexture, playButton, playButtonActive, shopButton,
                  shopButtonActive, exitButton, exitButtonActive, resumeButton, resumeButtonActive, leaveButton, leaveButtonActive,
                  buyButton, buyButtonActive, backButton, backButtonActive, flyingsprite, levelmenuBackground, level1Texture, level1ZoomTexture, level2Texture, 
                  level3Texture, level4Texture;
>>>>>>> b06bb1bfe2c6369b044cbe6e72074c6c0d7efb15
        Vector2 backgroundTest;
        float backgroundWidth;
        
        

        public static List<ObjektBasklassen> Objekten = new List<ObjektBasklassen>();

        //Instanser av klasser
        #region Klassinstanser
        Startmenu startmenu;
        Shopmenu shopmenu;
        Pausemenu pausemenu;
        Player player;
        LevelMenu levelMenu;
        #endregion

        //Klasslistor

        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            gamestates = Gamestates.startmenu;

            // Inladning av alla textures
            #region Inladning av textures

            Texture2D playerSprite = Content.Load<Texture2D>("player");
            Texture2D playerCrouch = Content.Load<Texture2D>("Crouch");
<<<<<<< HEAD
            objectSprite = Content.Load<Texture2D>("Block");
            flyingsprite = Content.Load<Texture2D>("snow123");
            damagesprite = Content.Load<Texture2D>("images");
=======
            Texture2D objectSprite = Content.Load<Texture2D>("flyingGrasBlock_100x30");
            flyingsprite = Content.Load<Texture2D>("snow123");
            Texture2D damagesprite = Content.Load<Texture2D>("grasBlock_100x60");
>>>>>>> b06bb1bfe2c6369b044cbe6e72074c6c0d7efb15
            background = Content.Load<Texture2D>("Forest-31");
            munkSprite = Content.Load<Texture2D>("snow123");
            backgroundWidth = background.Width;
            backgroundTest = new Vector2(0, 0);

            //Meny bakgrunder
            #region Meny Bakgrunder
            startmenuTexture = Content.Load<Texture2D>("title_screen_almost");
            shopmenuTexture = Content.Load<Texture2D>("liten_shopscreen_test");
            pausemenuTexture = Content.Load<Texture2D>("liten_pausescreen_test");
            levelmenuBackground = Content.Load<Texture2D>("levelmeny_bakgrund_utan");
            #endregion

            //Alla knappterturers
            #region Knapptexturers
            playButton = Content.Load<Texture2D>("playButton");
            playButtonActive = Content.Load<Texture2D>("playButton_active");

            shopButton = Content.Load<Texture2D>("shopButton");
            shopButtonActive = Content.Load<Texture2D>("shopButton_active");

            exitButton = Content.Load<Texture2D>("exitButton");
            exitButtonActive = Content.Load<Texture2D>("exitButton_active");

            resumeButton = Content.Load<Texture2D>("resumeButton");
            resumeButtonActive = Content.Load<Texture2D>("resumeButton_active");

            leaveButton = Content.Load<Texture2D>("leaveButton");
            leaveButtonActive = Content.Load<Texture2D>("leaveButton_active");

            backButton = Content.Load<Texture2D>("backButton");
            backButtonActive = Content.Load<Texture2D>("backButton_active");

            buyButton = Content.Load<Texture2D>("buyButton");
            buyButtonActive = Content.Load<Texture2D>("buyButton_active");

            level1Texture = Content.Load<Texture2D>("level-1");
            level1ZoomTexture = Content.Load<Texture2D>("level-1-zoom");

            level2Texture = Content.Load<Texture2D>("level-2");
            level3Texture = Content.Load<Texture2D>("level-3");
            level4Texture = Content.Load<Texture2D>("level-4");
            #endregion

            buyJump = Content.Load<SpriteFont>("BuyJump");
            #endregion

            startmenu = new Startmenu(startmenuTexture, playButton, playButtonActive, shopButton, shopButtonActive, exitButton, exitButtonActive);
            shopmenu = new Shopmenu(shopmenuTexture, buyButton, buyButtonActive, backButton, backButtonActive);
            levelMenu = new LevelMenu(levelmenuBackground, backButton, backButtonActive);
            pausemenu = new Pausemenu(pausemenuTexture, resumeButton, resumeButtonActive, leaveButton, leaveButtonActive);
            player = new Player(playerSprite, playerCrouch);


            
            
            
                       
<<<<<<< HEAD
           
=======
            //Lägger till 10 blocks på rad med ett avstånd mellan varandra som är bredden på objektet.
            for (int i = 0; i < 1000; i++)
            {
                blocklista.Add(new Block(objectSprite, new Vector2(positionx, 100)));
                
                damageblocks.Add(new DamageBlock(damagesprite, new Vector2(positionx, 424)));

                positionx += blocklista[i].ObjectHitbox.Width + 100;
            }

>>>>>>> b06bb1bfe2c6369b044cbe6e72074c6c0d7efb15

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            lvl1 = new Level1(player);

            effect = Content.Load<SoundEffect>("Jump");

          
          

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {


            // De olika if-satserna  nedan som anroppar de olika "Update" metoderna 
            // är till för att när man till exempel spelaren inte ska fortsätta springa runt 
            // när man har pausat spelet.  


            //Kör "testleveln och playern"
            if (gamestates == Gamestates.inGame)
            #region Allt i test level och player
            {
                IsMouseVisible = false;
                gamestates = lvl1.Update(gameTime, player, effect);

                camera.Update(player.position);
                lvl1.Update(gameTime, player, effect);
            }
            #endregion

            //Lämnar spelet
            if (gamestates == Gamestates.exitgame)
            {
                Exit();
            }


            //Visar start menyn
            if (gamestates == Gamestates.startmenu)
            {
                IsMouseVisible = true;
                gamestates = startmenu.Update();
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Delete))
                    Exit();
            }


            //Visar level menyn
            if (gamestates == Gamestates.levelmenu)
            {
                IsMouseVisible = true;
                gamestates = levelMenu.Update();
            }


            //Visar paus menyn 
            if (gamestates == Gamestates.pausemenu)
            {
                IsMouseVisible = true;
                gamestates = pausemenu.Update();
            }


            //Visar shop menyn
            if (gamestates == Gamestates.shopmenu)
            {
                IsMouseVisible = true;
                gamestates = shopmenu.Update(player);
            }


            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);          

            // De olika "Draw" metoderna nedan anroppas beroende på i vilken gamestate man är. 
            if (gamestates == Gamestates.startmenu)
            {
                spriteBatch.Begin();
                startmenu.Draw(spriteBatch);
                spriteBatch.End();
            }


            if(gamestates == Gamestates.levelmenu)
            {
                spriteBatch.Begin();
                levelMenu.Draw(spriteBatch);
                spriteBatch.End();
            }

            if (gamestates == Gamestates.shopmenu)
            {
                spriteBatch.Begin();
                shopmenu.Draw(spriteBatch, buyJump);
                spriteBatch.End();
            }


            if (gamestates == Gamestates.inGame)
            #region InGame Draw
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.ViewMatrix);

                for (float i = 0; i < 100; i++)
                {
                    spriteBatch.Draw(background, backgroundTest, Color.White);
                    backgroundTest = new Vector2(backgroundWidth * i, 0);
                }


                player.Draw(spriteBatch);
                foreach (ObjektBasklassen objekten in Objekten)
                {
                    objekten.Draw(spriteBatch);
                }
               
                spriteBatch.End();
            }
            #endregion
            

            if (gamestates == Gamestates.pausemenu)
            {
                spriteBatch.Begin();
                pausemenu.Draw(spriteBatch);
                spriteBatch.End();
            }

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
