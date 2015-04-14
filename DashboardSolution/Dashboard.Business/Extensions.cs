using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Dashboard.Business
{
    public static class Extensions
    {
        public static string GetDisplayAttrString(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field != null)
            {
                var display = ((DisplayAttribute[])field.GetCustomAttributes(typeof(DisplayAttribute), false)).FirstOrDefault();
                if (display != null)
                {
                    return display.GetName();
                }
            }
            return value.DisplayString();
        }

        public static string DisplayString(this Enum value)
        {
            //Using reflection to get the field info
            var info = value.GetType().GetField(value.ToString());

            //Get the Description Attributes
            var attributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);

            //Only capture the description attribute if it is a concrete result (i.e. 1 entry)
            if (attributes.Length == 1)
            {
                return attributes[0].Description;
            }
            else //Use the value for display if not concrete result
            {
                return value.ToString();
            }
        }
    }
}
