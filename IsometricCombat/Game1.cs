using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IsometricCombat
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Graph board;

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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            board = new Graph(Content.Load<Texture2D>("tile"), 12, 25);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            //spriteBatch.Begin();
            board.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }

    class Graph
    {
        Texture2D texture;
        int width;
        int height;
        
        
        public Graph(Texture2D texture, int width, int height)
        {
            this.texture = texture;
            this.width = width;
            this.height = height;
        }

        public void Draw(SpriteBatch sb)
        {
            Vector2 pos = new Vector2(0, 0);
            int x = 0;
            int y = 0;
            int sizeMult = 4;
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    sb.Draw(texture, new Rectangle(x,y,texture.Width*sizeMult,texture.Height*sizeMult), Color.White);
                    x += texture.Width*sizeMult;
                }
                y += texture.Width*sizeMult/4;
                x -= width * texture.Width*sizeMult;
                if (x == 0){x = texture.Width * sizeMult / 2;}
                else {x = 0;}
            }
        }
    }
}
