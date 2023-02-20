using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Authmvvmcross.Core.Model
{
    public class ErrorTextBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty ErrorTextProperty = BindableProperty.Create("ErrorText", typeof(string), typeof(ErrorTextBehavior), default(string));

        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set { SetValue(ErrorTextProperty, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            if (entry != null)
            {
                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                {
                    entry.BackgroundColor = Color.Red;
                    entry.Text = ErrorText;
                }
                else
                {
                    entry.BackgroundColor = Color.Default;
                    entry.Text = string.Empty;
                }
            }
        }
    }

}
