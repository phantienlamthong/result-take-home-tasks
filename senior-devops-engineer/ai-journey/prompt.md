# Key Prompts

## Architecture analysis

> Identify the Windows coupling in this .NET application and explain
> which components can safely move to Linux.

Purpose:
Understand the dependency graph before changing the project structure.

---

## Docker

> Review the Dockerfile for this ASP.NET Core application and identify
> production concerns such as Windows dependencies, root execution,
> health checks, and image size.

Purpose:
Review the containerization strategy.

---

## Kubernetes

> Review this Helm Deployment and identify issues with probes,
> securityContext, serviceAccount, resources, and Service configuration.

Purpose:
Validate Kubernetes deployment design.

---

## Troubleshooting

> Explain this Kubernetes CrashLoopBackOff and identify the likely
> configuration problem based on the application logs.

Purpose:
Diagnose runtime configuration failure.

---

## Documentation

> Review the take-home implementation and identify what should be
> documented in the README, runbook, and production considerations.

Purpose:
Ensure the final deliverables cover operational concerns.