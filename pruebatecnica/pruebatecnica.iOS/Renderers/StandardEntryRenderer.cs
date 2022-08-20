﻿using System;
using System.ComponentModel;
using System.Drawing;
using pruebatecnica.Controls;
using pruebatecnica.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(StandardEntry), typeof(StandardEntryRenderer))]
namespace pruebatecnica.iOS.Renderers
{
    public sealed class StandardEntryRenderer : EntryRendererBase<UITextFieldPadding>
    {
        public StandardEntry ElementV2 => Element as StandardEntry;


        public StandardEntryRenderer()
        {
            Frame = new RectangleF(0, 20, 320, 40);
        }


        protected override UITextFieldPadding CreateNativeControl()
        {
            var control = new UITextFieldPadding(RectangleF.Empty)
            {
                Padding = ElementV2.Padding,
                BorderStyle = UITextBorderStyle.RoundedRect,
                ClipsToBounds = true
            };
            UpdateBackground(control);
            return control;
        }


        private void UpdateBackground(UITextFieldPadding control)
        {
            if (control == null) return;
            control.Layer.CornerRadius = ElementV2.CornerRadius;
            control.Layer.BorderWidth = ElementV2.BorderThickness;
            control.Layer.BorderColor = ElementV2.BorderColor.ToCGColor();

        }


        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == StandardEntry.CornerRadiusProperty.PropertyName)
            {
                UpdateBackground(Control);
            }
            else if (e.PropertyName == StandardEntry.BorderThicknessProperty.PropertyName)
            {
                UpdateBackground(Control);
            }
            else if (e.PropertyName == StandardEntry.BorderColorProperty.PropertyName)
            {
                UpdateBackground(Control);
            }

            base.OnElementPropertyChanged(sender, e);
        }
    }
}