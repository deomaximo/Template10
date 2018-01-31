﻿using Prism.Navigation;
using System;
using System.Linq;
using Windows.Foundation;

namespace Template10.Navigation
{
    public class PageNavigationInfo
    {
        private string _originalString;

        public PageNavigationInfo(string originalString, INavigationParameters parameters)
        {
            _originalString = originalString;

            // parse name/key

            PageKey = originalString.Split('?').First();

            // parse parameters

            var query = new WwwFormUrlDecoder(originalString.Split('?').Last());
            foreach (var item in query)
            {
                Parameters.Add(item.Name, item.Value);
            }

            // merge parameters

            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    Parameters.Add(item.Key, item.Value);
                }
            }
        }

        public int Index { get; set; }

        public NavigationParameters Parameters { get; } = new NavigationParameters();

        public string PageKey { get; set; }

        public Type PageType { get; internal set; }

        public Type ViewModelType { get; internal set; }

        public override string ToString()
        {
            return _originalString;
        }
    }
}
