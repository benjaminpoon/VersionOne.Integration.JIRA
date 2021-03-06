/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using VersionOne.ServiceHost.Core.Logging;

namespace VersionOne.ServerConnector.StartupValidation {
    public class V1FieldValidator : BaseValidator {
        private readonly string fieldName;
        private readonly string containingTypeToken;

        public V1FieldValidator(string fieldName, string containingTypeToken) {
            this.fieldName = fieldName;
            this.containingTypeToken = containingTypeToken;
        }

        public override bool Validate() {
            var typeWorkitem = containingTypeToken.Equals("Theme") ? "Feature Group" : containingTypeToken;
            Log(LogMessage.SeverityType.Info, string.Format("Checking custom field for {0}...", typeWorkitem));

            if (string.IsNullOrEmpty(fieldName)) {
                Log(LogMessage.SeverityType.Error, "Configuration contains undefined or empty field name.");
                return false;
            }

            if (!V1Processor.AttributeExists(containingTypeToken, fieldName)) {
                Log(LogMessage.SeverityType.Error, string.Format("Custom field {0} is not assigned to type {1}", fieldName, containingTypeToken));
                return false;
            }

            Log(LogMessage.SeverityType.Info, "Custom field check successful.");
            return true;
        }
    }
}