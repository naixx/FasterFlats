using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// [MANDATORY] The following GUID is used as a unique identifier of the plugin. Generate a fresh one for your plugin!
[assembly: Guid("1fa64c65-22f9-491b-bb26-b2057d68cc8f")]

// [MANDATORY] The assembly versioning
//Should be incremented for each new release build of a plugin
[assembly: AssemblyVersion("1.0.0.1")]
[assembly: AssemblyFileVersion("1.0.0.1")]

// [MANDATORY] The name of your plugin
[assembly: AssemblyTitle("FasterFlats")]
// [MANDATORY] A short description of your plugin
[assembly: AssemblyDescription("Disable autostretch for flats sequences")]

// The following attributes are not required for the plugin per se, but are required by the official manifest meta data

// Your name
[assembly: AssemblyCompany("naixx")]
// The product name that this plugin is part of
[assembly: AssemblyProduct("FasterFlats")]
[assembly: AssemblyCopyright("Copyright © 2025 naixx")]

// The minimum Version of N.I.N.A. that this plugin is compatible with
[assembly: AssemblyMetadata("MinimumApplicationVersion", "3.0.0.2017")]

// The license your plugin code is using
[assembly: AssemblyMetadata("License", "MPL-2.0")]
// The url to the license
[assembly: AssemblyMetadata("LicenseURL", "https://www.mozilla.org/en-US/MPL/2.0/")]
// The repository where your pluggin is hosted
[assembly: AssemblyMetadata("Repository", "https://github.com/naixx/FasterFlats")]

// The following attributes are optional for the official manifest meta data

//[Optional] Your plugin homepage URL - omit if not applicaple
[assembly: AssemblyMetadata("Homepage", "https://github.com/naixx/FasterFlats")]

//[Optional] Common tags that quickly describe your plugin
[assembly: AssemblyMetadata("Tags", "flats,sequences,autostretch")]

//[Optional] A link that will show a log of all changes in between your plugin's versions
[assembly: AssemblyMetadata("ChangelogURL", "https://github.com/naixx/FasterFlats/blob/master/CHANGELOG.md")]

//[Optional] The url to a featured logo that will be displayed in the plugin list next to the name
[assembly: AssemblyMetadata("FeaturedImageURL", "")]
//[Optional] A url to an example screenshot of your plugin in action
[assembly: AssemblyMetadata("ScreenshotURL", "")]
//[Optional] An additional url to an example example screenshot of your plugin in action
[assembly: AssemblyMetadata("AltScreenshotURL", "")]
//[Optional] An in-depth description of your plugin
[assembly: AssemblyMetadata("LongDescription", @"# **FasterFlats**

A lightweight plugin for N.I.N.A. that adds sequence commands to temporarily disable and re-enable auto-stretch during flat frame acquisition.

## **Motivation**

I run N.I.N.A. on a low-end mini PC equipped with an Intel Celeron J4125 — a processor that struggles under heavy workloads. When capturing flat frames every second, the continuous processing (especially with auto-stretch and annotation enabled) places significant strain on the CPU. This often led to performance issues and, in some cases, complete application crashes.

To address this, I created **FasterFlats** — a simple yet effective plugin that allows you to disable auto-stretch and annotation temporarily during flat capture sequences, reducing CPU load and improving stability.

## **How It Works**

The plugin introduces two custom sequence items:
- **Disable Auto-Stretch & Annotation**
- **Enable Auto-Stretch & Annotation**

Insert these commands before and after your flat capture routine to minimize processing overhead during high-frequency captures.

> ⚠️ **Note**: This functionality is designed for **non-light frames only** (i.e., flats, biases, darks). Disabling auto-stretch has no effect on light frames in normal imaging sequences.")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]
// [Unused]
[assembly: AssemblyConfiguration("")]
// [Unused]
[assembly: AssemblyTrademark("")]
// [Unused]
[assembly: AssemblyCulture("")]