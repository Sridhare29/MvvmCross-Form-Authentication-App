using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Authmvvmcross.Core.Model
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty ErrorTextProperty =
        BindableProperty.Create("ErrorText", typeof(string), typeof(CustomEntry), default(string));

        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set { SetValue(ErrorTextProperty, value); }
        }
    }

}
