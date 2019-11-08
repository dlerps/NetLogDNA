﻿using System;
using System.Linq;
using System.Net.NetworkInformation;
using NetLogDNA.LogDnaApi.Dto;
using Refit;

namespace NetLogDNA.LogDnaApi.Requests
{
    public class IngestRequest
    {
        [AliasAs("hostname")]
        public string HostName { get; set; }

        [AliasAs("ip")]
        public string IpAddress { get; set; }

//        [AliasAs("mac")]
//        public string MacAddress => GetMacAddress();

        [AliasAs("now")]
        public long UnitEpochTimestamp => GetUnixEpochTimestamp();
        
        private static string GetMacAddress()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .FirstOrDefault(net => net.OperationalStatus == OperationalStatus.Up
                                       && net.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                ?.GetPhysicalAddress()
                .ToString();
        }

        private static long GetUnixEpochTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
    }
}