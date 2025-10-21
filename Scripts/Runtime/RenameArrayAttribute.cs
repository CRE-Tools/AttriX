using UnityEngine;

namespace PUCPR.AttriX
{
    public sealed class RenameArrayAttribute : PropertyAttribute
    {
        public string BaseName;

        public RenameArrayAttribute(string baseName)
        {
            BaseName = baseName;
        }
    }
}
