# HatchGradientPattern Class



## Properties

| Name | Summary | 
| :- | :- | 
| Enabled | Indicates solid hatch or gradient | 
| Angle | Rotation angle in radians for gradients (default = 0, 0) | 
| Shift | Gradient definition; corresponds to the Centered option on the Gradient Tab of the Boundary Hatch and Fill dialog box.
Each gradient has two definitions, shifted and non-shifted. 
A Shift value describes the blend of the two definitions that should be used. A value of 0.0 means only the non-shifted version should be used, and a value of 1.0 means that only the shifted version should be used. | 
| IsSingleColorGradient | Records how colors were defined and is used only by dialog code | 
| ColorTint | Color tint value used by dialog code (default = 0, 0; range is 0.0 to 1.0). The color tint value is a gradient color and controls the degree of tint in the dialog when the Hatch group code 452 is set to 1. | 
| Colors | Colors in the gradient | 
| Name | Name of the gradient  | 

## Methods

| Name | Summary | 
| :- | :- | 
| Clone |  | 

