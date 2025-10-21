v1.0.0
<p align="center">
    <img width="100" height="100" src="/Documentation~/logos/1024x.png" align="center" />
</p>

<h1 align="center">UNITY - AttriX</h1>

[About](#about) | [How to Install](#how-to-install) | <a href="/Documentation~/UserManual.md">Documentation</a> | <a href="/Documentation~/CONTRIBUTING.md">Contributing</a>

## About

AttriX is a utility package for Unity that adds custom attributes to enhance the Inspector experience. It simplifies editor workflows by improving how serialized fields are displayed and interacted with, without requiring custom editor scripts.

The package includes attributes for visual organization, providing a cleaner and more intuitive editing experience, and integrates seamlessly into Unity projects. It is designed to be lightweight, extensible, and easy to use.

### Features

- EnumNamedArray
  Automatically resizes an array to match the size of a referenced enum and renames the element labels to match enum names.

- LayerMaskField
  Replaces an `int` field with a layer mask-compatible dropdown in the Inspector.

- RenameArray
  Dynamically renames array element labels using a sequence based on a provided base string.

- TagMaskField
  Replaces a `string` field with a tag-selection dropdown in the Inspector.

- UnderlineSeparator
  Adds a visual horizontal line below the decorated field in the Inspector to separate and organize sections.

## How to Install

- Unity -> Window -> Package Manager  
- Click "+" at the top left corner  
- Add package from git URL  
- Insert `https://github.com/CRE-Tools/AttriX.git`
- Add  
- Done

> [!NOTE]
> For bug reports and feature requests, please open an issue in the repository.

[Copyright (c) 2025 Centro de Realidade estendida - PUCPR](LICENSE.md)
