using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        SoundEffect  explode;
        Texture2D nukeTexture;
        Rectangle nukeRect;
        bool exploded = false;
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
            nukeRect = new Rectangle(50, 50, 700, 400);
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            bombTexture = Content.Load<Texture2D>("bomb");
            font = Content.Load<SpriteFont>("File");
            explode = Content.Load<SoundEffect>("explosion");
            nukeTexture = Content.Load<Texture2D>("nuke");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;
            
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;
            
            if (seconds >= 15 && !exploded)
            {
                explode.Play();
                exploded = true;
            }
            if (seconds >= 20) 
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            _spriteBatch.Draw(bombTexture, bombRect, Color.White);
            //_spriteBatch.DrawString(font,"1.00", new Vector2(270, 200), Color.White);
            _spriteBatch.DrawString(font,(15 - seconds).ToString("00:00"), new Vector2(270, 200), Color.Black);
            if (seconds >= 15) 
            {
                _spriteBatch.Draw(nukeTexture, nukeRect, Color.White);
            }
           
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}