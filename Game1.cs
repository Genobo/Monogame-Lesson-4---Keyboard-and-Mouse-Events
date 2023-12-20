using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Lesson_4___Keyboard_and_Mouse_Events
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D pacTexture;
        Rectangle pacLocation;
        KeyboardState keyboardState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            pacLocation = new Rectangle(10, 10, 75, 75);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            pacTexture = Content.Load<Texture2D>("PacSleep");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
            keyboardState = Keyboard.GetState();
            pacTexture = Content.Load<Texture2D>("PacSleep");
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                pacLocation.Y -= 2;
                pacTexture = Content.Load<Texture2D>("PacUp");
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                pacLocation.Y += 2;
                pacTexture = Content.Load<Texture2D>("PacDown");
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                pacLocation.X -= 2;
                pacTexture = Content.Load<Texture2D>("PacLeft");
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                pacLocation.X += 2;
                pacTexture = Content.Load<Texture2D>("PacRight");
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            _spriteBatch.Begin();
            _spriteBatch.Draw(pacTexture, pacLocation, Color.White);
            _spriteBatch.End();
        }
    }
}