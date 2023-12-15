using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Castle.Core.Logging;
using Common.ConfigOptions;
using Infrastructure.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.Common.Exceptions;

namespace Infrastructure.Tests.Caching;
public class CachingManagerTests
{
    private readonly Mock<ILogger<ICacheManager>> _mockLogger;
    private readonly Mock<IDistributedCache> _mockDistributedCache;
    private readonly Mock<IOptions<CacheConfig>> _cacheConfig;

    public CachingManagerTests() 
    {
        _mockLogger = new Mock<ILogger<ICacheManager>>();
        _mockDistributedCache = new Mock<IDistributedCache>();
        _cacheConfig =  new Mock<IOptions<CacheConfig>>();
    }

    [Fact]
    public GetRecordAsync_Execute_ReturnCacheData()
    { 
        // Assign

        // Act

        // Assert
    }

}
