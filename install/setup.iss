#define MyAppName "Authenticator"
#define MyAppVersion "1.0 beta1"
#define MyAppPublisher "Jcarrasco96"
#define MyAppExeName "Authenticator.exe"
#define MyReleaseDir "..\bin\Release"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
;;;;; App related
AppId={{E2922543-3D1E-4BF7-A7F5-59E2F67BC279}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
;;;;; Pages
DisableProgramGroupPage=yes
;LicenseFile=license.txt
;InfoBeforeFile=info_before.txt
;InfoAfterFile=info_after.txt
;;;;; Other
OutputBaseFilename={#MyAppName} {#MyAppVersion}
;SetupIconFile=icon.ico
;Compression=lzma
SolidCompression=yes
WizardStyle=modern
DisableWelcomePage=no

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#MyReleaseDir}\Authenticator.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MyReleaseDir}\System.Data.SQLite.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MyReleaseDir}\System.Data.SQLite.EF6.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MyReleaseDir}\System.Data.SQLite.Linq.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MyReleaseDir}\x64\*"; DestDir: "{app}\x64"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#MyReleaseDir}\x86\*"; DestDir: "{app}\x86"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

