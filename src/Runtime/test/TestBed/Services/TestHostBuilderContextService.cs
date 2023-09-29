﻿// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

namespace BlazorFocused.Automation.Runtime.Test.TestBed.Services;

internal class TestHostBuilderContextService
{
    public string EnvironmentName { get; private set; }
    public string ConnectionString { get; private set; }
    public string ConfigurationValue { get; private set; }

    public TestHostBuilderContextService(
        string environmentName,
        string connectionString,
        string configurationValue)
    {
        EnvironmentName = environmentName;
        ConnectionString = connectionString;
        ConfigurationValue = configurationValue;
    }
}
