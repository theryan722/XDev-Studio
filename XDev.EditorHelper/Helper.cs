using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDev.EditorHelper
{
   public class Helper
    {
       /// <summary>
       /// Determines if a character is a brace
       /// </summary>
       /// <param name="c"></param>
       /// <returns>True if the character is a brace, false otherwise</returns>
        public static bool IsBrace(int c)
        {
            switch (c)
            {
                case '(':
                case ')':
                case '[':
                case ']':
                case '{':
                case '}':
                case '<':
                case '>':
                    return true;
            }

            return false;
        }
    }
}
