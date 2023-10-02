﻿// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using System.Management.Automation;
using BlazorFocused.Automation.PowerShell.Test.Services;
using BlazorFocused.Automation.PowerShell.Test.TestBed.Startup;

namespace BlazorFocused.Automation.PowerShell.Test.TestBed.Commands;

[Cmdlet(VerbsCommon.Get, "TestSDKCommand")]
public class TestPSCmdletCommand : AutomationShell<TestStartup>
{
    [AutomationDependency]
    protected readonly ITestService testService;

    protected override void ProcessRecord()
    {
        base.ProcessRecord();

        testService.CallTestMethod();
        testService.CallTestMethod();
        testService.CallTestMethod();

        WriteObject(testService.CallCount);
    }
}