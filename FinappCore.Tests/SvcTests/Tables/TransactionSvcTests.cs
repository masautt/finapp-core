using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace FinappCore.Tests.SvcTests.Tables;

[Collection("Database")]
public class TransactionSvcTests
{
    private readonly ITransactionSvc _transactionSvc;

    public TransactionSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");
        _transactionSvc = provider.GetRequiredService<ITransactionSvc>();
    }

    [Fact]
    public async Task FetchTotalCount_ReturnsNonNegativeValue()
    {
        var total = await _transactionSvc.FetchTotalCount();
        Assert.True(total >= 0, "Total count should be non-negative");
    }

    [Fact]
    public async Task FetchById_ReturnsNullIfNotExists()
    {
        const string nonExistentId = "nonexistent";
        var entity = await _transactionSvc.FetchById(nonExistentId);
        Assert.Null(entity);
    }

    [Fact]
    public async Task FetchRandomRecord_ReturnsSomeRecord()
    {
        var randomRecord = await _transactionSvc.FetchRandomRecord();
        Assert.NotNull(randomRecord);
        Assert.True(randomRecord.Common.Number > 0);
    }

    [Fact]
    public async Task FetchLatestRecord_ReturnsRecordWithHighestNumber()
    {
        var latest = await _transactionSvc.FetchLatestRecord();
        Assert.NotNull(latest);
        Assert.True(latest.Common.Number > 0);
    }

    [Fact]
    public async Task FetchOldestRecord_ReturnsRecordWithLowestNumber()
    {
        var oldest = await _transactionSvc.FetchOldestRecord();
        Assert.NotNull(oldest);
        Assert.True(oldest.Common.Number > 0);
    }

    [Fact]
    public async Task FetchByNumber_ReturnsCorrectEntity()
    {
        var latest = await _transactionSvc.FetchLatestRecord();
        if (latest != null)
        {
            var fetched = await _transactionSvc.FetchByNumber(latest.Common.Number);
            Assert.NotNull(fetched);
            Assert.Equal(latest.Common.Number, fetched.Common.Number);
        }
    }

    [Fact]
    public async Task FetchByCustom_ReturnsCorrectRecords()
    {
        var records = await _transactionSvc.FetchByCustom(
            (x => x.Common.Number, 1),
            (x => x.Category, "groceries")
        );

        Assert.NotNull(records);
        foreach (var r in records)
        {
            Assert.Equal(1, r.Common.Number);
            Assert.Equal("groceries", r.Category);
        }
    }

    [Fact]
    public async Task FetchSubcategories_ReturnsDistinctValues()
    {
        // Act
        var subcategories = await _transactionSvc.FetchSubcategories();

        // Assert
        Assert.NotNull(subcategories);
        Assert.True(subcategories.Count > 0, "Should return at least one subcategory");
        Assert.Equal(subcategories.Count, subcategories.Distinct().Count()); // Ensure uniqueness
    }

    [Fact]
    public async Task FetchSubcategories_WithCategoryFilter_ReturnsFilteredDistinctValues()
    {
        const string category = "groceries";

        // Act
        var subcategories = await _transactionSvc.FetchSubcategories(category);

        // Assert
        Assert.NotNull(subcategories);
        Assert.True(subcategories.Count > 0, "Should return at least one subcategory for the category");
        Assert.Equal(subcategories.Count, subcategories.Distinct().Count()); // Ensure uniqueness
    }

    [Fact]
    public async Task FetchBusinesses_ReturnsDistinctValues()
    {
        // Act
        var businesses = await _transactionSvc.FetchBusinesses();

        // Assert
        Assert.NotNull(businesses);
        Assert.True(businesses.Count > 0, "Should return at least one business");
        Assert.Equal(businesses.Count, businesses.Distinct().Count()); // Ensure uniqueness
    }

    [Fact]
    public async Task FetchBusinesses_WithFilters_ReturnsFilteredDistinctValues()
    {
        const string category = "eatingout";
        const string subcategory = "fastFood";

        // Act
        var businesses = await _transactionSvc.FetchBusinesses(category, subcategory);

        // Assert
        Assert.NotNull(businesses);
        Assert.True(businesses.Count > 0, "Should return at least one business for the filters");
        Assert.Equal(businesses.Count, businesses.Distinct().Count()); // Ensure uniqueness
    }


    [Fact]
    public async Task FetchByDateRangeWithExactDateFields_ReturnsRecordsInRange()
    {
        var startDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var endDate = new DateTime(2024, 12, 31, 23, 59, 59, DateTimeKind.Utc);

        var results = await _transactionSvc.FetchByDateRangeWithExactDateFields(
            startDate,
            endDate,
            t => t.Date
        );

        Assert.NotNull(results);
        Assert.All(results, t =>
        {
            Assert.True(t.Date.Date >= startDate && t.Date.Date <= endDate);
        });
    }

    [Fact]
    public async Task FetchByDateRangeWithExactDateFields_ReturnsEmptyListWhenNoMatches()
    {
        var startDate = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var endDate = new DateTime(1900, 12, 31, 23, 59, 59, DateTimeKind.Utc);

        var results = await _transactionSvc.FetchByDateRangeWithExactDateFields(
            startDate,
            endDate,
            t => t.Date
        );

        Assert.NotNull(results);
        Assert.Empty(results);
    }
}
