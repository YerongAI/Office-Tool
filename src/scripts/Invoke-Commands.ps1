# Set commands like this:
# $Commands = @("deploy /add O365ProPlusRetail_en-us", "ospp /inslicid MondoVolume /sethst 192.168.1.1 /act")
# The commands will be executed in sequence after downloading Office Tool Plus.

# Enable TLSv1.2 for compatibility with older clients
[System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor [System.Net.SecurityProtocolType]::Tls12
# Do not display progress for WebRequest.
$ProgressPreference = 'SilentlyContinue'
$Host.UI.RawUI.WindowTitle = "Office Tool Plus | Commands"

# Localization
$CurrentLang = (Get-WinUserLanguageList)[0].LanguageTag.Replace("-", "_")
$SupportedLanguages = @("en_US", "zh_Hans_CN")
# Fallback to default language if not supported.
if ($SupportedLanguages -notcontains $CurrentLang) {
    $CurrentLang = $SupportedLanguages[0].Replace("-", "_")
}
$AllLanguages = @{
    "OSInfo"             = [PSCustomObject]@{
        en_US      = "OS info:"
        zh_Hans_CN = "系统信息:"
    }
    "CommandsWillBeExec" = [PSCustomObject]@{
        en_US      = "  The following commands will be executed in sequence:"
        zh_Hans_CN = "  将会依次执行以下命令："
    }
    "Downloading"        = [PSCustomObject]@{
        en_US      = "  Downloading Office Tool Plus, please wait."
        zh_Hans_CN = "  正在下载 Office Tool Plus，请稍等..."
    }
    "Extracting"         = [PSCustomObject]@{
        en_US      = "  Extracting files, please wait."
        zh_Hans_CN = "  正在解压文件，请稍等..."
    }
    "ErrorDownloading"   = [PSCustomObject]@{
        en_US      = "  An error occurred while downloading the file."
        zh_Hans_CN = "  下载文件时发生错误。"
    }
    "RetryDownload"      = [PSCustomObject]@{
        en_US      = "  Do you want to retry? (Y/N)"
        zh_Hans_CN = "  你想重试吗？(Y/N)"
    }
    "DownloadSuccess"    = [PSCustomObject]@{
        en_US      = "  Office Tool Plus was extracted to {0}"
        zh_Hans_CN = "  Office Tool Plus 已保存到 {0}"
    }
    "PressToContinue"    = [PSCustomObject]@{
        en_US      = "  Press Enter to continue."
        zh_Hans_CN = "  请按下回车键以继续"
    }
    "PressToExit"        = [PSCustomObject]@{
        en_US      = "Press Enter to exit."
        zh_Hans_CN = "按下回车键以退出"
    }
}

function Get-LString {
    param([string]$Key)

    return $AllLanguages[$Key].$CurrentLang
}

function Get-OTP {
    param([string]$DownloadURL, [string]$SavePath)

    $FileName = "$env:TEMP\Office Tool Plus.zip"
    $DownloadSuccess = $false
    do {
        try {
            Get-LString "Downloading"
            Invoke-WebRequest -Uri $DownloadURL -UseBasicParsing -OutFile $FileName -ErrorAction Stop
            Get-LString "Extracting"
            Expand-Archive -LiteralPath $FileName -DestinationPath $SavePath -Force
            $DownloadSuccess = $true
        }
        catch {
            Get-LString "ErrorDownloading"
            $UserChoice = Read-Host $(Get-LString "RetryDownload")
            if ($UserChoice -ne "Y") {
                Get-LString "RedownloadTip"
                Read-Host
                Exit
            }
        }
        finally {
            if (Test-Path $FileName) {
                $item = Get-Item -LiteralPath $FileName
                $item.Delete()
            }
        }
    } while (-not $DownloadSuccess)
}

function Get-RuntimeVersion {
    try {
        $DotnetInfo = dotnet --list-runtimes | Select-String -Pattern "Microsoft.WindowsDesktop.App 8"
        $IsX86Version = $DotnetInfo | Select-String -Pattern "(x86)"
        # If x86 version of runtime is installed on system, ignore it. Because we will download x64 version of OTP by default.
        if ($null -ne $IsX86Version) {
            return $false
        }
        if ($null -ne $DotnetInfo) {
            return $true
        }
    }
    catch {
        return $false
    }
    return $false
}

# Collect system information
$OsVersion = [System.Environment]::OSVersion.VersionString
$Arch = (Get-CimInstance Win32_OperatingSystem).OSArchitecture
$Arch = if ($Arch -Match "ARM64") { "ARM64" } elseif ($Arch -Match "64") { "x64" } else { "x86" }

Clear-Host
Write-Host "=========================== Office Tool Plus ==========================="
Write-Host
Write-Host "  $(Get-LString "OSInfo") $OsVersion $Arch"
Write-Host
if (Get-RuntimeVersion -eq $true) {
    $Type = "normal"
}
else {
    $Type = "runtime"
}

Write-Host "$(Get-LString "CommandsWillBeExec")"
foreach ($Command in $Commands) {
    Write-Host "    $Command"
}

Write-Host
Write-Host $(Get-LString -Key "PressToContinue") -NoNewline
Read-Host

# Download Office Tool Plus
$TempFolder = "$env:TEMP\Office Tool Plus"
Get-OTP -DownloadURL "https://www.officetool.plus/redirect/download.php?type=$Type&arch=$Arch" -SavePath $TempFolder

# Run commands
foreach ($Command in $Commands) {
    Clear-Host
    Start-Process -FilePath "$TempFolder\Office Tool\Office Tool Plus.Console.exe" -NoNewWindow -ArgumentList $Command -Wait -WorkingDirectory "$TempFolder\Office Tool"
}

# Clean up
Remove-Item "$TempFolder\*" -Recurse -Force
Remove-Item "$TempFolder" -Force

Write-Host
Write-Host "$(Get-LString -Key "PressToExit")"
Read-Host
Exit
