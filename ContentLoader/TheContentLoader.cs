#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using ErrorDepartment;
#endregion

namespace ContentLoader
{
    public static class TheContentLoader
    {
        public static Texture2D BackUp;
        public static Texture2D[] CharSprite = new Texture2D[150];
        public static Texture2D[] NPCSprite = new Texture2D[200];
        public static Texture2D[] WeapSprite = new Texture2D[200];
        public static Texture2D[] ConsSprite = new Texture2D[200];
        public static Texture2D[] ArmorSprite = new Texture2D[200];
        public static Texture2D[] UITexture = new Texture2D[5];
        public static Texture2D[] TextureSprite = new Texture2D[10];
        public static SpriteFont[] Font = new SpriteFont[5];

        public static void LoadEverything(ContentManager cm)
        {
            Console.WriteLine("Let's load everything!\n");

            try { BackUp = cm.Load<Texture2D>("sprites/mt"); }
            catch (ContentLoadException) { ConsolePrinter.RedPrint("You are missing the placeholder texture!\n"); }

            ConsolePrinter.BluePrint("Loading " + Font.Length + " fonts.");
            try { LoadFont(cm); }
            catch (ContentLoadException e) { ConsolePrinter.RedPrint("Missing a font? No playing for you.\n"); throw e; }
            ConsolePrinter.GreenPrint("Loading succeeded!\n");

            try
            {
                ConsolePrinter.BluePrint("Loading " + CharSprite.Length + " character sprites.");
                LoadCharContent(cm);
                ConsolePrinter.GreenPrint("Loading succeeded!\n");
            }
            catch (ContentLoadException e)
            {
                ConsolePrinter.RedPrint("Loading failed!\n");
                ConsolePrinter.GrayPrint(e + "\n");
                ConsolePrinter.RedPrint("This means you are missing a file. Please redownload the game.");
                ConsolePrinter.YellowPrint("However, you may continue playing, but with messed up textures.\n");
                if (HandleItAll.ResponseToFailure())
                {
                    throw e;
                }
            }

            try
            {
                ConsolePrinter.BluePrint("Loading " + TextureSprite.Length + " level textures.");
                LoadLevelTexture(cm);
                ConsolePrinter.GreenPrint("Loading succeeded!\n");
            }
            catch (ContentLoadException e)
            {
                ConsolePrinter.RedPrint("Loading failed!\n");
                ConsolePrinter.GrayPrint(e + "\n");
                ConsolePrinter.RedPrint("This means you are missing a file. Please redownload the game.");
                ConsolePrinter.YellowPrint("However, you may continue playing, but with messed up textures.\n");
                if (HandleItAll.ResponseToFailure())
                {
                    throw e;
                }
            }

            try
            {
                ConsolePrinter.BluePrint("Loading " + UITexture.Length + " user interface textures.");
                LoadInventory(cm);
                ConsolePrinter.GreenPrint("Loading succeeded!\n");
            }
            catch (ContentLoadException e)
            {
                ConsolePrinter.RedPrint("Loading failed!\n");
                ConsolePrinter.GrayPrint(e + "\n");
                ConsolePrinter.RedPrint("This means you are missing a file. Please redownload the game.");
                ConsolePrinter.YellowPrint("However, you may continue playing, but with messed up textures.\n");
                if (HandleItAll.ResponseToFailure())
                {
                    throw e;
                }
            }

            try
            {
                ConsolePrinter.BluePrint("Loading " + WeapSprite.Length + " weapon sprites.");
                LoadWeaponContent(cm);
                ConsolePrinter.GreenPrint("Loading succeeded!\n");
            }
            catch (ContentLoadException e)
            {
                ConsolePrinter.RedPrint("Loading failed!\n");
                ConsolePrinter.GrayPrint(e + "\n");
                ConsolePrinter.RedPrint("This means you are missing a file. Please redownload the game.");
                ConsolePrinter.YellowPrint("However, you may continue playing, but with messed up textures.\n");
                if (HandleItAll.ResponseToFailure())
                {
                    throw e;
                }
            }

            try
            {
                ConsolePrinter.BluePrint("Loading " + ConsSprite.Length + " consumable sprites.");
                LoadConsumableContent(cm);
                ConsolePrinter.GreenPrint("Loading succeeded!\n");
            }
            catch (ContentLoadException e)
            {
                ConsolePrinter.RedPrint("Loading failed!\n");
                ConsolePrinter.GrayPrint(e + "\n");
                ConsolePrinter.RedPrint("This means you are missing a file. Please redownload the game.");
                ConsolePrinter.YellowPrint("However, you may continue playing, but with messed up textures.\n");
                if (HandleItAll.ResponseToFailure())
                {
                    throw e;
                }
            }

            try
            {
                ConsolePrinter.BluePrint("Loading " + ArmorSprite.Length + " armor sprites.");
                LoadArmorContent(cm);
                ConsolePrinter.GreenPrint("Loading succeeded!\n");
            }
            catch (ContentLoadException e)
            {
                ConsolePrinter.RedPrint("Loading failed!\n");
                ConsolePrinter.GrayPrint(e + "\n");
                ConsolePrinter.RedPrint("This means you are missing a file. Please redownload the game.");
                ConsolePrinter.YellowPrint("However, you may continue playing, but with messed up textures.\n");
                if (HandleItAll.ResponseToFailure())
                {
                    throw e;
                }
            }

            try
            {
                ConsolePrinter.BluePrint("Loading " + NPCSprite.Length + " NPC sprites.");
                LoadSpriteContent(cm);
                ConsolePrinter.GreenPrint("Loading succeeded!\n");
            }
            catch (ContentLoadException e)
            {
                ConsolePrinter.RedPrint("Loading failed!\n");
                ConsolePrinter.GrayPrint(e + "\n");
                ConsolePrinter.RedPrint("This means you are missing a file. Please redownload the game.");
                ConsolePrinter.YellowPrint("However, you may continue playing, but with messed up textures.\n");
                if (HandleItAll.ResponseToFailure())
                {
                    throw e;
                }
            }
        }
        private static void LoadCharContent(ContentManager cm)
        {
            CharSprite[0] = cm.Load<Texture2D>("sprites/charactersSprites/Turtle");        //0
        }
        private static void LoadNPCContent(ContentManager cm)
        {
            CharSprite[0] = cm.Load<Texture2D>("sprites/charactersSprites/TestNPC");
            CharSprite[1] = cm.Load<Texture2D>("sprites/charactersSprites/TestMerchant");
            //Heaven Levels 1-5
            CharSprite[10] = cm.Load<Texture2D>("sprites/charactersSprites/Slime");        //10
            //Heaven Levels 6-10
            CharSprite[15] = cm.Load<Texture2D>("sprites/charactersSprites/Knight");
        }
        private static void LoadLevelTexture(ContentManager cm)
        {
            #region Town

            TextureSprite[0] = cm.Load<Texture2D>("leveltextures/town/WholeTownV1");
            //TextureSprite[0] = cm.Load<Texture2D>("leveltextures/town/Grass");
            TextureSprite[1] = cm.Load<Texture2D>("leveltextures/town/Dirt");
            //TextureSprite[1] = cm.Load<Texture2D>("leveltextures/town/MerchantHouse");
            //TextureSprite[2] = cm.Load<Texture2D>("leveltextures/town/MedicHouse");

            #endregion
        }
        private static void LoadFont(ContentManager cm)
        {
            Font[0] = cm.Load<SpriteFont>("fonts/Menu");        //0
            Font[1] = cm.Load<SpriteFont>("fonts/Chat");
            Font[2] = cm.Load<SpriteFont>("fonts/MerchantChat");
            Font[3] = cm.Load<SpriteFont>("fonts/PlayerChat");
        }
        private static void LoadInventory(ContentManager cm)
        {
            UITexture[0] = cm.Load<Texture2D>("sprites/ui/PlayerInventory");
            UITexture[1] = cm.Load<Texture2D>("sprites/ui/MerchantInventory");
            UITexture[2] = cm.Load<Texture2D>("sprites/ui/Belt");
            UITexture[3] = cm.Load<Texture2D>("sprites/ui/HealthBar");
            UITexture[4] = cm.Load<Texture2D>("sprites/ui/HealthBarBorder");
        }
        private static void LoadWeaponContent(ContentManager cm)
        {
            #region One-Handed Swords

            WeapSprite[0] = cm.Load<Texture2D>("sprites/items/weapons/swords/Dagger");
            WeapSprite[1] = cm.Load<Texture2D>("sprites/items/weapons/swords/ShortSword");
            WeapSprite[2] = cm.Load<Texture2D>("sprites/items/weapons/swords/HonGim");
            WeapSprite[3] = cm.Load<Texture2D>("sprites/items/weapons/swords/Dou");

            #endregion

            #region Two-Handed Swords



            #endregion

            #region Polearms

            WeapSprite[20] = cm.Load<Texture2D>("sprites/items/weapons/polearms/Cheong");
            WeapSprite[21] = cm.Load<Texture2D>("sprites/items/weapons/polearms/Naginata");
            WeapSprite[22] = cm.Load<Texture2D>("sprites/items/weapons/polearms/GwaanDou");
            //WeapSprite[23] = cm.Load<Texture2D>("sprites/items/weapons/polearms/Halberd");

            #endregion

            #region Maces

            WeapSprite[30] = cm.Load<Texture2D>("sprites/items/weapons/maces/Scepter");
            WeapSprite[31] = cm.Load<Texture2D>("sprites/items/weapons/maces/Bin");
            WeapSprite[32] = cm.Load<Texture2D>("sprites/items/weapons/maces/Flail");
            //WeapSprite[33] = cm.Load<Texture2D>("sprites/items/weapons/maces/WarHammer");

            #endregion


        }
        private static void LoadConsumableContent(ContentManager cm)
        {
            #region Health Potions

            ConsSprite[0] = cm.Load<Texture2D>("sprites/items/consumables/healthpotions/HealthVial");
            ConsSprite[1] = cm.Load<Texture2D>("sprites/items/consumables/healthpotions/HealthBottle");
            ConsSprite[2] = cm.Load<Texture2D>("sprites/items/consumables/healthpotions/HealthFlask");
            ConsSprite[3] = cm.Load<Texture2D>("sprites/items/consumables/healthpotions/HealthGourd");
            ConsSprite[4] = cm.Load<Texture2D>("sprites/items/consumables/healthpotions/HealthPotion");
            ConsSprite[5] = cm.Load<Texture2D>("sprites/items/consumables/healthpotions/HealthJar");
            ConsSprite[6] = cm.Load<Texture2D>("sprites/items/consumables/healthpotions/HealthPot");

            #endregion

            #region Food
            ConsSprite[20] = cm.Load<Texture2D>("sprites/items/consumables/food/Dragonfruit");
            #endregion
        }
        private static void LoadArmorContent(ContentManager cm)
        {
            #region Helmet
            ArmorSprite[2] = cm.Load<Texture2D>("sprites/items/armor/helmets/SkullCap");
            #endregion

            #region Body Armor
            #endregion

            #region Shield

            ArmorSprite[20] = cm.Load<Texture2D>("sprites/items/armor/shields/Buckler");
            ArmorSprite[22] = cm.Load<Texture2D>("sprites/items/armor/shields/HeaterShield");

            #endregion

            #region Gloves
            #endregion

            #region Belt
            #endregion

            #region Boots
            #endregion
        }
        private static void LoadSpriteContent(ContentManager cm)
        {
            #region Town
            NPCSprite[0] = cm.Load<Texture2D>("sprites/charactersSprites/TestNPC");
            NPCSprite[1] = cm.Load<Texture2D>("sprites/charactersSprites/TestMerchant");
            #endregion

            #region Heaven Levels 1-5
            NPCSprite[10] = cm.Load<Texture2D>("sprites/charactersSprites/Slime");
            #endregion

            #region Heaven Levels 6-10
            NPCSprite[15] = cm.Load<Texture2D>("sprites/charactersSprites/Knight");
            #endregion
        }
    }
}
