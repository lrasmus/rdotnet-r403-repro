# rdotnet-r403-repro
Reproduce and troubleshoot issues reported with R.NET using R 4.0.3 and higher [https://github.com/rdotnet/rdotnet/issues/139](https://github.com/rdotnet/rdotnet/issues/139)

- C-RTest - a minimum embedded R wrapper written in C that handles basic initialization.  This is a modified version of [https://github.com/wch/r-source/blob/206cf2b7677d20dc51fb7667098b8893951e88d2/src/gnuwin32/front-ends/rtest.c](https://github.com/wch/r-source/blob/206cf2b7677d20dc51fb7667098b8893951e88d2/src/gnuwin32/front-ends/rtest.c).
- CSharp-RTest - a minimum embedded R wrapper written in C# that also handles basic initialization.
- R - this is a **custom build** of `R-devel` used for testing this issue.  This is not an official or stable R build, and should not be used.


## Status

- C-RTest - runs
- CSharp-RTest - crashes