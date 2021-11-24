using System.Collections.Generic;

namespace EficazFramework.Collections
{
    public class StringCollection : List<string>
    {
        public override string ToString()
        {
            if (Count == 0)
                return null;
            var buider = new System.Text.StringBuilder();
            foreach (var it in this)
                buider.AppendLine(it);
            string result = buider.ToString();
            return result;
        }
    }
}