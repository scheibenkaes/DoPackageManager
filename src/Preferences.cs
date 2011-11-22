//  Preferences.cs
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
using Do.Platform;

namespace PackageManager
{
	public class Preferences
	{
		private static IPreferences prefs;
		
		private const string SELECTED_PROVIDER = "SelectedProvider";
		
		static Preferences ()
		{
			prefs = Services.Preferences.Get<Preferences> ();
			SetStandardBackend ();
		}
		
		private static void SetStandardBackend ()
		{
			if (null == SelectedProvider)
			{
				Configuration.SetBackend (PackageManagerFactory.APT_BACKEND);
			}
		}
		
		public static string SelectedProvider 
		{
			set 
			{
				prefs.Set<string> (SELECTED_PROVIDER, value);
			}
			
			get
			{
				return prefs.Get<string> (SELECTED_PROVIDER, null);
			}
		}
	}
}
