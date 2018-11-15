using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Mathys.CustomControles
{
    public class AttachedProperties
    {
        public static readonly BindableProperty HasPopProperty =
            BindableProperty.CreateAttached("HasPop", typeof(bool), typeof(AttachedProperties), false, propertyChanging: (a, b, c) => PopAnim(a, b, c));

        public static readonly BindableProperty HasTranslationProperty =
            BindableProperty.CreateAttached("HasTranslation", typeof(bool), typeof(AttachedProperties), false, propertyChanging: (a, b, c) => TranslationAnim(a, b, c));

        private async static void PopAnim(BindableObject a, object b, object c)
        {
            
            if (a is StackLayout)
            {
                var obj = (StackLayout)a;
                if ((bool)c)
                {
                    obj.Scale = 2;
                    await obj.ScaleTo(1, 500, Easing.SpringIn);
                }
            }
            if (a is Frame)
            {
                var obj = (Frame)a;
                if ((bool)c)
                {
                    obj.Scale = 2;
                    await obj.ScaleTo(1, 500, Easing.SpringIn);
                }
            }
        }

        private async static void TranslationAnim(BindableObject a, object b, object c)
        {
            if (a is StackLayout)
            {
                var obj = (StackLayout)a;
                if ((bool)c)
                {
                    await obj.TranslateTo(Application.Current.MainPage.Width, 0, 0);
                    obj.IsVisible = true;
                    await obj.TranslateTo(0, 0, 750, Easing.SpringIn);
                }
            }
            if (a is Frame)
            {
                var obj = (Frame)a;
                if ((bool)c)
                {
                    await obj.TranslateTo(Application.Current.MainPage.Width, 0, 0);
                    obj.IsVisible = true;
                    await obj.TranslateTo(0, 0, 750, Easing.SpringIn);
                }
            }
        }

        public static bool GetHasPop(BindableObject view)
        {
            return (bool)view.GetValue(HasPopProperty);
        }

        public static void SetHasPop(BindableObject view, bool value)
        {
            view.SetValue(HasPopProperty, value);
        }

        public static bool GetHasTranslation(BindableObject view)
        {
            return (bool)view.GetValue(HasTranslationProperty);
        }

        public static void SetHasTranslation(BindableObject view, bool value)
        {
            view.SetValue(HasTranslationProperty, value);
        }
    }
}
