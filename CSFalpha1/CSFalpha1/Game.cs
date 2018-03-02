using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CSFalpha1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D cursor;
        private MouseState mouseState;
        private static int width, height;
        private static byte gameState;
        private static double playerStatus;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameState = 1; //0 is MenuState; 1 is PlayState
            width = 640;  // set this value to the desired width of your window
            height = 480;   // set this value to the desired height of your window
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            //graphics.ToggleFullScreen();
            this.IsMouseVisible = true;
            graphics.ApplyChanges();

            Random r = new Random();
            playerStatus = r.Next() * height + Math.Sqrt(width);
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
            base.Initialize();

            //This is required to set everything to a sprite value!
            Menu.MenuState.Initialize();
            Menu.MenuState.LoadContent();
            Play.PlayState.Initialize();
            Play.PlayState.LoadContent();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            cursor = Content.Load<Texture2D>("sprites/Cursor");
            ContentLoader.LoadEverything(Content);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            //Keyboard input
            KeyboardState keyboardState = Keyboard.GetState();

            //Mouse input
            mouseState = Mouse.GetState();

            //Must come before everything, or else crash!!!
            switch (gameState)
            {
                case 0:
                    Menu.MenuState.LoadContent();
                    Menu.MenuState.Update(keyboardState, mouseState, this);
                    break;
                case 1:
                    Play.PlayState.LoadContent();
                    Play.PlayState.Update(keyboardState, mouseState);
                    break;
                default:
                    Console.WriteLine("Error: Game.gameState must be an integer between 0 to 1.");
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            switch (gameState)
            {
                case 0:
                    Menu.MenuState.Draw(spriteBatch, mouseState);
                    break;
                case 1:
                    Play.PlayState.Draw(spriteBatch, mouseState);
                    break;
            }

            //Draw the cursor to the screen
            if (!Play.PlayState.Player.PickUpItem)
            {
                spriteBatch.Draw(cursor, new Rectangle(mouseState.X, mouseState.Y, 20, 20), Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
        public static int Height { get { return height; } set { height = value; } }
        public static int Width { get { return width; } set { width = value; } }
        public static byte GameState { get { return gameState; } set { gameState = value; } }
        public static double PlayerStatusNumber { get { return playerStatus; } }
        public static double PlayerStatus(double a) { return a / playerStatus; }
    }
}
