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
        Color backgroundColor;
        

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
            tribbleGreySpeed = new Vector2(69, 69);
            tribbleOrangeSpeed = new Vector2(69, 69);
            tribbleBrownSpeed = new Vector2(69, 69);
            tribbleCreamSpeed = new Vector2(69, 69);
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
                backgroundColor = Color.Red;
            }

            if (greyTribbleRect.Top < 0 || greyTribbleRect.Bottom > graphics.PreferredBackBufferHeight)
            {
                tribbleGreySpeed.Y *= -1;
                backgroundColor = Color.Gray;
            }

            orangeTribbleRect.X += (int)tribbleOrangeSpeed.X;
            orangeTribbleRect.Y += (int)tribbleOrangeSpeed.Y;

            if (orangeTribbleRect.Right > graphics.PreferredBackBufferWidth || orangeTribbleRect.Left < 0)
            {
                tribbleOrangeSpeed.X *= -1;
                backgroundColor = Color.Blue;
            }

            if (orangeTribbleRect.Top < 0 || orangeTribbleRect.Bottom > graphics.PreferredBackBufferHeight)
            {
                tribbleOrangeSpeed.Y *= -1;
                backgroundColor = Color.Orange;
            }

            brownTribbleRect.X += (int)tribbleBrownSpeed.X;
            brownTribbleRect.Y += (int)tribbleBrownSpeed.Y;

            if (brownTribbleRect.Right > graphics.PreferredBackBufferWidth || brownTribbleRect.Left < 0)
            {
                tribbleBrownSpeed.X *= -1;
                backgroundColor = Color.Yellow;
            }

            if (brownTribbleRect.Top < 0 || brownTribbleRect.Bottom > graphics.PreferredBackBufferHeight)
            {
                tribbleBrownSpeed.Y *= -1;
                backgroundColor = Color.SaddleBrown;
            }

            creamTribbleRect.X += (int)tribbleCreamSpeed.X;
            creamTribbleRect.Y += (int)tribbleCreamSpeed.Y;

            if (creamTribbleRect.Right > graphics.PreferredBackBufferWidth || creamTribbleRect.Left < 0)
            {
                tribbleCreamSpeed.X *= -1;
                backgroundColor = Color.Green;

            }

            if (creamTribbleRect.Top < 0 || creamTribbleRect.Bottom > graphics.PreferredBackBufferHeight)
            {
                tribbleCreamSpeed.Y *= -1;
                backgroundColor = Color.PeachPuff;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);
            spriteBatch.Begin();
            spriteBatch.Draw(tribbleGreyTexture, greyTribbleRect, Color.White);
            spriteBatch.Draw(tribbleOrangeTexture, orangeTribbleRect, Color.White);
            spriteBatch.Draw(tribbleBrownTexture, brownTribbleRect, Color.White);
            spriteBatch.Draw(tribbleCreamTexture, creamTribbleRect, Color.White);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}