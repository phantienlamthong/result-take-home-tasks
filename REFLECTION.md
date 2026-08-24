# Reflection

## Key Decisions

- Moved the platform-independent `Items` and `Customers` modules into `JtlDemo.Modules`.
- Removed the unnecessary Windows dependency from the REST server composition layer.
- Updated the host to run on Linux/.NET 8 and removed Windows-specific startup dependencies.
- Built a Linux-compatible Docker image using the ASP.NET Core .NET 8 runtime image.
- Added a non-root container user for better container security.
- Added a Docker health check using `/healthz`.
- Created a Helm chart to deploy the application to a local Kubernetes cluster.
- Added Kubernetes liveness/readiness probes and resource requests/limits.
- Injected `ConnectionString` through Kubernetes configuration instead of hard-coding it.

## Trade-offs

The Windows-only modules were intentionally left outside the Linux image because they depend on Windows-specific APIs such as GDI+ and printer enumeration.

For a real production environment, I would further improve secret management, container image signing/scanning, observability, CI/CD, and deployment automation.

## What I Would Change for Production

- Use Azure Key Vault or another managed secret store.
- Push images to a private container registry.
- Add image vulnerability scanning.
- Use GitHub Actions or Azure DevOps for CI/CD.
- Add Prometheus metrics and centralized logging.
- Add distributed tracing with OpenTelemetry.
- Use production-grade Kubernetes ingress and TLS.
- Add automated rollback and deployment verification.