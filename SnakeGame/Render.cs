using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnakeGame
{
    public static class Render
    {
        public static void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, GameTime gameTime)
        {
            graphicsDevice.Clear(new Color(93, 169, 198));

            spriteBatch.Begin();

            int offsetX = (800 - (GameLogic.GridHeight * GameLogic.CellSize)) / 2;
            int offsetY = (800 - (GameLogic.GridWidth * GameLogic.CellSize)) / 2;

            if (GameLogic.CurrentState == GameState.Menu)
            {
                AssetLoader.MenuSoundInstance.Play();
                graphicsDevice.Clear(new Color(187, 236, 238));
                spriteBatch.Draw(AssetLoader.Logo, new Vector2(240, 120), null, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
                spriteBatch.DrawString(AssetLoader.Font, "Stiskni libovolnou klávesu pro start", new Vector2(190, 480), new Color(44, 108, 236), 0f, Vector2.Zero, 1.2f, SpriteEffects.None, 0f);
            }
            else if (GameLogic.CurrentState == GameState.Countdown)
            {
                AssetLoader.MenuSoundInstance.Volume = 0.1f;
                graphicsDevice.Clear(new Color(93, 169, 198));
                spriteBatch.DrawString(AssetLoader.Font, $"HRA ZAČÍNÁ ZA.. {((int)GameLogic.CountdownTimer + 1).ToString()}", new Vector2(280, 380), Color.WhiteSmoke, 0f, Vector2.Zero, 1.2f, SpriteEffects.None, 0f);
            }
            else if (GameLogic.CurrentState == GameState.Playing || GameLogic.CurrentState == GameState.GameOver)
            {
                for (int y = 0; y < 17; y++)
                {
                    for (int x = 0; x < 17; x++)
                    {
                        spriteBatch.Draw(AssetLoader.EmptyTexture, new Rectangle(offsetX + x * 35, offsetY + y * 35, 35, 35), Color.White);
                    }
                }

                spriteBatch.Draw(AssetLoader.FoodTexture, new Rectangle(offsetX + GameLogic.Food.X * 35, offsetY + GameLogic.Food.Y * 35, 35, 35), Color.White);

                for (int i = 0; i < GameLogic.Snake.Count; i++)
                {
                    var segment = GameLogic.Snake[i];
                    var texture = (i == 0) ? (GameLogic.IsGameOver ? AssetLoader.DeadHeadTexture : AssetLoader.HeadTexture) : (GameLogic.IsGameOver ? AssetLoader.DeadBodyTexture : AssetLoader.BodyTexture);
                    spriteBatch.Draw(texture, new Rectangle(offsetX + segment.X * 35, offsetY + segment.Y * 35, 35, 35), Color.White);
                }

                spriteBatch.DrawString(AssetLoader.Font, $"SCORE: {GameLogic.Score}", new Vector2(340, 25), Color.White, 0f, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
                spriteBatch.DrawString(AssetLoader.Font, $"HightScore: {GameLogic.HighScore}", new Vector2(330, 60), Color.Gold, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

                if (GameLogic.CurrentState == GameState.GameOver)
                {
                    AssetLoader.MenuSoundInstance.Stop();
                    AssetLoader.EatSoundInstance.Stop();
                    AssetLoader.DeathSoundInstance.Volume = 0.2f;
                    AssetLoader.DeathSoundInstance.IsLooped = false;
                    AssetLoader.DeathSoundInstance.Play();
                    spriteBatch.DrawString(AssetLoader.Font, "Prohrál jsi! Stiskni ENTER pro restart", new Vector2(200, 370), Color.Red, 0f, Vector2.Zero, 1.2f, SpriteEffects.None, 0f);
                }
            }

            spriteBatch.End();
        }
    }
}