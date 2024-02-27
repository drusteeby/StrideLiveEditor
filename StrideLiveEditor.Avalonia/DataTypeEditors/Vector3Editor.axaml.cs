using Stride.Core.Mathematics;
using Stride.Engine;

namespace StrideLiveEditor.Avalonia.DataTypeEditors
{
	public partial class Vector3Editor : BaseEditor
	{
		public Vector3Editor()
		{
			InitializeComponent();
		}

		public Vector3Editor(EntityComponent component, ComponentPropertyItem property)
			: base(component, property)
		{
			InitializeComponent();

			PropertyName.Text = property.Name;
			UpdateValues(false);

			AddNumericBoxEvents(OnValueChanged, X, Y, Z);
		}

		private void OnValueChanged()
		{
			var v = new Vector3(GetFloat(X.Value), GetFloat(Y.Value), GetFloat(Z.Value));

			ComponentProperty.SetValue(Component, v);
		}

		public override void UpdateValues(bool editorWindowIsActive)
		{
			var value = (Vector3)ComponentProperty.GetValue(Component);

			if ((!editorWindowIsActive || !X.IsFocused) && GetFloat(X.Value) != value.X)
				X.Value = (decimal)value.X;
			if ((!editorWindowIsActive || !Y.IsFocused) && GetFloat(Y.Value) != value.Y)
				Y.Value = (decimal)value.Y;
			if ((!editorWindowIsActive || !Z.IsFocused) && GetFloat(Z.Value) != value.Z)
				Z.Value = (decimal)value.Z;
		}
	}
}
