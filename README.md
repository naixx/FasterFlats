# **FasterFlats**

A lightweight plugin for N.I.N.A. that adds sequence commands to temporarily disable and re-enable auto-stretch during flat frame acquisition.

## **Motivation**

I run N.I.N.A. on a low-end mini PC equipped with an Intel Celeron J4125 — a processor that struggles under heavy workloads. When capturing flat frames every second, the continuous processing (especially with auto-stretch and annotation enabled) places significant strain on the CPU. This often led to performance issues and, in some cases, complete application crashes.

To address this, I created **FasterFlats** — a simple yet effective plugin that allows you to disable auto-stretch and annotation temporarily during flat capture sequences, reducing CPU load and improving stability.

## **How It Works**

The plugin introduces two custom sequence items:
- **Disable Auto-Stretch & Annotation**
- **Enable Auto-Stretch & Annotation**

Insert these commands before and after your flat capture routine to minimize processing overhead during high-frequency captures.

> ⚠️ **Note**: This functionality is designed for **non-light frames only** (i.e., flats, biases, darks). Disabling auto-stretch has no effect on light frames in normal imaging sequences.