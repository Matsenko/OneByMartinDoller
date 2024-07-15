# CadHeader Class



## Properties

| Name | Summary | 
| :- | :- | 
| VersionString | The Drawing database version number. | 
| Version |  | 
| MaintenanceVersion | Maintenance version number(should be ignored) | 
| CodePage | Drawing code page. | 
| LastSavedBy | Displays the name of the last person who modified the file | 
| RequiredVersions | The default value is 0.
Read only. | 
| AssociatedDimensions |  | 
| UpdateDimensionsWhileDragging | System variable DIMSHO | 
| MeasurementUnits | Sets drawing units | 
| PolylineLineTypeGeneration | Governs the generation of linetype patterns around the vertices of a 2D polyline:<br />
1 = Linetype is generated in a continuous pattern around vertices of the polyline<br />
0 = Each segment of the polyline starts and ends with a dash | 
| OrthoMode | System variable ORTHOMODE.
Ortho mode on if nonzero. | 
| RegenerationMode | System variable REGENMODE.
REGENAUTO mode on if nonzero | 
| FillMode | Fill mode on if nonzero | 
| QuickTextMode | Quick Text mode on if nonzero | 
| PaperSpaceLineTypeScaling | Controls paper space linetype scaling. | 
| LimitCheckingOn | Nonzero if limits checking is on
System variable LIMCHECK. | 
| BlipMode | System variable BLIPMODE	?? | 
| UserTimer | Controls the user timer for the drawing
System variable USRTIMER | 
| SketchPolylines | Determines the object type created by the SKETCH command
System variable SKPOLY | 
| AngularDirection | Represents angular direction.
System variable ANGDIR | 
| ShowSplineControlPoints | Controls the display of helixes and smoothed mesh objects.
System variable SPLFRAME | 
| MirrorText | Mirror text if nonzero <br />
System variable MIRRTEXT | 
| WorldView | Determines whether input for the DVIEW and VPOINT command evaluated as relative to the WCS or current UCS <br />
System variable WORLDVIEW | 
| ShowModelSpace | 1 for previous release compatibility mode; 0 otherwise <br />
System variable TILEMODE | 
| PaperSpaceLimitsChecking | Limits checking in paper space when nonzero <br />
System variable PLIMCHECK | 
| RetainXRefDependentVisibilitySettings | Controls the properties of xref-dependent layers: <br />
0 = Don't retain xref-dependent visibility settings <br />
1 = Retain xref-dependent visibility settings <br />
System variable VISRETAIN | 
| DisplaySilhouetteCurves | Controls the display of silhouette curves of body objects in Wireframe mode | 
| CreateEllipseAsPolyline |  | 
| ProxyGraphics | Controls the saving of proxy object images | 
| SpatialIndexMaxTreeDepth | Specifies the maximum depth of the spatial index | 
| LinearUnitFormat | Units format for coordinates and distances | 
| LinearUnitPrecision | Units precision for coordinates and distances | 
| AngularUnit | Entity linetype name, or BYBLOCK or BYLAYER | 
| AngularUnitPrecision | Units precision for angles | 
| ObjectSnapMode | Sets running object snaps, only for R13 - R14 | 
| AttributeVisibility | Attribute visibility | 
| PointDisplayMode | Point display mode | 
| UserShort1 | Integer variable intended for use by third-party developers | 
| UserShort2 | Integer variable intended for use by third-party developers | 
| UserShort3 | Integer variable intended for use by third-party developers | 
| UserShort4 | Integer variable intended for use by third-party developers | 
| UserShort5 | Integer variable intended for use by third-party developers | 
| NumberOfSplineSegments | Undocumented | 
| SurfaceDensityU | Surface density (for PEDIT Smooth) in M direction | 
| SurfaceDensityV | Surface density(for PEDIT Smooth) in N direction | 
| SurfaceType | Surface type for PEDIT Smooth | 
| SurfaceMeshTabulationCount1 | Number of mesh tabulations in first direction | 
| SurfaceMeshTabulationCount2 | Number of mesh tabulations in second direction | 
| SplineType | Spline curve type for PEDIT Spline | 
| ShadeEdge | Controls the shading of edges | 
| ShadeDiffuseToAmbientPercentage | Percent ambient/diffuse light | 
| UnitMode | Low bit set = Display fractions, feet-and-inches, and surveyor's angles in input format | 
| MaxViewportCount | Sets maximum number of viewports to be regenerated | 
| SurfaceIsolineCount |  | 
| CurrentMultilineJustification | Current multiline justification | 
| TextQuality |  | 
| LineTypeScale | Global linetype scale | 
| TextHeightDefault | Default text height | 
| TextStyleName | Current text style name | 
| CurrentLayerName | Current layer name | 
| CurrentLineTypeName | Entity linetype name, or BYBLOCK or BYLAYER | 
| MultiLineStyleName | Current multiline style name | 
| TraceWidthDefault | Default trace width | 
| SketchIncrement | Sketch record increment | 
| FilletRadius | Sketch record increment | 
| ThicknessDefault | Current thickness set by ELEV command | 
| AngleBase | Angle 0 direction | 
| PointDisplaySize | Point display size | 
| PolylineWidthDefault | Default polyline width | 
| UserDouble1 | Real variable intended for use by third-party developers | 
| UserDouble2 | Real variable intended for use by third-party developers | 
| UserDouble3 | Real variable intended for use by third-party developers | 
| UserDouble4 | Real variable intended for use by third-party developers | 
| UserDouble5 | Real variable intended for use by third-party developers | 
| ChamferDistance1 | First chamfer distance | 
| ChamferDistance2 | Second  chamfer distance | 
| ChamferLength | Chamfer length | 
| ChamferAngle | Chamfer angle | 
| FacetResolution |  | 
| CurrentMultilineScale | Current multiline scale | 
| CurrentEntityLinetypeScale | Current entity linetype scale | 
| MenuFileName | Name of menu file | 
| HandleSeed | Next available handle | 
| CreateDateTime | Local date/time of drawing creation (see Special Handling of Date/Time Variables) | 
| UniversalCreateDateTime | Universal date/time the drawing was created(see Special Handling of Date/Time Variables) | 
| UpdateDateTime | Local date/time of last drawing update(see Special Handling of Date/Time Variables) | 
| UniversalUpdateDateTime | Universal date/time of the last update/save(see Special Handling of Date/Time Variables) | 
| TotalEditingTime | Cumulative editing time for this drawing(see Special Handling of Date/Time Variables) | 
| UserElapsedTimeSpan | User-elapsed timer | 
| CurrentEntityColor | Current entity color number | 
| ViewportDefaultViewScaleFactor | View scale factor for new viewports | 
| PaperSpaceInsertionBase | Insertion base set by BASE command(in WCS) | 
| PaperSpaceExtMin | X, Y, and Z drawing extents lower-left corner (in WCS) | 
| PaperSpaceExtMax | X, Y, and Z drawing extents upper-right corner(in WCS) | 
| PaperSpaceLimitsMin | XY drawing limits lower-left corner(in WCS) | 
| PaperSpaceLimitsMax | XY drawing limits upper-right corner (in WCS) | 
| PaperSpaceElevation | Current elevation set by ELEV command | 
| PaperSpaceBaseName | Name of the UCS that defines the origin and orientation of orthographic UCS settings (paper space only) | 
| PaperSpaceName | Current paper space UCS name | 
| PaperSpaceUcsOrigin | Origin of current UCS (in WCS) | 
| PaperSpaceUcsXAxis | Direction of the current UCS X axis (in WCS) | 
| PaperSpaceUcsYAxis | Direction of the current UCS Y aYis (in WCS) | 
| PaperSpaceOrthographicTopDOrigin | Point which becomes the new UCS origin after changing paper space UCS to TOP when PUCSBASE is set to WORLD | 
| PaperSpaceOrthographicBottomDOrigin | Point which becomes the new UCS origin after changing paper space UCS to BOTTOM when PUCSBASE is set to WORLD | 
| PaperSpaceOrthographicLeftDOrigin | Point which becomes the new UCS origin after changing paper space UCS to LEFT when PUCSBASE is set to WORLD | 
| PaperSpaceOrthographicRightDOrigin | Point which becomes the new UCS origin after changing paper space UCS to RIGHT when PUCSBASE is set to WORLD | 
| PaperSpaceOrthographicFrontDOrigin | Point which becomes the new UCS origin after changing paper space UCS to FRONT when PUCSBASE is set to WORLD | 
| PaperSpaceOrthographicBackDOrigin | Point which becomes the new UCS origin after changing paper space UCS to BACK when PUCSBASE is set to WORLD | 
| ModelSpaceOrthographicTopDOrigin | Point which becomes the new UCS origin after changing model space UCS to TOP when PUCSBASE is set to WORLD | 
| ModelSpaceOrthographicBottomDOrigin | Point which becomes the new UCS origin after changing model space UCS to BOTTOM when PUCSBASE is set to WORLD | 
| ModelSpaceOrthographicLeftDOrigin | Point which becomes the new UCS origin after changing model space UCS to LEFT when PUCSBASE is set to WORLD | 
| ModelSpaceOrthographicRightDOrigin | Point which becomes the new UCS origin after changing model space UCS to RIGHT when PUCSBASE is set to WORLD | 
| ModelSpaceOrthographicFrontDOrigin | Point which becomes the new UCS origin after changing model space UCS to FRONT when PUCSBASE is set to WORLD | 
| ModelSpaceOrthographicBackDOrigin | Point which becomes the new UCS origin after changing model space UCS to BACK when PUCSBASE is set to WORLD | 
| ModelSpaceInsertionBase | Insertion base set by BASE command(in WCS) | 
| ModelSpaceExtMin | X, Y, and Z drawing extents lower-left corner (in WCS) | 
| ModelSpaceExtMax | X, Y, and Z drawing extents upper-right corner(in WCS) | 
| ModelSpaceLimitsMin | XY drawing limits lower-left corner (in WCS) | 
| ModelSpaceLimitsMax | XY drawing limits upper-right corner (in WCS) | 
| UcsBaseName | Name of the UCS that defines the origin and orientation of orthographic UCS settings | 
| UcsName | Name of current UCS | 
| Elevation | Current elevation set by ELEV command | 
| ModelSpaceOrigin | Origin of current UCS(in WCS) | 
| ModelSpaceXAxis | Direction of the current UCS X axis (in WCS) | 
| ModelSpaceYAxis | Direction of the current UCS Y axis (in WCS) | 
| DimensionBlockName | Arrow block name | 
| ArrowBlockName | Arrow block name for leaders | 
| DimensionBlockNameFirst | First arrow block name | 
| DimensionBlockNameSecond | Second arrow block name | 
| StackedTextAlignment |  | 
| StackedTextSizePercentage |  | 
| HyperLinkBase | Path for all relative hyperlinks in the drawing. If null, the drawing path is used | 
| CurrentEntityLineWeight | Lineweight of new objects | 
| EndCaps | Lineweight endcaps setting for new objects | 
| JoinStyle | Lineweight joint setting for new objects | 
| DisplayLineWeight | Controls the display of lineweights on the Model or Layout tab<br />
0 = Lineweight is not displayed<br />
1 = Lineweight is displayed | 
| XEdit | Controls whether the current drawing can be edited in-place when being referenced by another drawing | 
| ExtendedNames | Controls symbol table naming | 
| PlotStyleMode | Indicates whether the current drawing is in a Color-Dependent or Named Plot Style mode | 
| LoadOLEObject |  | 
| InsUnits | Default drawing units for blocks | 
| CurrentEntityPlotStyle | Plot style type of new objects | 
| FingerPrintGuid | Set at creation time, uniquely identifies a particular drawing | 
| VersionGuid | Uniquely identifies a particular version of a drawing. Updated when the drawing is modified | 
| EntitySortingFlags | Controls the object sorting methods | 
| IndexCreationFlags | Controls whether layer and spatial indexes are created and saved in drawing files | 
| HideText | Specifies HIDETEXT system variable | 
| ExternalReferenceClippingBoundaryType | Controls the visibility of xref clipping boundaries | 
| DimensionAssociativity | Controls the associativity of dimension objects | 
| HaloGapPercentage | Specifies a gap to be displayed where an object is hidden by another object; the value is specified as a percent of one unit and is independent of the zoom level.A haloed line is shortened at the point where it is hidden when HIDE or the Hidden option of SHADEMODE is used | 
| ObscuredColor |  | 
| InterfereColor | Represents the ACI color index of the "interference objects" created during the INTERFERE command. Default value is 1 | 
| ObscuredType |  | 
| IntersectionDisplay |  | 
| ProjectName | Assigns a project name to the current drawing. Used when an external reference or image is not found on its original path. The project name points to a section in the registry that can contain one or more search paths for each project name defined. Project names and their search directories are created from the Files tab of the Options dialog box | 
| CameraDisplayObjects |  | 
| StepsPerSecond |  | 
| StepSize |  | 
| Dw3DPrecision |  | 
| LensLength |  | 
| CameraHeight |  | 
| SolidsRetainHistory |  | 
| ShowSolidsHistory |  | 
| SweptSolidWidth |  | 
| SweptSolidHeight |  | 
| DraftAngleFirstCrossSection |  | 
| DraftAngleSecondCrossSection |  | 
| DraftMagnitudeFirstCrossSection |  | 
| DraftMagnitudeSecondCrossSection |  | 
| SolidLoftedShape |  | 
| LoftedObjectNormals |  | 
| Latitude | Specifies the latitude of the drawing model in decimal format | 
| Longitude | Specifies the longitude of the drawing model in decimal format | 
| NorthDirection |  | 
| TimeZone |  | 
| DisplayLightGlyphs |  | 
| DwgUnderlayFramesVisibility |  | 
| DgnUnderlayFramesVisibility |  | 
| ShadowMode | Shadow mode for a 3D object | 
| ShadowPlaneLocation | Location of the ground shadow plane. This is a Z axis ordinate | 
| StyleSheetName |  | 
| DimensionTextStyleName | Dimension text style | 
| DimensionStyleOverridesName | Dimension style name | 
| DimensionAngularDimensionDecimalPlaces | Number of precision places displayed in angular dimensions | 
| DimensionDecimalPlaces | Number of decimal places for the tolerance values of a primary units dimension | 
| DimensionToleranceDecimalPlaces | Number of decimal places to display the tolerance values | 
| DimensionAlternateUnitDimensioning | Alternate unit dimensioning performed if nonzero | 
| DimensionAlternateUnitFormat | Units format for alternate units of all dimension style family members except angular | 
| DimensionAlternateUnitScaleFactor | Alternate unit scale factor | 
| DimensionExtensionLineOffset | Extension line offset | 
| DimensionScaleFactor | Overall dimensioning scale factor | 
| DimensionAlternateUnitDecimalPlaces | Alternate unit decimal places | 
| DimensionAlternateUnitToleranceDecimalPlaces | Number of decimal places for tolerance values of an alternate units dimension | 
| DimensionAngularUnit | Angle format for angular dimensions | 
| DimensionFractionFormat | Undocumented | 
| DimensionLinearUnitFormat | Sets units for all dimension types except Angular | 
| DimensionDecimalSeparator | Single-character decimal separator used when creating dimensions whose unit format is decimal | 
| DimensionTextMovement | Dimension text movement rules decimal | 
| DimensionTextHorizontalAlignment | Horizontal dimension text position | 
| DimensionSuppressFirstDimensionLine | Suppression of first extension line | 
| DimensionSuppressSecondDimensionLine | Suppression of second extension line | 
| DimensionGenerateTolerances | Vertical justification for tolerance values | 
| DimensionToleranceAlignment | Vertical justification for tolerance values | 
| DimensionZeroHandling | Controls suppression of zeros for primary unit values | 
| DimensionToleranceZeroHandling | Controls suppression of zeros for tolerance values | 
| DimensionFit |  | 
| DimensionAlternateUnitZeroHandling | Controls suppression of zeros for alternate unit dimension values | 
| DimensionAlternateUnitToleranceZeroHandling | Controls suppression of zeros for alternate tolerance values | 
| DimensionCursorUpdate | Cursor functionality for user-positioned text | 
| DimensionDimensionTextArrowFit | Controls dimension text and arrow placement when space is not sufficient to place both within the extension lines | 
| DimensionAlternateUnitRounding | Determines rounding of alternate units | 
| DimensionAlternateDimensioningSuffix | Alternate dimensioning suffix | 
| DimensionArrowSize | Dimensioning arrow size | 
| DimensionAngularZeroHandling | Controls suppression of zeros for angular dimensions | 
| DimensionArcLengthSymbolPosition | Undocumented | 
| DimensionSeparateArrowBlocks | Use separate arrow blocks if nonzero | 
| DimensionCenterMarkSize | Size of center mark/lines | 
| DimensionTickSize | Dimensioning tick size | 
| DimensionLineColor | Dimension line color | 
| DimensionExtensionLineColor | Dimension extension line color | 
| DimensionTextColor | Dimension text color | 
| DimensionLineExtension | Dimension line extension | 
| DimensionLineIncrement | Dimension line increment | 
| DimensionExtensionLineExtension | Extension line extension | 
| DimensionIsExtensionLineLengthFixed | Undocumented | 
| DimensionFixedExtensionLineLength | Undocumented | 
| DimensionJoggedRadiusDimensionTransverseSegmentAngle | Undocumented | 
| DimensionTextBackgroundFillMode | Undocumented | 
| DimensionTextBackgroundColor | Undocumented | 
| DimensionLineGap | Undocumented | 
| DimensionLinearScaleFactor | Linear measurements scale factor | 
| DimensionTextVerticalPosition | Text vertical position | 
| DimensionLineWeight | Dimension line lineweight | 
| ExtensionLineWeight | Extension line lineweight | 
| DimensionPostFix | Undocumented | 
| DimensionRounding | Rounding value for dimension distances | 
| DimensionSuppressFirstExtensionLine | First extension line suppressed if nonzero | 
| DimensionSuppressSecondExtensionLine | Second extension line suppressed if nonzero | 
| DimensionSuppressOutsideExtensions | Suppress outside-extensions dimension lines if nonzero | 
| DimensionTextVerticalAlignment | Text above dimension line if nonzero | 
| DimensionUnit | Controls suppression of zeros for alternate unit dimension values | 
| DimensionToleranceScaleFactor | Dimension tolerance display scale factor | 
| DimensionTextInsideHorizontal | Text inside horizontal if nonzero | 
| DimensionTextInsideExtensions | Force text inside extensions if nonzero | 
| DimensionMinusTolerance | Minus tolerance | 
| DimensionTextOutsideExtensions | If text is outside the extension lines, dimension lines are forced between the extension lines if nonzero | 
| DimensionTextOutsideHorizontal | Text outside horizontal if nonzero | 
| DimensionLimitsGeneration | Dimension limits generated if nonzero | 
| DimensionPlusTolerance | Plus tolerance | 
| DimensionTextHeight | Dimensioning text height | 
| DimensionTextDirection | Undocumented | 
| DimensionAltMzf | Undocumented | 
| DimensionAltMzs | Undocumented | 
| DimensionMzf | Undocumented | 
| DimensionMzs | Undocumented | 
| DimensionLineType | Undocumented | 
| DimensionTex1 | Undocumented | 
| DimensionTex2 | Undocumented | 
| CurrentLayer |  | 
| CurrentLineType |  | 
| CurrentTextStyle |  | 
| DimensionTextStyle |  | 
| DimensionStyleOverrides |  | 
| ModelSpaceUcs |  | 
| ModelSpaceUcsBase |  | 
| PaperSpaceUcs |  | 
| PaperSpaceUcsBase |  | 
| Document | Document where this header resides | 

## Methods

| Name | Summary | 
| :- | :- | 
| SetValue | Set a valueo of a system variable by name | 
| GetValue |  | 
| GetValues | Get the primitive values in each dxf code | 

