using Avalonia.Interactivity;

using Stride.Engine;

namespace StrideLiveEditor.Avalonia.DataTypeEditors
{
	public partial class BooleanEditor : BaseEditor
	{
		public BooleanEditor()
		{
			InitializeComponent();
		}

		public BooleanEditor(EntityComponent component, ComponentPropertyItem property)
			: base(component, property)
		{
			InitializeComponent();
			PropertyName.Text = property.Name;

			UpdateValues(false);

			Value.Click += OnValueChanged;
		}

		private void OnValueChanged(object sender, RoutedEventArgs e)
		{
			ComponentProperty.SetValue(Component, Value.IsChecked);
		}

		public override void UpdateValues(bool editorWindowIsActive)
		{
			var value = (bool)ComponentProperty.GetValue(Component);

			if (Value.IsChecked != value)
				Value.IsChecked = value;
		}
	}
}
