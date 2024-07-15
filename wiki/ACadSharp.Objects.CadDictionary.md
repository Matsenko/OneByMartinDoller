# CadDictionary Class

Represents a <see cref="T:ACadSharp.Objects.CadDictionary" /> object.

## Properties

| Name | Summary | 
| :- | :- | 
| ObjectType |  | 
| ObjectName |  | 
| SubclassMarker |  | 
| HardOwnerFlag | indicates that elements of the dictionary are to be treated as hard-owned. | 
| ClonningFlags | Duplicate record cloning flag (determines how to merge duplicate entries) | 
| EntryNames | Entry names | 
| EntryHandles | Soft-owner ID/handle to entry object | 
| Item |  | 

## Methods

| Name | Summary | 
| :- | :- | 
| Add | Add a <see cref="T:ACadSharp.Objects.NonGraphicalObject" /> to the collection, this method triggers <see cref="E:ACadSharp.Objects.CadDictionary.OnAdd" /> | 
| Add | Add a <see cref="T:ACadSharp.Objects.NonGraphicalObject" /> to the collection, this method triggers <see cref="E:ACadSharp.Objects.CadDictionary.OnAdd" /> | 
| TryAdd | Tries to add the <see cref="T:ACadSharp.Objects.NonGraphicalObject" /> entry if the key doesn't exits. | 
| TryAdd | Tries to add the <see cref="T:ACadSharp.Objects.NonGraphicalObject" /> entry using the name as key. | 
| Remove | Removes a <see cref="T:ACadSharp.Objects.NonGraphicalObject" /> from the collection, this method triggers <see cref="E:ACadSharp.Objects.CadDictionary.OnRemove" /> | 
| GetEntry | Gets the value associated with the specific key | 
| TryGetEntry | Gets the value associated with the specific key | 
| GetEnumerator |  | 

