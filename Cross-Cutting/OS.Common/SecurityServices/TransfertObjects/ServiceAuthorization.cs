﻿using System;

namespace OS.Common.SecurityServices.TransfertObjects
{
    public class ServiceAuthorization
    {
        public Guid ServiceGuid { get; set; }
        public Guid AuthorizationToken { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
