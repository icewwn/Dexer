﻿/*
    Dexer, open source framework for .DEX files (Dalvik Executable Format)
    Copyright (C) 2010 Sebastien LEBRETON

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using Dexer.Core;
using Dexer.Instructions;
using Dexer.Metadata;

namespace Dexer.IO.Collector
{
    internal class StringCollector : BaseCollector<String>
    {

        public override void Collect(DebugInfo debugInfo)
        {
            base.Collect(debugInfo);

            if (debugInfo != null)
                Collect("this");
        }

        public override void Collect(Prototype prototype)
        {
            base.Collect(prototype);

            // Shorty descriptor
            Collect(TypeDescriptor.Encode(prototype));
        }

        public override void Collect(ArrayType array)
        {
            // Do not 'over' collect String descriptors by iterating over array.ElementType
            Collect(array as TypeReference);
        }

        public override void Collect(TypeReference tref)
        {
            base.Collect(tref);
            Collect(TypeDescriptor.Encode(tref));
        }

        public override void Collect(string str)
        {
            base.Collect(str);

            if (str != null)
            {
                if (!Items.ContainsKey(str))
                    Items[str] = 0;

                Items[str]++;
            }
        }

    }
}
