//  PackageManagerAct.cs
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
using System.Linq;
using System.Collections.Generic;

using Do.Universe;
using Do.Universe.Common;

using Do.Platform;
using Do.Platform.Linux;


namespace PackageManager
{	
	public class PackageManagerAct: Act, IConfigurable
	{
		private IPackageManagerBackend backend;
		
		public PackageManagerAct()
		{
			backend = PackageManagerFactory.GetBackend ();
			
			Configuration.PackageManagerSelected += HandlePackageManagerSelected;
		}

		private void HandlePackageManagerSelected(object sender, PackageManagerSelectedEventArgs e)
		{
			backend = PackageManagerFactory.GetBackend (e.SelectedBackend);
			Preferences.SelectedProvider = e.SelectedBackend;
		}

		public override IEnumerable<Type> SupportedItemTypes {
			get {
				yield return typeof (TextItem);
				yield return typeof (PackageItem);
			}
		}

		public override IEnumerable<Item> Perform (IEnumerable<Item> items, IEnumerable<Item> modItems)
		{
			Item first = items.First ();
			if (null == first) {
				return null;
			}
			
			if (first is PackageItem) {				
				PackageItem package = (PackageItem) first;	
				backend.Install (package);				
			} else if (first is TextItem) {				
				TextItem text = (TextItem) first;		
				return backend.Search (text.Text).ToArray ();
			}
			return null;
		}

		public override bool SupportsItem (Item item)
		{
			if (null == backend)
				return false;
			return item is TextItem || item is PackageItem;
		}

		public Gtk.Bin GetConfiguration ()
		{
			return new Configuration ( PackageManagerFactory.AvailableBackends );
		}
		
		public override string Description {
			get {
				return "Search and install packages with your favourite package manager";
			}
		}

		public override string Icon {
			get {
				return "update-manager";
			}
		}

		public override string Name {
			get {
				return "PackageManager - Search and install packages";
			}
		}
	}
}
