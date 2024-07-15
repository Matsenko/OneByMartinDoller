# DxfClass Class



## Properties

| Name | Summary | 
| :- | :- | 
| DxfName | Class DXF record name; always unique | 
| CppClassName | C++ class name. Used to bind with software that defines object class behavior; always unique | 
| ApplicationName | Application name. Posted in Alert box when a class definition listed in this section is not currently loaded | 
| ProxyFlags | Proxy capabilities flag. Bit-coded value that indicates the capabilities of this object as a proxy | 
| InstanceCount | Instance count for a custom class | 
| WasZombie | Was-a-proxy flag. Set to 1 if class was not loaded when this DXF file was created, and 0 otherwise | 
| IsAnEntity | Is-an-entity flag.
Set to 1 if class was derived from the AcDbEntity class and can reside in the BLOCKS or ENTITIES section.
If 0, instances may appear only in the OBJECTS section | 
| ClassNumber | Class number | 
| DwgVersion |  | 

## Methods

| Name | Summary | 
| :- | :- | 
| ToString |  | 

