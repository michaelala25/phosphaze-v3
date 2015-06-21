﻿#region License

// Copyright (c) 2015 FCDM
// Permission is hereby granted, free of charge, to any person obtaining 
// a copy of this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation the 
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
// copies of the Software, and to permit persons to whom the Software is furnished 
// to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all 
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
// PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION 
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion

#region Header

/* Author: Michael Ala
 * Date of Creation: 6/12/2015
 * 
 * Description
 * ===========
 * This file is the main Monogame Game object.
 */

#endregion

#region Using Statements

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Phosphaze_V3.Framework;
using Phosphaze_V3.Framework.Forms;
using Phosphaze_V3.Framework.Input;
using Phosphaze_V3.Framework.Extensions;
using Phosphaze_V3.Framework.Display;
using Phosphaze_V3.Framework.Timing;

#endregion

namespace Phosphaze_V3
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Phosphaze : Game
    {
        public GraphicsDeviceManager graphics { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        MultiformManager multiformManager;
        DisplayManager displayManager;
        TimeManager timingManager;

        // TEMPORARY
        Texture2D texture;

        public Phosphaze()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //multiformManager = new MultiformManager();
            displayManager = new DisplayManager(this, graphics, spriteBatch, Constants.BG_FILLCOL);

            texture = Content.Load<Texture2D>("TestContent/Speaker1");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Update the global game timing manager.
            TimeManager.Update(gameTime);

            // Update the input
            MouseInput.Update();
            KeyboardInput.Update();

            // Update the multiforms.
            // multiformManager.Update();

            if (KeyboardInput.IsReleased(Keys.Escape))
                Exit();
            if (KeyboardInput.IsReleased(Keys.Enter))
                displayManager.SetResolution(displayManager.currentResolutionIndex + 1);
            if (KeyboardInput.IsReleased(Keys.B))
                displayManager.ToggleBorder();
            if (KeyboardInput.IsReleased(Keys.F))
                displayManager.ToggleFullscreen();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            displayManager.BeginUpdate();

            displayManager.Draw(texture, new Vector2(0.5f, 0.5f));
            displayManager.Draw(texture, new Vector2(0.25f, 0.5f));

            displayManager.EndUpdate();

            base.Draw(gameTime);
        }
    }
}
