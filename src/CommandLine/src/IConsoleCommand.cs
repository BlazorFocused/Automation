﻿// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using BlazorFocused.Automation.Runtime;
using System.CommandLine;

namespace BlazorFocused.Automation.CommandLine;

/// <summary>
/// Command line automation interface used to register/build commands
/// </summary>
public interface IConsoleCommand : IAutomationStartup
{
    /// <summary>
    /// Set specific command configuration/properties
    /// </summary>
    /// <param name="serviceBinderFactory">Factory used to bind services based on inherited <see cref="IAutomationStartup"/> dependency injection</param>
    /// <param name="command">Current command context to establish properties, configuration, and attributes</param>
    void ConfigureCommand(IServiceBinderFactory serviceBinderFactory, Command command);
}
