# Dimension Class

Represents a <see cref="T:ACadSharp.Entities.Dimension" /> entity.

## Properties

| Name | Summary | 
| :- | :- | 
| SubclassMarker |  | 
| Version | Version number | 
| Block | Block that contains the entities that make up the dimension picture | 
| DefinitionPoint | Definition point(in WCS) | 
| TextMiddlePoint | Middle point of dimension text(in OCS) | 
| InsertionPoint | Insertion point for clones of a dimension-Baseline and Continue(in OCS) | 
| Normal | Specifies the three-dimensional normal unit vector for the object. | 
| Flags | Dimension type | 
| IsTextUserDefinedLocation | Indicates if the dimension text has been positioned at a user-defined location rather than at the default location | 
| AttachmentPoint | Attachment point | 
| LineSpacingStyle | Dimension text line-spacing style | 
| LineSpacingFactor | Dimension text-line spacing factor | 
| Measurement | Actual measurement | 
| FlipArrow1 | Gets or sets a value indicating whether the first arrow
is to be flipped. | 
| FlipArrow2 | Gets or sets a value indicating whether the second arrow
to be flipped. | 
| Text | Gets or sets an explicit dimension text to be displayed instead of the standard
dimension text created from the measurement in the format specified by the
dimension-style properties. | 
| TextRotation | rotation angle of the dimension text away from its default orientation (the direction of the dimension line) | 
| HorizontalDirection | All dimension types have an optional 51 group code, which indicates the horizontal direction for the dimension entity.The dimension entity determines the orientation of dimension text and lines for horizontal, vertical, and rotated linear dimensions
This group value is the negative of the angle between the OCS X axis and the UCS X axis. It is always in the XY plane of the OCS | 
| Style | Dimension style | 

## Methods

| Name | Summary | 
| :- | :- | 
| Clone |  | 

