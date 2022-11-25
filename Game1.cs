using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Topic_4_Time_and_sound
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D bombTexture;
        Rectangle bombRect;
        SpriteFont font;
        float seconds,startTime;
        MouseState mouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            this.Window.Title = "MonoGame Pt4-Time and Sound";
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.PreferredBackBufferWidth = 800;
            bombRect = new Rectangle(50, 50, 700, 400);
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            bombTexture = Content.Load<Texture2D>("bomb");
            font = Content.Load<SpriteFont>("File");
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;
            if (seconds > 15) // Takes a timestamp every 10 seconds.
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            _spriteBatch.Draw(bombTexture, bombRect, Color.White);
            //_spriteBatch.DrawString(font,"1.00", new Vector2(270, 200), Color.White);
            _spriteBatch.DrawString(font, seconds.ToString("00:00"), new Vector2(270, 200), Color.Black);
            
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}