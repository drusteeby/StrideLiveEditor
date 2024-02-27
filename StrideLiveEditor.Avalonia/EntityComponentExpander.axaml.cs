using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Stride.Engine;

namespace StrideLiveEditor.Avalonia
{
    public partial class EntityComponentExpander : UserControl
    {
        public EntityComponent Component { get; set; }

        public EntityComponentExpander() { }

        public EntityComponentExpander(EntityComponent component)
        {
            Component = component;
            InitializeComponent();
        }
    }
}
