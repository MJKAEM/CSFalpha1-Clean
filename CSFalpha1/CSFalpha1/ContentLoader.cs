using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CSFalpha1
{
    public class ContentLoader
    {
        private static Texture2D[] charSprite = new Texture2D[150];
        private static Texture2D[] itemSprite = new Texture2D[200];
        private static Texture2D[] invSprite = new Texture2D[5];
        private static Texture2D[] textureSprite = new Texture2D[10];
        private static SpriteFont[] font = new SpriteFont[5];
        public static void LoadEverything(ContentManager cm)
        {
            LoadCharContent(cm);
            LoadFont(cm);
            LoadInventory(cm);
            LoadItemContent(cm);
            LoadLevelTexture(cm);
        }
        public static void LoadCharContent(ContentManager cm)
        {
            charSprite[0] = cm.Load<Texture2D>("sprites/charactersSprites/Turtle");        //0
            charSprite[1] = cm.Load<Texture2D>("sprites/charactersSprites/TestNPC");
            charSprite[2] = cm.Load<Texture2D>("sprites/charactersSprites/TestMerchant");
            //Heaven Levels 1-5
            charSprite[10] = cm.Load<Texture2D>("sprites/charactersSprites/Slime");        //10
            //Heaven Levels 6-10
            charSprite[15] = cm.Load<Texture2D>("sprites/charactersSprites/Knight");
        }
        public static void LoadItemContent(ContentManager cm)
        {
            //Nothing
            itemSprite[0] = cm.Load<Texture2D>("sprites/Nothing");        //0
            //Health Potions
            itemSprite[1] = cm.Load<Texture2D>("sprites/items/consumables/healthpotions/HealthVial");
            itemSprite[2] = cm.Load<Texture2D>("sprites/items/consumables/healthpotions/HealthBottle");
            itemSprite[3] = cm.Load<Texture2D>("sprites/items/consumables/healthpotions/HealthFlask");
            itemSprite[4] = cm.Load<Texture2D>("sprites/items/consumables/healthpotions/HealthGourd");
            itemSprite[5] = cm.Load<Texture2D>("sprites/items/consumables/healthpotions/HealthPotion");   //5
            itemSprite[6] = cm.Load<Texture2D>("sprites/items/consumables/healthpotions/HealthJar");
            itemSprite[7] = cm.Load<Texture2D>("sprites/items/consumables/healthpotions/HealthPot");
            //itemSprite[8] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[9] = cm.Load<Texture2D>("sprites/Nothing"));
            //One Handed Swords
            itemSprite[10] = cm.Load<Texture2D>("sprites/items/weapons/swords/Dagger");         //10
            itemSprite[11] = cm.Load<Texture2D>("sprites/items/weapons/swords/ShortSword");
            itemSprite[12] = cm.Load<Texture2D>("sprites/items/weapons/swords/HonGim");
            itemSprite[13] = cm.Load<Texture2D>("sprites/items/weapons/swords/Dou");
            //itemSprite[14] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[15] = cm.Load<Texture2D>("sprites/Nothing"));        //15
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //Two Handed Swords
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));        //20
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));        //25
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //Pole Arms
            itemSprite[30] = cm.Load<Texture2D>("sprites/items/weapons/polearms/Cheung");        //30
            itemSprite[31] = cm.Load<Texture2D>("sprites/items/weapons/polearms/Naginata");
            itemSprite[32] = cm.Load<Texture2D>("sprites/items/weapons/polearms/GuaanDou");
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));        //35
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //Maces
            itemSprite[40] = cm.Load<Texture2D>("sprites/items/weapons/maces/Scepter");        //40
            itemSprite[41] = cm.Load<Texture2D>("sprites/items/weapons/maces/Bin");
            itemSprite[42] = cm.Load<Texture2D>("sprites/items/weapons/maces/Flail");
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));        //45
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));
            //itemSprite[2] = cm.Load<Texture2D>("sprites/Nothing"));

        }
        public static void LoadInventory(ContentManager cm)
        {
            invSprite[0] = cm.Load<Texture2D>("sprites/ui/PlayerInventory");           //0
            invSprite[1] = cm.Load<Texture2D>("sprites/ui/MerchantInventory");
            invSprite[2] = cm.Load<Texture2D>("sprites/ui/Belt");
        }
        public static void LoadLevelTexture(ContentManager cm)
        {
            //Town
            textureSprite[0] = cm.Load<Texture2D>("leveltextures/town/Background");           //0
            textureSprite[1] = cm.Load<Texture2D>("leveltextures/town/MerchantHouse");
            textureSprite[2] = cm.Load<Texture2D>("leveltextures/town/MedicHouse");
        }
        public static void LoadFont(ContentManager cm)
        {
            font[0] = cm.Load<SpriteFont>("fonts/Menu");        //0
            font[1] = cm.Load<SpriteFont>("fonts/Chat");
            font[2] = cm.Load<SpriteFont>("fonts/MerchantChat");
        }
        public static Texture2D ItemSprite(int index) { return itemSprite[index]; }
        public static Texture2D CharSprite(int index) { return charSprite[index]; }
        public static Texture2D InvSprite(int index) { return invSprite[index]; }
        public static Texture2D TextureSprite(int index) { return textureSprite[index]; }
        public static SpriteFont Font(int index) { return font[index]; }
    }
}
