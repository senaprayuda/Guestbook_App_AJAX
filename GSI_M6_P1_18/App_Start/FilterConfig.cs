﻿using System.Web;
using System.Web.Mvc;

namespace GSI_M6_P1_18
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
