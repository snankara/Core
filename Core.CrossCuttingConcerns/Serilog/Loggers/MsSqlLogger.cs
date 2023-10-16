using Core.CrossCuttingConcerns.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Serilog.Loggers;
public class MsSqlLogger : LoggerServiceBase
{

    public MsSqlLogger(IConfiguration configuration)
    {
        MsSqlConfiguration msSqlConfiguration = configuration.GetSection("SerilogConfigurations:MsSqlConfiguration").Get<MsSqlConfiguration>()
        ?? throw new Exception(SerilogMessages.NullOptionsMessage);

        MSSqlServerSinkOptions sinkOptions = new()
        {
            TableName = msSqlConfiguration.TableName,
            AutoCreateSqlDatabase = msSqlConfiguration.AutoCreateTable
        };

        ColumnOptions columnOptions = new();

        Logger = new LoggerConfiguration().WriteTo
            .MSSqlServer(msSqlConfiguration.ConnectionString, sinkOptions, columnOptions: columnOptions)
            .CreateLogger();

    }
}
