﻿using System;
using System.Web;

namespace Coevery.Localization.Services {
    public class SiteCultureSelector : ICultureSelector {
        private readonly IWorkContextAccessor _workContextAccessor;

        public SiteCultureSelector(IWorkContextAccessor workContextAccessor) {
            _workContextAccessor = workContextAccessor;
        }

        public CultureSelectorResult GetCulture(HttpContextBase context) {
            string currentCultureName = _workContextAccessor.GetContext().CurrentSite.SiteCulture;

            if (String.IsNullOrEmpty(currentCultureName)) {
                return null;
            }

            return new CultureSelectorResult { Priority = -5, CultureName = currentCultureName };
        }
    }

    public class CultureSettings {
    }
}
