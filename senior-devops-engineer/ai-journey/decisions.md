# AI-Assisted Decisions and Overrides

## Decision 1 - .NET version

The original task targets .NET 8.

Although newer .NET versions were available locally, I kept the
application on .NET 8 to match the task's stated runtime and reduce
unnecessary migration scope.

---

## Decision 2 - Windows modules

AI suggested separating platform-independent modules from
Windows-specific modules.

I validated this against the actual source code.

`StatsModule` did not use Windows APIs, while:

- `DocumentExportModule` uses System.Drawing/GDI+
- `PrinterModule` uses Windows printer APIs

Therefore only the genuinely platform-dependent modules remained
outside the Linux deployment.

---

## Decision 3 - Docker security

The container was changed to run as a non-root user.

This was validated using:

```bash
docker exec jtl-demo id

---

## Decision 3 - Docker security