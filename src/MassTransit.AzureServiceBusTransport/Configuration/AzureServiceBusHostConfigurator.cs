﻿// Copyright 2007-2014 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.AzureServiceBusTransport.Configuration
{
    using System;
    using Microsoft.ServiceBus;


    public class AzureServiceBusHostConfigurator :
        IServiceBusHostConfigurator
    {
        readonly HostSettings _settings;

        public AzureServiceBusHostConfigurator(Uri serviceAddress)
        {
            _settings = new HostSettings(serviceAddress);
        }

        public ServiceBusHostSettings Settings => _settings;

        public TokenProvider TokenProvider
        {
            set { _settings.TokenProvider = value; }
        }

        public TimeSpan OperationTimeout
        {
            set { _settings.OperationTimeout = value; }
        }


        class HostSettings :
            ServiceBusHostSettings
        {
            public HostSettings(Uri serviceUri)
            {
                ServiceUri = serviceUri;
                OperationTimeout = TimeSpan.FromSeconds(30);
            }

            public Uri ServiceUri { get; private set; }
            public TokenProvider TokenProvider { get; set; }
            public TimeSpan OperationTimeout { get; set; }
        }
    }
}