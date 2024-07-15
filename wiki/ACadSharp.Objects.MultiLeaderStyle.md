# MultiLeaderStyle Class

Represents a <see cref="T:ACadSharp.Objects.MultiLeaderStyle" /> object.

## Properties

| Name | Summary | 
| :- | :- | 
| ObjectType |  | 
| ObjectName |  | 
| SubclassMarker |  | 
| ContentType | Gets or sets a value indicating the content type for the multileader. | 
| MultiLeaderDrawOrder | DrawMLeaderOrder Type | 
| LeaderDrawOrder | DrawLeaderOrder Type | 
| MaxLeaderSegmentsPoints | Gets or sets the max number of segments when a new leader is being created for a multileader. | 
| FirstSegmentAngleConstraint | Gets or sets a snap angle value for the first leader segment when a leader line
is being created for the mutileader. | 
| SecondSegmentAngleConstraint | Gets or sets a snap angle value for the second leader segment when a leader line
is being created for the mutileader. | 
| PathType | Gets or sets a value indicating whether leaders are to be displayed as polyline,
a spline curve or invisible. This setting applies for all leader lines of the
multileader. | 
| LineColor | Gets or sets color to be applied all leader lines of the multileader. | 
| LeaderLineType | Gets or sets a <see cref="T:ACadSharp.Tables.LineType" /> object specifying line-type properties for the
musltileader. This setting applies for all leader lines of the multileader. | 
| LeaderLineWeight | Gets or sets a value specifying the lineweight to be applied to all leader lines of the multileader. | 
| EnableLanding | Gets or sets a value indicating whether landing is enabled. | 
| LandingGap | Gets or sets the landing gap. This is the distance between the leader end point or, if present,
the end of the dogleg and the text label or the content block. | 
| EnableDogleg | Gets or sets a value indicating that leader lines are to be drawn with a dogleg. | 
| LandingDistance | Gets or sets the landing distance, i.e. the length of the dogleg.  | 
| Description | Gets or sets a text containing the description of this <see cref="T:ACadSharp.Objects.MultiLeaderStyle" />. | 
| Arrowhead | Gets or sets a <see cref="T:ACadSharp.Tables.BlockRecord" /> representing the arrowhead
to be displayed with every leader line. | 
| ArrowheadSize | Gests or sets the arrowhead size. | 
| DefaultTextContents | Gests or sets a default text that is to be set when a mutileader is being created
with this <see cref="T:ACadSharp.Objects.MultiLeaderStyle" />. | 
| TextStyle | Gets or sets the <see cref="P:ACadSharp.Objects.MultiLeaderStyle.TextStyle" /> to be used to display the text label of the
multileader. | 
| TextLeftAttachment | Gets or sets the Text Left Attachment Type.
This value controls the position of the connection point of the leader
attached to the left side of the text label. | 
| TextAngle | Gets or sets a value indicating the text angle. | 
| TextAlignment | Gets or sets the text alignment, i.e. the alignment of text lines if the a multiline
text label, relative to the <see cref="P:ACadSharp.Objects.MultiLeaderAnnotContext.TextLocation" />. | 
| TextRightAttachment | Gets or sets the Text Right Attachment Type.
This value controls the position of the connection point of the leader
attached to the right side of the text label. | 
| TextColor | Gest or sets the color for the text label of the multileader. | 
| TextHeight | Gest or sets the text height for the text label of the multileader. | 
| TextFrame | Gets or sets a value indicating that the text label is to be drawn with a frame. | 
| TextAlignAlwaysLeft | Text Align Always Left | 
| AlignSpace | Align Space | 
| BlockContent | Gets a <see cref="T:ACadSharp.Tables.BlockRecord" /> containing elements
to be drawn as content for the multileader. | 
| BlockContentColor | Gets or sets the block-content color. | 
| BlockContentScale | Gets or sets the scale factor for block content. | 
| EnableBlockContentScale | Gets or sets a value indicating whether scaling of the block content is enabled. | 
| BlockContentRotation | Gets or sets the block content rotation. | 
| EnableBlockContentRotation | Gets or sets a value indicating whether rotation of the block content is enabled. | 
| BlockContentConnection | Gets or sets a value indicating whether the multileader connects to the content-block extents
or to the content-block base point. | 
| ScaleFactor | Gets or sets the scale factor for the <see cref="P:ACadSharp.Objects.MultiLeaderStyle.ArrowheadSize" />, <see cref="P:ACadSharp.Objects.MultiLeaderStyle.LandingDistance" />,
<see cref="P:ACadSharp.Objects.MultiLeaderStyle.LandingGap" />, <see cref="P:ACadSharp.Objects.MultiLeaderStyle.TextHeight" />, and the elements of <see cref="P:ACadSharp.Objects.MultiLeaderStyle.BlockContentScale" />. | 
| OverwritePropertyValue | Overwrite Property Value | 
| IsAnnotative | Is Annotative | 
| BreakGapSize | Break Gap Size | 
| TextAttachmentDirection | Gets or sets the Text attachment direction for text or block contents, rename?
This property defines whether the leaders attach to the left/right of the content block/text,
or attach to the top/bottom. | 
| TextBottomAttachment | Gets or sets the text bottom attachment type.
This value controls the position of the connection point of the leader
attached to the bottom of the text label. | 
| TextTopAttachment | Gets or sets the text top attachment type.
This value controls the position of the connection point of the leader
attached to the top of the text label. | 

## Methods

| Name | Summary | 
| :- | :- | 
| Clone |  | 

