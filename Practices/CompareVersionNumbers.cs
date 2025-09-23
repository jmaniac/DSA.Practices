using System;
using System.Collections.Generic;
using System.Text;

namespace Practices.Problems
{
    internal class CompareVersionNumbers
    {
        public int CompareVersion(string version1, string version2)
        {
            return new VersionInfo(version1).CompareTo(new VersionInfo(version2));
        }
    }

    public class VersionInfo : IComparable<VersionInfo>
    {
        private string[] parts;
        private int length => parts.Length;
        public VersionInfo(string version)
        {
            parts = version.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        }

        public int CompareTo(VersionInfo? other)
        {
            if (other == null) return 1;
            int maxLength = Math.Max(this.length, other.length);
            for (int i = 0; i < maxLength; i++)
            {
                int thisPart = i < this.length ? int.Parse(this.parts[i]) : 0;
                int otherPart = i < other.length ? int.Parse(other.parts[i]) : 0;
                if (thisPart < otherPart) return -1;
                if (thisPart > otherPart) return 1;
            }
            return 0;
        }
    }
}
