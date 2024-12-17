using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SnakeGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
        }

        protected override void Initialize()
        {
            base.Initialize();
            GameLogic.ResetGame();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            AssetLoader.LoadContent(Content);
            
            AssetLoader.MenuSoundInstance = AssetLoader.MenuSound.CreateInstance();
            AssetLoader.MenuSoundInstance.IsLooped = true;
            
            AssetLoader.EatSoundInstance = AssetLoader.EatSound.CreateInstance();
            AssetLoader.EatSoundInstance.IsLooped = false;
            
            AssetLoader.DeathSoundInstance = AssetLoader.DeathSound.CreateInstance();
            AssetLoader.DeathSoundInstance.IsLooped = false;
        }

        protected override void Update(GameTime gameTime)
        {
            GameLogic.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Render.Draw(_spriteBatch, GraphicsDevice, gameTime);
            base.Draw(gameTime);
        }
    }
}