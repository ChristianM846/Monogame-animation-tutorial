using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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
        Random generator = new Random();
        SoundEffect tribblecoo;

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
            greyTribbleRect = new Rectangle(generator.Next(0, 700), generator.Next(0, 400), 100, 100);
            orangeTribbleRect = new Rectangle(generator.Next(0, 700), generator.Next(0, 400), 100, 100);
            brownTribbleRect = new Rectangle(generator.Next(0, 700), generator.Next(0, 400), 100, 100);
            creamTribbleRect = new Rectangle(generator.Next(0, 700), generator.Next(0, 400), 100, 100);
            tribbleGreySpeed = new Vector2(4, 0);
            tribbleOrangeSpeed = new Vector2(0, 5);
            tribbleBrownSpeed = new Vector2(2, 3);
            tribbleCreamSpeed = new Vector2(7, 2);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribblecoo = Content.Load<SoundEffect>("tribble_coo");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            greyTribbleRect.X += (int)tribbleGreySpeed.X;
            greyTribbleRect.Y += (int)tribbleGreySpeed.Y;

            if (greyTribbleRect.Right > graphics.PreferredBackBufferWidth  || greyTribbleRect.Left < 0)
            {
                tribblecoo.Play();
                tribbleGreySpeed.X *= -1;
                backgroundColor = Color.Gray;
                greyTribbleRect.Y = generator.Next(0, 500);
            }

            orangeTribbleRect.X += (int)tribbleOrangeSpeed.X;
            orangeTribbleRect.Y += (int)tribbleOrangeSpeed.Y;

            if (orangeTribbleRect.Top < 0 || orangeTribbleRect.Bottom > graphics.PreferredBackBufferHeight)
            {
                tribblecoo.Play();
                tribbleOrangeSpeed.Y *= -1;
                backgroundColor = Color.DarkOrange;
                orangeTribbleRect.X = generator.Next(0, 700);
            }

            brownTribbleRect.X += (int)tribbleBrownSpeed.X;
            brownTribbleRect.Y += (int)tribbleBrownSpeed.Y;

            if (brownTribbleRect.Right > graphics.PreferredBackBufferWidth || brownTribbleRect.Left < 0)
            {
                tribbleBrownSpeed.X *= -1;
                backgroundColor = Color.SaddleBrown;
                tribblecoo.Play();
            }

            if (brownTribbleRect.Top < 0 || brownTribbleRect.Bottom > graphics.PreferredBackBufferHeight)
            {
                tribbleBrownSpeed.Y *= -1;
                backgroundColor = Color.SaddleBrown;
                tribblecoo.Play();
            }

            creamTribbleRect.X += (int)tribbleCreamSpeed.X;
            creamTribbleRect.Y += (int)tribbleCreamSpeed.Y;

            if (creamTribbleRect.Right > graphics.PreferredBackBufferWidth || creamTribbleRect.Left < 0)
            {
                tribbleCreamSpeed.X *= -1;
                backgroundColor = Color.PeachPuff;
                tribblecoo.Play();

            }

            if (creamTribbleRect.Top < 0 || creamTribbleRect.Bottom > graphics.PreferredBackBufferHeight)
            {
                tribbleCreamSpeed.Y *= -1;
                backgroundColor = Color.PeachPuff;
                tribblecoo.Play();
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