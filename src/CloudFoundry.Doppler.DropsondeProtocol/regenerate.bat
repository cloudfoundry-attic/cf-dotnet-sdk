cd "%~dp0..\..\packages\Google.Protobuf.Tools.*\tools\windows_x86\"
set protoc=%CD%\protoc.exe
cd "%~dp0"

"%protoc%" dropsonde-protocol\events\envelope.proto --proto_path=dropsonde-protocol\events --include_imports  -o %TEMP%\dropsonde_proto_tmp.bin

cd "%~dp0..\..\packages\protogen-net.*\tools"
set protogen=%CD%\protogen.exe
cd "%~dp0"

"%protogen%" "-i:%TEMP%\dropsonde_proto_tmp.bin" -o:Envelope.cs -ns:CloudFoundry.Doppler.Client

@echo -----
@echo NOTE:
@echo Rename the "event" namespace to "CloudFoundry.Doppler.DropsondeProtocol" manually