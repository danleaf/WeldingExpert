using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WeldingExpert.Attributes
{
    public class SocialIDAttribute : ValidationAttribute, IClientValidatable
    {
        static int[] w = new int[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
        static char[] sig = new char[] { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };

        public SocialIDAttribute()
            : base("身份证号不合法")
        {
        }

        public override bool IsValid(object value)
        {
            String id = value as string;
            if (id == null || id.Length != 18)
                return false;

            char[] chs = id.ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += (chs[i] - '0') * w[i];
            }

            sum %= 11;
            if (chs[17] != sig[sum])
                return false;

            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.DisplayName != null ? metadata.DisplayName : metadata.PropertyName);
            rule.ValidationType = "socialidvalidate";
            yield return rule;
        }
    }

    public class AgeAttribute : ValidationAttribute, IClientValidatable
    {
        int min;
        int max;

        public AgeAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public override bool IsValid(object value)
        {
            int age = (int)value;
            if (age < min || age > max)
                return false;

            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.DisplayName != null ? metadata.DisplayName : metadata.PropertyName);
            rule.ValidationType = "agevalidate";
            rule.ValidationParameters.Add("min", min);
            rule.ValidationParameters.Add("max", max);
            yield return rule;
        }

        public override string FormatErrorMessage(string name)
        {
            if(ErrorMessage != null)
                return String.Format(ErrorMessage, name, min, max);
            else
                return String.Format("{0} must between {1} and {2}", name, min, max);
        }
    }
}