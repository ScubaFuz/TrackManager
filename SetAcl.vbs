Set Shell = CreateObject("WScript.Shell")
Set oFSO = CreateObject("Scripting.FileSystemObject")
strComputer = Shell.ExpandEnvironmentStrings("%computername%")

Set objWMIService = GetObject("winmgmts://" & strComputer & "/root/cimv2")


OSType = FindOSType(strComputer)
'wscript.echo OSType

If OSType = "Windows XP" Then
   Shell.Run "%COMSPEC% /c Echo Y| cacls ""%PROGRAMFILES%\Thicor Services\TrackManager"" /e /c  USERS:M ", 2, True
End If

If OSType = "Windows Vista" Then
   Shell.Run "Icacls ""%PROGRAMFILES%\Thicor Services\TrackManager"" /grant USERS:(OI)(CI)M /t /c /q",7,False
End If

If OSType = "Windows 7" Then
   Shell.Run "Icacls ""%PROGRAMFILES%\Thicor Services\TrackManager"" /grant USERS:(OI)(CI)M /t /c /q",7,False
End If

Function FindOSType(strComputer)
    'Defining Variables
    Dim objWMI, objItem, colItems
    Dim OSVersion, OSName, ProductType

    'Get the WMI object and query results
    Set objWMI = GetObject("winmgmts://" & strComputer & "/root/cimv2")
    Set colItems = objWMI.ExecQuery("Select * from Win32_OperatingSystem",,48)

    'Get the OS version number (first two) and OS product type (server or desktop)
    For Each objItem in colItems
        OSVersion = Left(objItem.Version,3)
        ProductType = objItem.ProductType
    Next

    'Time to convert numbers into names
    Select Case OSVersion
    Case "6.1"
    OSName = "Windows 7"
        Case "6.0"
            OSName = "Windows Vista"
        Case "5.2"
            OSName = "Windows 2003"
        Case "5.1"
            OSName = "Windows XP"
        Case "5.0"
            OSName = "Windows 2000"
        Case "4.0"
            OSName = "Windows NT 4.0"
        Case Else
            OSName = "Windows 9x"
    End Select

    'Return the OS name
    FindOSType = OSName

    'Clear the memory
    Set colItems = Nothing
    Set objWMI = Nothing
End Function