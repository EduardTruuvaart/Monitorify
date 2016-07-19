﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Monitorify.Core.Configuration;
using Moq;
using Xunit;

namespace Monitorify.Core.Tests.Unit
{
    public class MonitorifyServiceTests
    {
        [Fact]
        public async void Start_ListeneresAreConfigured_ListenerStartListeningIsExecuted()
        {
            // Arrange
            Mock<IConfiguration> configurationMock = new Mock<IConfiguration>();
            var endpoint = new EndPoint {Name = "Test", Url = "http://test.test"};
            var delay = TimeSpan.Zero;
            configurationMock.Setup(x => x.EndPoints).Returns(new List<EndPoint> { endpoint });
            configurationMock.Setup(x => x.PingDelay).Returns(delay);
            MonitorifyService monitorifyService = new MonitorifyService();

            Mock<IUrlListener> urlListenerMock = new Mock<IUrlListener>();
            monitorifyService.UrlListenerFactory = () => urlListenerMock.Object;

            // Act
            monitorifyService.Start(configurationMock.Object);
            await Task.Delay(100);

            // Assert
            urlListenerMock.Verify(x => x.StartListening(endpoint, delay));
        }
    }
}
