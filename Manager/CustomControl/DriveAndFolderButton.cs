using System;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Manager.CustomControl
{
    class DriveAndFolderButton: RadioButton
    {
        public PathGeometry Icon
        {
            get { return (PathGeometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(PathGeometry), typeof(DriveAndFolderButton));


    }
}
