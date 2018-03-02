using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSFalpha1.Play.Level.NPC.Town
{
    public abstract class TownNPC : abstractNPC
    {
        public TownNPC(int x, int y) : base(x, y) { }
        public void Chat(String str)
        {
            leftFactorX = (PlayState.Player.PosX - 16  >= x + 32 - 2 && PlayState.Player.PosX - 16  <= x + 32 );
            rightFactorX = (PlayState.Player.PosX + 16  >= x && PlayState.Player.PosX + 16  <= x + 2);
            upFactorY = (PlayState.Player.PosY - 16  >= y + 32 - 2 && PlayState.Player.PosY - 16  <= y + 32 );
            downFactorY = (PlayState.Player.PosY + 16  >= y && PlayState.Player.PosY + 16  <= y + 2);
            if (PlayState.Player.PosX - 16  <= x + 32 && PlayState.Player.PosX + 16  >= x)
            {
                if (upFactorY || downFactorY)
                {
                    PlayState.Player.AddChatLine(str);
                    PlayState.Player.Chatting = true;
                }
                else if (PlayState.Player.PosY - 16  <= y + 32 && PlayState.Player.PosY + 16  >= y)
                {
                    if (leftFactorX || rightFactorX)
                    {
                        PlayState.Player.AddChatLine(str);
                        PlayState.Player.Chatting = true;
                    }
                }
            }

        }
        public abstract void ChatLines();
    }
}
