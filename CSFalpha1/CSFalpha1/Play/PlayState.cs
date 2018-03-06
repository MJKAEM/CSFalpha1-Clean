#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using CSFalpha1.Play.Level;
using CSFalpha1.Play.Player;
using VideoDisplay;
using CSFalpha1.Play.Level.Map.LevelU01;
using ErrorDepartment;
#endregion

namespace CSFalpha1.Play
{
    public static class PlayState
    {
        private static MainPlayer P;
        private static DungeonLevel[] L = new DungeonLevel[50];
        private static Town T;
        private static sbyte curLevel = -1;

        public static void Initialize()
        {
            P = new MainPlayer();
            T = new Town();
            for (int i = 0; i < 5; i++)
            {
                L[i] = new LevelU01Map();
            }
        }
        public static void Draw(SpriteBatch sb, MouseState mouseState)
        {
            switch (curLevel)
            {
                case -1:
                    T.Show(sb);
                    break;
                default:
                    L[curLevel].Show(sb);
                    break;
            }

            P.Show(sb, mouseState);
            P.DisplayChat(sb);

            switch (curLevel)
            {
                case -1:
                    T.AShow(sb);
                    T.Merchant(sb, mouseState);
                    break;
                default:
                    L[curLevel].AShow(sb);
                    break;
            }
            if (P.PInv.InventoryOpen)
            {
                P.PInv.ShowInventory(sb);
                if (P.PInv.RightHand != null)
                {
                    P.PInv.RightHand.EquipShow(sb,
                        (VideoVariables.ResolutionWidth - 320) + 15 + 30 - (((P.PInv.RightHand.SpaceX + 1) * 30) / 2),
                        ((VideoVariables.ResolutionHeight / 2) - 190) + 60 - (((P.PInv.RightHand.SpaceY + 1) * 30) / 2));
                    //mouseState.Y > VideoVariables.ResolutionHeight / 2 - 190 && mouseState.Y < VideoVariables.ResolutionHeight / 2 - 190 + 120)
                }
                if (P.PInv.LeftHand != null)
                {
                    P.PInv.LeftHand.EquipShow(sb,
                        (VideoVariables.ResolutionWidth - 320) + 244 + 30 - (((P.PInv.LeftHand.SpaceX + 1) * 30) / 2),
                        ((VideoVariables.ResolutionHeight / 2) - 190) + 60 - (((P.PInv.LeftHand.SpaceY + 1) * 30) / 2));
                }
                if (P.PInv.Helmet != null)
                {
                    P.PInv.Helmet.EquipShow(sb,
                        (VideoVariables.ResolutionWidth - 320) + 129,
                        VideoVariables.ResolutionHeight / 2 - 230);
                }
                if (P.PInv.Body != null)
                {
                    P.PInv.Body.EquipShow(sb,
                        (VideoVariables.ResolutionWidth - 320) + 129,
                        VideoVariables.ResolutionHeight / 2 - 160);
                }
            }
            sb.Draw(P.BeltSprite, new Rectangle(VideoVariables.ResolutionWidth / 2 - 320, VideoVariables.ResolutionHeight - 40, 640, 40), new Color(200, 200, 200, 225));
            P.ShowHealthBar(sb);
            P.ShowMouseStorage(sb, mouseState);
        }
        public static void Update(KeyboardState keyboardState, MouseState mouseState, Game game)
        {
            //KeyboardState oldKeyboardState = PlayControls.OldKeyboardState;
            MouseState oldMouseState = PlayControls.OldMouseState;
            VideoVariables.RenderPosX = P.PosX;
            VideoVariables.RenderPosY = P.PosY;
            P.Move();
            switch (curLevel)
            {
                case -1:
                    PlayControls.TradingMerchant = T.GetIsTradingMerchant();
                    T.Move();
                    if (!P.PInv.InventoryOpen || mouseState.X < VideoVariables.ResolutionWidth / 2)
                    {
                        T.MerchantSelectMenu(mouseState, oldMouseState);
                    }
                    PlayControls.CloseMerchantInventory(mouseState);
                    PlayControls.NPCchat(keyboardState);
                    if (T.GetIsChattingMerchant() != null)
                    {
                        P.PInv.InventoryOpen = false;
                    }
                    else if (T.GetIsTradingMerchant() != null)
                    {
                        P.PInv.InventoryOpen = true;
                    }
                    break;
                default:
                    try
                    {
                        L[curLevel].Move();
                    }
                    #region Not Important (Catch Statement)
                    catch (IndexOutOfRangeException)
                    {
                        ConsolePrinter.RedPrint("Stop trying to access a level that cannot exist.\n");
                        ConsolePrinter.RedPrint("I will send you back to town. Press any key to coninue.");
                        Console.ReadKey(true);
                        curLevel = 0;
                    }
                    break;
                    #endregion
            }
            PlayControls.PlayerMove(keyboardState);
            PlayControls.PlayerStop(keyboardState);
            PlayControls.Inventory(keyboardState);
            if (P.PInv.InventoryOpen)
            {
                PlayControls.PickUp(mouseState);
                PlayControls.UseConsumableItem(mouseState);
                PlayControls.ClosePlayerInventory(mouseState);
            }

            //Must be at the end
            PlayControls.OldState(keyboardState, mouseState);
        }
        #region Properties
        public static MainPlayer Player { get { return P; } }
        public static DungeonLevel[] Level { get { return L; } }
        public static Town Town { get { return T; } }
        public static sbyte CurrentLevel { get { return curLevel; } set { curLevel = value; } }
        #endregion
    }
}
