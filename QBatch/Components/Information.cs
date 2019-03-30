using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    public class Information
    {
        public static int MajorVersion
        {
            get
            {
                return 1;
            }
        }
        public static int MinorVersion
        {
            get
            {
                return 1;
            }
        }
        public static int Build
        {
            get
            {
                return 1;
            }
        }
        public static int Revision
        {
            get
            {
                return 1;
            }
        }
        public static string CurrentVersion
        {
            get
            {
                return MajorVersion.ToString() + "." + MinorVersion.ToString() + "." + Build.ToString() + "." + Revision.ToString();
            }
        }
        public static DateTime release
        {
            get
            {
                return new DateTime(2019, 3, 29).Date;
            }
        }
    }
}
