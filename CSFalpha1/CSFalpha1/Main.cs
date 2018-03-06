#region Using Statements
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
using VideoDisplay;
using ContentLoader;
using ErrorDepartment;
#endregion

//Elemental Catastrophe 0: Otherworld Tower
namespace CSFalpha1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public sealed class Main : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D cursor;
        private string version = "A.1.0.2013.9.26";
        private MouseState mouseState;

        private static byte gameState;
        private static double playerStatus;
        private static byte collisionValue;

        public Main()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Starting 'EC 0: Otherworld Tower' " + version + ".\n");
            Console.ResetColor();

            Window.Title = "Elemental Catastrophe: Otherworld Tower " + version;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameState = 1; //0 is MenuState; 1 is PlayState; 2 is Credits
            VideoVariables.ResolutionWidth = 640;  // set this value to the desired width of your window
            VideoVariables.ResolutionHeight = 480;   // set this value to the desired height of your window
            graphics.PreferredBackBufferWidth = VideoVariables.ResolutionWidth;
            graphics.PreferredBackBufferHeight = VideoVariables.ResolutionHeight;
            //graphics.ToggleFullScreen();
            IsMouseVisible = true;
            graphics.ApplyChanges();

            Random r = new Random();
            playerStatus = r.Next() * VideoVariables.ResolutionHeight + Math.Sqrt(VideoVariables.ResolutionWidth);
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

            Console.ForegroundColor = ConsoleColor.Green;
            ConsolePrinter.BluePrint("Starting game with resolution: " + VideoVariables.ResolutionWidth + 'x' + VideoVariables.ResolutionHeight + "\n");

            //This is required to set everything to a sprite value!
            Menu.MenuState.Initialize();
            Menu.MenuState.LoadContent();
            Play.PlayState.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            #region Missing cursor icon catch.
            try
            {
                cursor = Content.Load<Texture2D>("sprites/Cursor");
            }
            catch (ContentLoadException)
            {
                ConsolePrinter.RedPrint("You are missing the cursor icon. Continuing the game without it.\n");

                cursor.Dispose();
                IsMouseVisible = true;
            }
            #endregion
            #region Missing other texture catch.

            TheContentLoader.LoadEverything(Content);

            #endregion

            // TODO: use this.Content to load your game content here
        }

        #region Who cares
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        #endregion

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
            if (IsActive)
            {
                //Keyboard input
                KeyboardState keyboardState = Keyboard.GetState();

                //Mouse input
                mouseState = Mouse.GetState();

                //Must come before everything, or else crash!!!

                switch (gameState)
                {
                    case 0://Menu
                        Menu.MenuState.LoadContent();
                        Menu.MenuState.Update(keyboardState, mouseState, this);
                        break;
                    case 1://Game
                        Play.PlayState.Update(keyboardState, mouseState, this);
                        break;
                    case 2://Credits
                        break;
                    default://How to get whooped.
                        ConsolePrinter.RedPrint("Error: Game.gameState must be an integer between 0 to 2, inclusive.");
                        ConsolePrinter.RedPrint("Now stop messing with things you shouldn't be touching.\n");
                        ConsolePrinter.RedPrint("Press any key to return to the menu.");
                        Console.ReadKey(true);
                        gameState = 0;
                        break;
                }
                if (cursor == null)
                {
                    if (Play.PlayState.Player.PickUpItem)
                    {
                        //IsMouseVisible = false;
                    }
                    else
                    {
                        IsMouseVisible = true;
                    }
                }
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

            spriteBatch.Begin();

            switch (gameState)
            {
                case 0:
                    Menu.MenuState.Draw(spriteBatch, mouseState);
                    break;
                case 1:
                    Play.PlayState.Draw(spriteBatch, mouseState);
                    break;
                case 2:
                    break;
            }

            //Draw the cursor to the screen
            if (!Play.PlayState.Player.PickUpItem /*&& !IsMouseVisible*/)
            {
                spriteBatch.Draw(cursor, new Vector2(mouseState.X, mouseState.Y), Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }


        public static void Wop()
        {
            throw new NotImplementedException();
        }

        public static byte GameState { get { return gameState; } set { gameState = value; } }
        public static double PlayerStatusNumber { get { return playerStatus; } }
        public static double PlayerStatus(double a) { return a / playerStatus; }
        public static byte Collision { get { return collisionValue; } set { collisionValue = value; } }
    }
}
