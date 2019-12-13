﻿using System;
using System.Net.Http;
using Pixeval.Data.Web.Protocol;
using Refit;

namespace Pixeval.Data.Web.Delegation
{
    public class HttpClientFactory
    {
        public static readonly IPublicApiProtocol PublicApiService = RestService.For<IPublicApiProtocol>(PixivApi(ProtocolBase.PublicApiBaseUrl));

        public static readonly IAppApiProtocol AppApiService = RestService.For<IAppApiProtocol>(PixivApi(ProtocolBase.AppApiBaseUrl));

        public static HttpClient PixivApi(string baseAddress)
        {
            return new HttpClient(PixivApiHttpClientHandler.Instance)
            {
                Timeout = TimeSpan.FromSeconds(20),
                BaseAddress = new Uri(baseAddress)
            };
        }

        public static HttpClient PixivImage()
        {
            return new HttpClient(PixivImageHttpClientHandler.Instance);
        }
    }
}