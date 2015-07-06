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
 * Date of Creation: 7/4/2015
 * 
 * Description
 * ===========
 * An AbstractPowerSineTransition is just the base AbstractTransition for transition
 * functions of the form
 * 
 *      f(x) = (sin(π/2*x))^p, p >= 1
 */

#endregion

#region Using Statements

using System;

#endregion

namespace Phosphaze.Framework.Forms.Effectors.Transitions
{
    public abstract class AbstractPowerSineTransition : AbstractTransition
    {

        /// <summary>
        /// The power by which to raise the sine function.
        /// </summary>
        protected virtual double Power { get; set; }

        private double alpha;

        public AbstractPowerSineTransition(
            string attr
            , double finalValue
            , double duration
            , bool relative = true)
            : base(attr, finalValue, duration, relative) { }

        public AbstractPowerSineTransition(
            string attr
            , double finalValue
            , double duration
            , Form form
            , bool relative = true)
            : base(attr, finalValue, duration, form, relative) { }

        protected override void Initialize()
        {
            base.Initialize();
            alpha = Math.PI / (2.0 * duration);
        }

        protected override double Function(double time, int frame)
        {
            return deltaValue * Math.Sin(alpha * time) + initialValue;
        }

    }
}
