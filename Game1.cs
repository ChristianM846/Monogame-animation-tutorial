using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_animation_tutorial
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        Texture2D tribbleGreyTexture, tribbleOrangeTexture, tribbleBrownTexture, tribbleCreamTexture;
        Rectangle greyTribbleRect, orangeTribbleRect, brownTribbleRect, creamTribbleRect;
        Vector2 tribbleGreySpeed, tribbleOrangeSpeed, tribbleBrownSpeed, tribbleCreamSpeed;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            greyTribbleRect = new Rectangle(10, 10, 100, 100);
            orangeTribbleRect = new Rectangle(100, 350, 100, 100);
            brownTribbleRect = new Rectangle(600, 500, 100, 100);
            creamTribbleRect = new Rectangle(300, 300, 100, 100);
            tribbleGreySpeed = new Vector2(3, 2);
            tribbleOrangeSpeed = new Vector2(2, 8);
            tribbleBrownSpeed = new Vector2(4, 6);
            tribbleCreamSpeed = new Vector2(11, 2);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            greyTribbleRect.X += (int)tribbleGreySpeed.X;
            greyTribbleRect.Y += (int)tribbleGreySpeed.Y;

            if (greyTribbleRect.Right > graphics.PreferredBackBufferWidth  || greyTribbleRect.Left < 0)
            {
                tribbleGreySpeed.X *= -1;
            }

            if (greyTribbleRect.Top < 0 || greyTribbleRect.Bottom > graphics.PreferredBackBufferHeight)
            {
                tribbleGreySpeed.Y *= -1;
            }

            orangeTribbleRect.X += (int)tribbleOrangeSpeed.X;
            orangeTribbleRect.Y += (int)tribbleOrangeSpeed.Y;

            if (orangeTribbleRect.Right > graphics.PreferredBackBufferWidth || orangeTribbleRect.Left < 0)
            {
                tribbleOrangeSpeed.X *= -1;
            }

            if (orangeTribbleRect.Top < 0 || orangeTribbleRect.Bottom > graphics.PreferredBackBufferHeight)
            {
                tribbleOrangeSpeed.Y *= -1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(tribbleGreyTexture, greyTribbleRect, Color.White);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}