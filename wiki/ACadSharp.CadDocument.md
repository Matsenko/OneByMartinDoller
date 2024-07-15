# CadDocument Class

A CAD drawing

## Properties

| Name | Summary | 
| :- | :- | 
| Handle | The document handle is always 0, this field makes sure that no object overrides this value | 
| Header | Contains all the header variables for this document. | 
| SummaryInfo | Accesses drawing properties such as the Title, Subject, Author, and Keywords properties | 
| Classes | Dxf classes defined in this document | 
| AppIds | The collection of all registered applications in the drawing | 
| BlockRecords | The collection of all block records in the drawing | 
| DimensionStyles | The collection of all dimension styles in the drawing | 
| Layers | The collection of all layers in the drawing | 
| LineTypes | The collection of all linetypes in the drawing | 
| TextStyles | The collection of all text styles in the drawing | 
| UCSs | The collection of all user coordinate systems (UCSs) in the drawing | 
| Views | The collection of all views in the drawing | 
| VPorts | The collection of all vports in the drawing | 
| Layouts | The collection of all layouts in the drawing. | 
| Groups | The collection of all groups in the drawing.  | 
| Scales | The collection of all scales in the drawing.  | 
| MLineStyles | The collection of all Multi line styles in the drawing.  | 
| ImageDefinitions |  | 
| MLeaderStyles | The collection of all Multi leader styles in the drawing.  | 
| RootDictionary | Root dictionary of the document | 
| Entities | Collection with all the entities in the drawing | 
| ModelSpace | Model space block record containing the drawing | 
| PaperSpace | Default paper space of the model | 

## Methods

| Name | Summary | 
| :- | :- | 
| GetCadObject | Gets an object in the document by it's handle | 
| GetCadObject | Gets an object in the document by it's handle | 
| TryGetCadObject | Gets an object in the document by it's handle | 
| CreateDefaults |  | 
| UpdateCollections | Updates the collections in the document and link them to it's dictionary | 

