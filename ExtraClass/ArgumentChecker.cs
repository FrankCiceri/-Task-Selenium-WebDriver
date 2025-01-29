using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webdriver_task_3.ExtraClass
{
    public static class ArgumentChecker
    {
        public static void CheckArgumentIsNull<T>(T argument, string argumentName)
        {
            if (argument is null) throw new ArgumentNullException(argumentName, $"{argumentName} Can't Be Null");
        }
    }
}
