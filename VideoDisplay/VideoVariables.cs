using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace VideoDisplay
{
    public static class VideoVariables
    {
        private static int width, height;
        private static int renderPosX, renderPosY;
        private static bool fullscreen;


        public static int ResolutionHeight { get { return height; } set { height = value; } }
        public static int ResolutionWidth { get { return width; } set { width = value; } }
        public static bool Fullscreen { get { return fullscreen; } set { fullscreen = value; } }

        public static int RenderPosX { get { return renderPosX; } set { renderPosX = value - width / 2; } }
        public static int RenderPosY { get { return renderPosY; } set { renderPosY = value - height / 2; } }
    }
}
