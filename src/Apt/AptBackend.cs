//  AptBackend.cs
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
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;


using Do.Platform;

namespace PackageManager
{
	public class AptBackend: IPackageManagerBackend
	{
		private const string SEARCH_COMMAND = "/usr/bin/apt-cache";
		
		private const string INSTALLED_COMMAND = "/usr/bin/dpkg";
		
		#region IPackageManagerBackend implementation
		public void Install (PackageItem package)
		{
			if (null == package)
				throw new ArgumentNullException ("package");
			// Many thanks to the author of the apturl plugin for this solution!!!
			Process.Start ("apturl apt:" + package.Name);
		}
		
		public IList<PackageItem> Search (string term)
		{
			if (string.IsNullOrEmpty (term) ) 
				throw new ArgumentNullException ("term");
						
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = SEARCH_COMMAND;
			startInfo.Arguments = " search " + term;
			startInfo.UseShellExecute = false;
			startInfo.RedirectStandardOutput = true;
			
			Process search = new Process();			
			search.StartInfo = startInfo;			
			search.Start();
			
			string[] lines = search.StandardOutput.ReadToEnd ().Split ('\n');			
			IList<PackageItem> result = new List<PackageItem> ();
			foreach (var line in lines)
			{
				var l = line.Trim ();
				if (!string.IsNullOrEmpty (l))
				{
					int blank = l.IndexOf (" ");
					
					var package = new PackageItem (
					                               line.Substring(0, blank).Trim (), 
					                               line.Substring(blank + 2).Trim ()
					                               );
					result.Add (package);
				}
			}
			return result.OrderBy (r => r.Name).ToArray (); 
		}

		#endregion
	}
}
