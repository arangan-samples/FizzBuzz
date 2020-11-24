[CmdletBinding()]
param(
    #[Parameter(Mandatory = $true)]
    #[AllowEmptyString()]
    [ValidateSet('build', 'clean', 'test', 'run', ErrorMessage=' Usage make.ps1 -command <build|clean|test|run>')]
    [string]$command
)
$hr = "==========================";

Clear-Host

switch ($command) {
    "build" {
        Write-Host "`n$hr`nBuilding .....`n$hr`n"
        dotnet build
    }

    "clean" {
        Write-Host "`n$hr`nCleaning .....`n$hr`n"
        dotnet clean
    }

    "test" {
        Write-Host "`n$hr`nRunning Unit Tests .....`n$hr`n"
        dotnet test
    }

    "run" {
        Write-Host "`n$hr`nExecuting .....`n$hr`n"
        dotnet run --project conApp
    }
    default {
       Write-Host "`nUsage make.ps1 -command <build|clean|test|run>`n"
       return
    }
}

Write-Host "`n======= Completed =======`n"