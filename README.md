<p align="center">
    <img height="210px" margin="30px" src="https://raw.githubusercontent.com/zsr2531/Bali/master/assets/cava.png" title="Ascended Java logo by Rist#7448 in the C# Discord server" />
</p>

Bali
====

[![License](https://img.shields.io/github/license/zsr2531/Bali?style=for-the-badge)](https://github.com/zsr2531/Bali/tree/master/LICENSE)
[![Docs](https://img.shields.io/badge/docs-Docfx-blueviolet?style=for-the-badge)](https://zsr2531.github.io/Bali/api)
[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Bali?style=for-the-badge)](https://www.nuget.org/packages/Bali)

A fast and lightweight .Net library to read and write Java .class files.

Features
--------

- Low memory footprint, the library doesn't allocate much from the heap.
- Provides low level access to the constant pool.
- Handles Java's "modified UTF-8" encoding correctly, unlike many other libraries out there.
- High level representation of the class file. *(todo)*
- Ability to read .jar files. *(todo)*

Why `Bali`?
-----------

> The island of Bali lies 3.2 km (2.0 mi) east of Java.

...

Want to contribute?
-------------------

If you wish to contribute, I will gladly appreciate it. You can read the contributing guidelines and a few small tips [here](CONTRIBUTING.md).

External libraries used
-----------------------

- [CodeGenHelpers](https://github.com/dansiegel/CodeGenHelpers) (MIT License): Used only for aiding source generation.

Disclaimer
----------

The library is still under heavy development.
