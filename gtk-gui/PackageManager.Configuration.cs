// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace PackageManager {
    
    
    public partial class Configuration {
        
        private Gtk.VBox vbox1;
        
        private Gtk.Label label;
        
        private Gtk.ComboBox combobox;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget PackageManager.Configuration
            Stetic.BinContainer.Attach(this);
            this.Name = "PackageManager.Configuration";
            // Container child PackageManager.Configuration.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.label = new Gtk.Label();
            this.label.Name = "label";
            this.label.Xalign = 0F;
            this.label.LabelProp = Mono.Unix.Catalog.GetString("label1");
            this.vbox1.Add(this.label);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox1[this.label]));
            w1.Position = 1;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.combobox = Gtk.ComboBox.NewText();
            this.combobox.Name = "combobox";
            this.vbox1.Add(this.combobox);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox1[this.combobox]));
            w2.Position = 2;
            w2.Expand = false;
            w2.Fill = false;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Hide();
        }
    }
}
