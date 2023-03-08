using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Humanizer;
namespace EdUnity.Data
{
    public sealed class InputSelectEnum<TEnum> : InputBase<TEnum>
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "select");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "class", CssClass);
            builder.AddAttribute(3, "value", BindConverter.FormatValue(CurrentValueAsString));
            builder.AddAttribute(4, "onchange", EventCallback.Factory.CreateBinder<string>(this, value => CurrentValueAsString = value, CurrentValueAsString, null));
            var enumType = GetEnumType();
            foreach (TEnum value in Enum.GetValues(enumType))
            {
                builder.OpenElement(5, "option");
                builder.AddAttribute(6, "value", value.ToString());
                builder.AddContent(7, GetDisplayName(value));
                builder.CloseElement();
            }
            builder.CloseElement();
        }
        protected override bool TryParseValueFromString(string value, out TEnum result, out string validationErrorMessage)
        {
            if (BindConverter.TryConvertTo(value, CultureInfo.CurrentCulture, out TEnum parsedValue))
            {
                result = parsedValue;
                validationErrorMessage = null;
                return true;
            }
            if (string.IsNullOrEmpty(value))
            {
                var nullableType = Nullable.GetUnderlyingType(typeof(TEnum));
                if (nullableType != null)
                {
                    result = default;
                    validationErrorMessage = null;
                    return true;
                }
            }
            result = default;
            validationErrorMessage = $"The {FieldIdentifier.FieldName} field is not valid.";
            return false;
        }
        private string GetDisplayName(TEnum value)
        {
            var member = value.GetType().GetMember(value.ToString())[0];
            var displayAttribute = member.GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute != null) return displayAttribute.GetName();
            return value.ToString().Humanize();
        }
        private Type GetEnumType()
        {
            var nullableType = Nullable.GetUnderlyingType(typeof(TEnum));
            if (nullableType != null) return nullableType;
            return typeof(TEnum);
        }
    }
}