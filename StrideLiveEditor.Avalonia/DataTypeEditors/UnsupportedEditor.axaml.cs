using Stride.Engine;

namespace StrideLiveEditor.Avalonia.DataTypeEditors
{
	public partial class UnsupportedEditor : BaseEditor
	{
		public UnsupportedEditor()
		{
			InitializeComponent();
		}

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
