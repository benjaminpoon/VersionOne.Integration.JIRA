﻿/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System;
using System.Xml;
using VersionOne.ServiceHost.Core.Configuration;
using VersionOne.ServiceHost.Eventing;
using Ninject;

namespace VersionOne.ServiceHost.Core.Logging {
    public class Logger : ILogger {
        private readonly IEventManager eventManager;

        [Inject]
        public Logger(IEventManager eventManager) {
            this.eventManager = eventManager;
        }

        public void Log(string message) {
            Log(LogMessage.SeverityType.Info, message, null);
        }

        public void Log(string message, Exception exception) {
            Log(LogMessage.SeverityType.Error, message, exception);
        }

        public void Log(LogMessage.SeverityType severity, string message) {
            Log(severity, message, null);
        }

        public void Log(LogMessage.SeverityType severity, string message, Exception exception) {
            eventManager.Publish(new LogMessage(severity, message, exception));
        }

        public void LogVersionOneConfiguration(LogMessage.SeverityType severity, XmlElement config) {
            try {
                var entity = VersionOneSettings.FromXmlElement(config);
                Log(severity, "    VersionOne URL: " + entity.Url);
                Log(severity, string.Format("    Using proxy server: {0}, Integrated authentication: {1}", entity.ProxySettings != null && entity.ProxySettings.Enabled, entity.IntegratedAuth));
            } catch(Exception ex) {
                Log(LogMessage.SeverityType.Warning, "Failed to log VersionOne configuration data.", ex);
            }
        }

        public void LogVersionOneConnectionInformation(LogMessage.SeverityType severity, string metaVersion, string memberOid, string defaultMemberRole) {
            Log(severity, "    VersionOne Meta version: " + metaVersion);
            Log(severity, "    VersionOne Member OID: " + memberOid);
            Log(severity, "    VersionOne Member default role: " + defaultMemberRole);
        }
    }
}