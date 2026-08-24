# JTL Demo - Linux Containerization

## Overview

This project demonstrates the migration of a Windows-coupled ASP.NET Core
service to a Linux-compatible container.

The original application contained Windows-specific dependencies in the
composition root, host startup, and two runtime modules.

The goal was to isolate the Windows-specific functionality and produce a
non-root Linux container that can be deployed locally with Kubernetes.

---

## Architecture

The resulting architecture is:

```text
                     Kubernetes
                         |
                  +------+------+
                  |             |
              Service       Service
                  |             |
             +----+----+   +----+----+
             |         |   |         |
           Pod 1     Pod 2         ...
             |         |
             +----+----+
                  |
             ASP.NET Core
                 :8080