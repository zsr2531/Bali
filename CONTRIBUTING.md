Contributing
============

First of all, thank you for reading this document. I hope that it'll be helpful in any contributions you make to the library.

Code style
----------

A `.editorconfig` file is provided to help keep the style of the codebase consitent. However, I'd like to highlight a few things you should keep in mind.

- Try to use longer names rather than abbreviations.
- Prefer not to use `this.`.
- Make property names descriptive, almost like a question. (eg. `IsDone` versus `Done`).
- You should place at least an XMLDOC `<summary>` on every public member.
- It is prefered to use normal overloads instead of default parameters, unless the API isn't likely to change.

Pull requests & committing
--------------------------

You should aim for small commits with clear and descriptive messages. If you want to work on a feature/bugfix, open your PR ***before*** starting to implement/fix the feature/bug. You should prefix your PR's title with `[WIP]`. After you have finished working on your PR, you can remove the prefix and ask for a review.
