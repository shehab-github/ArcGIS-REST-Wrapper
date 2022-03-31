using System;

namespace ArcGIS_ServiceCallingWrapper.Helpers
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IsNullAllowedAttribute : Attribute
    {
        public bool IsAllowed { get; private set; }
        public IsNullAllowedAttribute(bool _isAllowed)
        {
            this.IsAllowed = _isAllowed;
        }
    }
}
