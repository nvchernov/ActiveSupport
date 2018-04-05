::Before start tests build tests project (Debug)
::If xUnit Runner cannot find tests look here http://xunit.github.io/docs/getting-started-desktop.html#run-tests-visualstudio

@echo off
packages\xunit.runner.console.2.3.1\tools\net452\xunit.console NSupport.Test\bin\Debug\NSupport.Test.dll
set /p T=Hit ENTER to continue...