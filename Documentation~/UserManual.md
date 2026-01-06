> [!IMPORTANT]
> Outdated document

<h1 align="center">AttriX - User Manual</h1>
<p align="right">v1.1.0</p>

### Contents
1. [Introduction](#introduction)
   - [Overview](#overview)
   - [Features](#features)
   - [Requirements](#requirements)
2. [Getting Started](#getting-started)
   - [Installation](#installation)
   - [Basic Setup](#basic-setup)
   - [Quick Start Guide](#quick-start-guide)
3. [Attributes Reference](#attributes-reference)
   - [EnumNamedArray](#enumnamedarray)
   - [LayerMaskField](#layermaskfield)
   - [RenameArray](#renamearray)
   - [TagMaskField](#tagmaskfield)
   - [UnderlineSeparator](#underlineseparator)
4. [Usage](#usage)
   - [Core Concepts](#core-concepts)
   - [Best Practices](#best-practices)
5. [Troubleshooting](#troubleshooting)
   - [Common Issues](#common-issues)
   - [FAQ](#faq)

---
## Introduction
### Overview
AttriX is a lightweight Unity package that provides custom property attributes to enhance the Unity Editor's Inspector window. These attributes help make your inspector more organized, intuitive, and user-friendly.

### Features
- **EnumNamedArray**: Automatically names array elements based on an enum type
- **LayerMaskField**: Creates a user-friendly layer mask selector
- **RenameArray**: Custom names for array elements in the Inspector
- **TagMaskField**: Tag selector similar to LayerMask but for tags
- **UnderlineSeparator**: Adds visual separators to organize your Inspector

### Requirements
- Unity 2020.3 or later

## Getting Started
### Installation
#### Via Package Manager (Recommended)
1. Open your Unity project
2. Go to `Window > Package Manager`
3. Click the `+` button in the top-left corner
4. Select `Add package from git URL...`
5. Enter: `https://github.com/CRE-Tools/AttriX.git`
6. Click `Add`

#### Manual Installation
1. Clone or download this repository
2. Copy the contents to your project's `Packages` folder
3. The package will be automatically imported into your Unity project

### Basic Setup
No special setup is required. The attributes are ready to use as soon as the package is imported.

### Quick Start Guide
1. Add the `PUCPR.AttriX` namespace to your script
2. Apply the desired attributes to your fields
3. See the changes immediately in the Unity Inspector

Example:
```csharp
using PUCPR.AttriX;

public class Example : MonoBehaviour
{
   [LayerMaskField]
   public LayerMask targetLayers;
}
```

## Examples

### EnumNamedArray - Practical Example

Here's a practical example demonstrating how to use `EnumNamedArray` with proper array size management:

```csharp
using System;
using UnityEngine;
using PUCPR.AttriX;

public class Example : MonoBehaviour
{
    // Store the enum count in a static variable
    private static int s_enumExampleCount = Enum.GetNames(typeof(EnumExample)).Length;
    
    // Declare array with EnumNamedArray attribute
    [EnumNamedArray(typeof(EnumExample))]
    public GameObject[] gameObjectArrayExample = new GameObject[s_enumExampleCount];

    // Maintain array size consistency with enum
    public void OnValidate()
    {
        if (gameObjectArrayExample.Length != s_enumExampleCount)
        {
            Array.Resize(ref gameObjectArrayExample, s_enumExampleCount);
        }
    }
}

[Serializable]
public enum EnumExample
{
    example1,
    example2,
    example3,
    example4
}
```

**Key Points:**
1. Use a static variable to store the enum count
2. Initialize the array size using the enum count
3. Use `OnValidate()` to maintain array size consistency
4. The array in the Inspector will show elements named after the enum values

## Attributes Reference

### EnumNamedArray
Automatically names array elements based on an enum type.

**Usage:**
```csharp
public enum ItemType { Health, Ammo, Key }

[EnumNamedArray(typeof(ItemType))]
public int[] itemCounts;
```

**Result:** The array in the Inspector will show elements named after the enum values (Health, Ammo, Key) instead of just indices.

### LayerMaskField
Creates a user-friendly layer mask selector in the Inspector.

**Usage:**
```csharp
[LayerMaskField]
public LayerMask targetLayers;
```

**Result:** Displays a dropdown menu with all available layers that can be toggled on/off.

### RenameArray
Renames array elements in the Inspector using a base string with automatic numbering and index display.

**Usage:**
```csharp
[RenameArray("Item")]
public GameObject[] items;
```

**Result:** The array elements will be displayed with the format "[BaseName] [Count] (index:[Index])".
For example, with the attribute `[RenameArray("Item")]`, the elements will appear as:
- "Item 1 (index:0)"
- "Item 2 (index:1)"
- "Item 3 (index:2)"

**Note:** The index in parentheses is zero-based, while the count number is one-based for better readability.

### TagMaskField
Creates a tag selector similar to the LayerMask field but for tags.

**Usage:**
```csharp
[TagMaskField]
public string[] targetTags;
```

**Result:** Displays a dropdown menu with all available tags that can be selected.

### UnderlineSeparator
Adds a horizontal line below the field in the Inspector, creating a visual separation between sections.

**Usage:**
```csharp
[UnderlineSeparator]
public float health;

public int attackPower;
public float attackSpeed;

[UnderlineSeparator]
public string playerName;
```

**Result:** Draws a horizontal line below the field it's applied to, helping to visually separate groups of related fields in the Inspector.

## Usage
### Core Concepts
- **Attributes**: Special markers that can be placed above class fields to modify their Inspector appearance
- **Custom Drawers**: Behind the scenes, each attribute has a corresponding PropertyDrawer that defines how it's displayed

### Best Practices
- Keep attribute usage consistent across your project

>**EnumNamedArray**:
>- Use `EnumNamedArray` when you have an array that directly corresponds to an enum type
>- When using `EnumNamedArray`, always use a static variable to store the enum count and initialize the array size
>- Use `OnValidate()` to maintain array size consistency based on the enum count.

>**RenameArray**:
>- Use `RenameArray` for consistent naming of array elements, and identify the array elements by index counter

>**UnderlineSeparator**:
>- Group related fields together using `UnderlineSeparator` for better organization

>**LayerMaskField and TagMaskField**:
>- Prefer `LayerMaskField` and `TagMaskField` over string fields for layer/tag selection to prevent typos

## Troubleshooting
### Common Issues
1. **Attributes not working**:
   - Make sure you've added `using PUCPR.AttriX;` at the top of your script
   - Check for any compilation errors in the Console window
   - Verify that the field types match what the attribute expects

2. **EnumNamedArray array size mismatch**:
   - For `EnumNamedArray`, remember to use a static variable to store the enum count and initialize the array size
   - Use `OnValidate()` to maintain array size consistency based on the enum count.

### FAQ
**Q: Can I use multiple attributes on a single field?**
A: Yes, you can combine most attributes, however the attributes must be compatible with the same property type. Some combinations might not work as expected. Test in the Editor.

**Q: Do these attributes work with custom property drawers?**
A: In most cases, yes. The attributes modify how properties are drawn in the Inspector.

**Q: Are there any performance implications?**
A: The performance impact is negligible as the custom drawing only happens in the Unity Editor.

**Q: Can I use these attributes in custom editor scripts?**
A: Yes, these attributes work with both standard MonoBehaviours and custom editor scripts.

**Q: How do I update the package?**
A: Use the Package Manager to update to the latest version, or re-import the package if you're using a local version.

