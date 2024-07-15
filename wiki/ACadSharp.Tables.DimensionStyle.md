# DimensionStyle Class

Represents a <see cref="T:ACadSharp.Tables.DimensionStyle" /> table entry.

## Properties

| Name | Summary | 
| :- | :- | 
| ObjectType |  | 
| ObjectName |  | 
| SubclassMarker |  | 
| PostFix | Specifies a text prefix or suffix (or both) to the dimension measurement
(see DIMPOST System Variable). | 
| AlternateDimensioningSuffix | Specifies a text prefix or suffix (or both) to the alternate dimension
measurement for all types of dimensions except angular
(see DIMAPOST System Variable). | 
| GenerateTolerances | Appends tolerances to dimension text
(see DIMTOL System Variable). | 
| LimitsGeneration | Generates dimension limits as the default text
(see DIMLIM System Variable). | 
| TextInsideHorizontal | Controls the position of dimension text inside the extension lines for all
dimension types except Ordinate.
(see DIMTIH System Variable). | 
| TextOutsideHorizontal | Controls the position of dimension text outside the extension lines
(see DIMTOH System Variable). | 
| SuppressFirstExtensionLine | Suppresses display of the first extension line
(see DIMSE1 System Variable). | 
| SuppressSecondExtensionLine | Suppresses display of the second extension line
(see DIMSE2 System Variable). | 
| TextVerticalAlignment | Controls the vertical position of text in relation to the dimension line
(see DIMTAD System Variable). | 
| ZeroHandling | Controls the suppression of zeros in the primary unit value
(see DIMZIN System Variable). | 
| AlternateUnitDimensioning | Controls the display of alternate units in dimensions
(see DIMALT System Variable). | 
| AlternateUnitDecimalPlaces | Controls the number of decimal places in alternate units
(see DIMALTD System Variable). | 
| TextOutsideExtensions | Controls whether a dimension line is drawn between the extension lines even when the text
is placed outside.
(see DIMTOFL System Variable). | 
| SeparateArrowBlocks | Controls the display of dimension line arrowhead blocks
(see DIMSAH System Variable). | 
| TextInsideExtensions | Draws text between extension lines
(see DIMTIX System Variable). | 
| SuppressOutsideExtensions | Suppresses arrowheads if not enough space is available inside the extension lines
(see DIMSOXD System Variable). | 
| AngularDimensionDecimalPlaces | Controls the number of precision places displayed in angular dimensions
(see DIMADEC System Variable). | 
| TextHorizontalAlignment | Controls the horizontal positioning of dimension text
(see DIMJUST System Variable). | 
| SuppressFirstDimensionLine | Controls suppression of the first dimension line and arrowhead
(see DIMSD1 System Variable). | 
| SuppressSecondDimensionLine | Controls suppression of the second dimension line and arrowhead
(see DIMSD2 System Variable). | 
| ToleranceAlignment | Gets or sets the vertical justification for tolerance values relative to the nominal dimension text.
(see DIMTOLJ System Variable). | 
| ToleranceZeroHandling | Controls the suppression of zeros in tolerance values
(see DIMTZIN System Variable). | 
| AlternateUnitZeroHandling | Controls the suppression of zeros for alternate unit dimension values
(see DIMALTZ System Variable). | 
| DimensionFit | Determines how dimension text and arrows are arranged when space is not sufficient to
place both within the extension lines.
(see DIMFIT System Variable). | 
| CursorUpdate | Controls options for user-positioned text
(see DIMUPT System Variable). | 
| AlternateUnitToleranceZeroHandling | Controls suppression of zeros in tolerance values
(see DIMALTTZ System Variable). | 
| DimensionUnit | DIMUNIT (obsolete, now use DIMLUNIT AND DIMFRAC) | 
| AngularUnit | Gets or sets the units format for angular dimensions
(see DIMAUNIT System Variable). | 
| DecimalPlaces | Gets or sets the number of decimal places displayed for the primary
units of a dimension
(see DIMDEC System Variable). | 
| ToleranceDecimalPlaces | Gets or sets the number of decimal places to display in tolerance values
for the primary units in a dimension
(see DIMTDEC System Variable). | 
| AlternateUnitFormat | Gets or sets the units format for alternate units of all dimension substyles
except Angular
(see DIMALTU System Variable). | 
| AlternateUnitToleranceDecimalPlaces | Gets or sets the number of decimal places for the tolerance values in the alternate
units of a dimension
(see DIMALTTD System Variable). | 
| ScaleFactor | Gets or sets the overall scale factor applied to dimensioning variables that specify
sizes, distances, or offsets
(see DIMSCALE System Variable). | 
| ArrowSize | Controls the size of dimension line and leader line arrowheads. Also controls the
size of hook lines
(see DIMASZ System Variable). | 
| ExtensionLineOffset | Specifies how far extension lines are offset from origin points
(see DIMEXO System Variable). | 
| DimensionLineIncrement | Controls the spacing of the dimension lines in baseline dimensions
(see DIMDLI System Variable). | 
| ExtensionLineExtension | Specifies how far to extend the extension line beyond the dimension line
(see DIMEXE System Variable). | 
| Rounding | Rounds all dimensioning distances to the specified value
(see DIMRND System Variable). | 
| DimensionLineExtension | Sets the distance the dimension line extends beyond the extension line when
oblique strokes are drawn instead of arrowheads.
(see DIMDLE System Variable). | 
| PlusTolerance | Gets or sets the maximum (or upper) tolerance limit for dimension text when
<see cref="P:ACadSharp.Tables.DimensionStyle.GenerateTolerances" /> or <see cref="P:ACadSharp.Tables.DimensionStyle.LimitsGeneration" /> is on (true)
(see DIMTP System Variable). | 
| MinusTolerance | Gets or sets the minimum (or lower) tolerance limit for dimension text when
<see cref="P:ACadSharp.Tables.DimensionStyle.GenerateTolerances" /> or <see cref="P:ACadSharp.Tables.DimensionStyle.LimitsGeneration" /> is on (true).
(see DIMTM System Variable). | 
| FixedExtensionLineLength | Sets the total length of the extension lines starting from the dimension line
toward the dimension origin
(see DIMFXL System Variable). | 
| JoggedRadiusDimensionTransverseSegmentAngle | Determines the angle of the transverse segment of the dimension line in a jogged radius dimension in radians.
(see DIMJOGANG System Variable). | 
| TextBackgroundFillMode | Controls the background of dimension text
(see DIMTFILL System Variable). | 
| TextBackgroundColor | Sets the color for the text background in dimensions.
(see DIMTFILLCLR System Variable). | 
| AngularZeroHandling | Suppresses zeros for angular dimensions
(see DIMAZIN System Variable). | 
| ArcLengthSymbolPosition | Controls display of the arc symbol in an arc length dimension
(see DIMARCSYM System Variable). | 
| TextHeight | Specifies the height of dimension text, unless the current text style has a fixed height
(see DIMTXT System Variable). | 
| CenterMarkSize | Controls drawing of circle or arc center marks and centerlines by the
DIMCENTER, DIMDIAMETER, and DIMRADIUS commands
(see DIMCEN System Variable). | 
| TickSize | Specifies the size of oblique strokes drawn instead of arrowheads for linear, radius,
and diameter dimensioning
(see DIMTSZ System Variable). | 
| AlternateUnitScaleFactor | Controls the multiplier for alternate units
(see DIMALTF System Variable). | 
| LinearScaleFactor | Sets a scale factor for linear dimension measurements
(see DIMLFAC System Variable). | 
| TextVerticalPosition | Controls the vertical position of dimension text above or below the dimension line
(see DIMTVP System Variable). | 
| ToleranceScaleFactor | Specifies a scale factor for the text height of fractions and tolerance values relative
to the dimension text height, as set by <see cref="P:ACadSharp.Tables.DimensionStyle.TextHeight" />
(see DIMTFAC System Variable). | 
| DimensionLineGap | Gets or sets the distance around the dimension text when the dimension line breaks to
accommodate dimension text
(see DIMGAP System Variable). | 
| AlternateUnitRounding | Rounds off the alternate dimension units
(see DIMALTRND System Variable). | 
| DimensionLineColor | Gets or sets colors to dimension lines, arrowheads, and dimension leader lines
(see DIMCLRD System Variable). | 
| ExtensionLineColor | Gets or sets colors to extension lines, center marks, and centerlines
(see DIMCLRE System Variable). | 
| TextColor | Assigns colors to dimension text
(see DIMCLRT System Variable). | 
| FractionFormat | Gets or sets the fraction format when <see cref="P:ACadSharp.Tables.DimensionStyle.LinearUnitFormat" /> is set to 4 (Architectural) or 5 (Fractional).
(see DIMFRAC System Variable). | 
| LinearUnitFormat | Gets or sets units for all dimension types except Angular
(see DIMLUNIT System Variable). | 
| DecimalSeparator | Specifies a single-character decimal separator to use when creating dimensions whose unit
format is decimal
(see DIMDSEP System Variable). | 
| TextMovement | Sets dimension text movement rules
(see DIMTMOVE System Variable). | 
| IsExtensionLineLengthFixed | Controls whether extension lines are set to a fixed length
(see DIMFXLON System Variable). | 
| TextDirection | Specifies the reading direction of the dimension text
(see DIMTXTDIRECTION System Variable). | 
| DimensionLineWeight | Assigns lineweight to dimension lines
(see DIMLWD System Variable). | 
| ExtensionLineWeight | Assigns lineweight to extension lines
(see DIMLWE System Variable). | 
| DimensionTextArrowFit | Determines how dimension text and arrows are arranged when space is not sufficient
to place both within the extension lines.
(see DIMATFIT System Variable). | 
| Style | Specifies the text style of the dimension
(see DIMTXSTY System Variable). | 
| LeaderArrow | Specifies the arrow type for leaders
(see DIMLDRBLK System Variable). | 
| ArrowBlock | Gets or sets the arrowhead block displayed at the ends of dimension lines
(see DIMBLK System Variable). | 
| DimArrow1 | Gets or sets the arrowhead for the first end of the dimension line when
<see cref="P:ACadSharp.Tables.DimensionStyle.SeparateArrowBlocks" /> is on (true)
(see DIMBLK1 System Variable). | 
| DimArrow2 | Gets or sets the arrowhead for the first end of the dimension line when
<see cref="P:ACadSharp.Tables.DimensionStyle.SeparateArrowBlocks" /> is on (true)
(see DIMBLK2 System Variable). | 

## Methods

| Name | Summary | 
| :- | :- | 
| Clone |  | 

