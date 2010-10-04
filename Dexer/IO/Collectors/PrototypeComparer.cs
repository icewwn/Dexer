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

using System.Collections.Generic;
using Dexer.Core;
using Dexer.Metadata;
using System;

namespace Dexer.IO.Collector
{
    internal class PrototypeComparer : IComparer<Prototype>
    {
        private TypeReferenceComparer typeReferenceComparer = new TypeReferenceComparer();

        public int Compare(Prototype x, Prototype y)
        {
            int crt = typeReferenceComparer.Compare(x.ReturnType, y.ReturnType);
            if (crt == 0)
            {
                if (x.Parameters.Count == 0 && y.Parameters.Count != 0)
                    return -1;

                if (y.Parameters.Count == 0 && x.Parameters.Count != 0)
                    return 1;

                int minp = Math.Min(x.Parameters.Count, y.Parameters.Count);
                for (int i = 0; i < minp; i++)
                {
                    int cp = typeReferenceComparer.Compare(x.Parameters[i].Type,y.Parameters[i].Type);
                    if (cp != 0)
                        return cp;
                }
                return x.Parameters.Count.CompareTo(y.Parameters.Count);
            }
            return crt;
        }
    }
}
