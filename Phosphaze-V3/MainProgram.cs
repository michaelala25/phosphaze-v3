﻿#define TESTING_SOMETHING_STUPID
#undef TESTING_SOMETHING_STUPID
#region License

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
 * This is the main file that is run when the program starts up.
 */

#endregion

#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using Phosphaze_V3.Tests.Test001;
using Phosphaze_V3.Tests.Test002;

#endregion

namespace Phosphaze_V3
{
    using Phosphaze_V3.Framework.Collision;
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class MainProgram
    {

        public class Circle : Collidable
        {
            public override int Precedence { get { return 2; } }
            public bool CollidingWith(Point p) { return false; }
            public bool CollidingWith(Rect r) { return false; }
            public bool CollidingWith(Circle c) { return false; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if TESTING_SOMETHING_STUPID
            Point p = new Point();
            Rect r = new Rect();
            Circle c = new Circle();
            Console.WriteLine(Checker.CollisionBetween(p, r));
            Console.WriteLine(Checker.CollisionBetween(c, p));
            Console.WriteLine(Checker.CollisionBetween(c, c));

            Collidable c2 = new Circle();
            Collidable r2 = new Rect();
            Console.WriteLine(c2.CollidingWith(c));
            Console.WriteLine(c2.CollidingWith(r2));
            Console.WriteLine(c2.CollidingWith(new object()));
            Console.WriteLine("THING: " + c2.CollidingWith("hello"));
#else
            using (var game = new Phosphaze(new Test002Engine()))
                game.Run();
#endif
        }
    }
#endif
}
