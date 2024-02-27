﻿using Stride.Core.Mathematics;
using Stride.Engine;

namespace StrideLiveEditor.Avalonia.DataTypeEditors
{
	public partial class Vector2Editor : BaseEditor
	{
		public Vector2Editor()
		{
			InitializeComponent();
		}

		public Vector2Editor(EntityComponent component, ComponentPropertyItem property)
			: base(component, property)
		{
			InitializeComponent();

			PropertyName.Text = property.Name;
			UpdateValues(false);

			AddNumericBoxEvents(OnValueChanged, X, Y);
		}

		private void OnValueChanged()
		{
			var v = new Vector2(GetFloat(X.Value), GetFloat(Y.Value));
			ComponentProperty.SetValue(Component, v);
		}

		public override void UpdateValues(bool editorWindowIsActive)
		{
			var value = (Vector2)ComponentProperty.GetValue(Component);

			if ((!editorWindowIsActive || !X.IsFocused) && GetFloat(X.Value) != value.X)
				X.Value = (decimal)value.X;
			if ((!editorWindowIsActive || !Y.IsFocused) && GetFloat(Y.Value) != value.Y)
				Y.Value = (decimal)value.Y;
		}
	}
}
