using AspectCore.DynamicProxy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Application
{
    public class CustomInterceptorAttribute : AbstractInterceptorAttribute
    {
        private static Dictionary<Type, List<PropertyInfo>> dicTypes = new Dictionary<Type, List<PropertyInfo>>();
        private static Dictionary<string, List<ValidationAttribute>> dicAttributes = new Dictionary<string, List<ValidationAttribute>>();
        public override Task Invoke(AspectContext context, AspectDelegate next)
        {
            List<string> errors = new List<string>();

            var param = context.Parameters[0];
            var tem = validateErrors(param);
            errors.AddRange(tem);
            if (errors.Count > 0)
            {
                throw new ParameterValidateException(Newtonsoft.Json.JsonConvert.SerializeObject(errors));
            }
            return context.Invoke(next);
        }

        private List<string> validateErrors(object o)
        {
            var errors = new List<string>();
            var properties = getProperties(o);
            foreach (var pro in properties)
            {
                var value = pro.GetValue(o);
                if (value != null && value.GetType().IsClass && value.GetType() != typeof(System.String))
                {
                    errors.AddRange(validateErrors(value));
                }
                var attributes = getAttributes(pro);
                foreach (var attribute in attributes)
                {
                    try
                    {
                        attribute.Validate(pro.GetValue(o), pro.Name);
                    }
                    catch (Exception ex)
                    {
                        errors.Add(ex.Message);
                    }

                }
            }
            return errors;
        }

        private List<PropertyInfo> getProperties(object o)
        {
            var type = o.GetType();
            var properties = new List<PropertyInfo>();
            if (dicTypes.ContainsKey(type))
            {
                properties = dicTypes[type];
            }
            else
            {
                properties.AddRange(o.GetType().GetProperties());
                dicTypes.Add(type, properties);
            }
            return properties;
        }

        private List<ValidationAttribute> getAttributes(PropertyInfo propertyInfo)
        {
            var key = propertyInfo.DeclaringType.FullName + "." + propertyInfo.Name;
            var attributes = new List<ValidationAttribute>();
            if (dicAttributes.ContainsKey(key))
            {
                attributes = dicAttributes[key];
            }
            else
            {
                attributes.AddRange(propertyInfo.GetCustomAttributes(typeof(ValidationAttribute), false) as ValidationAttribute[]);
                dicAttributes.Add(key, attributes);
            }
            return attributes;
        }
    }

    public class ParameterValidateException : Exception
    {
        public ParameterValidateException()
        {
            
        }
        public ParameterValidateException(string message):base(message)
        {

        }

        public ParameterValidateException(string message, Exception innerException):base(message,innerException)
        {

        }
        
    }
}
