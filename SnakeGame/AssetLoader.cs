using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SnakeGame
{
    public static class AssetLoader
    {
        public static Texture2D HeadTexture;
        public static Texture2D BodyTexture;
        public static Texture2D FoodTextureWinter;
        public static Texture2D FoodTextureForest;
        public static Texture2D DeadHeadTexture;
        public static Texture2D DeadBodyTexture;
        public static Texture2D EmptyTextureWinter;
        public static Texture2D EmptyTextureForest;
        public static Texture2D Logo;
        public static Texture2D WinterButton;
        public static Texture2D ForestButton;
        
        
        public static SoundEffect MenuSound;
        public static SoundEffect EatSound;
        public static SoundEffect DeathSound;
        public static SoundEffectInstance MenuSoundInstance;
        public static SoundEffectInstance EatSoundInstance;
        public static SoundEffectInstance DeathSoundInstance;
        
        public static SpriteFont Font;

        public static void LoadContent(ContentManager content)
        {
            HeadTexture = content.Load<Texture2D>("Textures/Head");
            BodyTexture = content.Load<Texture2D>("Textures/Body");
            FoodTextureWinter = content.Load<Texture2D>("Textures/FoodWinter");
            FoodTextureForest = content.Load<Texture2D>("Textures/FoodForest");
            DeadHeadTexture = content.Load<Texture2D>("Textures/DeadHead");
            DeadBodyTexture = content.Load<Texture2D>("Textures/DeadBody");
            EmptyTextureWinter = content.Load<Texture2D>("Textures/EmptyWinter");
            EmptyTextureForest = content.Load<Texture2D>("Textures/EmptyForest");
            Logo = content.Load<Texture2D>("Textures/Logo");
            Font = content.Load<SpriteFont>("Fonts/Font");
            MenuSound = content.Load<SoundEffect>("Sounds/MenuSound");
            EatSound = content.Load<SoundEffect>("Sounds/Eat");
            DeathSound = content.Load<SoundEffect>("Sounds/Death");
            ForestButton = content.Load<Texture2D>("Textures/ForestButton");
            WinterButton = content.Load<Texture2D>("Textures/WinterButton");
        }
    }
}