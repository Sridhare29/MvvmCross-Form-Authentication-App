using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Authmvvmcross.Core.Model
{
    public class ListViewSelectedItemBehavior : Behavior<ListView>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(ListViewSelectedItemBehavior));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.ItemSelected += OnItemSelected;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemSelected -= OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (Command == null)
                return;

            if (Command.CanExecute(e.SelectedItem))
                Command.Execute(e.SelectedItem);
        }
    }

}
