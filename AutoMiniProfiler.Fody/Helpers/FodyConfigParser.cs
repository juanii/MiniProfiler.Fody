using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AutoMiniProfiler.Fody.Filters;
using AutoMiniProfiler.Fody.Weavers;

namespace AutoMiniProfiler.Fody.Helpers
{
    public class FodyConfigParser
    {
        private FodyConfigParser()
        {
        }

        private string _error;
        private bool _profilerConstructorsFlag;
        private bool _profilerPropertiesFlag;
        private List<XElement> _filterConfigElements;

        public static FodyConfigParser Parse(XElement element)
        {
            var result = new FodyConfigParser();
            result.DoParse(element);

            return result;
        }

        private void DoParse(XElement element)
        {
            try
            {
                _profilerConstructorsFlag = bool.Parse(GetBoolString(GetAttributeValueOrDefault(element, "profilerConstructors", bool.FalseString)));
                _profilerPropertiesFlag = bool.Parse(GetBoolString(GetAttributeValueOrDefault(element, "profilerProperties", bool.FalseString)));

                _filterConfigElements = element.Descendants().ToList();
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }
        }


        public ProfilerConfiguration Result
        {
            get
            {
                var result = new ProfilerConfiguration(new DefaultProfilerFilter(_filterConfigElements), _profilerConstructorsFlag, _profilerPropertiesFlag);

                return result;
            }
        }

        public bool IsErroneous
        {
            get { return !string.IsNullOrEmpty(_error); }
        }

        public string Error
        {
            get { return _error; }
        }

        private static string GetAttributeValue(XElement element, string attributeName, bool isMandatory)
        {
            var attribute = element.Attribute(attributeName);
            if (isMandatory && (attribute == null || string.IsNullOrWhiteSpace(attribute.Value)))
            {
                throw new ApplicationException(string.Format("Profiler: attribute {0} is missing or empty.", attributeName));
            }

            return attribute != null ? attribute.Value : null;
        }

        private static string GetAttributeValueOrDefault(XElement element, string attributeName, string defaultValue)
        {
            var attribute = element.Attribute(attributeName);
            return attribute != null ? attribute.Value : defaultValue;
        }

        private static string GetBoolString(string value)
        {
            // XML boolean admits 1 and 0 for true and false
            switch (value)
            {
                case "0":
                    return bool.FalseString;
                case "1":
                    return bool.TrueString;
                default:
                    return value;
            }
        }
    }
}