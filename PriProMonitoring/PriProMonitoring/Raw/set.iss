; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Printer Monitoring"
#define MyAppVersion "1.0.0.0"
#define MyAppPublisher "Perfecto Group of Companies"
#define MyAppExeName "PriProMonitoring.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{D6912105-C357-4CEE-AF60-69594FC3E7E0}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={pf}\pri-pro\Fuji Film Printer Monitoring}
DefaultGroupName=pri-pro\Fuji Film Printer Monitoring
OutputDir=C:\Users\MISGWAPOHON\Desktop
OutputBaseFilename=pripro-testing
SetupIconFile=C:\Users\MISGWAPOHON\Documents\GitHub\for-Production-Monitoring\PriProMonitoring\PriProMonitoring\Custom-Icon-Design-Flatastic-9-Monitoring.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\MISGWAPOHON\Documents\GitHub\for-Production-Monitoring\PriProMonitoring\PriProMonitoring\bin\Debug\PriProMonitoring.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\MISGWAPOHON\Documents\GitHub\for-Production-Monitoring\PriProMonitoring\PriProMonitoring\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKCU; Subkey: "Software\pri-pro"; Flags: uninsdeletekeyifempty
Root: HKCU; Subkey: "Software\pri-pro\PrinterProduction"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\pri-pro"; Flags: uninsdeletekeyifempty
Root: HKLM; Subkey: "Software\pri-pro\PrinterProduction"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\pri-pro\PrinterProduction"; ValueType: string; ValueName: "InstallPath"; ValueData: "{app}"

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

