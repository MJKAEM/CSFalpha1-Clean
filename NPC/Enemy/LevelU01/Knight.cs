using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ContentLoader;
using VideoDisplay;

namespace NPC.Enemy.LevelU01
{
    public class Knight : WarriorEnemy
    {
        private bool backwardsOnSprite;
        public Knight(int x, int y)
            : base(x, y)
        {
            //width : height ratio is 3 : 4
            //Width = 36;//15 45 
            //Height = 48;//15 60
            Width = 45;
            Height = 60;
            MaxAnimationFrame = 2;
            MaxAttackFrame = 6;
            backwardsOnSprite = false;
            TimeBeforeNextAttack = 60;
            Speed = 0;
            MinDmg = 3;
            MaxDmg = 7;

            CharSprite = TheContentLoader.NPCSprite[15];
        }
        public override void Show(SpriteBatch sb)
        {
            if (FrameTimer < 5 /*30*/ * 1 && !TouchingPlayer)
            {
                AttackTimer = 0;
                AttackFrame = 0;
                TimeBeforeNextAttack = 30;
                FrameTimer++;
            }
            else
            {
                FrameTimer = 0;
                if (AnimationFrame < MaxAnimationFrame && !backwardsOnSprite)
                {
                    AnimationFrame++;
                }
                else if (AnimationFrame > 0 && backwardsOnSprite)
                {
                    AnimationFrame--;
                }
                else
                {
                    backwardsOnSprite = !backwardsOnSprite;
                    if (backwardsOnSprite)
                    {
                        AnimationFrame--;
                    }
                    else
                    {
                        AnimationFrame++;
                    }
                }
            }
            if (TimeBeforeNextAttack > 0)
            {
                TimeBeforeNextAttack--;
                if (TimeBeforeNextAttack == 1)
                {
                    AttackFrame = 0;
                }
            }
            else if (AttackTimer < 3 * 1 && TouchingPlayer)
            {
                FrameTimer = 0;
                AttackTimer++;
            }
            else
            {
                AttackTimer = 0;
                if (AttackFrame < MaxAttackFrame)
                {
                    AttackFrame++;
                }
                else
                {
                    AttackFrame = MaxAttackFrame;
                    TimeBeforeNextAttack = 30;
                }
            }
            if (!PlayerSeen)
            {
                MaxAnimationFrame = 2;
                switch (AnimationFrame)
                {
                    case 0:
                        sb.Draw(CharSprite,
                            new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                            new Rectangle(0, 0, 32, 32),
                            Color.White);
                        break;

                    case 1:
                        sb.Draw(CharSprite,
                            new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                            new Rectangle(32, 0, 32, 32),
                            Color.White);
                        break;
                    case 2:
                        sb.Draw(CharSprite,
                            new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                            new Rectangle(64, 0, 32, 32),
                            Color.White);
                        break;
                }
            }
            else if (XFacing == 0 && (YFacing == 0 || YFacing == 1))
            {
                if (!TouchingPlayer)
                {
                    MaxAnimationFrame = 2;
                    switch (AnimationFrame)
                    {
                        case 0:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(96, 0, 32, 32),
                                Color.White);
                            break;

                        case 1:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(32, 0, 32, 32),
                                Color.White);
                            break;
                        case 2:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(128, 0, 32, 32),
                                Color.White);
                            break;
                    }
                }
                else
                {
                    MaxAttackFrame = 5;

                    switch (AttackFrame)
                    {
                        case 0:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(0, 32, 32, 32),
                                Color.White);
                            break;

                        case 1:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(32, 32, 32, 32),
                                Color.White);
                            break;

                        case 2:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(64, 32, 32, 32),
                                Color.White);
                            break;

                        case 3:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(96, 32, 32, 32),
                                Color.White);
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY + Height, Width, Height),
                                new Rectangle(96, 64, 32, 32),
                                Color.White);
                            break;

                        case 4:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(128, 32, 32, 32),
                                Color.White);
                            break;

                        case 5:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(0, 64, 32, 32),
                                Color.White);
                            break;

                        case 6:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(32, 64, 32, 32),
                                Color.White);
                            break;

                        /*case 7:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(64, 64, 32, 32),
                                Color.White);
                            break;

                        case 8:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(96, 64, 32, 32),
                                Color.White);
                            break;

                        case 9:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(32, 96, 32, 32),
                                Color.White);
                            break;

                        case 10:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(64, 96, 32, 32),
                                Color.White);
                            break;*/
                    }
                }
            }
            else if (XFacing == 2 && YFacing == 0)
            {
                if (!TouchingPlayer)
                {
                    MaxAnimationFrame = 2;
                    Speed = 1;

                    switch (AnimationFrame)
                    {
                        case 0:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(0, 96, 32, 32),
                                Color.White);
                            break;

                        case 1:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(32, 96, 32, 32),
                                Color.White);
                            break;

                        case 2:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(64, 96, 32, 32),
                                Color.White);
                            break;

                        /*case 3:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(96, 96, 32, 32),
                                Color.White);
                            break;*/
                    }
                }
                else
                {
                    MaxAttackFrame = 5;

                    switch (AttackFrame)
                    {
                        case 0:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(0, 128, 32, 32),
                                Color.White);
                            break;

                        case 1:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(32, 128, 32, 32),
                                Color.White);
                            break;

                        case 2:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX - Width, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(64, 128, 32, 32),
                                Color.White);
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(96, 128, 32, 32),
                                Color.White);
                            break;

                        case 3:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(128, 128, 32, 32),
                                Color.White);
                            break;

                        case 4:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(0, 160, 32, 32),
                                Color.White);
                            break;

                        case 5:
                            sb.Draw(CharSprite,
                                new Rectangle(PosX - VideoVariables.RenderPosX, PosY - VideoVariables.RenderPosY, Width, Height),
                                new Rectangle(32, 160, 32, 32),
                                Color.White);
                            break;
                    }
                }
            }
        }
        public override void Attack()
        {
            base.Attack();
        }
    }
}
