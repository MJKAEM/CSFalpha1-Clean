using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSFalpha1.Play.Level.NPC.Enemy.LevelU01
{
    public class Knight : WarriorEnemy
    {
        private bool backwardsOnSprite;
        public Knight(int x, int y)
            : base(x, y)
        {
            //width : height ratio is 3 : 4
            width = 36;
            height = 48;
            maxAnimationFrame = 2;
            maxAttackFrame = 6;
            backwardsOnSprite = false;
            timeBeforeNextAttack = 60;
            speed = 0;
            minDmg = 3;
            maxDmg = 7;
        }
        public override void LoadContent()
        {
            charSprite = ContentLoader.CharSprite(15);
        }
        public override void Show(SpriteBatch sb)
        {
            if (frameTimer < 15 /*30*/ * 1 && !touchingPlayer)
            {
                attackTimer = 0;
                attackFrame = 0;
                timeBeforeNextAttack = 30;
                frameTimer++;
            }
            else
            {
                frameTimer = 0;
                if (animationFrame < maxAnimationFrame && !backwardsOnSprite)
                {
                    animationFrame++;
                }
                else if (animationFrame > 0 && backwardsOnSprite)
                {
                    animationFrame--;
                }
                else
                {
                    backwardsOnSprite = !backwardsOnSprite;
                    if (backwardsOnSprite)
                    {
                        animationFrame--;
                    }
                    else
                    {
                        animationFrame++;
                    }
                }
            }
            if (timeBeforeNextAttack > 0)
            {
                timeBeforeNextAttack--;
                if (timeBeforeNextAttack == 1)
                {
                    attackFrame = 0;
                }
            }
            else if (attackTimer < 3 * 1 && touchingPlayer)
            {
                frameTimer = 0;
                attackTimer++;
            }
            else
            {
                attackTimer = 0;
                if (attackFrame < maxAttackFrame)
                {
                    attackFrame++;
                }
                else
                {
                    attackFrame = maxAttackFrame;
                    timeBeforeNextAttack = 30;
                }
            }
            if (!playerSeen)
            {
                maxAnimationFrame = 2;
                switch (animationFrame)
                {
                    case 0:
                        sb.Draw(charSprite,
                            new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                            new Rectangle(0, 0, 32, 32),
                            Color.White);
                        break;

                    case 1:
                        sb.Draw(charSprite,
                            new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                            new Rectangle(32, 0, 32, 32),
                            Color.White);
                        break;
                    case 2:
                        sb.Draw(charSprite,
                            new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                            new Rectangle(64, 0, 32, 32),
                            Color.White);
                        break;
                }
            }
            else if (xFacing == 0 && (yFacing == 0 || yFacing == 1))
            {
                if (!touchingPlayer)
                {
                    maxAnimationFrame = 2;
                    switch (animationFrame)
                    {
                        case 0:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(96, 0, 32, 32),
                                Color.White);
                            break;

                        case 1:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(32, 0, 32, 32),
                                Color.White);
                            break;
                        case 2:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(128, 0, 32, 32),
                                Color.White);
                            break;
                    }
                }
                else
                {
                    maxAttackFrame = 5;

                    switch (attackFrame)
                    {
                        case 0:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(0, 32, 32, 32),
                                Color.White);
                            break;

                        case 1:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(32, 32, 32, 32),
                                Color.White);
                            break;

                        case 2:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(64, 32, 32, 32),
                                Color.White);
                            break;

                        case 3:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(96, 32, 32, 32),
                                Color.White);
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY + height, width, height),
                                new Rectangle(96, 64, 32, 32),
                                Color.White);
                            break;

                        case 4:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(128, 32, 32, 32),
                                Color.White);
                            break;

                        case 5:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(0, 64, 32, 32),
                                Color.White);
                            break;

                        case 6:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(32, 64, 32, 32),
                                Color.White);
                            break;

                        /*case 7:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(64, 64, 32, 32),
                                Color.White);
                            break;

                        case 8:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(96, 64, 32, 32),
                                Color.White);
                            break;

                        case 9:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(32, 96, 32, 32),
                                Color.White);
                            break;

                        case 10:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(64, 96, 32, 32),
                                Color.White);
                            break;*/
                    }
                }
            }
            else if (xFacing == 2 && yFacing == 0)
            {
                if (!touchingPlayer)
                {
                    maxAnimationFrame = 2;
                    speed = 1;

                    switch (animationFrame)
                    {
                        case 0:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(0, 96, 32, 32),
                                Color.White);
                            break;

                        case 1:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(32, 96, 32, 32),
                                Color.White);
                            break;

                        case 2:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(64, 96, 32, 32),
                                Color.White);
                            break;

                        /*case 3:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(96, 96, 32, 32),
                                Color.White);
                            break;*/
                    }
                }
                else
                {
                    maxAttackFrame = 5;

                    switch (attackFrame)
                    {
                        case 0:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(0, 128, 32, 32),
                                Color.White);
                            break;

                        case 1:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(32, 128, 32, 32),
                                Color.White);
                            break;

                        case 2:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX - width, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(64, 128, 32, 32),
                                Color.White);
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(96, 128, 32, 32),
                                Color.White);
                            break;

                        case 3:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(128, 128, 32, 32),
                                Color.White);
                            break;

                        case 4:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(0, 160, 32, 32),
                                Color.White);
                            break;

                        case 5:
                            sb.Draw(charSprite,
                                new Rectangle(x - PlayState.Player.RenderPosX, y - PlayState.Player.RenderPosY, width, height),
                                new Rectangle(32, 160, 32, 32),
                                Color.White);
                            break;
                    }
                }
            }
        }
    }
}
