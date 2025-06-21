using System.Reflection;

namespace _00___Attribute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region CustomAttribute
            var teacherType = typeof(TeacherServoce);
            var teacherMethods = teacherType.GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            foreach (var method in teacherMethods)
            {
                var attr = method.GetCustomAttribute<CustomAttribute>();
                if (attr != null)
                {
                    Console.WriteLine($"Method: {method.Name}, Name: {attr.Name}, Age: {attr.Age}");

                }
            }
            #endregion

            #region ModelCustomAttribute
            User user = new User
            {
                Name = "John",
            };
            var userType = typeof(User);
            var userProperties = userType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in userProperties)
            {
                var attr = property.GetCustomAttribute<ModelCustomAttribute>();
                var value = property.GetValue(user);
                var obj = (ModelCustomAttribute)attr;
                if (attr != null)
                {
                    if (value != null && attr.IsRequired)
                    {
                        var valueString = value.ToString();
                        if (valueString.Length > obj.MaxLength)
                        {
                            Console.WriteLine($"{property.Name} can't beyond {obj.MaxLength}");
                        }
                    }
                    else
                    {
                        if (property.PropertyType == typeof(string))
                        {
                            Console.WriteLine($"{property.Name} can't be null");
                        }
                    }
                }
            }
            #endregion
        }

        [Obsolete("", true)]
        // this is old and should not be used, true means it will throw an exception if used, false means it will just warn
        // "" is the message that will be shown in the warning or exception
        private static void Test()
        {

        }
    }
}
