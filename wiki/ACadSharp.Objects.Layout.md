# Layout Class

Represents a <see cref="T:ACadSharp.Objects.Layout" /> object

## Properties

| Name | Summary | 
| :- | :- | 
| ObjectType |  | 
| ObjectName |  | 
| SubclassMarker |  | 
| Name | Layout name | 
| LayoutFlags | Layout flags | 
| TabOrder | Tab order.This number is an ordinal indicating this layout's ordering in the tab control that is attached to the drawing window. Note that the “Model” tab always appears as the first tab regardless of its tab order | 
| MinLimits | Minimum limits for this layout (defined by LIMMIN while this layout is current) | 
| MaxLimits | Maximum limits for this layout(defined by LIMMAX while this layout is current) | 
| InsertionBasePoint | Insertion base point for this layout(defined by INSBASE while this layout is current)  | 
| MinExtents | Minimum extents for this layout(defined by EXTMIN while this layout is current) | 
| MaxExtents | Maximum extents for this layout(defined by EXTMAX while this layout is current) | 
| Elevation | Layout elevation | 
| Origin | UCS origin | 
| XAxis | UCS X-axis | 
| YAxis | UCS Y-axis | 
| UcsOrthographicType | Orthographic type of UCS | 
| AssociatedBlock | The associated paper space block table record | 
| Viewport | Viewport that was last active in this layout when the layout was current | 
| UCS | UCS Table Record if UCS is a named UCS | 
| BaseUCS | UCSTableRecord of base UCS if UCS is orthographic (<see cref="P:ACadSharp.Objects.Layout.UcsOrthographicType" /> is non-zero) | 
| Viewports |  | 

## Methods

| Name | Summary | 
| :- | :- | 
| ToString |  | 

