//  PackageItem.cs
//
//  GNOME Do is the legal property of its developers, whose names are too
//  numerous to list here.  Please refer to the COPYRIGHT file distributed with
//  this source distribution.
//
//  This program is free software: you can redistribute it and/or modify it
//  under the terms of the GNU General Public License as published by the Free
//  Software Foundation, either version 3 of the License, or (at your option)
//  any later version.
//
//  This program is distributed in the hope that it will be useful, but WITHOUT
//  ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
//  FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for
//  more details.
//
//  You should have received a copy of the GNU General Public License along with
//  this program.  If not, see <http://www.gnu.org/licenses/>.

using System;

using Do.Universe;

namespace PackageManager
{
	public class PackageItem: Item
	{
		private string description, name;
		
		public PackageItem (string name, string description)
		{
			this.description = description;
			this.name = name;
		}
		
		public override string Description {
			get {
				return description;
			}
		}

		public override string Icon {
			get {
				return "zip";
			}
		}

		public override string Name {
			get {
				return name;
			}
		}	
	}
}
