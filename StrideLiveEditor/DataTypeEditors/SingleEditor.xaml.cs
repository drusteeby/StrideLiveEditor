using Dru.StrideLiveEditor;
using Dru.StrideLiveEditor.DataTypeEditors;
using MahApps.Metro.Controls;
using Stride.Engine;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dru.StrideLiveEditor.DataTypeEditors
{
    public partial class SingleEditor : BaseEditor
    {
        public SingleEditor(EntityComponent component, ComponentPropertyItem property)
            : base(component, property)
        {
            InitializeComponent();
            
            PropertyName.Text = property.Name;
            UpdateValues(false);
            
            AddNumericBoxEvents(OnValueChanged, Value);
        }
        
        private void OnValueChanged()
        {
            ComponentProperty.SetValue(Component, GetFloat(Value.Value));
        }
        
        public override void UpdateValues(bool editorWindowIsActive)
        {
            var value = (float)ComponentProperty.GetValue(Component);

            if ((!editorWindowIsActive || !Value.IsFocused) && GetFloat(Value.Value) != value)
                Value.Value = value;
        }

        private Point _lastDragPoint;
        private bool _isDragging = false;

        private void Value_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var control = sender as NumericUpDown;
            if (control != null)
            {
                _lastDragPoint = e.GetPosition(control);
                control.CaptureMouse();
                _isDragging = true;
            }
        }

        private void Value_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && e.LeftButton == MouseButtonState.Pressed)
            {
                var control = sender as NumericUpDown;
                if (control != null)
                {
                    var currentPoint = e.GetPosition(control);
                    var diff = currentPoint.Y - _lastDragPoint.Y;

                    // Adjust the value based on the drag direction and speed
                    control.Value -= diff * control.Interval;
                    _lastDragPoint = currentPoint;
                }
            }
        }

        private void Value_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var control = sender as NumericUpDown;
            if (control != null)
            {
                control.ReleaseMouseCapture();
                _isDragging = false;
            }
        }
    }
}
