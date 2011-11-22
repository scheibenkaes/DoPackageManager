//  Configuration.cs
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
using Gtk;

namespace PackageManager
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class Configuration : Gtk.Bin
	{
		public static event EventHandler<PackageManagerSelectedEventArgs> PackageManagerSelected;
			
		public Configuration( IEnumerable<string> managers )
		{
			this.Build();
			
			managers.ForEach ( m => combobox.AppendText ( m ) );
			int selectedPackageManagerId = SelectedPackageManagerId (managers);
			if (-1 != selectedPackageManagerId)
				combobox.Active = selectedPackageManagerId;
			
			label.Text = "Select package manager";
			
			combobox.Changed += HandleChanged;
		}
		
		private int SelectedPackageManagerId( IEnumerable<string> managers )
		{
			int index = 0;
			foreach (var m in managers)
			{
				if (m == Preferences.SelectedProvider)
				{
					return index;
				}
				index++;
			}
			return -1;
		}

		private void HandleChanged(object o, EventArgs args)
		{
			PackageManagerSelectedEventArgs pmse = new PackageManagerSelectedEventArgs ();
			TreeIter iter;
			if (combobox.GetActiveIter (out iter))
				pmse.SelectedBackend = (string) combobox.Model.GetValue (iter, 0);
			if (null != PackageManagerSelected)
				PackageManagerSelected (this, pmse);
		}
		
		public static void SetBackend (string name)
		{
			PackageManagerSelectedEventArgs pmse = new PackageManagerSelectedEventArgs ();
			pmse.SelectedBackend = PackageManagerFactory.APT_BACKEND;
			if (null != PackageManagerSelected)
				PackageManagerSelected (null, pmse);
		}
	}
}
