using Dru.StrideLiveEditor;
using Dru.StrideLiveEditor.DataTypeEditors;
using Stride.Engine;
using System.Windows.Controls;

namespace Dru.StrideLiveEditor.DataTypeEditors
{
    public partial class UnsupportedEditor : BaseEditor
    {
        public UnsupportedEditor(EntityComponent component, ComponentPropertyItem property)
            : base(component, property)
        {
            InitializeComponent();
            
            PropertyName.Text = property.Name;
            var value = property.GetValue(component);
            Value.Text = value == null ? "null" : value.GetType().Name;
        }

        public override void UpdateValues(bool editorWindowIsActive) { }
    }
}
