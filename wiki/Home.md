# ACadSharp

ACadSharp 2.3.2.0 Library

C# library to read/write cad files like dxf/dwg.

## Namespaces

## [ACadSharp Namespace](ACadSharp)

### Classes

| Name | Summary | 
| :- | :- | 
| [ACadVersion](ACadSharp.ACadVersion) | Drawing format version. | 
| [CadDocument](ACadSharp.CadDocument) | A CAD drawing | 
| [CadObject](ACadSharp.CadObject) | Represents an element in a CadDocument | 
| [CadObjectCollection\<T\>](ACadSharp.CadObjectCollection_T_) |  | 
| [CadSummaryInfo](ACadSharp.CadSummaryInfo) |  | 
| [CadSystemVariable](ACadSharp.CadSystemVariable) |  | 
| [CollectionChangedEventArgs](ACadSharp.CollectionChangedEventArgs) |  | 
| [Color](ACadSharp.Color) |  | 
| [DwgPreview](ACadSharp.DwgPreview) |  | 
| [DwgReferenceType](ACadSharp.DwgReferenceType) |  | 
| [DxfClassMap](ACadSharp.DxfClassMap) |  | 
| [DxfCode](ACadSharp.DxfCode) |  | 
| [DxfFileToken](ACadSharp.DxfFileToken) |  | 
| [DxfMap](ACadSharp.DxfMap) |  | 
| [DxfMapBase](ACadSharp.DxfMapBase) |  | 
| [DxfProperty](ACadSharp.DxfProperty) |  | 
| [DxfPropertyBase\<T\>](ACadSharp.DxfPropertyBase_T_) |  | 
| [DxfReferenceType](ACadSharp.DxfReferenceType) | Type of dxf reference | 
| [DxfSubclassMarker](ACadSharp.DxfSubclassMarker) |  | 
| [ExtendedData](ACadSharp.ExtendedData) |  | 
| [ExtendedDataDictionary](ACadSharp.ExtendedDataDictionary) |  | 
| [ExtendedDataRecord](ACadSharp.ExtendedDataRecord) |  | 
| [FlowDirectionType](ACadSharp.FlowDirectionType) |  | 
| [GroupCodeValue](ACadSharp.GroupCodeValue) |  | 
| [GroupCodeValueType](ACadSharp.GroupCodeValueType) | Group codes define the type of the associated value as an integer, a floating-point number, or a string, according to the following table of group code ranges. | 
| [IHandledCadObject](ACadSharp.IHandledCadObject) | Defines a CadObject with a unique handle | 
| [INamedCadObject](ACadSharp.INamedCadObject) | Defines a CadObject with a unique name | 
| [IObservableCollection\<T\>](ACadSharp.IObservableCollection_T_) |  | 
| [ISeqendCollection](ACadSharp.ISeqendCollection) |  | 
| [LineSpacingStyle](ACadSharp.LineSpacingStyle) |  | 
| [LineweightType](ACadSharp.LineweightType) |  | 
| [MathUtils](ACadSharp.MathUtils) |  | 
| [MultiLeaderPathType](ACadSharp.MultiLeaderPathType) | Controls the way the leader is drawn. | 
| [ObjectType](ACadSharp.ObjectType) | Some object types have fixed values, this enum contains the values for these objects. | 
| [OnNameChangedArgs](ACadSharp.OnNameChangedArgs) |  | 
| [OrthographicType](ACadSharp.OrthographicType) | Orthographic type | 
| [RenderMode](ACadSharp.RenderMode) | Viewport render mode | 
| [SeqendCollection\<T\>](ACadSharp.SeqendCollection_T_) | Represents a collection of <see cref="T:ACadSharp.CadObject" /> ended by a <see cref="T:ACadSharp.Entities.Seqend" /> entity | 
| [TextAlignmentType](ACadSharp.TextAlignmentType) |  | 
| [TextAngleType](ACadSharp.TextAngleType) |  | 
| [TextAttachmentDirectionType](ACadSharp.TextAttachmentDirectionType) |  | 
| [TextAttachmentPointType](ACadSharp.TextAttachmentPointType) |  | 
| [TextAttachmentType](ACadSharp.TextAttachmentType) |  | 
| [Transparency](ACadSharp.Transparency) |  | 


## [ACadSharp.Attributes Namespace](ACadSharp.Attributes)

### Classes

| Name | Summary | 
| :- | :- | 
| [CadSystemVariableAttribute](ACadSharp.Attributes.CadSystemVariableAttribute) |  | 
| [DxfCodeValueAttribute](ACadSharp.Attributes.DxfCodeValueAttribute) |  | 
| [DxfNameAttribute](ACadSharp.Attributes.DxfNameAttribute) | Mark the class as a dxf class equivalent | 
| [DxfSubClassAttribute](ACadSharp.Attributes.DxfSubClassAttribute) | Mark the class as a dxf class equivalent | 
| [ICodeValueAttribute](ACadSharp.Attributes.ICodeValueAttribute) |  | 


## [ACadSharp.Blocks Namespace](ACadSharp.Blocks)

### Classes

| Name | Summary | 
| :- | :- | 
| [Block](ACadSharp.Blocks.Block) | Represents a <see cref="T:ACadSharp.Blocks.Block" /> entity | 
| [BlockEnd](ACadSharp.Blocks.BlockEnd) | Represents a <see cref="T:ACadSharp.Blocks.BlockEnd" /> entity | 
| [BlockTypeFlags](ACadSharp.Blocks.BlockTypeFlags) | Block-type flags (bit-coded values, may be combined). | 


## [ACadSharp.Classes Namespace](ACadSharp.Classes)

### Classes

| Name | Summary | 
| :- | :- | 
| [DxfClass](ACadSharp.Classes.DxfClass) |  | 
| [DxfClassCollection](ACadSharp.Classes.DxfClassCollection) |  | 
| [ProxyFlags](ACadSharp.Classes.ProxyFlags) |  | 


## [ACadSharp.Entities Namespace](ACadSharp.Entities)

### Classes

| Name | Summary | 
| :- | :- | 
| [Arc](ACadSharp.Entities.Arc) | Represents a <see cref="T:ACadSharp.Entities.Arc" /> entity. | 
| [AttachmentPointType](ACadSharp.Entities.AttachmentPointType) | Attachment point for Multiline text. | 
| [AttributeBase](ACadSharp.Entities.AttributeBase) | Common base class for <see cref="T:ACadSharp.Entities.AttributeEntity" /> and <see cref="T:ACadSharp.Entities.AttributeDefinition" />. | 
| [AttributeDefinition](ACadSharp.Entities.AttributeDefinition) | Represents a <see cref="T:ACadSharp.Entities.AttributeDefinition" /> entity. | 
| [AttributeEntity](ACadSharp.Entities.AttributeEntity) | Represents a <see cref="T:ACadSharp.Entities.AttributeEntity" /> entity. | 
| [AttributeFlags](ACadSharp.Entities.AttributeFlags) | Attribute flags. | 
| [AttributeType](ACadSharp.Entities.AttributeType) |  | 
| [BackgroundFillFlags](ACadSharp.Entities.BackgroundFillFlags) | Represents a background fill flags | 
| [BlockContentConnectionType](ACadSharp.Entities.BlockContentConnectionType) |  | 
| [BoundaryPathFlags](ACadSharp.Entities.BoundaryPathFlags) | Defines the boundary path type of the hatch. | 
| [CadImageBase](ACadSharp.Entities.CadImageBase) |  | 
| [Circle](ACadSharp.Entities.Circle) | Represents a <see cref="T:ACadSharp.Entities.Circle" /> entity. | 
| [ClipMode](ACadSharp.Entities.ClipMode) | Represents the clip mode. | 
| [ClipType](ACadSharp.Entities.ClipType) | Clipping boundary type | 
| [ColumnType](ACadSharp.Entities.ColumnType) | Represents the type of columns. | 
| [Dimension](ACadSharp.Entities.Dimension) | Represents a <see cref="T:ACadSharp.Entities.Dimension" /> entity. | 
| [DimensionAligned](ACadSharp.Entities.DimensionAligned) | Represents a <see cref="T:ACadSharp.Entities.DimensionAligned" /> entity. | 
| [DimensionAngular2Line](ACadSharp.Entities.DimensionAngular2Line) | Represents a <see cref="T:ACadSharp.Entities.DimensionAngular2Line" /> entity. | 
| [DimensionAngular3Pt](ACadSharp.Entities.DimensionAngular3Pt) | Represents a <see cref="T:ACadSharp.Entities.DimensionAngular3Pt" /> entity. | 
| [DimensionDiameter](ACadSharp.Entities.DimensionDiameter) | Represents a <see cref="T:ACadSharp.Entities.DimensionDiameter" /> entity. | 
| [DimensionLinear](ACadSharp.Entities.DimensionLinear) | Represents a <see cref="T:ACadSharp.Entities.DimensionLinear" /> entity. | 
| [DimensionOrdinate](ACadSharp.Entities.DimensionOrdinate) | Represents a <see cref="T:ACadSharp.Entities.DimensionOrdinate" /> entity. | 
| [DimensionRadius](ACadSharp.Entities.DimensionRadius) | Represents a <see cref="T:ACadSharp.Entities.DimensionRadius" /> entity. | 
| [DimensionType](ACadSharp.Entities.DimensionType) | Dimension type | 
| [DrawingDirectionType](ACadSharp.Entities.DrawingDirectionType) | Multiline text drawing direction. | 
| [Ellipse](ACadSharp.Entities.Ellipse) | Represents a <see cref="T:ACadSharp.Entities.Ellipse" /> entity. | 
| [Entity](ACadSharp.Entities.Entity) | The standard class for a basic CAD entity or a graphical object. | 
| [Face3D](ACadSharp.Entities.Face3D) | Represents a <see cref="T:ACadSharp.Entities.Face3D" /> entity. | 
| [GradientColor](ACadSharp.Entities.GradientColor) |  | 
| [Hatch](ACadSharp.Entities.Hatch) | Represents a <see cref="T:ACadSharp.Entities.Hatch" /> entity. | 
| [HatchGradientPattern](ACadSharp.Entities.HatchGradientPattern) |  | 
| [HatchPattern](ACadSharp.Entities.HatchPattern) |  | 
| [HatchPatternType](ACadSharp.Entities.HatchPatternType) | Hatch pattern fill type. | 
| [HatchStyleType](ACadSharp.Entities.HatchStyleType) | Hatch pattern style. | 
| [IEntity](ACadSharp.Entities.IEntity) |  | 
| [ImageDisplayFlags](ACadSharp.Entities.ImageDisplayFlags) |  | 
| [Insert](ACadSharp.Entities.Insert) | Represents a <see cref="T:ACadSharp.Entities.Insert" /> entity. | 
| [InvisibleEdgeFlags](ACadSharp.Entities.InvisibleEdgeFlags) | Defines which edges are hidden. | 
| [IPolyline](ACadSharp.Entities.IPolyline) |  | 
| [IText](ACadSharp.Entities.IText) |  | 
| [IVertex](ACadSharp.Entities.IVertex) |  | 
| [KnotParameterization](ACadSharp.Entities.KnotParameterization) | Knot parameterization | 
| [Leader](ACadSharp.Entities.Leader) | Represents a <see cref="T:ACadSharp.Entities.Leader" /> entity. | 
| [LeaderCreationType](ACadSharp.Entities.LeaderCreationType) | Leader creation type | 
| [LeaderPathType](ACadSharp.Entities.LeaderPathType) | Controls the way the leader is drawn. | 
| [LightingType](ACadSharp.Entities.LightingType) | Represents lighting type. | 
| [Line](ACadSharp.Entities.Line) | Represents a <see cref="T:ACadSharp.Entities.Line" /> entity. | 
| [LineSpacingStyleType](ACadSharp.Entities.LineSpacingStyleType) | Line spacing style for Multiline text and Dimensions. | 
| [LwPolyline](ACadSharp.Entities.LwPolyline) | Represents a <see cref="T:ACadSharp.Entities.LwPolyline" /> entity | 
| [LwPolylineFlags](ACadSharp.Entities.LwPolylineFlags) | Polyline flag (bit-coded) | 
| [Mesh](ACadSharp.Entities.Mesh) | Represents a <see cref="T:ACadSharp.Entities.Mesh" /> entity. | 
| [MLine](ACadSharp.Entities.MLine) | Represents a <see cref="T:ACadSharp.Entities.MLine" /> entity. | 
| [MLineFlags](ACadSharp.Entities.MLineFlags) | Flags (bit-coded values) | 
| [MLineJustification](ACadSharp.Entities.MLineJustification) | Justification | 
| [MText](ACadSharp.Entities.MText) | Represents a <see cref="T:ACadSharp.Entities.MText" /> entity. | 
| [MultiLeader](ACadSharp.Entities.MultiLeader) | Represents a <see cref="T:ACadSharp.Entities.MultiLeader" /> entity. | 
| [MultiLeaderPropertyOverrideFlags](ACadSharp.Entities.MultiLeaderPropertyOverrideFlags) |  | 
| [Point](ACadSharp.Entities.Point) | Represents a <see cref="T:ACadSharp.Entities.Point" /> entity. | 
| [PolyfaceMesh](ACadSharp.Entities.PolyfaceMesh) | Represents a <see cref="T:ACadSharp.Entities.PolyfaceMesh" /> entity. | 
| [Polyline](ACadSharp.Entities.Polyline) | Represents a <see cref="T:ACadSharp.Entities.Polyline" /> entity | 
| [Polyline2D](ACadSharp.Entities.Polyline2D) | Represents a <see cref="T:ACadSharp.Entities.Polyline2D" /> entity. | 
| [Polyline3D](ACadSharp.Entities.Polyline3D) | Represents a <see cref="T:ACadSharp.Entities.Polyline3D" /> entity. | 
| [PolylineFlags](ACadSharp.Entities.PolylineFlags) | Defines the polyline flags. | 
| [RasterImage](ACadSharp.Entities.RasterImage) | Represents a <see cref="T:ACadSharp.Entities.RasterImage" /> entity. | 
| [Ray](ACadSharp.Entities.Ray) | Represents a <see cref="T:ACadSharp.Entities.Ray" /> entity. | 
| [Seqend](ACadSharp.Entities.Seqend) | Represents a <see cref="T:ACadSharp.Entities.Seqend" /> entity | 
| [ShadowMode](ACadSharp.Entities.ShadowMode) |  | 
| [Shape](ACadSharp.Entities.Shape) | Represents a <see cref="T:ACadSharp.Entities.Shape" /> entity. | 
| [SmoothSurfaceType](ACadSharp.Entities.SmoothSurfaceType) | Curves and smooth surface type. | 
| [Solid](ACadSharp.Entities.Solid) | Represents a <see cref="T:ACadSharp.Entities.Solid" /> entity. | 
| [Solid3D](ACadSharp.Entities.Solid3D) | Represents a <see cref="T:ACadSharp.Entities.Solid" /> entity. | 
| [Spline](ACadSharp.Entities.Spline) | Represents a <see cref="T:ACadSharp.Entities.Spline" /> entity. | 
| [SplineFlags](ACadSharp.Entities.SplineFlags) | Defines the spline flags | 
| [SplineFlags1](ACadSharp.Entities.SplineFlags1) | Defines the spline flags 1  | 
| [TextEntity](ACadSharp.Entities.TextEntity) | Represents a <see cref="T:ACadSharp.Entities.TextEntity" /> | 
| [TextHorizontalAlignment](ACadSharp.Entities.TextHorizontalAlignment) |  | 
| [TextMirrorFlag](ACadSharp.Entities.TextMirrorFlag) |  | 
| [TextVerticalAlignmentType](ACadSharp.Entities.TextVerticalAlignmentType) | Text vertical justification. | 
| [Tolerance](ACadSharp.Entities.Tolerance) | Represents a <see cref="T:ACadSharp.Entities.Tolerance" /> entity. | 
| [UnknownEntity](ACadSharp.Entities.UnknownEntity) | Class that holds the basic information for an unknown entity | 
| [Vertex](ACadSharp.Entities.Vertex) | Represents a base type for Vertex entities | 
| [Vertex2D](ACadSharp.Entities.Vertex2D) | Represents a <see cref="T:ACadSharp.Entities.Vertex2D" /> entity | 
| [Vertex3D](ACadSharp.Entities.Vertex3D) | Represents a <see cref="T:ACadSharp.Entities.Vertex3D" /> entity | 
| [VertexFaceMesh](ACadSharp.Entities.VertexFaceMesh) | Represents a <see cref="T:ACadSharp.Entities.VertexFaceMesh" /> entity | 
| [VertexFaceRecord](ACadSharp.Entities.VertexFaceRecord) | Represents a <see cref="T:ACadSharp.Entities.VertexFaceRecord" /> entity | 
| [VertexFlags](ACadSharp.Entities.VertexFlags) | Defines the vertex flags. | 
| [VerticalAlignmentType](ACadSharp.Entities.VerticalAlignmentType) | Text vertical justification. | 
| [Viewport](ACadSharp.Entities.Viewport) | Represents a <see cref="T:ACadSharp.Entities.Viewport" /> entity. | 
| [ViewportStatusFlags](ACadSharp.Entities.ViewportStatusFlags) | viewport status flags | 
| [Wipeout](ACadSharp.Entities.Wipeout) | Represents a <see cref="T:ACadSharp.Entities.Wipeout" /> entity. | 
| [XLine](ACadSharp.Entities.XLine) | Represents a <see cref="T:ACadSharp.Entities.XLine" /> entity. | 


## [ACadSharp.Exceptions Namespace](ACadSharp.Exceptions)

### Classes

| Name | Summary | 
| :- | :- | 
| [CadNotSupportedException](ACadSharp.Exceptions.CadNotSupportedException) |  | 
| [DwgException](ACadSharp.Exceptions.DwgException) |  | 
| [DwgNotSupportedException](ACadSharp.Exceptions.DwgNotSupportedException) |  | 
| [DxfException](ACadSharp.Exceptions.DxfException) |  | 
| [DxfNotSupportedException](ACadSharp.Exceptions.DxfNotSupportedException) |  | 


## [ACadSharp.Header Namespace](ACadSharp.Header)

### Classes

| Name | Summary | 
| :- | :- | 
| [AttributeVisibilityMode](ACadSharp.Header.AttributeVisibilityMode) |  | 
| [CadHeader](ACadSharp.Header.CadHeader) |  | 
| [DimensionAssociation](ACadSharp.Header.DimensionAssociation) | Controls the associativity of dimension objects. | 
| [EntityPlotStyleType](ACadSharp.Header.EntityPlotStyleType) | Plot style type of new objects | 
| [IndexCreationFlags](ACadSharp.Header.IndexCreationFlags) | Controls whether layer and spatial indexes are created and saved in drawing files | 
| [MeasurementUnits](ACadSharp.Header.MeasurementUnits) | Measurement units | 
| [ObjectSnapMode](ACadSharp.Header.ObjectSnapMode) | Object snap mode AcDb::OsnapMask | 
| [ObjectSortingFlags](ACadSharp.Header.ObjectSortingFlags) | Bitmask flags to set the various object sorting types. | 
| [ShadeEdgeType](ACadSharp.Header.ShadeEdgeType) | Edge shape type | 
| [ShadowMode](ACadSharp.Header.ShadowMode) | Shadow mode for a 3D object | 
| [SpaceLineTypeScaling](ACadSharp.Header.SpaceLineTypeScaling) | Controls paper space linetype scaling. | 
| [SplineType](ACadSharp.Header.SplineType) | Spline type | 


## [ACadSharp.IO Namespace](ACadSharp.IO)

### Classes

| Name | Summary | 
| :- | :- | 
| [CadReaderBase](ACadSharp.IO.CadReaderBase) |  | 
| [CadReaderConfiguration](ACadSharp.IO.CadReaderConfiguration) |  | 
| [CadWriterBase](ACadSharp.IO.CadWriterBase) |  | 
| [DwgReader](ACadSharp.IO.DwgReader) |  | 
| [DwgReaderConfiguration](ACadSharp.IO.DwgReaderConfiguration) |  | 
| [DwgWriter](ACadSharp.IO.DwgWriter) |  | 
| [DxfReader](ACadSharp.IO.DxfReader) |  | 
| [DxfReaderConfiguration](ACadSharp.IO.DxfReaderConfiguration) |  | 
| [DxfWriter](ACadSharp.IO.DxfWriter) |  | 
| [DxfWriterOptions](ACadSharp.IO.DxfWriterOptions) |  | 
| [ICadReader](ACadSharp.IO.ICadReader) |  | 
| [ICadWriter](ACadSharp.IO.ICadWriter) |  | 
| [NotificationEventArgs](ACadSharp.IO.NotificationEventArgs) |  | 
| [NotificationEventHandler](ACadSharp.IO.NotificationEventHandler) |  | 
| [NotificationType](ACadSharp.IO.NotificationType) |  | 


## [ACadSharp.Objects Namespace](ACadSharp.Objects)

### Classes

| Name | Summary | 
| :- | :- | 
| [AcdbPlaceHolder](ACadSharp.Objects.AcdbPlaceHolder) | Represents a <see cref="T:ACadSharp.Objects.AcdbPlaceHolder" /> object. | 
| [CadDictionary](ACadSharp.Objects.CadDictionary) | Represents a <see cref="T:ACadSharp.Objects.CadDictionary" /> object. | 
| [CadDictionaryWithDefault](ACadSharp.Objects.CadDictionaryWithDefault) | Represents a <see cref="T:ACadSharp.Objects.CadDictionaryWithDefault" /> object. | 
| [DictionaryCloningFlags](ACadSharp.Objects.DictionaryCloningFlags) | Duplicate record cloning flag (determines how to merge duplicate entries). | 
| [DictionaryVariable](ACadSharp.Objects.DictionaryVariable) | Represents a <see cref="T:ACadSharp.Objects.DictionaryVariable" /> object. | 
| [FaceColorMode](ACadSharp.Objects.FaceColorMode) |  | 
| [FaceLightingModelType](ACadSharp.Objects.FaceLightingModelType) |  | 
| [FaceLightingQualityType](ACadSharp.Objects.FaceLightingQualityType) |  | 
| [FaceModifierType](ACadSharp.Objects.FaceModifierType) |  | 
| [Group](ACadSharp.Objects.Group) | Represents a <see cref="T:ACadSharp.Objects.Group" /> object. | 
| [ImageDefinition](ACadSharp.Objects.ImageDefinition) | Represents a <see cref="T:ACadSharp.Objects.ImageDefinition" /> object. | 
| [ImageDefinitionReactor](ACadSharp.Objects.ImageDefinitionReactor) | Represents a <see cref="T:ACadSharp.Objects.ImageDefinitionReactor" /> object. | 
| [Layout](ACadSharp.Objects.Layout) | Represents a <see cref="T:ACadSharp.Objects.Layout" /> object | 
| [LayoutFlags](ACadSharp.Objects.LayoutFlags) | Layout flags | 
| [LeaderContentType](ACadSharp.Objects.LeaderContentType) |  | 
| [LeaderDrawOrderType](ACadSharp.Objects.LeaderDrawOrderType) | Specifies the draw order of a <see cref="T:ACadSharp.Objects.MultiLeaderAnnotContext.LeaderRoot" />
in a <see cref="T:ACadSharp.Entities.MultiLeader" /> entity. | 
| [LeaderLinePropertOverrideFlags](ACadSharp.Objects.LeaderLinePropertOverrideFlags) |  | 
| [Material](ACadSharp.Objects.Material) |  | 
| [MLineStyle](ACadSharp.Objects.MLineStyle) | Represents a <see cref="T:ACadSharp.Objects.MLineStyle" /> object | 
| [MLineStyleFlags](ACadSharp.Objects.MLineStyleFlags) | Flags (bit-coded). | 
| [MultiLeaderAnnotContext](ACadSharp.Objects.MultiLeaderAnnotContext) | This class represents a subset ob the properties of the MLeaderAnnotContext
object, that are embedded into the MultiLeader entity. | 
| [MultiLeaderDrawOrderType](ACadSharp.Objects.MultiLeaderDrawOrderType) | Specifies the draw order of a <see cref="T:ACadSharp.Entities.MultiLeader" /> entity. | 
| [MultiLeaderStyle](ACadSharp.Objects.MultiLeaderStyle) | Represents a <see cref="T:ACadSharp.Objects.MultiLeaderStyle" /> object. | 
| [NonGraphicalObject](ACadSharp.Objects.NonGraphicalObject) | The standard class for a basic CAD non-graphical object. | 
| [PaperMargin](ACadSharp.Objects.PaperMargin) | Represents the unprintable margins of a paper.  | 
| [PlotFlags](ACadSharp.Objects.PlotFlags) | Defines the plot settings flag. | 
| [PlotPaperUnits](ACadSharp.Objects.PlotPaperUnits) | Plot paper units | 
| [PlotRotation](ACadSharp.Objects.PlotRotation) | Plot rotation | 
| [PlotSettings](ACadSharp.Objects.PlotSettings) | Represents a <see cref="T:ACadSharp.Objects.PlotSettings" /> object | 
| [PlotType](ACadSharp.Objects.PlotType) | Defines the portion of paper space to output to the media | 
| [ResolutionUnit](ACadSharp.Objects.ResolutionUnit) | Resolution units for images. | 
| [Scale](ACadSharp.Objects.Scale) | Represents a <see cref="T:ACadSharp.Objects.Scale" /> object | 
| [ScaledType](ACadSharp.Objects.ScaledType) |  | 
| [ShadePlotMode](ACadSharp.Objects.ShadePlotMode) | Defines the shade plot mode | 
| [ShadePlotResolutionMode](ACadSharp.Objects.ShadePlotResolutionMode) | Defines the shade plot resolution mode. | 
| [SortEntitiesTable](ACadSharp.Objects.SortEntitiesTable) | Represents a <see cref="T:ACadSharp.Objects.SortEntitiesTable" /> object | 
| [VisualStyle](ACadSharp.Objects.VisualStyle) | Represents a <see cref="T:ACadSharp.Objects.VisualStyle" /> object | 
| [XRecord](ACadSharp.Objects.XRecord) | Represents a <see cref="T:ACadSharp.Objects.XRecord" /> object | 


## [ACadSharp.Objects.Collections Namespace](ACadSharp.Objects.Collections)

### Classes

| Name | Summary | 
| :- | :- | 
| [GroupCollection](ACadSharp.Objects.Collections.GroupCollection) |  | 
| [ImageDefinitionCollection](ACadSharp.Objects.Collections.ImageDefinitionCollection) |  | 
| [LayoutCollection](ACadSharp.Objects.Collections.LayoutCollection) |  | 
| [MLeaderStyleCollection](ACadSharp.Objects.Collections.MLeaderStyleCollection) |  | 
| [MLineStyleCollection](ACadSharp.Objects.Collections.MLineStyleCollection) |  | 
| [ObjectDictionaryCollection\<T\>](ACadSharp.Objects.Collections.ObjectDictionaryCollection_T_) | Object collection linked to a dictionary | 
| [ScaleCollection](ACadSharp.Objects.Collections.ScaleCollection) |  | 


## [ACadSharp.Tables Namespace](ACadSharp.Tables)

### Classes

| Name | Summary | 
| :- | :- | 
| [AppId](ACadSharp.Tables.AppId) | Represents a <see cref="T:ACadSharp.Tables.AppId" /> entry | 
| [ArcLengthSymbolPosition](ACadSharp.Tables.ArcLengthSymbolPosition) | Controls the arc length symbol position in an arc length dimension. | 
| [BlockRecord](ACadSharp.Tables.BlockRecord) | Represents a <see cref="T:ACadSharp.Tables.BlockRecord" /> entry | 
| [DefaultLightingType](ACadSharp.Tables.DefaultLightingType) | Default lighting type | 
| [DimensionStyle](ACadSharp.Tables.DimensionStyle) | Represents a <see cref="T:ACadSharp.Tables.DimensionStyle" /> table entry. | 
| [DimensionTextBackgroundFillMode](ACadSharp.Tables.DimensionTextBackgroundFillMode) | Represents the dimension text background color. | 
| [DimensionTextHorizontalAlignment](ACadSharp.Tables.DimensionTextHorizontalAlignment) | Controls the vertical placement of dimension text in relation to the dimension line. | 
| [DimensionTextVerticalAlignment](ACadSharp.Tables.DimensionTextVerticalAlignment) | Controls the placement of dimension text. | 
| [EntryFlags](ACadSharp.Tables.EntryFlags) | Standard entry flags (bit-coded values). | 
| [FontFlags](ACadSharp.Tables.FontFlags) | Represent the font character formatting, such as italic, bold, or regular. | 
| [FractionFormat](ACadSharp.Tables.FractionFormat) | Represents the fraction format when the linear unit format is set to architectural or fractional. | 
| [GridFlags](ACadSharp.Tables.GridFlags) |  | 
| [Layer](ACadSharp.Tables.Layer) | Represents a <see cref="T:ACadSharp.Tables.Layer" /> entry | 
| [LayerFlags](ACadSharp.Tables.LayerFlags) | Standard layer flags (bit-coded values). | 
| [LineType](ACadSharp.Tables.LineType) | Represents a <see cref="T:ACadSharp.Tables.LineType" /> entry | 
| [LinetypeShapeFlags](ACadSharp.Tables.LinetypeShapeFlags) | Represents a line type complex element type. | 
| [StandardFlags](ACadSharp.Tables.StandardFlags) | Standard flags for tables | 
| [StyleFlags](ACadSharp.Tables.StyleFlags) | Standard layer flags (bit-coded values). | 
| [TableEntry](ACadSharp.Tables.TableEntry) |  | 
| [TextArrowFitType](ACadSharp.Tables.TextArrowFitType) | How dimension text and arrows are arranged when space is not sufficient to place both within the extension lines. | 
| [TextDirection](ACadSharp.Tables.TextDirection) | Represents the text direction (left-to-right or right-to-left). | 
| [TextMovement](ACadSharp.Tables.TextMovement) | Text movement rules. | 
| [TextStyle](ACadSharp.Tables.TextStyle) | Represents a <see cref="T:ACadSharp.Tables.TextStyle" /> entry | 
| [ToleranceAlignment](ACadSharp.Tables.ToleranceAlignment) | Tolerance alignment. | 
| [UCS](ACadSharp.Tables.UCS) | Represents a <see cref="T:ACadSharp.Tables.UCS" /> entry | 
| [UscIconType](ACadSharp.Tables.UscIconType) | Display Ucs icon | 
| [View](ACadSharp.Tables.View) | Represents a <see cref="T:ACadSharp.Tables.View" /> entry | 
| [ViewModeType](ACadSharp.Tables.ViewModeType) |  | 
| [VPort](ACadSharp.Tables.VPort) | Represents a <see cref="T:ACadSharp.Tables.VPort" /> table entry | 
| [ZeroHandling](ACadSharp.Tables.ZeroHandling) | Represents supression of zeros in displaying decimal numbers. | 


## [ACadSharp.Tables.Collections Namespace](ACadSharp.Tables.Collections)

### Classes

| Name | Summary | 
| :- | :- | 
| [AppIdsTable](ACadSharp.Tables.Collections.AppIdsTable) |  | 
| [BlockRecordsTable](ACadSharp.Tables.Collections.BlockRecordsTable) |  | 
| [DimensionStylesTable](ACadSharp.Tables.Collections.DimensionStylesTable) |  | 
| [LayersTable](ACadSharp.Tables.Collections.LayersTable) |  | 
| [LineTypesTable](ACadSharp.Tables.Collections.LineTypesTable) |  | 
| [Table\<T\>](ACadSharp.Tables.Collections.Table_T_) |  | 
| [TextStylesTable](ACadSharp.Tables.Collections.TextStylesTable) |  | 
| [UCSTable](ACadSharp.Tables.Collections.UCSTable) |  | 
| [ViewsTable](ACadSharp.Tables.Collections.ViewsTable) |  | 
| [VPortsTable](ACadSharp.Tables.Collections.VPortsTable) |  | 


## [ACadSharp.Types.Units Namespace](ACadSharp.Types.Units)

### Classes

| Name | Summary | 
| :- | :- | 
| [AngularDirection](ACadSharp.Types.Units.AngularDirection) | Represents angular direction. | 
| [AngularUnitFormat](ACadSharp.Types.Units.AngularUnitFormat) | Angular unit format | 
| [LinearUnitFormat](ACadSharp.Types.Units.LinearUnitFormat) | Units format for decimal numbers | 
| [UnitsType](ACadSharp.Types.Units.UnitsType) |  | 


## [CSMath Namespace](CSMath)

### Classes

| Name | Summary | 
| :- | :- | 
| [BoundingBox](CSMath.BoundingBox) | Bounding box representation aligned to XYZ axis. | 
| [IVector](CSMath.IVector) |  | 
| [MathUtils](CSMath.MathUtils) |  | 
| [Matrix4](CSMath.Matrix4) | 4x4 Matrix | 
| [Quaternion](CSMath.Quaternion) | Four dimensional vector which is used to efficiently rotate an object about the (x,y,z) vector by the angle theta, where w = cos(theta/2). | 
| [VectorExtensions](CSMath.VectorExtensions) |  | 
| [XY](CSMath.XY) |  | 
| [XYZ](CSMath.XYZ) |  | 
| [XYZM](CSMath.XYZM) |  | 


## [CSMath.Geometry Namespace](CSMath.Geometry)

### Classes

| Name | Summary | 
| :- | :- | 
| [ILine\<T\>](CSMath.Geometry.ILine_T_) |  | 
| [Line2D](CSMath.Geometry.Line2D) |  | 
| [Line3D](CSMath.Geometry.Line3D) |  | 
| [LineExtensions](CSMath.Geometry.LineExtensions) |  | 


## [CSUtilities.Attributes Namespace](CSUtilities.Attributes)

### Classes

| Name | Summary | 
| :- | :- | 
| [StringValueAttribute](CSUtilities.Attributes.StringValueAttribute) | Simple attribute class for storing String Values | 


## [CSUtilities.Extensions Namespace](CSUtilities.Extensions)

### Classes

| Name | Summary | 
| :- | :- | 
| [IDictionaryExtension](CSUtilities.Extensions.IDictionaryExtension) | Estensions for <see cref="T:System.Collections.Generic.IDictionary`2" /> | 


